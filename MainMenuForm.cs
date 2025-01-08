using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2taldea
{
    public partial class MainMenuForm : Form
    {
        // Variable privada para almacenar el nombre del usuario
        private string nombreUsuario;

        // Constructor que recibe el nombre del usuario
        public MainMenuForm(string nombreUsuario)
        {
            InitializeComponent();
            labelIzena.Text = nombreUsuario;
            this.nombreUsuario = nombreUsuario; // Asignamos el nombre del usuario al campo privado

        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            // Asignamos el nombre del usuario al label
            labelIzena.Text = nombreUsuario;
        }

        private void btnProduktuak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produktuak atala ireki da.");
            // Aquí podrías abrir otro formulario relacionado con 'Produktuak'
        }

        private void btnKomandak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Komandak atala ireki da.");
            // Aquí podrías abrir otro formulario relacionado con 'Komandak'
        }

        private void btnEskaerak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eskaerak atala ireki da.");
            // Aquí podrías abrir otro formulario relacionado con 'Eskaerak'
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar la ventana principal y volver al inicio de sesión
        }

        private void labelIzena_Click(object sender, EventArgs e)
        {

        }
    }
}
