using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2taldea
{
    partial class ProduktuaEditForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtIzena;
        private TextBox txtStock;
        private TextBox txtPrezioa;
        private TextBox txtMax;
        private TextBox txtMin;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnEliminar;
        private Label labelIzena;
        private Label labelProduktuak;
        private Label labelStock;
        private Label labelPrezioa;
        private Label labelMax;
        private Label labelMin;
        private PictureBox pictureBoxLogo;

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
            txtIzena=new TextBox();
            txtStock=new TextBox();
            txtPrezioa=new TextBox();
            txtMax=new TextBox();
            txtMin=new TextBox();
            btnGuardar=new Button();
            btnCancelar=new Button();
            btnEliminar=new Button();
            labelIzena=new Label();
            labelProduktuak=new Label();
            labelStock=new Label();
            labelPrezioa=new Label();
            labelMax=new Label();
            labelMin=new Label();
            pictureBoxLogo=new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // txtIzena
            // 
            txtIzena.Location=new Point(850, 400);
            txtIzena.Name="txtIzena";
            txtIzena.Size=new Size(350, 23);
            txtIzena.TabIndex=7;
            // 
            // txtStock
            // 
            txtStock.Location=new Point(850, 450);
            txtStock.Name="txtStock";
            txtStock.Size=new Size(350, 23);
            txtStock.TabIndex=8;
            // 
            // txtPrezioa
            // 
            txtPrezioa.Location=new Point(850, 500);
            txtPrezioa.Name="txtPrezioa";
            txtPrezioa.Size=new Size(350, 23);
            txtPrezioa.TabIndex=9;
            // 
            // txtMax
            // 
            txtMax.Location=new Point(850, 550);
            txtMax.Name="txtMax";
            txtMax.Size=new Size(350, 23);
            txtMax.TabIndex=10;
            // 
            // txtMin
            // 
            txtMin.Location=new Point(850, 600);
            txtMin.Name="txtMin";
            txtMin.Size=new Size(350, 23);
            txtMin.TabIndex=11;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor=Color.SaddleBrown;
            btnGuardar.FlatStyle=FlatStyle.Flat;
            btnGuardar.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor=Color.White;
            btnGuardar.Location=new Point(500, 800);
            btnGuardar.Name="btnGuardar";
            btnGuardar.Size=new Size(150, 50);
            btnGuardar.TabIndex=12;
            btnGuardar.Text="Gorde";
            btnGuardar.UseVisualStyleBackColor=false;
            btnGuardar.Click+=btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor=Color.DarkOrange;
            btnCancelar.FlatStyle=FlatStyle.Flat;
            btnCancelar.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor=Color.White;
            btnCancelar.Location=new Point(850, 800);
            btnCancelar.Name="btnCancelar";
            btnCancelar.Size=new Size(150, 50);
            btnCancelar.TabIndex=13;
            btnCancelar.Text="Utzi";
            btnCancelar.UseVisualStyleBackColor=false;
            btnCancelar.Click+=btnCancelar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor=Color.Red;
            btnEliminar.FlatStyle=FlatStyle.Flat;
            btnEliminar.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor=Color.White;
            btnEliminar.Location=new Point(1200, 800);
            btnEliminar.Name="btnEliminar";
            btnEliminar.Size=new Size(150, 50);
            btnEliminar.TabIndex=14;
            btnEliminar.Text="Ezabatu";
            btnEliminar.UseVisualStyleBackColor=false;
            btnEliminar.Click+=btnEliminar_Click;
            // 
            // labelIzena
            // 
            labelIzena.AutoSize=true;
            labelIzena.Font=new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelIzena.ForeColor=Color.Gray;
            labelIzena.Location=new Point(850, 50);
            labelIzena.Name="labelIzena";
            labelIzena.Size=new Size(361, 45);
            labelIzena.TabIndex=1;
            labelIzena.Text="Produktuaren Editorea";
            // 
            // labelProduktuak
            // 
            labelProduktuak.AutoSize=true;
            labelProduktuak.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelProduktuak.Location=new Point(600, 400);
            labelProduktuak.Name="labelProduktuak";
            labelProduktuak.Size=new Size(64, 25);
            labelProduktuak.TabIndex=2;
            labelProduktuak.Text="Izena:";
            // 
            // labelStock
            // 
            labelStock.AutoSize=true;
            labelStock.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelStock.Location=new Point(600, 450);
            labelStock.Name="labelStock";
            labelStock.Size=new Size(68, 25);
            labelStock.TabIndex=3;
            labelStock.Text="Stock:";
            // 
            // labelPrezioa
            // 
            labelPrezioa.AutoSize=true;
            labelPrezioa.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelPrezioa.Location=new Point(600, 500);
            labelPrezioa.Name="labelPrezioa";
            labelPrezioa.Size=new Size(83, 25);
            labelPrezioa.TabIndex=4;
            labelPrezioa.Text="Prezioa:";
            // 
            // labelMax
            // 
            labelMax.AutoSize=true;
            labelMax.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelMax.Location=new Point(600, 550);
            labelMax.Name="labelMax";
            labelMax.Size=new Size(56, 25);
            labelMax.TabIndex=5;
            labelMax.Text="Max:";
            // 
            // labelMin
            // 
            labelMin.AutoSize=true;
            labelMin.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelMin.Location=new Point(600, 600);
            labelMin.Name="labelMin";
            labelMin.Size=new Size(52, 25);
            labelMin.TabIndex=6;
            labelMin.Text="Min:";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image=Properties.Resources.logo;
            pictureBoxLogo.Location=new Point(50, 30);
            pictureBoxLogo.Name="pictureBoxLogo";
            pictureBoxLogo.Size=new Size(250, 200);
            pictureBoxLogo.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex=0;
            pictureBoxLogo.TabStop=false;
            // 
            // ProduktuaEditForm
            // 
            BackColor=Color.BurlyWood;
            ClientSize=new Size(1920, 1061);
            Controls.Add(pictureBoxLogo);
            Controls.Add(labelIzena);
            Controls.Add(labelProduktuak);
            Controls.Add(labelStock);
            Controls.Add(labelPrezioa);
            Controls.Add(labelMax);
            Controls.Add(labelMin);
            Controls.Add(txtIzena);
            Controls.Add(txtStock);
            Controls.Add(txtPrezioa);
            Controls.Add(txtMax);
            Controls.Add(txtMin);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            FormBorderStyle=FormBorderStyle.FixedDialog;
            Name="ProduktuaEditForm";
            Text="Produktuaren Editorea";
            WindowState=FormWindowState.Maximized;
            Load+=ProduktuaEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
