using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHibernate;

namespace _2taldea
{
    public partial class EskaerakForm2 : Form
    {
        private string nombreUsuario;
        private ISessionFactory sessionFactory;

        public EskaerakForm2(string nombreUsuario, ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario ?? throw new ArgumentNullException(nameof(nombreUsuario));
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
        }

        private void EskaerakForm_Load(object sender, EventArgs e)
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
                MessageBox.Show($"Errorea mahaiak sortzean: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMesa_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                int mesaId = (int)btn.Tag;

                EskaeraKudeatzaile2.ProcesarMesa(mesaId, nombreUsuario, sessionFactory);
            }
        }


        private void BtnAtzera_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

