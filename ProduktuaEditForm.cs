using System;
using System.Windows.Forms;
using NHibernate;

namespace _2taldea
{
    public partial class ProduktuaEditForm : Form
    {
        private Produktua produktua;
        private ISessionFactory sessionFactory;

        public ProduktuaEditForm(Produktua produktua, ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.produktua = produktua;
            this.sessionFactory = sessionFactory;

            // Cargar los datos del producto en los controles
            txtIzena.Text = produktua.Izena;
            txtStock.Text = produktua.Stock.ToString();
            txtPrezioa.Text = produktua.Prezioa.ToString();
            txtMax.Text = produktua.Max.ToString();
            txtMin.Text = produktua.Min.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    produktua.Izena = txtIzena.Text;
                    produktua.Stock = int.Parse(txtStock.Text);
                    produktua.Prezioa = float.Parse(txtPrezioa.Text);
                    produktua.Max = int.Parse(txtMax.Text);
                    produktua.Min = int.Parse(txtMin.Text);

                    session.Update(produktua);
                    transaction.Commit();

                    MessageBox.Show("Produktuaren datuak eguneratu dira.", "Informazioa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea produktua gordetzean: {ex.Message}", "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Ziur zaude produktua ezabatu nahi duzula?", "Konfirmazioa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var session = sessionFactory.OpenSession())
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(produktua);
                        transaction.Commit();

                        MessageBox.Show("Produktuak arrakastaz ezabatu da.", "Informazioa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK; // Cerrar el formulario
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errorea produktua ezabatzean: {ex.Message}", "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void labelProduktuak_Click(object sender, EventArgs e)
        {

        }
    }
}
