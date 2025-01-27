using System;
using System.Collections.Generic;
using System.Drawing; // Para colores en el formulario
using System.IO;
using System.Windows.Forms;
using NHibernate;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Borders;

// Alias para evitar conflictos
using PdfColor = iText.Kernel.Colors.Color;
using PdfImage = iText.Layout.Element.Image;
namespace _2taldea
{
    public partial class EskaeraResumenForm2 : Form
    {
        private List<Eskaera> eskaerak;
        private int mesaId;
        private ISessionFactory sessionFactory;

        public EskaeraResumenForm2(int mesaId, List<Eskaera> eskaerak, string nombreUsuario, ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.mesaId = mesaId;
            this.eskaerak = eskaerak;
            this.sessionFactory = sessionFactory;

            // Asignar el nombre del usuario directamente (sin necesidad de cambiarlo después)
            labelNombreUsuario.Text = nombreUsuario;

            CargarDatos();
        }

        private void CargarDatos()
        {
            labelMesa.Text = $"{mesaId},";
            flowLayoutPanelPedidos.Controls.Clear();
            float totalPrecioa = 0;

            foreach (var eskaera in eskaerak)
            {
                FlowLayoutPanel panelProducto = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Padding = new Padding(0, 10, 0, 10),
                    Margin = new Padding(0, 0, 0, 10),
                    Width = flowLayoutPanelPedidos.ClientSize.Width - 10
                };

                FlowLayoutPanel innerPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Width = panelProducto.Width - 20,
                    Margin = new Padding(0)
                };

                Label lblProducto = new Label
                {
                    Text = eskaera.Izena,
                    Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
                    ForeColor = System.Drawing.Color.White, // Especificar explicitamente
                    AutoSize = true
                };
                innerPanel.Controls.Add(lblProducto);

                Label lblPrecio = new Label
                {
                    Text = $"{eskaera.Prezioa}€",
                    Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
                    ForeColor = System.Drawing.Color.White, // Especificar explicitamente
                    AutoSize = true
                };
                lblPrecio.Anchor = AnchorStyles.Right;
                innerPanel.Controls.Add(lblPrecio);

                panelProducto.Controls.Add(innerPanel);
                flowLayoutPanelPedidos.Controls.Add(panelProducto);

                Label lblLinea = new Label
                {
                    Text = string.Empty,
                    Height = 2,
                    BackColor = System.Drawing.Color.White, // Especificar explicitamente
                    Dock = DockStyle.Top,
                    Width = flowLayoutPanelPedidos.ClientSize.Width
                };
                flowLayoutPanelPedidos.Controls.Add(lblLinea);

                totalPrecioa += eskaera.Prezioa;
            }

            labelPrezioa.Text = $"Prezioa: {totalPrecioa}€";
        }


        private void BtnAtzera_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEskaeraSortu2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Baimenik ez.");
        }

        private void EskaeraResumenForm_Load(object sender, EventArgs e)
        {

        }
    }
}

