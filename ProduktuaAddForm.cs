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
            try
            {
                String izena = txtIzena.Text;
                int stock = Convert.ToInt16(txtStock.Text);
                float prezioa = Convert.ToSingle(txtPrezioa.Text);
                int max = Convert.ToInt16(txtMax.Text);
                int min = Convert.ToInt16(txtMin.Text);

                String result = ProduktuaKudeatzailea.ProduktuaAdd(sessionFactory, izena, stock, prezioa, max, min);

                if (result == "true")
                {
                    MessageBox.Show("Producto añadido correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        private void ProduktuaAddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
