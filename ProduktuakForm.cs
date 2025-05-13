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
                // Llamar al controlador para obtener los productos y las alertas
                var (produktuak, produktuakStockBaxua) = ProduktuaKudeatzailea.ObtenerProduktuakConAlertas(sessionFactory);

                if (produktuak == null || produktuak.Count == 0)
                {
                    MessageBox.Show("Ez dira billatu produktuak.", "Abisua", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asignar productos al DataGridView
                dataGridViewProduktuak.DataSource = produktuak;
                ConfigurarDataGridView();

                // Resaltar productos con bajo stock en rojo
                foreach (DataGridViewRow row in dataGridViewProduktuak.Rows)
                {
                    if (row.DataBoundItem is Produktua produktua && produktuakStockBaxua.Contains(produktua))
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.White; // Cambiar el texto a blanco para mejor visibilidad
                    }
                }

                // Mostrar alerta si hay productos con stock insuficiente
                if (produktuakStockBaxua.Count > 0)
                {
                    string mensaje = "Ez dago stock nahikoa:\n" +
                                     string.Join("\n", produktuakStockBaxua.Select(p => p.Izena));
                    MessageBox.Show(mensaje, "Abisua", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Produktuak kargatzean arazoak: {ex.Message}", "Arazoak", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"DatagridView kargatzean arazoak: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Llamar al controlador para obtener los productos filtrados
                var produktuak = ProduktuaKudeatzailea.FiltrarProduktuak(sessionFactory, criterio);

                if (produktuak == null || produktuak.Count == 0)
                {
                    MessageBox.Show("Ez dira produktuak billatu kriterio horrekin", "Abixua", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asignar los productos filtrados al DataGridView
                dataGridViewProduktuak.DataSource = produktuak;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Produktuak filtratzean arazoak: {ex.Message}", "Arazoak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduktuak.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewProduktuak.SelectedRows[0].DataBoundItem as Produktua;

                if (selectedRow != null)
                {
                    var editForm = new ProduktuaEditForm(selectedRow, sessionFactory);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        CargarProduktuak(); // Recargar los productos después de la edición
                    }
                }
                else
                {
                    MessageBox.Show("Produktu balido bat aukeratu", "Abixua", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Editatzeko produktu bat aukeratu", "Abixua", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new ProduktuaAddForm(sessionFactory);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                CargarProduktuak(); // Recargar los productos después de añadir uno nuevo
            }
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewProduktuak_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlateraAddForm plateraForm = new PlateraAddForm(sessionFactory);
            plateraForm.Show();
        }
    }
}




