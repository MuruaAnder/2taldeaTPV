using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _2taldea
{
    public partial class PlateraAddForm : Form
    {
        private ISessionFactory sessionFactory;
        private List<PlateraProduktua> plateraProduktuak = new List<PlateraProduktua>();
        private string selectedImagePath = null; // Ruta temporal de la imagen seleccionada

        public class PlateraProduktua
        {
            public int ProduktuaId { get; set; }
            public string ProduktuaIzena { get; set; }
            public int Kantitatea { get; set; }
        }

        public PlateraAddForm(ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
        }

        private void PlateraAddForm_Load(object sender, EventArgs e)
        {
            KargatuProduktuak();
        }

        private void KargatuProduktuak()
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    var produktuak = session.CreateSQLQuery("SELECT id, izena FROM produktua")
                                          .List<object[]>();

                    lstProduktuak.Items.Clear();
                    foreach (var produktua in produktuak)
                    {
                        lstProduktuak.Items.Add(new KeyValuePair<int, string>((int)produktua[0], produktua[1].ToString()));
                    }

                    // Configurar el display member y value member
                    lstProduktuak.DisplayMember = "Value";
                    lstProduktuak.ValueMember = "Key";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea produktuak kargatzerakoan: " + ex.Message);
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select an Image File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    MessageBox.Show("Imagen seleccionada: " + selectedImagePath);

                    // Mostrar la imagen seleccionada en el PictureBox
                    if (File.Exists(selectedImagePath))
                    {
                        pictureBoxPreview.Image = Image.FromFile(selectedImagePath);
                    }
                }
            }
        }

        private void btnGehituProduktua_Click(object sender, EventArgs e)
        {
            if (lstProduktuak.SelectedItem == null)
            {
                MessageBox.Show("Aukeratu produktu bat");
                return;
            }

            if (!int.TryParse(txtProduktuKantitatea.Text, out int kantitatea) || kantitatea <= 0)
            {
                MessageBox.Show("Sartu kantitate baliogarria");
                return;
            }

            var selectedProduktua = (KeyValuePair<int, string>)lstProduktuak.SelectedItem;

            // Comprobar si ya existe
            var existente = plateraProduktuak.FirstOrDefault(p => p.ProduktuaId == selectedProduktua.Key);
            if (existente != null)
            {
                existente.Kantitatea += kantitatea;
            }
            else
            {
                plateraProduktuak.Add(new PlateraProduktua
                {
                    ProduktuaId = selectedProduktua.Key,
                    ProduktuaIzena = selectedProduktua.Value,
                    Kantitatea = kantitatea
                });
            }

            ErakutsiPlateraProduktuak();
            txtProduktuKantitatea.Clear();
        }

        private void ErakutsiPlateraProduktuak()
        {
            dgvPlateraProduktuak.DataSource = null;
            dgvPlateraProduktuak.DataSource = plateraProduktuak.Select(p => new
            {
                Produktua = p.ProduktuaIzena,
                Kantitatea = p.Kantitatea
            }).ToList();
        }

        private void btnGorde_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos básicos
                if (string.IsNullOrWhiteSpace(txtIzena.Text) ||
                    cmbKategoria.SelectedItem == null ||
                    !int.TryParse(txtKantitatea.Text, out _) ||
                    !float.TryParse(txtPrezioa.Text, out _))
                {
                    MessageBox.Show("Bete eremu guztiak behar bezala");
                    return;
                }

                // Obtener los datos del formulario
                string izena = txtIzena.Text;
                string kategoria = cmbKategoria.SelectedItem.ToString();
                int kantitatea = Convert.ToInt32(txtKantitatea.Text);
                float prezioa = Convert.ToSingle(txtPrezioa.Text);

                // Guardar la imagen si se seleccionó
                string imageName = null;
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    imageName = Path.GetFileName(selectedImagePath);
                    string destinationPath = Path.Combine(@"C:\Info ez nub\TPV3taldeaErronka\TPV3taldeaErronka\2taldea\bin\Debug\Images", imageName);

                    // Copiar la imagen a la carpeta de destino
                    File.Copy(selectedImagePath, destinationPath, overwrite: true);
                }

                // Guardar el plato primero
                string result = PlateraKudeatzailea.PlateraAdd(sessionFactory, izena, kategoria, kantitatea, prezioa, imageName);

                if (result == "true")
                {
                    // Obtener el ID del plato recién creado
                    int plateraId = LortuAzkenPlateraId();

                    // Guardar los productos del plato
                    if (plateraId > 0 && plateraProduktuak.Count > 0)
                    {
                        GordePlateraProduktuak(plateraId);
                    }

                    MessageBox.Show("Platera eta bere produktuak ongi gordeta", "Informazioa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Errorea: " + ex.Message);
            }
        }

        private int LortuAzkenPlateraId()
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    var query = session.CreateSQLQuery("SELECT MAX(id) FROM platera");
                    var result = query.UniqueResult();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea platera ID-a lortzerakoan: " + ex.Message);
                return -1;
            }
        }

        private void GordePlateraProduktuak(int plateraId)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    foreach (var pp in plateraProduktuak)
                    {
                        // Crear nueva relación platera-produktua
                        var plateraProduktua = new
                        {
                            platera_id = plateraId,
                            produktua_id = pp.ProduktuaId,
                            kantitatea = pp.Kantitatea
                        };

                        session.CreateSQLQuery(
                            "INSERT INTO platera_produktua (platera_id, produktua_id, kantitatea) " +
                            "VALUES (:plateraId, :produktuaId, :kantitatea)")
                              .SetParameter("plateraId", plateraId)
                              .SetParameter("produktuaId", pp.ProduktuaId)
                              .SetParameter("kantitatea", pp.Kantitatea)
                              .ExecuteUpdate();
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea platera produktuak gordetzerakoan: " + ex.Message);
                throw;
            }
        }

        private void btnUtzi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrezioa_TextChanged(object sender, EventArgs e)
        {
            // Validación opcional del precio
        }
    }
}