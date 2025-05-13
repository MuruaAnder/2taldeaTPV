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

            this.nombreUsuario = nombreUsuario ?? throw new ArgumentNullException(nameof(nombreUsuario));
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
                var mesas = KomandakKudeatzailea.ObtenerMesas(sessionFactory);

                int filas = 2;
                int buttonWidth = 175;
                int buttonHeight = 175;
                int buttonSpacingHorizontal = 40;
                int buttonSpacingVertical = 50;

                int mesasPorFila = (int)Math.Ceiling((double)mesas.Count / filas);
                int totalWidth = mesasPorFila * buttonWidth + (mesasPorFila - 1) * buttonSpacingHorizontal;
                int startX = (this.ClientSize.Width - totalWidth) / 2;
                int startY = 300;

                for (int i = 0; i < mesas.Count; i++)
                {
                    Mahaia mesa = mesas[i];

                    // Verificar si la mesa tiene pedidos activos
                    bool tienePedidoActivo = KomandakKudeatzailea.TienePedidoActivo(mesa.Id, sessionFactory);

                    Button btnMesa = new Button
                    {
                        Text = $"{mesa.MahaiZenbakia} .Mahaia\n{mesa.Kopurua} pertsonentzat",
                        Width = buttonWidth,
                        Height = buttonHeight,
                        Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                        BackColor = tienePedidoActivo ? Color.FromArgb(100, 80, 50) : Color.SaddleBrown, // Marrón grisáceo si hay pedido activo
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Tag = mesa.Id
                    };

                    int column = i % mesasPorFila;
                    int row = i / mesasPorFila;

                    btnMesa.Location = new Point(
                        startX + column * (buttonWidth + buttonSpacingHorizontal),
                        startY + row * (buttonHeight + buttonSpacingVertical) + (row * 20)
                    );

                    btnMesa.Click += BtnMesa_Click;
                    this.Controls.Add(btnMesa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea mahaiak sortzean: {ex.Message}", "Arazoak", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Errorea mahaia aukeratzean: {ex.Message}", "Arazoak", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtzera_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
