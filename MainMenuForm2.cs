using System;
using System.Windows.Forms;
using NHibernate; // Asegúrate de tener esta referencia

namespace _2taldea
{
    public partial class MainMenuForm2 : Form
    {
        private string nombreUsuario;
        private ISessionFactory sessionFactory;

        public MainMenuForm2(string nombreUsuario, ISessionFactory sessionFactory)
        {
            InitializeComponent();
            labelIzena.Text = nombreUsuario;
            this.nombreUsuario = nombreUsuario;
            this.sessionFactory = sessionFactory; // Guardar la instancia de ISessionFactory
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            labelIzena.Text = nombreUsuario;
        }

        private void btnProduktuak_Click(object sender, EventArgs e)
        {

            // Pasar `sessionFactory` al constructor de `ProduktuakForm`
            ProduktuakForm2 produktuakForm = new ProduktuakForm2(nombreUsuario, sessionFactory);
            produktuakForm.Show();
        }

        private void btnKomandak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Permisoak ez.");
        }




        private void btnEskaerak_Click(object sender, EventArgs e)
        {
            EskaerakForm2 eskaerakForm = new EskaerakForm2(nombreUsuario, sessionFactory);
            eskaerakForm.Show();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelIzena_Click(object sender, EventArgs e)
        {
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
