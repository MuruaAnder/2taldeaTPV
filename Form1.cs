using System;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;

namespace _2taldea
{
    public partial class Form1 : Form
    {
        private ISessionFactory sessionFactory;

        public Form1()
        {
            InitializeComponent();
            ConfigureNHibernate();
        }

        private void ConfigureNHibernate()
        {
            try
            {
                var configuration = new Configuration();
                configuration.Configure(); // Carga la configuración desde App.config o hibernate.cfg.xml
                sessionFactory = configuration.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea NHibernate konfiguratzean: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Rellena todos los campos.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (LoginGerente(userName, password))
            {
                MessageBox.Show("Ongi etorri!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario principal y pasar el nombre del usuario y la sesión
                MainMenuForm mainMenu = new MainMenuForm(userName, sessionFactory);
                this.Hide(); // Ocultar la ventana de inicio de sesión
                mainMenu.ShowDialog(); // Mostrar el formulario principal de forma modal
                this.Show(); // Volver al formulario de inicio de sesión después de cerrar el principal
            }
            else
            {
                MessageBox.Show("Usuarioa edo pasahitza gaizki!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LoginGerente(string userName, string password)
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
    }
}

