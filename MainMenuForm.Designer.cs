using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2taldea
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            BackgroundImage = Image.FromFile("background.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            btnProduktuak=new Button();
            btnKomandak=new Button();
            btnEskaerak=new Button();
            btnLogout=new Button();
            labelIzena=new Label();
            labelMenua=new Label();
            pictureBoxLogo=new PictureBox();
            buttonTxat=new Button();
            btnEguraldia = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // btnProduktuak
            // 
            btnProduktuak.BackColor=Color.SaddleBrown;
            btnProduktuak.FlatStyle=FlatStyle.Flat;
            btnProduktuak.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnProduktuak.ForeColor=Color.White;
            btnProduktuak.Location=new Point(550, 450);
            btnProduktuak.Name="btnProduktuak";
            btnProduktuak.Size=new Size(175, 188);
            btnProduktuak.TabIndex=0;
            btnProduktuak.Text="Produktuak";
            btnProduktuak.UseVisualStyleBackColor=false;
            btnProduktuak.Click+=btnProduktuak_Click;
            // 
            // btnKomandak
            // 
            btnKomandak.BackColor=Color.SaddleBrown;
            btnKomandak.FlatStyle=FlatStyle.Flat;
            btnKomandak.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnKomandak.ForeColor=Color.White;
            btnKomandak.Location=new Point(873, 450);
            btnKomandak.Name="btnKomandak";
            btnKomandak.Size=new Size(175, 188);
            btnKomandak.TabIndex=1;
            btnKomandak.Text="Komandak";
            btnKomandak.UseVisualStyleBackColor=false;
            btnKomandak.Click+=btnKomandak_Click;
            // 
            // btnEskaerak
            // 
            btnEskaerak.BackColor=Color.SaddleBrown;
            btnEskaerak.FlatStyle=FlatStyle.Flat;
            btnEskaerak.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnEskaerak.ForeColor=Color.White;
            btnEskaerak.Location=new Point(1196, 450);
            btnEskaerak.Name="btnEskaerak";
            btnEskaerak.Size=new Size(175, 188);
            btnEskaerak.TabIndex=2;
            btnEskaerak.Text="Eskaerak";
            btnEskaerak.UseVisualStyleBackColor=false;
            btnEskaerak.Click+=btnEskaerak_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor=Color.Red;
            btnLogout.FlatStyle=FlatStyle.Flat;
            btnLogout.Font=new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.ForeColor=Color.White;
            btnLogout.Location=new Point(1700, 900);
            btnLogout.Name="btnLogout";
            btnLogout.Size=new Size(131, 47);
            btnLogout.TabIndex=3;
            btnLogout.Text="Saioa itxi";
            btnLogout.UseVisualStyleBackColor=false;
            btnLogout.Click+=btnLogout_Click;
            // 
            // labelIzena
            // 
            labelIzena.AutoSize=true;
            labelIzena.BackColor=Color.Transparent;
            labelIzena.Font=new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelIzena.Location=new Point(1716, 50);
            labelIzena.Name="labelIzena";
            labelIzena.Size=new Size(75, 32);
            labelIzena.TabIndex=4;
            labelIzena.Text="Izena";
            labelIzena.TextAlign=ContentAlignment.TopCenter;
            labelIzena.Click+=labelIzena_Click;
            // 
            // labelMenua
            // 
            labelMenua.AutoSize=true;
            labelMenua.BackColor=Color.Transparent;
            labelMenua.Font=new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelMenua.ForeColor=Color.LightSlateGray;
            labelMenua.Location=new Point(894, 50);
            labelMenua.Name="labelMenua";
            labelMenua.Size=new Size(123, 45);
            labelMenua.TabIndex=5;
            labelMenua.Text="Menua";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor=Color.Transparent;
            pictureBoxLogo.Image=Properties.Resources.thebulls_logo;
            pictureBoxLogo.Location=new Point(50, 30);
            pictureBoxLogo.Name="pictureBoxLogo";
            pictureBoxLogo.Size=new Size(250, 200);
            pictureBoxLogo.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex=6;
            pictureBoxLogo.TabStop=false;
            // 
            // buttonTxat
            // 
            buttonTxat.BackColor=Color.SaddleBrown;
            buttonTxat.FlatStyle=FlatStyle.Flat;
            buttonTxat.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            buttonTxat.ForeColor=Color.White;
            buttonTxat.Location=new Point(796, 744);
            buttonTxat.Name="buttonTxat";
            buttonTxat.Size=new Size(332, 188);
            buttonTxat.TabIndex=7;
            buttonTxat.Text="Txata";
            buttonTxat.UseVisualStyleBackColor=false;
            buttonTxat.Click+=buttonTxat_Click;
            // 
            // btnEguraldia
            // 
            btnEguraldia.BackColor = Color.SaddleBrown;
            btnEguraldia.FlatStyle = FlatStyle.Flat;
            btnEguraldia.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnEguraldia.ForeColor = Color.White;
            btnEguraldia.Location = new Point(100, 900); // Ubicación en la parte inferior izquierda
            btnEguraldia.Name = "btnEguraldia";
            btnEguraldia.Size = new Size(175, 60); // Tamaño ajustado para mejor visualización
            btnEguraldia.TabIndex = 8; // Índice único
            btnEguraldia.Text = "Eguraldia";
            btnEguraldia.UseVisualStyleBackColor = false;
            btnEguraldia.Click += btnEguraldia_Click; // Asociar el evento Click
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.BurlyWood;
            BackgroundImageLayout=ImageLayout.Stretch;
            ClientSize=new Size(1920, 1080);
            Controls.Add(buttonTxat);
            Controls.Add(pictureBoxLogo);
            Controls.Add(labelMenua);
            Controls.Add(labelIzena);
            Controls.Add(btnLogout);
            Controls.Add(btnEskaerak);
            Controls.Add(btnKomandak);
            Controls.Add(btnProduktuak);
            Controls.Add(btnEguraldia);
            FormBorderStyle=FormBorderStyle.None;
            Name="MainMenuForm";
            Text="Main Menu";
            WindowState=FormWindowState.Maximized;
            Load+=MainMenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        
        }

        #endregion

        private Button btnProduktuak;
        private Button btnKomandak;
        private Button btnEskaerak;
        private Button btnLogout;
        private Label labelIzena;
        private Label labelMenua;
        private PictureBox pictureBoxLogo;
        private Button buttonTxat;
        private Button btnEguraldia;
    }
}
