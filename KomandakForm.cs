using NHibernate;

namespace _2taldea
{
    public partial class KomandakForm : Form
    {
        private string nombreUsuario;
        private ISessionFactory sessionFactory;

        // Constructor del formulario
        public KomandakForm(string nombreUsuario, ISessionFactory sessionFactory)
        {
            InitializeComponent();

            // Asegúrate de que nombreUsuario no sea null
            this.nombreUsuario = nombreUsuario ?? throw new ArgumentNullException(nameof(nombreUsuario));

            // Asegúrate de que sessionFactory no sea null
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
        }

        private void KomandakForm_Load(object sender, EventArgs e)
        {
            labelIzena.Text = nombreUsuario;
            CrearMesas();
        }


        private void CrearMesas()
        {
            try
            {
                // Llamar al controlador para obtener las mesas
                var mesas = KomandakKudeatzailea.ObtenerMesas(sessionFactory);

                int filas = 2; // Número de filas (2 filas)
                int buttonWidth = 175;
                int buttonHeight = 175;
                int buttonSpacingHorizontal = 40; // Espaciado horizontal aumentado
                int buttonSpacingVertical = 50; // Espaciado vertical aumentado

                // Calcula el número de mesas por fila
                int mesasPorFila = (int)Math.Ceiling((double)mesas.Count / filas);

                // Calcula el ancho total de los botones y espacios para centrar
                int totalWidth = mesasPorFila * buttonWidth + (mesasPorFila - 1) * buttonSpacingHorizontal;
                int startX = (this.ClientSize.Width - totalWidth) / 2; // Centrado horizontal
                int startY = 300; // Margen superior fijo

                for (int i = 0; i < mesas.Count; i++)
                {
                    Mahaia mesa = mesas[i];

                    Button btnMesa = new Button
                    {
                        Text = $"{mesa.MahaiZenbakia} .Mahaia\n{mesa.Kopurua} pertsonentzat",
                        Width = buttonWidth,
                        Height = buttonHeight,
                        Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                        BackColor = Color.SaddleBrown,
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Tag = mesa.Id
                    };

                    int column = i % mesasPorFila;
                    int row = i / mesasPorFila;

                    btnMesa.Location = new Point(
                        startX + column * (buttonWidth + buttonSpacingHorizontal),
                        startY + row * (buttonHeight + buttonSpacingVertical) + (row * 20) // Ajuste adicional para la segunda fila
                    );

                    btnMesa.Click += BtnMesa_Click;
                    this.Controls.Add(btnMesa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea mesak sortzean: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnMesa_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if (btn != null)
                {
                    int mesaId = (int)btn.Tag;

                    MesaDetallesForm detallesForm = new MesaDetallesForm(mesaId, sessionFactory);
                    detallesForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea mahaia aukeratzean: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtzera_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
