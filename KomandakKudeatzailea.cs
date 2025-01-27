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

        // Método para obtener todas las mesas de la base de datos
        public static List<Mahaia> ObtenerMesas(ISessionFactory sessionFactory)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    // Convertimos IList<Mahaia> a List<Mahaia> usando ToList()
                    var mesas = session.CreateQuery("FROM Mahaia").List<Mahaia>().ToList();
                    return mesas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las mesas: {ex.Message}");
                return new List<Mahaia>(); // Retornar lista vacía en caso de error
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

        // Método para guardar un pedido
        public static void GuardarEskaera(ISessionFactory sessionFactory, int mesaId, Dictionary<string, (int cantidad, float precio)> resumen, int ultimoEskaeraZenb)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    if (ultimoEskaeraZenb == 0)
                    {
                        ultimoEskaeraZenb = MesaDetallesForm.ObtenerNuevoEskaeraZenb(session);
                    }

                    foreach (var item in resumen)
                    {
                        var nombreProducto = item.Key;
                        var cantidad = item.Value.cantidad;
                        var precio = item.Value.precio;

                        for (int i = 0; i < cantidad; i++)
                        {
                            Eskaera nuevaEskaera = new Eskaera
                            {
                                EskaeraZenb = ultimoEskaeraZenb,
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

        // Método para desactivar los pedidos
        public static void BorrarPedidos(ISessionFactory sessionFactory, int mesaId, int ultimoEskaeraZenb)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var pedidosParaActualizar = session.QueryOver<Eskaera>()
                                                        .Where(e => e.MesaId == mesaId && e.EskaeraZenb == ultimoEskaeraZenb)
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

        // Método para cargar el último número de pedido
        public int CargarPedidosGuardados(int mesaId)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    var lastEskaera = session.QueryOver<Eskaera>()
                                              .Where(e => e.MesaId == mesaId && e.Activo == true)
                                              .OrderBy(e => e.EskaeraZenb).Desc
                                              .Take(1)
                                              .SingleOrDefault();

                    return lastEskaera?.EskaeraZenb ?? 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar los pedidos guardados: {ex.Message}");
            }
        }

        // Método para obtener el siguiente número de pedido
        private int ObtenerNuevoEskaeraZenb(ISession session)
        {
            var lastEskaera = session.QueryOver<Eskaera>()
                                     .Where(e => e.Activo == true)
                                     .OrderBy(e => e.EskaeraZenb).Desc
                                     .Take(1)
                                     .SingleOrDefault();

            return (lastEskaera?.EskaeraZenb ?? 0) + 1;
        }

        // Método para cargar el resumen de un pedido
        public static string CargarResumen(ISessionFactory sessionFactory, int mesaId, int ultimoEskaeraZenb)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    var eskaeras = session.QueryOver<Eskaera>()
                                          .Where(e => e.MesaId == mesaId && e.EskaeraZenb == ultimoEskaeraZenb && e.Activo == true)
                                          .List()
                                          .ToList();

                    if (!eskaeras.Any())
                    {
                        return "No hay pedidos actuales para esta mesa.";
                    }

                    string resumenTexto = "Resumen de Pedido:\n\n";
                    foreach (var eskaera in eskaeras)
                    {
                        resumenTexto += $"- {eskaera.Izena}: {eskaera.Prezioa:C2}\n";
                    }

                    return resumenTexto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar el resumen: {ex.Message}");
            }
        }
    }
}
