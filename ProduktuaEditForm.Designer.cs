using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2taldea
{
    partial class ProduktuaEditForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtIzena;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrezioa;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label labelIzena;
        private System.Windows.Forms.Label labelProduktuak;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelPrezioa;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.PictureBox pictureBoxLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProduktuaEditForm));

            this.txtIzena = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrezioa = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.labelIzena = new System.Windows.Forms.Label();
            this.labelProduktuak = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelPrezioa = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();

            // 
            // txtIzena
            // 
            this.txtIzena.Location = new System.Drawing.Point(850, 400);
            this.txtIzena.Size = new System.Drawing.Size(350, 30);
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(850, 450);
            this.txtStock.Size = new System.Drawing.Size(350, 30);
            // 
            // txtPrezioa
            // 
            this.txtPrezioa.Location = new System.Drawing.Point(850, 500);
            this.txtPrezioa.Size = new System.Drawing.Size(350, 30);
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(850, 550);
            this.txtMax.Size = new System.Drawing.Size(350, 30);
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(850, 600);
            this.txtMin.Size = new System.Drawing.Size(350, 30);
            // 
            // Labels
            // 
            this.labelProduktuak.AutoSize = true;
            this.labelProduktuak.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelProduktuak.Location = new System.Drawing.Point(600, 400);
            this.labelProduktuak.Text = "Izena:";

            this.labelStock.AutoSize = true;
            this.labelStock.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelStock.Location = new System.Drawing.Point(600, 450);
            this.labelStock.Text = "Stock:";

            this.labelPrezioa.AutoSize = true;
            this.labelPrezioa.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelPrezioa.Location = new System.Drawing.Point(600, 500);
            this.labelPrezioa.Text = "Prezioa:";

            this.labelMax.AutoSize = true;
            this.labelMax.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelMax.Location = new System.Drawing.Point(600, 550);
            this.labelMax.Text = "Max:";

            this.labelMin.AutoSize = true;
            this.labelMin.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelMin.Location = new System.Drawing.Point(600, 600);
            this.labelMin.Text = "Min:";

            this.labelIzena.AutoSize = true;
            this.labelIzena.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelIzena.ForeColor = System.Drawing.Color.Gray;
            this.labelIzena.Location = new System.Drawing.Point(850, 50);
            this.labelIzena.Text = "Produktuaren Editorea";

            // 
            // Botones
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(500, 800);
            this.btnGuardar.Size = new System.Drawing.Size(150, 50);
            this.btnGuardar.Text = "Gorde";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(850, 800);
            this.btnCancelar.Size = new System.Drawing.Size(150, 50);
            this.btnCancelar.Text = "Utzi";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(1200, 800);
            this.btnEliminar.Size = new System.Drawing.Size(150, 50);
            this.btnEliminar.Text = "Ezabatu";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = (System.Drawing.Image)resources.GetObject("pictureBoxLogo.Image");
            this.pictureBoxLogo.Location = new System.Drawing.Point(50, 30);
            this.pictureBoxLogo.Size = new System.Drawing.Size(250, 200);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // 
            // ProduktuaEditForm
            // 
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1920, 1061);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelIzena);
            this.Controls.Add(this.labelProduktuak);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.labelPrezioa);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.txtIzena);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrezioa);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProduktuaEditForm";
            this.Text = "Produktuaren Editorea";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
