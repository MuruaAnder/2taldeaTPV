using NHibernate.Mapping;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2taldea
{
    internal class ProduktuaKudeatzailea
    {
        public static String ProduktuaAdd(ISessionFactory sessionFactory, String izena, int stock, float prezioa, int max, int min)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var produktua = new Produktua
                    {
                        Izena = izena,
                        Stock = stock,
                        Prezioa = prezioa,
                        Max = max,
                        Min = min
                    };

                    session.Save(produktua);
                    transaction.Commit();
                    return "true";
                    
                }
            }
            catch (Exception ex)
            {
                return $"Error al guardar el producto: {ex.Message}";
            }
        }
        public static string ProduktuaUpdate(
             ISessionFactory sessionFactory,
             Produktua produktua,
             string izena,
             int stock,
             float prezioa,
             int max,
             int min)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    produktua.Izena = izena;
                    produktua.Stock = stock;
                    produktua.Prezioa = prezioa;
                    produktua.Max = max;
                    produktua.Min = min;

                    session.Update(produktua);
                    transaction.Commit();
                    return "true";
                }
            }
            catch (Exception ex)
            {
                return $"Errorea produktua eguneratzean: {ex.Message}";
            }
        }

        public static List<Produktua> ObtenerProduktuak(ISessionFactory sessionFactory)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    // Ejecutar la consulta para obtener todos los productos
                    var produktuak = session.CreateQuery("FROM Produktua").List<Produktua>().ToList();

                    return produktuak;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los productos: {ex.Message}");
                return new List<Produktua>(); // Retornar lista vacía en caso de error
            }
        }


        public static string ProduktuaDelete(ISessionFactory sessionFactory, Produktua produktua)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(produktua);
                    transaction.Commit();
                    return "true";
                }
            }
            catch (Exception ex)
            {
                return $"Errorea produktua ezabatzean: {ex.Message}";
            }
        }
        public static List<Produktua> FiltrarProduktuak(ISessionFactory sessionFactory, string criterio)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    string query = criterio == "Prezioa"
                        ? "FROM Produktua ORDER BY Prezioa DESC"
                        : "FROM Produktua ORDER BY Stock DESC";

                    var produktuak = session.CreateQuery(query).List<Produktua>().ToList();
                    return produktuak;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al filtrar los productos: {ex.Message}");
                return new List<Produktua>(); 
            }
        }
        public static (List<Produktua> produktuak, List<Produktua> produktuakStockBaxua) ObtenerProduktuakConAlertas(ISessionFactory sessionFactory)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    // Obtener todos los productos
                    var produktuak = session.CreateQuery("FROM Produktua").List<Produktua>().ToList();

                    // Filtrar productos con stock insuficiente
                    var produktuakStockBaxua = produktuak.Where(p => p.Stock < p.Min).ToList();

                    return (produktuak, produktuakStockBaxua);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los productos: {ex.Message}");
                return (new List<Produktua>(), new List<Produktua>()); // Retornar listas vacías en caso de error
            }
        }

    }

}
