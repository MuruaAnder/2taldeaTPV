using System;
using System.Windows.Forms;
using NHibernate; // Asegúrate de tener esta referencia

namespace _2taldea
{
    public partial class MainMenuForm : Form
    {
        private string nombreUsuario;
        private ISessionFactory sessionFactory;

        public MainMenuForm(string nombreUsuario, ISessionFactory sessionFactory)
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
            ProduktuakForm produktuakForm = new ProduktuakForm(nombreUsuario, sessionFactory);
            produktuakForm.Show();
        }

        private void btnKomandak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Komandak atala ireki da.");
        }

        private void btnEskaerak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eskaerak atala ireki da.");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelIzena_Click(object sender, EventArgs e)
        {
        }

    
    }
}
