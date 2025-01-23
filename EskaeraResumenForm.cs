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
    public partial class EskaeraResumenForm : Form
    {
        private List<Eskaera> eskaerak;
        private int mesaId;
        private ISessionFactory sessionFactory;

        public EskaeraResumenForm(int mesaId, List<Eskaera> eskaerak, string nombreUsuario, ISessionFactory sessionFactory)
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

        private void btnEskaeraSortu_Click(object sender, EventArgs e)
        {
            // Definir la carpeta de destino
            string pdfDirectory = @"C:\Info ez nub\2taldea\bin\Debug\net7.0-windows\pdf";

            // Asegurarse de que la carpeta exista
            if (!Directory.Exists(pdfDirectory))
            {
                Directory.CreateDirectory(pdfDirectory);
            }

            // Generar un nombre de archivo único con la fecha y hora
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"EskaeraResumen_{timestamp}.pdf";
            string path = Path.Combine(pdfDirectory, fileName);

            using (PdfWriter writer = new PdfWriter(path))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (Document document = new Document(pdf))
            {
                PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                PdfColor burlyWoodColor = new DeviceRgb(222, 184, 135);

                Table headerTable = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                headerTable.AddCell(new Cell().Add(new Paragraph("Michisuji")
                    .SetFont(boldFont)
                    .SetFontSize(20)
                    .SetFontColor(ColorConstants.BLACK))
                    .SetBorder(Border.NO_BORDER));

                try
                {
                    PdfImage logo = new PdfImage(ImageDataFactory.Create("C:\\Info ez nub\\2taldea\\logo.png"));
                    logo.SetWidth(80).SetHeight(80);
                    headerTable.AddCell(new Cell().Add(logo)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetBorder(Border.NO_BORDER));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error cargando el logo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                document.Add(headerTable);
                document.Add(new Paragraph().SetBackgroundColor(burlyWoodColor).SetHeight(10));

                Table infoTable = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 })).UseAllAvailableWidth().SetMarginTop(10);
                infoTable.AddCell(new Cell().Add(new Paragraph($"NOREN FAKTURA\n{labelNombreUsuario.Text}")
                    .SetFont(boldFont).SetFontSize(10)).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph($"MAHAI ZENBAKIA\n{mesaId}\nDATA\n{DateTime.Now:dd.MM.yyyy}")
                    .SetFont(boldFont).SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBorder(Border.NO_BORDER));
                document.Add(infoTable);

                document.Add(new LineSeparator(new SolidLine()));

                Table totalTable = new Table(UnitValue.CreatePercentArray(new float[] { 70, 30 })).UseAllAvailableWidth().SetMarginTop(20);
                totalTable.AddCell(new Cell().Add(new Paragraph("Faktura Totala")
                    .SetFont(boldFont).SetFontSize(16)).SetBorder(Border.NO_BORDER));

                float totalPrecioa = 0;
                foreach (var eskaera in eskaerak)
                {
                    totalPrecioa += eskaera.Prezioa;
                }

                totalTable.AddCell(new Cell().Add(new Paragraph($"{totalPrecioa:0.00} €")
                    .SetFont(boldFont).SetFontSize(16))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBorder(Border.NO_BORDER));
                document.Add(totalTable);

                document.Add(new LineSeparator(new SolidLine()));

                Table descriptionTable = new Table(UnitValue.CreatePercentArray(new float[] { 70, 30 })).UseAllAvailableWidth().SetMarginTop(10);
                descriptionTable.AddHeaderCell(new Cell().Add(new Paragraph("PRODUKTUA")
                    .SetFont(boldFont).SetFontSize(10).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));
                descriptionTable.AddHeaderCell(new Cell().Add(new Paragraph("IMPORTEA")
                    .SetFont(boldFont).SetFontSize(10).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));

                foreach (var eskaera in eskaerak)
                {
                    descriptionTable.AddCell(new Cell().Add(new Paragraph(eskaera.Izena)
                        .SetFont(regularFont).SetFontSize(10)));
                    descriptionTable.AddCell(new Cell().Add(new Paragraph($"{eskaera.Prezioa:0.00} €")
                        .SetFont(regularFont).SetFontSize(10))
                        .SetTextAlignment(TextAlignment.RIGHT));
                }

                descriptionTable.AddCell(new Cell().Add(new Paragraph("Guztira")
                    .SetFont(boldFont).SetFontSize(10)).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                descriptionTable.AddCell(new Cell().Add(new Paragraph($"{totalPrecioa:0.00} €")
                    .SetFont(boldFont).SetFontSize(10)).SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.RIGHT));
                document.Add(descriptionTable);

                document.Add(new Paragraph("\nEskerrik asko zure eskaeragatik!")
                    .SetFont(regularFont).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            }

            MessageBox.Show($"PDF generado con éxito en:\n{path}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EskaeraResumenForm_Load(object sender, EventArgs e)
        {

        }
    }
}

