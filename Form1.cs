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
                MessageBox.Show("Kampo guztiak bete", "Arazoak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (LoginKudeatzailea.LoginGerente(userName, password, sessionFactory))
            {
                MessageBox.Show("Ongi etorri, Gerentea!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainMenuForm mainMenu = new MainMenuForm(userName, sessionFactory);
                this.Hide();
                mainMenu.ShowDialog();
                this.Show();
            }
            else if (LoginKudeatzailea.LoginSukaldaria(userName, password, sessionFactory))
            {
                MessageBox.Show("Ongi etorri, Sukaldaria!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainMenuForm2 mainMenu2 = new MainMenuForm2(userName, sessionFactory);
                this.Hide();
                mainMenu2.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Usuarioa edo pasahitza gaizki!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

