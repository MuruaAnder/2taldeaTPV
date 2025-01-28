using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2taldea
{
    internal class KomandakKudeatzailea
    {
        private readonly ISessionFactory sessionFactory;

        public KomandakKudeatzailea(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        // Método para obtener todas las mesas
        public static List<Mahaia> ObtenerMesas(ISessionFactory sessionFactory)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    return session.CreateQuery("FROM Mahaia").List<Mahaia>().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las mesas: {ex.Message}");
                return new List<Mahaia>();
            }
        }

        // Método para cargar platos por categoría
        public List<Platera> CargarPlatos(string categoria)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.QueryOver<Platera>()
                              .Where(p => p.Kategoria == categoria)
                              .List()
                              .ToList();
            }
        }

        // Método para guardar un pedido y activarlo
        public static void GuardarEskaera(ISessionFactory sessionFactory, int mesaId, Dictionary<string, (int cantidad, float precio)> resumen)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Comprobar si la mesa existe
                    var mesa = session.Get<Mahaia>(mesaId);
                    if (mesa == null)
                    {
                        throw new Exception($"No se encontró la mesa con ID {mesaId}.");
                    }

                    int nuevoEskaeraZenb = ObtenerNuevoEskaeraZenb(session);

                    foreach (var item in resumen)
                    {
                        var nombrePlato = item.Key;
                        var cantidad = item.Value.cantidad;
                        var precio = item.Value.precio;

                        // Buscar el plato en la tabla Platera
                        var plato = session.QueryOver<Platera>()
                                           .Where(p => p.Izena == nombrePlato)
                                           .SingleOrDefault();

                        if (plato == null)
                        {
                            throw new Exception($"Plato '{nombrePlato}' no encontrado en la base de datos.");
                        }

                        // Buscar todos los productos en Produktua con el mismo nombre
                        var productos = session.QueryOver<Produktua>()
                                               .Where(p => p.Izena == plato.Izena)
                                               .List();

                        if (productos == null || productos.Count == 0)
                        {
                            throw new Exception($"No se encontró un producto asociado al plato '{nombrePlato}' en la tabla Produktua.");
                        }

                        // Sumar el stock total disponible de todos los productos con ese nombre
                        int stockTotalDisponible = productos.Sum(p => p.Stock);

                        // Verificar si hay stock suficiente
                        if (stockTotalDisponible < cantidad)
                        {
                            throw new Exception($"Stock insuficiente para '{nombrePlato}'. Disponible: {stockTotalDisponible}, solicitado: {cantidad}");
                        }

                        // Reducir el stock proporcionalmente en cada producto
                        int cantidadRestante = cantidad;
                        foreach (var producto in productos)
                        {
                            if (cantidadRestante == 0)
                                break;

                            int reducirEnEsteProducto = Math.Min(producto.Stock, cantidadRestante);
                            producto.Stock -= reducirEnEsteProducto;
                            cantidadRestante -= reducirEnEsteProducto;
                            session.Update(producto);
                        }

                        // Guardar los pedidos en la base de datos
                        for (int i = 0; i < cantidad; i++)
                        {
                            Eskaera nuevaEskaera = new Eskaera
                            {
                                EskaeraZenb = nuevoEskaeraZenb,
                                Izena = nombrePlato,  // Se usa el nombre del plato
                                Prezioa = precio,
                                MesaId = mesaId,
                                Activo = true
                            };

                            session.Save(nuevaEskaera);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Revertir los cambios en caso de error
                    Console.WriteLine($"Error al guardar el pedido y actualizar el stock: {ex.Message}");
                    throw;
                }
            }
        }





        // Método para desactivar los pedidos de una mesa
        public static void BorrarPedidos(ISessionFactory sessionFactory, int mesaId)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var pedidosParaActualizar = session.QueryOver<Eskaera>()
                                                        .Where(e => e.MesaId == mesaId && e.Activo == true)
                                                        .List();

                    foreach (var pedido in pedidosParaActualizar)
                    {
                        pedido.Activo = false;
                        session.Update(pedido);
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al desactivar los pedidos: {ex.Message}");
            }
        }

        // Método para obtener el siguiente número de pedido
        private static int ObtenerNuevoEskaeraZenb(ISession session)
        {
            var lastEskaera = session.QueryOver<Eskaera>()
                                     .OrderBy(e => e.EskaeraZenb).Desc
                                     .Take(1)
                                     .SingleOrDefault();

            return (lastEskaera?.EskaeraZenb ?? 0) + 1;
        }

        // Método para cargar el resumen de un pedido activo
        public static string CargarResumen(ISessionFactory sessionFactory, int mesaId)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    var pedidosActivos = session.QueryOver<Eskaera>()
                                                .Where(e => e.MesaId == mesaId && e.Activo == true)
                                                .List();

                    if (pedidosActivos == null || pedidosActivos.Count == 0)
                    {
                        return "Ez dago komandarik mahai honetarako."; // No hay pedido activo
                    }

                    // Crear diccionario con productos y cantidades
                    Dictionary<string, (int cantidad, float precio)> resumen = new();

                    foreach (var pedido in pedidosActivos)
                    {
                        if (resumen.ContainsKey(pedido.Izena))
                        {
                            resumen[pedido.Izena] = (resumen[pedido.Izena].cantidad + 1, pedido.Prezioa);
                        }
                        else
                        {
                            resumen[pedido.Izena] = (1, pedido.Prezioa);
                        }
                    }

                    // Crear resumen
                    string resumenTexto = "Komandaren laburpena:\n\n";
                    float total = 0;

                    foreach (var item in resumen)
                    {
                        float subtotal = item.Value.cantidad * item.Value.precio;
                        resumenTexto += $"- {item.Key}: {item.Value.cantidad} x {item.Value.precio:C2} = {subtotal:C2}\n";
                        total += subtotal;
                    }

                    resumenTexto += $"\nTotala: {total:C2}";

                    return resumenTexto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errorea laburpena kargatzean: {ex.Message}", ex);
            }
        }
    }
}
