using System;
using System.Windows.Forms;
using NHibernate;

namespace _2taldea
{
    public partial class ProduktuakForm2 : Form
    {
        private string nombreUsuario;
        private ISessionFactory sessionFactory;

        public ProduktuakForm2(string nombreUsuario, ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario ?? throw new ArgumentNullException(nameof(nombreUsuario));
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
        }

        private void ProduktuakForm_Load(object sender, EventArgs e)
        {
            labelIzena.Text = nombreUsuario; // Mostrar el nombre del usuario
            CargarProduktuak(); // Cargar los productos en el DataGridView
        }

        private void CargarProduktuak()
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    Console.WriteLine("Abriendo sesión de NHibernate...");
                    var produktuak = session.CreateQuery("FROM Produktua").List<Produktua>();

                    if (produktuak.Count == 0)
                    {
                        MessageBox.Show("No se encontraron productos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dataGridViewProduktuak.DataSource = produktuak; // Asignar productos al DataGridView
                    ConfigurarDataGridView(); // Configurar las columnas del DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }

        private void ConfigurarDataGridView()
        {
            try
            {
                if (dataGridViewProduktuak.Columns.Count == 0) return;

                // Ocultar la columna "Id" si no es necesaria
                if (dataGridViewProduktuak.Columns["Id"] != null)
                {
                    dataGridViewProduktuak.Columns["Id"].Visible = false;
                }

                // Personalizar encabezados
                if (dataGridViewProduktuak.Columns["Stock"] != null)
                    dataGridViewProduktuak.Columns["Stock"].HeaderText = "Stock";

                if (dataGridViewProduktuak.Columns["Max"] != null)
                    dataGridViewProduktuak.Columns["Max"].HeaderText = "Máximo";

                if (dataGridViewProduktuak.Columns["Min"] != null)
                    dataGridViewProduktuak.Columns["Min"].HeaderText = "Mínimo";

                if (dataGridViewProduktuak.Columns["Prezioa"] != null)
                    dataGridViewProduktuak.Columns["Prezioa"].HeaderText = "Precio";

                dataGridViewProduktuak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar el tamaño
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error configurando el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtzera_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario
        }

        private void btnFiltratu_Click(object sender, EventArgs e)
        {
            var filtratuForm = new ProduktuakFiltratu(FiltrarProduktuak);
            filtratuForm.ShowDialog();
        }

        private void FiltrarProduktuak(string criterio)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    string query = criterio == "Prezioa"
                        ? "FROM Produktua ORDER BY Prezioa DESC"
                        : "FROM Produktua ORDER BY Stock DESC";

                    var produktuak = session.CreateQuery(query).List<Produktua>();
                    dataGridViewProduktuak.DataSource = produktuak;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Permisoak ez");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Permisoak ez");

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }
    }
}




