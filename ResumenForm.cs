﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHibernate;

namespace _2taldea
{
    public partial class ResumenForm : Form
    {
        private IList<Eskaera> pedidos;
        private ISessionFactory sessionFactory;

        public ResumenForm(IList<Eskaera> pedidos)
        {
            InitializeComponent();
            this.pedidos = pedidos;
        }

        private void ResumenForm_Load(object sender, EventArgs e)
        {
            // Crear un DataGridView para mostrar los pedidos
            DataGridView dgvResumen = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true
            };

            // Configurar las columnas
            dgvResumen.Columns.Add("EskaeraZenb", "Número de Pedido");
            dgvResumen.Columns.Add("Izena", "Producto");
            dgvResumen.Columns.Add("Cantidad", "Cantidad");
            dgvResumen.Columns.Add("Precio", "Precio");
            dgvResumen.Columns.Add("Total", "Total");

            // Agregar los datos de los pedidos
            foreach (var pedido in pedidos)
            {
                dgvResumen.Rows.Add(pedido.EskaeraZenb, pedido.Izena, 1, pedido.Prezioa, pedido.Prezioa);
            }

            // Añadir el DataGridView al formulario
            this.Controls.Add(dgvResumen);

            // Crear un botón para borrar el pedido
            Button btnBorrar = new Button
            {
                Text = "Borrar Pedido",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnBorrar.Click += BtnBorrar_Click;
            this.Controls.Add(btnBorrar);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            // Comprobar si hay un pedido seleccionado
            if (MessageBox.Show("¿Estás seguro de que quieres borrar este pedido?", "Borrar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (ISession session = sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        // Obtener el último pedido
                        var ultimoPedido = pedidos.LastOrDefault();
                        if (ultimoPedido != null)
                        {
                            // Eliminar el último pedido
                            session.Delete(ultimoPedido);
                            transaction.Commit();
                            MessageBox.Show("Pedido borrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cerrar el formulario de resumen
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al borrar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void flowLayoutPanelPedidos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

