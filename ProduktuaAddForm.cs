using System;
using System.Windows.Forms;
using NHibernate;

namespace _2taldea
{
    public partial class ProduktuaAddForm : Form
    {
        private ISessionFactory sessionFactory;

        public ProduktuaAddForm(ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
        }

        private void btnGorde_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIzena.Text) ||
                !int.TryParse(txtStock.Text, out int stock) ||
                !float.TryParse(txtPrezioa.Text, out float prezioa) ||
                !int.TryParse(txtMax.Text, out int max) ||
                !int.TryParse(txtMin.Text, out int min))
            {
                MessageBox.Show("Rellena todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var produktua = new Produktua
                    {
                        Izena = txtIzena.Text,
                        Stock = stock,
                        Prezioa = prezioa,
                        Max = max,
                        Min = min
                    };

                    session.Save(produktua);
                    transaction.Commit();
                    MessageBox.Show("Producto añadido correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnUtzi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
