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
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    int nuevoEskaeraZenb = ObtenerNuevoEskaeraZenb(session);

                    foreach (var item in resumen)
                    {
                        var nombreProducto = item.Key;
                        var cantidad = item.Value.cantidad;
                        var precio = item.Value.precio;

                        for (int i = 0; i < cantidad; i++)
                        {
                            Eskaera nuevaEskaera = new Eskaera
                            {
                                EskaeraZenb = nuevoEskaeraZenb,
                                Izena = nombreProducto,
                                Prezioa = precio,
                                MesaId = mesaId,
                                Activo = true
                            };

                            session.Save(nuevaEskaera);
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el pedido: {ex.Message}");
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
