using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHibernate;

namespace _2taldea
{
    public partial class EskaerakForm : Form
    {
        private string nombreUsuario;
        private ISessionFactory sessionFactory;

        public EskaerakForm(string nombreUsuario, ISessionFactory sessionFactory)
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
                using (ISession session = sessionFactory.OpenSession())
                {
                    IList<Mahaia> mesas = session.CreateQuery("FROM Mahaia").List<Mahaia>();

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
                            startY + row * (buttonHeight + buttonSpacingVertical) + (row * 20)
                        );

                        btnMesa.Click += BtnMesa_Click;
                        this.Controls.Add(btnMesa);
                    }
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

                    // Buscar pedidos activos de la mesa seleccionada
                    using (ISession session = sessionFactory.OpenSession())
                    {
                        var pedidosActivos = session.CreateQuery("FROM Eskaera WHERE MesaId = :mesaId AND Activo = true")
                                                    .SetParameter("mesaId", mesaId)
                                                    .List<Eskaera>();

                        if (pedidosActivos.Count == 0)
                        {
                            MessageBox.Show("No hay pedidos activos para esta mesa.", "Resumen de Mesa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Mostrar el resumen en un nuevo formulario, pasando el nombre del usuario
                        EskaeraResumenForm resumenForm = new EskaeraResumenForm(mesaId, pedidosActivos.ToList(), nombreUsuario, sessionFactory);
                        resumenForm.ShowDialog();
                    }
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

