using NHibernate;

namespace _2taldea
{
    public static class PlateraKudeatzailea
    {
        public static string PlateraAdd(ISessionFactory sessionFactory, string izena, string kategoria,
                               int kantitatea, float prezioa, string imageName = "", string deskribapena = "")
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var query = session.CreateSQLQuery(
                        "INSERT INTO platera (izena, kategoria, kantitatea, prezioa, menu, foto, deskribapena) " +
                        "VALUES (:izena, :kategoria, :kantitatea, :prezioa, 1, :foto, :deskribapena)")
                        .SetParameter("izena", izena)
                        .SetParameter("kategoria", kategoria)
                        .SetParameter("kantitatea", kantitatea)
                        .SetParameter("prezioa", prezioa)
                        .SetParameter("foto", imageName) // Guardar el nombre de la imagen
                        .SetParameter("deskribapena", deskribapena);

                    query.ExecuteUpdate();
                    transaction.Commit();
                    return "true";
                }
            }
            catch (Exception ex)
            {
                return $"Errorea platera gehitzerakoan: {ex.Message}";
            }
        }
    }
}