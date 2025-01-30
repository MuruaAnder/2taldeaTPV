namespace _2taldea
{
    partial class EskaerakForm2 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelIzena;
        private PictureBox pictureBoxLogo;
        private Button btnAtzera;
        private Label labelMahaiak;

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
            labelIzena=new Label();
            pictureBoxLogo=new PictureBox();
            btnAtzera=new Button();
            labelMahaiak=new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // labelIzena
            // 
            labelIzena.AutoSize=true;
            labelIzena.Font=new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelIzena.Location=new Point(1716, 50);
            labelIzena.Name="labelIzena";
            labelIzena.Size=new Size(75, 32);
            labelIzena.TabIndex=1;
            labelIzena.Text="Izena";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image=Properties.Resources.logo;
            pictureBoxLogo.Location=new Point(50, 30);
            pictureBoxLogo.Name="pictureBoxLogo";
            pictureBoxLogo.Size=new Size(250, 200);
            pictureBoxLogo.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex=2;
            pictureBoxLogo.TabStop=false;
            // 
            // btnAtzera
            // 
            btnAtzera.BackColor=Color.Red;
            btnAtzera.FlatStyle=FlatStyle.Flat;
            btnAtzera.Font=new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAtzera.ForeColor=Color.White;
            btnAtzera.Location=new Point(1700, 900);
            btnAtzera.Name="btnAtzera";
            btnAtzera.Size=new Size(131, 47);
            btnAtzera.TabIndex=3;
            btnAtzera.Text="Atzera";
            btnAtzera.UseVisualStyleBackColor=false;
            btnAtzera.Click+=BtnAtzera_Click;
            // 
            // labelMahaiak
            // 
            labelMahaiak.AutoSize=true;
            labelMahaiak.Font=new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelMahaiak.ForeColor=Color.LightSlateGray;
            labelMahaiak.Location=new Point(894, 50);
            labelMahaiak.Name="labelMahaiak";
            labelMahaiak.Size=new Size(151, 45);
            labelMahaiak.TabIndex=5;
            labelMahaiak.Text="Eskaerak";
            // 
            // EskaerakForm2
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.BurlyWood;
            ClientSize=new Size(1835, 984);
            Controls.Add(labelMahaiak);
            Controls.Add(labelIzena);
            Controls.Add(pictureBoxLogo);
            Controls.Add(btnAtzera);
            FormBorderStyle=FormBorderStyle.None;
            Name="EskaerakForm2";
            Text="Eskaerak";
            WindowState=FormWindowState.Maximized;
            Load+=EskaerakForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
