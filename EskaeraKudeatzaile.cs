using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;

namespace _2taldea
{
    internal class EskaeraKudeatzaile
    {
        public static void ProcesarMesa(int mesaId, string nombreUsuario, ISessionFactory sessionFactory)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    var pedidosActivos = session.CreateQuery("FROM Eskaera WHERE MesaId = :mesaId AND Activo = true")
                                                .SetParameter("mesaId", mesaId)
                                                .List<Eskaera>();

                    if (pedidosActivos.Count == 0)
                    {
                        MessageBox.Show("No hay pedidos activos para esta mesa.", "Resumen de Mesa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Mostrar el resumen en un nuevo formulario, pasando el nombre del usuario
                    EskaeraResumenForm resumenForm = new EskaeraResumenForm(mesaId, pedidosActivos.ToList(), nombreUsuario, sessionFactory);
                    resumenForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea mahaia aukeratzean: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
