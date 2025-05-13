namespace _2taldea
{
    partial class Eguraldia
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelNombreUsuario;
        private Label labelLaburpena;
        private Panel panelEstadoCielo;
        private Panel panelTemperatura;
        private Panel panelHumedad;
        private Button btnAtzera;
        private PictureBox pictureBoxLogo;
        private ComboBox cmbDias;

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
            BackgroundImage = Image.FromFile("background.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            labelNombreUsuario=new Label();
            labelLaburpena=new Label();
            panelEstadoCielo=new Panel();
            panelTemperatura=new Panel();
            panelHumedad=new Panel();
            btnAtzera=new Button();
            pictureBoxLogo=new PictureBox();
            cmbDias=new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // labelNombreUsuario
            // 
            labelNombreUsuario.AutoSize=true;
            labelNombreUsuario.BackColor=Color.Transparent;
            labelNombreUsuario.Font=new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelNombreUsuario.Location=new Point(1716, 50);
            labelNombreUsuario.Name="labelNombreUsuario";
            labelNombreUsuario.Size=new Size(75, 32);
            labelNombreUsuario.TabIndex=1;
            labelNombreUsuario.Text="Izena";
            // 
            // labelLaburpena
            // 
            labelLaburpena.AutoSize=true;
            labelLaburpena.BackColor=Color.Transparent;
            labelLaburpena.Font=new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelLaburpena.ForeColor=Color.LightSlateGray;
            labelLaburpena.Location=new Point(894, 50);
            labelLaburpena.Name="labelLaburpena";
            labelLaburpena.Size=new Size(161, 45);
            labelLaburpena.TabIndex=2;
            labelLaburpena.Text="Eguraldia";
            // 
            // panelEstadoCielo
            // 
            panelEstadoCielo.BackColor=Color.SaddleBrown;
            panelEstadoCielo.BorderStyle=BorderStyle.FixedSingle;
            panelEstadoCielo.ForeColor=Color.SaddleBrown;
            panelEstadoCielo.Location=new Point(272, 450);
            panelEstadoCielo.Name="panelEstadoCielo";
            panelEstadoCielo.Size=new Size(300, 200);
            panelEstadoCielo.TabIndex=4;
            // 
            // panelTemperatura
            // 
            panelTemperatura.BackColor=Color.SaddleBrown;
            panelTemperatura.BorderStyle=BorderStyle.FixedSingle;
            panelTemperatura.ForeColor=Color.SaddleBrown;
            panelTemperatura.Location=new Point(622, 450);
            panelTemperatura.Name="panelTemperatura";
            panelTemperatura.Size=new Size(300, 200);
            panelTemperatura.TabIndex=5;
            // 
            // panelHumedad
            // 
            panelHumedad.BackColor=Color.SaddleBrown;
            panelHumedad.BorderStyle=BorderStyle.FixedSingle;
            panelHumedad.ForeColor=Color.SaddleBrown;
            panelHumedad.Location=new Point(972, 450);
            panelHumedad.Name="panelHumedad";
            panelHumedad.Size=new Size(300, 200);
            panelHumedad.TabIndex=6;
            // 
            // btnAtzera
            // 
            btnAtzera.BackColor=Color.Red;
            btnAtzera.FlatStyle=FlatStyle.Flat;
            btnAtzera.Font=new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAtzera.ForeColor=Color.White;
            btnAtzera.Location=new Point(1700, 900);
            btnAtzera.Name="btnAtzera";
            btnAtzera.Size=new Size(131, 47);
            btnAtzera.TabIndex=5;
            btnAtzera.Text="Atzera";
            btnAtzera.UseVisualStyleBackColor=false;
            btnAtzera.Click+=BtnAtzera_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor=Color.Transparent;
            pictureBoxLogo.Image=Properties.Resources.thebulls_logo;
            pictureBoxLogo.Location=new Point(50, 30);
            pictureBoxLogo.Name="pictureBoxLogo";
            pictureBoxLogo.Size=new Size(250, 200);
            pictureBoxLogo.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex=2;
            pictureBoxLogo.TabStop=false;
            // 
            // cmbDias
            // 
            cmbDias.DropDownStyle=ComboBoxStyle.DropDownList;
            cmbDias.Font=new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDias.FormattingEnabled=true;
            cmbDias.Items.AddRange(new object[] { "Gaur", "Bihar", "Etzi" });
            cmbDias.Location=new Point(472, 200);
            cmbDias.Name="cmbDias";
            cmbDias.Size=new Size(200, 29);
            cmbDias.TabIndex=8;
            cmbDias.SelectedIndexChanged+=CmbDias_SelectedIndexChanged;
            // 
            // Eguraldia
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            BackgroundImageLayout=ImageLayout.Stretch;
            ClientSize=new Size(1644, 1062);
            Controls.Add(cmbDias);
            Controls.Add(pictureBoxLogo);
            Controls.Add(btnAtzera);
            Controls.Add(panelHumedad);
            Controls.Add(panelTemperatura);
            Controls.Add(panelEstadoCielo);
            Controls.Add(labelLaburpena);
            Controls.Add(labelNombreUsuario);
            FormBorderStyle=FormBorderStyle.None;
            Name="Eguraldia";
            Text="Eguraldia";
            WindowState=FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}