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

        internal static string ProduktuaDelete(ISessionFactory sessionFactory, Produktua produktua)
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
    }

}
