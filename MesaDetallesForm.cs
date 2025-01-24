using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHibernate;

namespace _2taldea
{
    public partial class MesaDetallesForm : Form
    {
        private int mesaId;
        private ISessionFactory sessionFactory;
        private Dictionary<string, (int cantidad, float precio)> resumen = new Dictionary<string, (int cantidad, float precio)>();
        private int ultimoEskaeraZenb;

        public MesaDetallesForm(int mesaId, ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.mesaId = mesaId;
            this.sessionFactory = sessionFactory;

            if (mesaId <= 0)
            {
                throw new ArgumentException("El ID de la mesa debe ser mayor a 0.");
            }

            // Actualizamos el texto del Label con el número de mesa
            this.mesaLabel.Text = $" {mesaId}. Mahaia";

            // Agregar el evento SelectedIndexChanged al TabControl
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            // Cargar los datos en las pestañas correctas al iniciar
            CargarPlatos("Edaria", tabControl.TabPages[0]);
        }

        private void MesaDetallesForm_Load(object sender, EventArgs e)
        {
            // Configurar pestañas
            TabControl tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(tabControl);

            // Crear pestañas
            TabPage bebidasTab = new TabPage("Edaria");
            TabPage primerPlatoTab = new TabPage("Lehenengo platera");
            TabPage segundoPlatoTab = new TabPage("Bigarren platera");

            tabControl.TabPages.AddRange(new[] { bebidasTab, primerPlatoTab, segundoPlatoTab });

            // Agregar un Label en la esquina superior derecha para mostrar el número de mesa
            Label mesaLabel = new Label
            {
                Text = $"Mesa: {mesaId}",
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(this.ClientSize.Width - 100, 10), // Posición inicial
                Anchor = AnchorStyles.Top | AnchorStyles.Right // Fijar posición
            };
            this.Controls.Add(mesaLabel);

            // Asegurarnos de cargar los productos de la primera pestaña
            CargarPlatos("Edaria", bebidasTab); // Se carga de inmediato
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl != null)
            {
                TabPage selectedTab = tabControl.SelectedTab;
                string selectedCategory = selectedTab.Text;

                // Evitar cargar los productos más de una vez
                if (selectedTab.Controls.Count == 0)
                {
                    // Usamos BeginInvoke para asegurarnos de que la carga de los platos se realice correctamente después del cambio de pestaña
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
                {
                    var platos = session.QueryOver<Platera>()
                        .Where(p => p.Kategoria == kategoria)
                        .List();

                    // Panel principal con diseño vertical
                    TableLayoutPanel mainPanel = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        ColumnCount = 1,
                        AutoScroll = true,
                        BackColor = Color.BurlyWood, // Fondo de la pestaña
                        Padding = new Padding(0, 100, 0, 0) // Aumentar margen superior para mover todo más abajo
                    };

                    // Panel para organizar los platos en filas y columnas
                    TableLayoutPanel platosPanel = new TableLayoutPanel
                    {
                        Dock = DockStyle.Top,
                        ColumnCount = 2,
                        AutoSize = true,
                        Margin = new Padding(0),
                        Padding = new Padding(10),
                        Anchor = AnchorStyles.None
                    };

                    for (int i = 0; i < platosPanel.ColumnCount; i++)
                        platosPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                    // Crear los paneles de los productos
                    foreach (var plato in platos)
                    {
                        Panel productoPanel = new Panel
                        {
                            Width = 225, // Aumentar el tamaño del cuadro
                            Height = 225, // Aumentar el tamaño del cuadro
                            Margin = new Padding(40, 20, 40, 20),
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.SaddleBrown
                        };

                        Label lblNombre = new Label
                        {
                            Text = plato.Izena,
                            AutoSize = true,
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            ForeColor = Color.White,
                            Location = new Point(10, 10)
                        };
                        productoPanel.Controls.Add(lblNombre);

                        Label lblPrecio = new Label
                        {
                            Text = $"Precio: {plato.Prezioa:C2}",
                            AutoSize = true,
                            ForeColor = Color.White,
                            Location = new Point(10, 40)
                        };
                        productoPanel.Controls.Add(lblPrecio);

                        Button btnPlus = new Button
                        {
                            Text = "+",
                            Width = 50,
                            Height = 40,
                            Location = new Point(10, 70)
                        };
                        productoPanel.Controls.Add(btnPlus);

                        Button btnMinus = new Button
                        {
                            Text = "-",
                            Width = 50,
                            Height = 40,
                            Location = new Point(70, 70)
                        };
                        productoPanel.Controls.Add(btnMinus);

                        Label lblCantidad = new Label
                        {
                            Text = "0",
                            Width = 50,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Location = new Point(130, 70),
                            ForeColor = Color.White
                        };
                        productoPanel.Controls.Add(lblCantidad);

                        btnPlus.Click += (s, e) =>
                        {
                            int cantidad = int.Parse(lblCantidad.Text);
                            cantidad++;
                            lblCantidad.Text = cantidad.ToString();

                            if (!resumen.ContainsKey(plato.Izena))
                                resumen[plato.Izena] = (0, plato.Prezioa);

                            resumen[plato.Izena] = (cantidad, plato.Prezioa);
                        };

                        btnMinus.Click += (s, e) =>
                        {
                            int cantidad = int.Parse(lblCantidad.Text);
                            if (cantidad > 0)
                            {
                                cantidad--;
                                lblCantidad.Text = cantidad.ToString();

                                if (resumen.ContainsKey(plato.Izena))
                                    resumen[plato.Izena] = (cantidad, plato.Prezioa);
                            }
                        };

                        platosPanel.Controls.Add(productoPanel);
                    }

                    // Panel de botones inferior
                    FlowLayoutPanel botonesPanel = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Bottom,
                        FlowDirection = FlowDirection.LeftToRight,
                        AutoSize = true,
                        Padding = new Padding(0, 40, 0, 20), // Aumentar margen superior para bajar los botones
                        BackColor = Color.BurlyWood,
                        Anchor = AnchorStyles.None
                    };

                    Button btnGuardar = new Button
                    {
                        Text = "Guardar Pedido",
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
                        Text = "Ver Resumen",
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
                        Text = "Desactivar Pedidos",
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
                    btnAtzera.Click += (s, e) => { this.Close(); };

                    botonesPanel.Controls.AddRange(new Control[] { btnGuardar, btnResumen, btnBorrar, btnAtzera });

                    mainPanel.Controls.Add(platosPanel);
                    mainPanel.Controls.Add(botonesPanel);

                    tabPage.Controls.Add(mainPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los platos de la categoría {kategoria}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarPedidosGuardados()
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    var lastEskaera = session.QueryOver<Eskaera>()
                                              .Where(e => e.MesaId == mesaId && e.Activo == true)
                                              .OrderBy(e => e.EskaeraZenb).Desc
                                              .Take(1)
                                              .SingleOrDefault();

                    ultimoEskaeraZenb = lastEskaera?.EskaeraZenb ?? 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pedidos guardados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerNuevoEskaeraZenb(ISession session)
        {
            var lastEskaera = session.QueryOver<Eskaera>()
                                     .Where(e => e.Activo == true)
                                     .OrderBy(e => e.EskaeraZenb).Desc
                                     .Take(1)
                                     .SingleOrDefault();

            return (lastEskaera?.EskaeraZenb ?? 0) + 1;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarEskaera(resumen);
        }

        private void GuardarEskaera(Dictionary<string, (int cantidad, float precio)> resumen)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    if (ultimoEskaeraZenb == 0)
                    {
                        ultimoEskaeraZenb = ObtenerNuevoEskaeraZenb(session);
                    }

                    foreach (var item in resumen)
                    {
                        var nombreProducto = item.Key;
                        var cantidad = item.Value.cantidad;
                        var precio = item.Value.precio;

                        for (int i = 0; i < cantidad; i++)
                        {
                            Eskaera nuevaEskaera = new Eskaera
                            {
                                EskaeraZenb = ultimoEskaeraZenb,
                                Izena = nombreProducto,
                                Prezioa = precio,
                                MesaId = mesaId,
                                Activo = true
                            };

                            session.Save(nuevaEskaera);
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Pedido guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var pedidosParaActualizar = session.QueryOver<Eskaera>()
                                                        .Where(e => e.MesaId == mesaId && e.EskaeraZenb == ultimoEskaeraZenb)
                                                        .List();

                    foreach (var pedido in pedidosParaActualizar)
                    {
                        pedido.Activo = false;
                        session.Update(pedido);
                    }

                    transaction.Commit();
                    ultimoEskaeraZenb = 0;
                    resumen.Clear();
                    MessageBox.Show("Pedidos desactivados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desactivar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnResumen_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    var eskaeras = session.QueryOver<Eskaera>()
                                          .Where(e => e.MesaId == mesaId && e.EskaeraZenb == ultimoEskaeraZenb && e.Activo == true)
                                          .List();

                    if (!eskaeras.Any())
                    {
                        MessageBox.Show("No hay pedidos actuales para esta mesa.", "Resumen Vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string resumenTexto = "Resumen de Pedido:\n\n";
                    foreach (var eskaera in eskaeras)
                    {
                        resumenTexto += $"- {eskaera.Izena}: {eskaera.Prezioa:C2}\n";
                    }

                    MessageBox.Show(resumenTexto, "Resumen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar el resumen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
