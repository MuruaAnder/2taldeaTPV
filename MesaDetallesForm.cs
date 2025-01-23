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
            TabPage bebidasTab = new TabPage("Edariak");
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

            // Cargar los datos
            CargarPlatos("Edaria", bebidasTab);
            CargarPlatos("Lehenengo platera", primerPlatoTab);
            CargarPlatos("Bigarren platera", segundoPlatoTab);

            // Cargar los pedidos anteriores
            CargarPedidosGuardados();
        
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
                            RowCount = 2,
                            AutoScroll = true,
                            BackColor = Color.BurlyWood, // Fondo de la pestaña
                            Padding = new Padding(0, 30, 0, 0) // Margen superior para mover todo hacia abajo
                        };

                        // Panel para organizar los platos en 2 filas y 2 columnas, centrados
                        TableLayoutPanel platosPanel = new TableLayoutPanel
                        {
                            Dock = DockStyle.Top,
                            ColumnCount = 2,
                            RowCount = 2,
                            AutoSize = true,
                            AutoScroll = false,
                            Margin = new Padding(0),
                            Padding = new Padding(10),
                            Anchor = AnchorStyles.None
                        };

                        platosPanel.ColumnStyles.Clear();
                        platosPanel.RowStyles.Clear();

                        for (int i = 0; i < platosPanel.ColumnCount; i++)
                            platosPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)); // 50% cada columna

                        for (int i = 0; i < platosPanel.RowCount; i++)
                            platosPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F)); // 50% cada fila

                        // Crear los paneles de los productos
                        foreach (var plato in platos)
                        {
                            Panel productoPanel = new Panel
                            {
                                Width = 175,
                                Height = 175,
                                Margin = new Padding(40, 20, 40, 20), // Más separación horizontal (40 px), vertical queda igual (20 px)
                                BorderStyle = BorderStyle.FixedSingle,
                                BackColor = Color.SaddleBrown // Fondo del producto
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
                                Width = 40,
                                Height = 30,
                                Location = new Point(10, 70)
                            };
                            productoPanel.Controls.Add(btnPlus);

                            Button btnMinus = new Button
                            {
                                Text = "-",
                                Width = 40,
                                Height = 30,
                                Location = new Point(60, 70)
                            };
                            productoPanel.Controls.Add(btnMinus);

                            Label lblCantidad = new Label
                            {
                                Text = "0",
                                Width = 40,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Location = new Point(110, 70),
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


                    // Panel de botones inferior, centrado y más abajo
                    FlowLayoutPanel botonesPanel = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Bottom,
                        FlowDirection = FlowDirection.LeftToRight,
                        AutoSize = true,
                        Padding = new Padding(0, 20, 0, 20), // Margen superior e inferior para mover más abajo
                        BackColor = Color.BurlyWood,
                        Anchor = AnchorStyles.None
                    };

                    Button btnGuardar = new Button
                    {
                        Text = "Guardar Pedido",
                        BackColor = Color.Green,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Width = 150,
                        Height = 40,
                        Margin = new Padding(20, 0, 20, 0) // Espaciado entre botones
                    };
                    btnGuardar.Click += BtnGuardar_Click;

                    Button btnResumen = new Button
                    {
                        Text = "Ver Resumen",
                        BackColor = Color.Blue,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Width = 150,
                        Height = 40,
                        Margin = new Padding(20, 0, 20, 0) // Espaciado entre botones
                    };
                    btnResumen.Click += BtnResumen_Click;

                    Button btnBorrar = new Button
                    {
                        Text = "Desactivar Pedidos",
                        BackColor = Color.Red,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Width = 150,
                        Height = 40,
                        Margin = new Padding(20, 0, 20, 0) // Espaciado entre botones
                    };
                    btnBorrar.Click += BtnBorrar_Click;

                    // Cambiar el orden de los botones en el panel
                    botonesPanel.Controls.AddRange(new Control[] { btnGuardar, btnResumen, btnBorrar });

                    // Añadir los paneles al mainPanel
                    mainPanel.Controls.Add(platosPanel); // Productos arriba
                    mainPanel.Controls.Add(botonesPanel); // Botones abajo

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
