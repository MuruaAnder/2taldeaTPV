using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
using PdfColor = iText.Kernel.Colors.Color; // Alias para iText Color
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
            labelNombreUsuario.Text = nombreUsuario;
            CargarDatos();
        }

        private void CargarDatos()
        {
            labelMesa.Text = $"{mesaId}";
            flowLayoutPanelPedidos.Controls.Clear();
            float totalPrecioa = 0;

            // Añadir encabezados de columnas
            Panel headerPanel = new Panel
            {
                Width = flowLayoutPanelPedidos.Width - 25,
                Height = 50, // Altura aumentada para texto grande
                Margin = new Padding(0, 0, 0, 10)
            };

            int columnWidth = (headerPanel.Width - 30) / 3; // 30px para márgenes (10px entre columnas)

            // Crear etiquetas de encabezado
            Label lblIzena = new Label
            {
                Text = "Izena",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 5),
                ForeColor = System.Drawing.Color.White, // Texto en blanco

                Width = columnWidth
            };

            Label lblKantitatea = new Label
            {
                Text = "Kantitatea",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10 + columnWidth + 10, 5),
                ForeColor = System.Drawing.Color.White, // Texto en blanco

                Width = columnWidth
            };

            Label lblPrezioa = new Label
            {
                Text = "Prezioa",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10 + 2 * (columnWidth + 10), 5),
                ForeColor = System.Drawing.Color.White, // Texto en blanco

                Width = columnWidth
            };

            headerPanel.Controls.Add(lblIzena);
            headerPanel.Controls.Add(lblKantitatea);
            headerPanel.Controls.Add(lblPrezioa);
            flowLayoutPanelPedidos.Controls.Add(headerPanel);

            using (var session = sessionFactory.OpenSession())
            {
                var eskaeraIds = eskaerak.Select(e => e.Id).ToList();
                var detallesPedidos = session.QueryOver<EskaeraPlatera>()
                    .WhereRestrictionOn(ep => ep.Eskaera.Id).IsIn(eskaeraIds)
                    .JoinQueryOver(ep => ep.Platera)
                    .List();

                var resumen = new Dictionary<string, (int Cantidad, float Precio, string Nota)>();

                foreach (var detalle in detallesPedidos)
                {
                    string nombrePlato = detalle.Platera.Izena;
                    float precio = detalle.Platera.Prezioa;
                    string nota = detalle.NotaGehigarriak ?? "";

                    if (resumen.ContainsKey(nombrePlato))
                    {
                        resumen[nombrePlato] = (
                            resumen[nombrePlato].Cantidad + 1,
                            precio,
                            !string.IsNullOrEmpty(nota) ? nota : resumen[nombrePlato].Nota
                        );
                    }
                    else
                    {
                        resumen[nombrePlato] = (1, precio, nota);
                    }
                }

                foreach (var item in resumen)
                {
                    string nombrePlato = item.Key;
                    int cantidad = item.Value.Cantidad;
                    float precioUnitario = item.Value.Precio;
                    string nota = item.Value.Nota;
                    float subtotal = cantidad * precioUnitario;
                    totalPrecioa += subtotal;

                    // Panel para cada fila de datos
                    Panel rowPanel = new Panel
                    {
                        Width = flowLayoutPanelPedidos.Width - 25,
                        Height = 60, // Altura aumentada
                        Margin = new Padding(0, 0, 0, 5)
                    };

                    // Nombre del plato
                    Label lblNombre = new Label
                    {
                        Text = nombrePlato,
                        Font = new Font("Segoe UI", 15, FontStyle.Regular),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(10, 5),
                        Width = columnWidth,
                        ForeColor = System.Drawing.Color.White // Texto en blanco
                    };

                    // Cantidad
                    Label lblCantidad = new Label
                    {
                        Text = cantidad.ToString(),
                        Font = new Font("Segoe UI", 15, FontStyle.Regular),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(10 + columnWidth + 10, 5),
                        Width = columnWidth,
                        ForeColor = System.Drawing.Color.White // Texto en blanco
                    };

                    // Subtotal
                    Label lblSubtotal = new Label
                    {
                        Text = $"{subtotal:0.00}€",
                        Font = new Font("Segoe UI", 15, FontStyle.Regular),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(10 + 2 * (columnWidth + 10), 5),
                        Width = columnWidth,
                        ForeColor = System.Drawing.Color.White // Texto en blanco
                    };

                    // Línea separadora
                    Panel separator = new Panel
                    {
                        Width = flowLayoutPanelPedidos.Width - 25,
                        Height = 1,
                        BackColor = System.Drawing.Color.LightGray, // Usamos System.Drawing.Color aquí
                        Margin = new Padding(0, 5, 0, 5)
                    };

                    // Nota si existe
                    if (!string.IsNullOrEmpty(nota))
                    {
                        Label lblNota = new Label
                        {
                            Text = $"Oharra: {nota}",
                            Font = new Font("Segoe UI", 10, FontStyle.Italic),
                            ForeColor = System.Drawing.Color.White, // Texto en blanco
                            Location = new Point(10, 35),
                            Width = rowPanel.Width - 20
                        };
                        rowPanel.Height += 25; // Aumentar altura para la nota
                        rowPanel.Controls.Add(lblNota);
                    }

                    rowPanel.Controls.Add(lblNombre);
                    rowPanel.Controls.Add(lblCantidad);
                    rowPanel.Controls.Add(lblSubtotal);
                    flowLayoutPanelPedidos.Controls.Add(rowPanel);
                    flowLayoutPanelPedidos.Controls.Add(separator); // Añadir línea separadora
                }

                // Mantener el color original del total general
                labelPrezioa.ForeColor = System.Drawing.Color.Black; // Color original
                labelPrezioa.Text = $"GUZTIRA: {totalPrecioa:0.00}€";
            }
        }

        private void btnEskaeraSortu_Click(object sender, EventArgs e)
        {
            string pdfDirectory = @"C:\Info ez nub\TPV3taldeaErronka\TPV3taldeaErronka\2taldea\bin\Debug\pdf";
            if (!Directory.Exists(pdfDirectory))
            {
                Directory.CreateDirectory(pdfDirectory);
            }
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"EskaeraResumen_{timestamp}.pdf";
            string path = Path.Combine(pdfDirectory, fileName);

            try
            {
                using (PdfWriter writer = new PdfWriter(path))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {
                    // Configuración de fuentes
                    PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                    // Cabecera del PDF
                    Table headerTable = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    headerTable.AddCell(new Cell().Add(new Paragraph("The Bulls")
                        .SetFont(boldFont)
                        .SetFontSize(20)
                        .SetFontColor(ColorConstants.BLACK))
                        .SetBorder(Border.NO_BORDER));

                    try
                    {
                        PdfImage logo = new PdfImage(ImageDataFactory.Create("C:\\Info ez nub\\TPV3taldeaErronka\\TPV3taldeaErronka\\2taldea\\thebulls_logo.png"))
                            .SetWidth(85)
                            .SetHeight(85)
                            .SetMarginTop(-12);
                        headerTable.AddCell(new Cell().Add(logo)
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .SetBorder(Border.NO_BORDER)
                            .SetPaddingTop(-20));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errorea logoa kargatzean: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    document.Add(headerTable);

                    // Línea decorativa
                    try
                    {
                        PdfImage background = new PdfImage(ImageDataFactory.Create("C:\\Info ez nub\\TPV3taldeaErronka\\TPV3taldeaErronka\\2taldea\\background.png"))
                            .SetWidth(pdf.GetDefaultPageSize().GetWidth())
                            .SetHeight(10);
                        document.Add(background);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error atazeko argazkia kargatzean: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Información del pedido
                    Table infoTable = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 })).UseAllAvailableWidth().SetMarginTop(10);
                    infoTable.AddCell(new Cell().Add(new Paragraph($"NOREN FAKTURA\n{labelNombreUsuario.Text}")
                        .SetFont(boldFont).SetFontSize(10)).SetBorder(Border.NO_BORDER));
                    infoTable.AddCell(new Cell().Add(new Paragraph($"MAHAI ZENBAKIA\n{mesaId}\nDATA\n{DateTime.Now:dd.MM.yyyy}")
                        .SetFont(boldFont).SetFontSize(10))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetBorder(Border.NO_BORDER));
                    document.Add(infoTable);

                    document.Add(new LineSeparator(new SolidLine()));

                    // Total del pedido
                    float totalPrecioa = 0;
                    foreach (var eskaera in eskaerak)
                    {
                        totalPrecioa += eskaera.Prezioa;
                    }

                    Table totalTable = new Table(UnitValue.CreatePercentArray(new float[] { 70, 30 })).UseAllAvailableWidth().SetMarginTop(20);
                    totalTable.AddCell(new Cell().Add(new Paragraph("Faktura Totala")
                        .SetFont(boldFont).SetFontSize(16)).SetBorder(Border.NO_BORDER));
                    totalTable.AddCell(new Cell().Add(new Paragraph($"{totalPrecioa:0.00} €")
                        .SetFont(boldFont).SetFontSize(16))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetBorder(Border.NO_BORDER));
                    document.Add(totalTable);

                    document.Add(new LineSeparator(new SolidLine()));

                    // Detalles del pedido
                    Table descriptionTable = new Table(UnitValue.CreatePercentArray(new float[] { 40, 20, 40 })).UseAllAvailableWidth().SetMarginTop(10);
                    descriptionTable.AddHeaderCell(new Cell().Add(new Paragraph(" PRODUKTUA")
                        .SetFont(boldFont).SetFontSize(10).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));
                    descriptionTable.AddHeaderCell(new Cell().Add(new Paragraph(" KANTITATEA")
                        .SetFont(boldFont).SetFontSize(10).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));
                    descriptionTable.AddHeaderCell(new Cell().Add(new Paragraph(" IMPORTEA")
                        .SetFont(boldFont).SetFontSize(10).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));

                    using (var session = sessionFactory.OpenSession())
                    {
                        var eskaeraIds = eskaerak.Select(e => e.Id).ToList();
                        var detallesPedidos = session.QueryOver<EskaeraPlatera>()
                            .WhereRestrictionOn(ep => ep.Eskaera.Id).IsIn(eskaeraIds)
                            .JoinQueryOver(ep => ep.Platera)
                            .List();

                        var resumen = new Dictionary<string, (int Cantidad, float Precio)>();
                        foreach (var detalle in detallesPedidos)
                        {
                            string nombrePlato = detalle.Platera.Izena;
                            if (resumen.ContainsKey(nombrePlato))
                            {
                                resumen[nombrePlato] = (resumen[nombrePlato].Cantidad + 1, detalle.Platera.Prezioa);
                            }
                            else
                            {
                                resumen[nombrePlato] = (1, detalle.Platera.Prezioa);
                            }
                        }

                        foreach (var item in resumen)
                        {
                            string nombrePlato = item.Key;
                            int cantidad = item.Value.Cantidad;
                            float precioUnitario = item.Value.Precio;

                            // Añadir fila al PDF
                            descriptionTable.AddCell(new Cell().Add(new Paragraph(nombrePlato)
                                .SetFont(regularFont).SetFontSize(10))); // Nombre del producto
                            descriptionTable.AddCell(new Cell().Add(new Paragraph($"{cantidad}")
                                .SetFont(regularFont).SetFontSize(10)) // Cantidad
                                .SetTextAlignment(TextAlignment.CENTER)); // Centrar cantidad
                            descriptionTable.AddCell(new Cell().Add(new Paragraph($"{cantidad * precioUnitario:0.00} €")
                                .SetFont(regularFont).SetFontSize(10)) // Importe
                                .SetTextAlignment(TextAlignment.RIGHT)); // Alinear importe a la derecha
                        }
                    }

                    descriptionTable.AddCell(new Cell().Add(new Paragraph("Guztira")
                        .SetFont(boldFont).SetFontSize(10)).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                    descriptionTable.AddCell(new Cell().Add(new Paragraph("")) // Espacio vacío para cantidad
                        .SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                    descriptionTable.AddCell(new Cell().Add(new Paragraph($"{totalPrecioa:0.00} €")
                        .SetFont(boldFont).SetFontSize(10)).SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                        .SetTextAlignment(TextAlignment.RIGHT));

                    document.Add(descriptionTable);

                    document.Add(new Paragraph("\nEskerrik asko zure eskaeragatik!")
                        .SetFont(regularFont).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
                }

                MessageBox.Show($"PDF-a sortuta:\n{path}", "Ongi!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Acciones adicionales después de generar el PDF
                try
                {
                    using (var session = sessionFactory.OpenSession())
                    using (var transaction = session.BeginTransaction())
                    {
                        var pedidosActivos = session.QueryOver<Eskaera>()
                                                    .Where(e => e.MesaId == mesaId && e.Activo == 1)
                                                    .List();

                        foreach (var pedido in pedidosActivos)
                        {
                            pedido.Activo = 0; // Desactivar el pedido
                            session.Update(pedido);
                        }

                        transaction.Commit();
                    }

                    MessageBox.Show("Eskaria eta mahaia ongi itxi dira.", "Ongi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errorea eskaria itxieraan: {ex.Message}", "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea PDFa sortzean: {ex.Message}", "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtzera_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EskaeraResumenForm_Load(object sender, EventArgs e)
        {
            // Código de carga si es necesario
        }
    }
}