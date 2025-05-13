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

        internal static bool TienePedidoActivo(int mesaId, ISessionFactory sessionFactory)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    return session.QueryOver<Eskaera>()
                                  .Where(e => e.MesaId == mesaId && e.Activo == 1)
                                  .RowCount() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar pedidos activos en la mesa {mesaId}: {ex.Message}");
                return false;
            }
        }

        public static void GuardarEskaera(ISessionFactory sessionFactory, int mesaId,
                                        Dictionary<string, (int cantidad, float precio)> resumen,
                                        Dictionary<string, string> notasPlatos)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var mesa = session.Get<Mahaia>(mesaId);
                    if (mesa == null)
                    {
                        throw new Exception($"No se encontró la mesa con ID {mesaId}.");
                    }

                    var eskaera = session.QueryOver<Eskaera>()
                                       .Where(e => e.MesaId == mesaId && e.Activo == 1)
                                       .SingleOrDefault();

                    if (eskaera == null)
                    {
                        int nuevoEskaeraZenb = ObtenerNuevoEskaeraZenb(session);
                        eskaera = new Eskaera
                        {
                            EskaeraZenb = nuevoEskaeraZenb,
                            MesaId = mesaId,
                            Activo = 1,
                            Izena = "Pedido en curso",
                            Prezioa = 0
                        };
                        session.Save(eskaera);
                    }

                    foreach (var item in resumen)
                    {
                        if (item.Value.cantidad <= 0) continue;

                        var plato = session.QueryOver<Platera>()
                                         .Where(p => p.Izena == item.Key)
                                         .SingleOrDefault();

                        if (plato == null)
                        {
                            throw new Exception($"Plato '{item.Key}' no encontrado.");
                        }

                        // Verificar stock
                        var ingredientes = session.QueryOver<PlateraProduktua>()
                                                .Where(pp => pp.PlateraId == plato.Id)
                                                .JoinQueryOver(pp => pp.Produktua)
                                                .List();

                        foreach (var ingrediente in ingredientes)
                        {
                            var producto = session.Get<Produktua>(ingrediente.ProduktuaId);
                            int cantidadNecesaria = ingrediente.Kantitatea * item.Value.cantidad;

                            if (producto.Stock < cantidadNecesaria)
                            {
                                throw new Exception($"Ez dago nahiko {producto.Izena}  {plato.Izena}platerarako");
                            }

                            producto.Stock -= cantidadNecesaria;
                            session.Update(producto);
                        }

                        // Crear EskaeraPlatera (con clave simple)
                        for (int i = 0; i < item.Value.cantidad; i++)
                        {
                            var eskaeraPlatera = new EskaeraPlatera
                            {
                                Eskaera = eskaera, // Asignación directa del objeto
                                Platera = plato,
                                NotaGehigarriak = notasPlatos.ContainsKey(item.Key) ? notasPlatos[item.Key] : null,
                                Egoera = 0,
                                Done = 0,
                                EskaeraOrdua = DateTime.Now
                            };
                            session.Save(eskaeraPlatera);
                        }

                        eskaera.Prezioa += item.Value.cantidad * plato.Prezioa;
                    }

                    // Actualizar nombre del pedido
                    var platosPedido = session.QueryOver<EskaeraPlatera>()
                                           .Where(ep => ep.Eskaera.Id == eskaera.Id) // Acceso a través de la relación
                                           .JoinQueryOver(ep => ep.Platera)
                                           .List()
                                           .Select(ep => ep.Platera.Izena)
                                           .Distinct()
                                           .ToList();

                    eskaera.Izena = platosPedido.Count switch
                    {
                        0 => "Pedido vacío",
                        1 => platosPedido.First(),
                        _ => $"{platosPedido.First()} y otros {platosPedido.Count - 1}"
                    };

                    session.Update(eskaera);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Error al guardar el pedido: {ex.Message}");
                    throw;
                }
            }
        }

        public static void BorrarPedidos(ISessionFactory sessionFactory, int mesaId)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var pedidos = session.QueryOver<Eskaera>()
                                        .Where(e => e.MesaId == mesaId && e.Activo == 1)
                                        .List();

                    foreach (var pedido in pedidos)
                    {
                        pedido.Activo = 0;
                        session.Update(pedido);
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al desactivar pedidos: {ex.Message}");
            }
        }

        public static string CargarResumen(ISessionFactory sessionFactory, int mesaId)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    var pedidosActivos = session.QueryOver<Eskaera>()
                                                .Where(e => e.MesaId == mesaId && e.Activo == 1)
                                                .List();

                    if (pedidosActivos.Count == 0)
                    {
                        return "Ez dago komandarik mahai honetarako.";
                    }

                    var eskaeraIds = pedidosActivos.Select(e => e.Id).ToList();

                    var detallesPedidos = session.QueryOver<EskaeraPlatera>()
                        .WhereRestrictionOn(ep => ep.Eskaera.Id).IsIn(eskaeraIds) // Acceso a través de la relación
                        .List();

                    var resumen = new Dictionary<string, (int cantidad, float precio, string nota)>();

                    foreach (var detalle in detallesPedidos)
                    {
                        var plato = detalle.Platera; // Acceso directo al objeto relacionado
                        string nombrePlato = plato.Izena;

                        if (resumen.ContainsKey(nombrePlato))
                        {
                            resumen[nombrePlato] = (
                                resumen[nombrePlato].cantidad + 1,
                                plato.Prezioa,
                                detalle.NotaGehigarriak ?? resumen[nombrePlato].nota
                            );
                        }
                        else
                        {
                            resumen[nombrePlato] = (1, plato.Prezioa, detalle.NotaGehigarriak ?? "");
                        }
                    }

                    string resumenTexto = "Komandaren laburpena:\n\n";
                    float total = 0;

                    foreach (var item in resumen)
                    {
                        float subtotal = item.Value.cantidad * item.Value.precio;
                        resumenTexto += $"- {item.Key}: {item.Value.cantidad} x {item.Value.precio:C2} = {subtotal:C2}";

                        if (!string.IsNullOrEmpty(item.Value.nota))
                        {
                            resumenTexto += $" (Oharra: {item.Value.nota})";
                        }

                        resumenTexto += "\n";
                        total += subtotal;
                    }

                    resumenTexto += $"\nTotala: {total:C2}";
                    return resumenTexto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errorea laburpena kargatzean: {ex.Message}");
            }
        }

        private static int ObtenerNuevoEskaeraZenb(ISession session)
        {
            var lastEskaera = session.QueryOver<Eskaera>()
                                     .OrderBy(e => e.EskaeraZenb).Desc
                                     .Take(1)
                                     .SingleOrDefault();

            return (lastEskaera?.EskaeraZenb ?? 0) + 1;
        }
    }
}