using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHibernate;

namespace _2taldea
{
    public partial class MesaDetallesForm : Form
    {
        private int mesaId;
        private ISessionFactory sessionFactory;
        private Dictionary<string, (int cantidad, float precio, string nota)> resumen = new Dictionary<string, (int, float, string)>();
        private int ultimoEskaeraZenb;

        public MesaDetallesForm(int mesaId, ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.mesaId = mesaId;
            this.sessionFactory = sessionFactory;
            this.mesaLabel.Text = $"Mahaia: {mesaId}";

            // Configura el TabControl existente
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            // Carga los platos en la primera pestaña (Edaria)
            CargarPlatos("Edaria", tabControl.TabPages[0]);
            CargarPedidosGuardados();
        }

        private void MesaDetallesForm_Load(object sender, EventArgs e)
        {
            TabControl tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(tabControl);

            // Crear las pestañas con la nueva categoría "Postrea"
            TabPage bebidasTab = new TabPage("Edaria");
            TabPage primerPlatoTab = new TabPage("Lehenengo platera");
            TabPage segundoPlatoTab = new TabPage("Bigarren platera");
            TabPage postreTab = new TabPage("Postrea"); // Nueva pestaña

            tabControl.TabPages.AddRange(new[] { bebidasTab, primerPlatoTab, segundoPlatoTab, postreTab });

            Label mesaLabel = new Label
            {
                Text = $"Mahaia: {mesaId}",
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(this.ClientSize.Width - 150, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            if (!this.Controls.Contains(mesaLabel))
            {
                this.Controls.Add(mesaLabel);
            }

            // Cargar contenido inicial
            CargarPlatos("Edaria", bebidasTab);
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl != null)
            {
                TabPage selectedTab = tabControl.SelectedTab;
                string selectedCategory = selectedTab.Text;

                if (selectedTab.Controls.Count == 0)
                {
                    selectedTab.BeginInvoke((Action)(() =>
                    {
                        CargarPlatos(selectedCategory, selectedTab);
                    }));
                }
            }
        }

        private void CargarPlatos(string kategoria, TabPage tabPage)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var platos = session.QueryOver<Platera>()
                                        .Where(p => p.Kategoria == kategoria)
                                        .List();

                    Panel mainPanel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackgroundImage = Image.FromFile("background.png"),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    Panel platosPanel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        AutoScroll = true,
                        BackColor = Color.Transparent
                    };

                    TableLayoutPanel tablaPlatos = new TableLayoutPanel
                    {
                        AutoSize = true,
                        ColumnCount = 3,
                        Padding = new Padding(0),
                        Margin = new Padding(0),
                        BackColor = Color.Transparent
                    };

                    for (int i = 0; i < tablaPlatos.ColumnCount; i++)
                        tablaPlatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));

                    FlowLayoutPanel contenedorCentrado = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Top,
                        AutoSize = true,
                        FlowDirection = FlowDirection.LeftToRight,
                        Padding = new Padding(490, 0, 0, 0),
                        BackColor = Color.Transparent
                    };

                    contenedorCentrado.Controls.Add(tablaPlatos);
                    platosPanel.Controls.Add(contenedorCentrado);

                    int row = 0, col = 0;

                    foreach (var plato in platos)
                    {
                        Panel productoPanel = new Panel
                        {
                            Width = 280,
                            Height = 350,
                            Margin = new Padding(10),
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.None,
                            Cursor = Cursors.Hand
                        };

                        productoPanel.MouseEnter += (s, ev) => productoPanel.BackColor = Color.FromArgb(240, 240, 240);
                        productoPanel.MouseLeave += (s, ev) => productoPanel.BackColor = Color.White;

                        TableLayoutPanel layout = new TableLayoutPanel
                        {
                            ColumnCount = 1,
                            RowCount = 5,
                            Dock = DockStyle.Fill,
                            Padding = new Padding(15)
                        };

                        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
                        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                        // PictureBox para la imagen
                        PictureBox pictureBox = new PictureBox
                        {
                            Dock = DockStyle.Fill,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BackColor = Color.FromArgb(220, 220, 220)
                        };

                        if (!string.IsNullOrEmpty(plato.Foto))
                        {
                            try
                            {
                                // Normalizar el nombre del archivo
                                string normalizedFilename = plato.Foto.Trim().ToLower();
                                string imagePath = Path.Combine(@"C:\Info ez nub\TPV3taldeaErronka\TPV3taldeaErronka\2taldea\bin\Debug\Images", normalizedFilename);

                                if (File.Exists(imagePath))
                                {
                                    pictureBox.Image = Image.FromFile(imagePath);
                                }
                                else
                                {
                                    MessageBox.Show($"Archivo no encontrado: {imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        layout.Controls.Add(pictureBox, 0, 0);

                        // Nombre del plato
                        Label lblNombre = new Label
                        {
                            Text = plato.Izena,
                            AutoSize = true,
                            Font = new Font("Segoe UI", 14, FontStyle.Bold),
                            ForeColor = Color.FromArgb(50, 50, 50),
                            Dock = DockStyle.Top
                        };
                        layout.Controls.Add(lblNombre, 0, 1);

                        // Precio
                        Label lblPrecio = new Label
                        {
                            Text = $"{plato.Prezioa:C2}",
                            AutoSize = true,
                            Font = new Font("Segoe UI", 12),
                            ForeColor = Color.FromArgb(0, 150, 136),
                            Dock = DockStyle.Top
                        };
                        layout.Controls.Add(lblPrecio, 0, 2);

                        // Controles de cantidad
                        TableLayoutPanel controles = new TableLayoutPanel
                        {
                            ColumnCount = 3,
                            RowCount = 1,
                            AutoSize = true
                        };
                        controles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
                        controles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
                        controles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));

                        Button btnMinus = new Button
                        {
                            Text = "-",
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            BackColor = Color.FromArgb(255, 61, 53),
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat,
                            Size = new Size(50, 40)
                        };

                        Label lblCantidad = new Label
                        {
                            Text = "0",
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Segoe UI", 14),
                            ForeColor = Color.FromArgb(50, 50, 50),
                            Size = new Size(80, 40)
                        };

                        Button btnPlus = new Button
                        {
                            Text = "+",
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            BackColor = Color.FromArgb(0, 150, 136),
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat,
                            Size = new Size(50, 40)
                        };

                        controles.Controls.Add(btnMinus, 0, 0);
                        controles.Controls.Add(lblCantidad, 1, 0);
                        controles.Controls.Add(btnPlus, 2, 0);
                        layout.Controls.Add(controles, 0, 3);

                        // Botón de ingredientes
                        Button btnIngredientes = new Button
                        {
                            Text = "Osagaiak",
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            BackColor = Color.SaddleBrown,
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat,
                            Size = new Size(250, 40),
                            Margin = new Padding(0, 15, 0, 0)
                        };
                        layout.Controls.Add(btnIngredientes, 0, 4);

                        // Eventos
                        btnPlus.Click += (s, ev) =>
                        {
                            int cantidad = int.Parse(lblCantidad.Text) + 1;
                            lblCantidad.Text = cantidad.ToString();
                            if (!resumen.ContainsKey(plato.Izena))
                                resumen[plato.Izena] = (0, plato.Prezioa, "");
                            if (cantidad == 1)
                            {
                                string nota = Microsoft.VisualBasic.Interaction.InputBox(
                                    $"Oharra {plato.Izena}:",
                                    "Oharra gehitu",
                                    "");
                                resumen[plato.Izena] = (cantidad, plato.Prezioa, nota);
                            }
                            else
                            {
                                resumen[plato.Izena] = (cantidad, plato.Prezioa, resumen[plato.Izena].nota);
                            }
                        };

                        btnMinus.Click += (s, ev) =>
                        {
                            int cantidad = int.Parse(lblCantidad.Text);
                            if (cantidad > 0)
                            {
                                cantidad--;
                                lblCantidad.Text = cantidad.ToString();
                                if (cantidad == 0)
                                    resumen[plato.Izena] = (0, plato.Prezioa, "");
                                else
                                    resumen[plato.Izena] = (cantidad, plato.Prezioa, resumen[plato.Izena].nota);
                            }
                        };

                        btnIngredientes.Click += (s, ev) => MostrarIngredientes(plato);

                        productoPanel.Controls.Add(layout);
                        tablaPlatos.Controls.Add(productoPanel, col, row);
                        col++;
                        if (col >= 3)
                        {
                            col = 0;
                            row++;
                        }
                    }

                    // Panel de botones inferior
                    Panel botonesPanel = new Panel
                    {
                        Dock = DockStyle.Bottom,
                        Height = 100,
                        BackColor = Color.Transparent
                    };

                    FlowLayoutPanel flowBotones = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.LeftToRight,
                        AutoSize = true,
                        Padding = new Padding(490, 0, 0, 0),
                        BackColor = Color.Transparent
                    };

                    Button btnGuardar = new Button
                    {
                        Text = "Pedidoa gorde",
                        BackColor = Color.Green,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        Width = 200,
                        Height = 50,
                        Margin = new Padding(20, 0, 20, 0)
                    };

                    btnGuardar.Click += BtnGuardar_Click;

                    Button btnResumen = new Button
                    {
                        Text = "Laburpena ikusi",
                        BackColor = Color.Blue,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        Width = 200,
                        Height = 50,
                        Margin = new Padding(20, 0, 20, 0)
                    };

                    btnResumen.Click += BtnResumen_Click;

                    Button btnBorrar = new Button
                    {
                        Text = "Pedidoa ezabatu",
                        BackColor = Color.Red,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        Width = 200,
                        Height = 50,
                        Margin = new Padding(20, 0, 20, 0)
                    };

                    btnBorrar.Click += BtnBorrar_Click;

                    Button btnAtzera = new Button
                    {
                        Text = "Atzera",
                        BackColor = Color.Gray,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        Width = 200,
                        Height = 50,
                        Margin = new Padding(20, 0, 20, 0)
                    };

                    btnAtzera.Click += (s, ev) => { this.Close(); };

                    flowBotones.Controls.AddRange(new Control[] { btnGuardar, btnResumen, btnBorrar, btnAtzera });
                    botonesPanel.Controls.Add(flowBotones);
                    mainPanel.Controls.Add(platosPanel);
                    mainPanel.Controls.Add(botonesPanel);
                    tabPage.Controls.Add(mainPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriako platerak kargatzean arazoak {kategoria}: {ex.Message}", "Arazoak", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarIngredientes(Platera plato)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    var ingredientes = session.QueryOver<PlateraProduktua>()
                                            .Where(pp => pp.PlateraId == plato.Id)
                                            .JoinQueryOver(pp => pp.Produktua)
                                            .List();

                    string mensaje = $"{plato.Izena}:\nPlateraren osagaiak";
                    foreach (var ingrediente in ingredientes)
                    {
                        mensaje += $"\n- {ingrediente.Produktua.Izena}: {ingrediente.Kantitatea} unitate";
                    }

                    MessageBox.Show(mensaje, "Plateraren osagaiak", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ingredientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPedidosGuardados()
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    var lastEskaera = session.QueryOver<Eskaera>()
                                          .Where(e => e.MesaId == mesaId && e.Activo == 1)
                                          .OrderBy(e => e.EskaeraZenb).Desc
                                          .Take(1)
                                          .SingleOrDefault();
                    ultimoEskaeraZenb = lastEskaera?.EskaeraZenb ?? 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gordetako pedidoak ez dira kargatu: {ex.Message}", "Arazoak", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var resumenSimple = resumen.ToDictionary(
                    item => item.Key,
                    item => (item.Value.cantidad, item.Value.precio));
                var notasPlatos = resumen.ToDictionary(
                    item => item.Key,
                    item => item.Value.nota);
                KomandakKudeatzailea.GuardarEskaera(sessionFactory, mesaId, resumenSimple, notasPlatos);
                MessageBox.Show("Datuak ongi gorde dira", "Ongi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea gordetzerakoan: {ex.Message}", "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            KomandakKudeatzailea.BorrarPedidos(sessionFactory, mesaId);
            MessageBox.Show("Eskaria ezabatu da", "Ongi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnResumen_Click(object sender, EventArgs e)
        {
            try
            {
                string resumenTexto = KomandakKudeatzailea.CargarResumen(sessionFactory, mesaId);
                if (string.IsNullOrWhiteSpace(resumenTexto))
                {
                    MessageBox.Show("Ez dago informaziorik erakusteko.", "Laburpena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resumenTexto, "Laburpena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea laburpena kargatzean: {ex.Message}", "Errorea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}