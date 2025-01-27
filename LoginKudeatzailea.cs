using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2taldea
{
    internal class LoginKudeatzailea
    {
        public static bool LoginGerente(string userName, string password, ISessionFactory sessionFactory)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        string hql = @"SELECT COUNT(*) 
                                       FROM Langilea 
                                       WHERE izena = :userName 
                                         AND pasahitza = :password 
                                         AND postua = 'Gerentea'";

                        var count = session.CreateQuery(hql)
                                           .SetParameter("userName", userName)
                                           .SetParameter("password", password)
                                           .UniqueResult<long>();

                        transaction.Commit();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Errorea kontsultan: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea sesioan: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        internal static bool LoginSukaldaria(string userName, string password, ISessionFactory sessionFactory)
        {
            try
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    string hql = @"SELECT COUNT(*) 
                                   FROM Langilea 
                                   WHERE izena = :userName 
                                     AND pasahitza = :password 
                                     AND postua = 'Sukaldaria'";

                    var count = session.CreateQuery(hql)
                                       .SetParameter("userName", userName)
                                       .SetParameter("password", password)
                                       .UniqueResult<long>();

                    transaction.Commit();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Errorea kontsultan: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Errorea sesioan: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        }
    }
}
