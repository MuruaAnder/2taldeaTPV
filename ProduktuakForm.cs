using System;
using System.Windows.Forms;
using NHibernate;

namespace _2taldea
{
    public partial class ProduktuakForm : Form
    {
        private string nombreUsuario;
        private ISessionFactory sessionFactory;

        public ProduktuakForm(string nombreUsuario, ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario;
            this.sessionFactory = sessionFactory;
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

                    // Obtener los productos usando HQL
                    var produktuak = session.CreateQuery("FROM Produktua").List<Produktua>();

                    Console.WriteLine($"Productos encontrados: {produktuak.Count}");

                    if (produktuak.Count == 0)
                    {
                        MessageBox.Show("No se encontraron productos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Asignar los datos al DataGridView
                    dataGridViewProduktuak.DataSource = produktuak;

                    // Configurar las columnas del DataGridView
                    ConfigurarDataGridView();

                    Console.WriteLine($"Filas mostradas en DataGridView: {dataGridViewProduktuak.Rows.Count}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show($"Errorea produktuak kargatzean: {ex.Message}",
                                "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }

        private void ConfigurarDataGridView()
        {
            try
            {
                // Verificar si el DataGridView tiene columnas antes de configurarlas
                if (dataGridViewProduktuak.Columns.Count == 0) return;

                // Ocultar la columna "Id" si no se necesita
                if (dataGridViewProduktuak.Columns["Id"] != null)
                {
                    dataGridViewProduktuak.Columns["Id"].Visible = false;
                }

                // Personalizar encabezados de columnas
                if (dataGridViewProduktuak.Columns["Stock"] != null)
                    dataGridViewProduktuak.Columns["Stock"].HeaderText = "Stock";

                if (dataGridViewProduktuak.Columns["Max"] != null)
                    dataGridViewProduktuak.Columns["Max"].HeaderText = "Máximo";

                if (dataGridViewProduktuak.Columns["Min"] != null)
                    dataGridViewProduktuak.Columns["Min"].HeaderText = "Mínimo";

                if (dataGridViewProduktuak.Columns["Prezioa"] != null)
                    dataGridViewProduktuak.Columns["Prezioa"].HeaderText = "Precio";

                // Ajustar el tamaño de las columnas
                dataGridViewProduktuak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                Console.WriteLine("Configuración del DataGridView completada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea konfiguratzeko datuak: {ex.Message}",
                                "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error configurando DataGridView: {ex.Message}");
            }
        }

        private void btnAtzera_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario y regresar al menú principal
        }

        private void btnFiltratu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Filtratu botoia sakatu duzu.");
        }
    }
}


