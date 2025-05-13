namespace _2taldea
{
    partial class EskaeraResumenForm2 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelMesa;
        private Label labelNombreUsuario;
        private Label labelLaburpena;
        private FlowLayoutPanel flowLayoutPanelPedidos;
        private Label labelPrezioa;
        private Button btnAtzera;
        private Button btnEskaeraSortu2;
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
            BackgroundImage = Image.FromFile("background.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            labelMesa=new Label();
            labelNombreUsuario=new Label();
            labelLaburpena=new Label();
            flowLayoutPanelPedidos=new FlowLayoutPanel();
            labelPrezioa=new Label();
            btnAtzera=new Button();
            btnEskaeraSortu2=new Button();
            pictureBoxLogo=new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // labelMesa
            // 
            labelMesa.AutoSize=true;
            labelMesa.Font=new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelMesa.Location=new Point(1685, 50);
            labelMesa.Name="labelMesa";
            labelMesa.Size=new Size(35, 32);
            labelMesa.TabIndex=0;
            labelMesa.Text="1,";
            labelMesa.BackColor=Color.Transparent;

            // 
            // labelNombreUsuario
            // 
            labelNombreUsuario.AutoSize=true;
            labelNombreUsuario.Font=new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelNombreUsuario.Location=new Point(1716, 50);
            labelNombreUsuario.Name="labelNombreUsuario";
            labelNombreUsuario.Size=new Size(75, 32);
            labelNombreUsuario.TabIndex=1;
            labelNombreUsuario.Text="Izena";
            labelNombreUsuario.BackColor=Color.Transparent;

            // 
            // labelLaburpena
            // 
            labelLaburpena.AutoSize=true;
            labelLaburpena.BackColor=Color.Transparent;
            labelLaburpena.Font=new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelLaburpena.ForeColor=Color.LightSlateGray;
            labelLaburpena.Location=new Point(894, 50);
            labelLaburpena.Name="labelLaburpena";
            labelLaburpena.Size=new Size(178, 45);
            labelLaburpena.TabIndex=2;
            labelLaburpena.Text="Laburpena";
            // 
            // flowLayoutPanelPedidos
            // 
            flowLayoutPanelPedidos.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            flowLayoutPanelPedidos.AutoScroll=true;
            flowLayoutPanelPedidos.BackColor=Color.SaddleBrown;
            flowLayoutPanelPedidos.FlowDirection=FlowDirection.TopDown;
            flowLayoutPanelPedidos.Location=new Point(321, 250);
            flowLayoutPanelPedidos.Name="flowLayoutPanelPedidos";
            flowLayoutPanelPedidos.Size=new Size(1028, 562);
            flowLayoutPanelPedidos.TabIndex=3;
            flowLayoutPanelPedidos.WrapContents=false;
            // 
            // labelPrezioa
            // 
            labelPrezioa.AutoSize=true;
            labelPrezioa.BackColor=Color.Transparent;
            labelPrezioa.Font=new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelPrezioa.Location=new Point(894, 900);
            labelPrezioa.Name="labelPrezioa";
            labelPrezioa.Size=new Size(185, 45);
            labelPrezioa.TabIndex=4;
            labelPrezioa.Text="Prezioa: 0€";
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
            // btnEskaeraSortu2
            // 
            btnEskaeraSortu2.BackColor=Color.Gray;
            btnEskaeraSortu2.FlatStyle=FlatStyle.Flat;
            btnEskaeraSortu2.Font=new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEskaeraSortu2.ForeColor=Color.White;
            btnEskaeraSortu2.Location=new Point(150, 900);
            btnEskaeraSortu2.Name="btnEskaeraSortu2";
            btnEskaeraSortu2.Size=new Size(150, 50);
            btnEskaeraSortu2.TabIndex=6;
            btnEskaeraSortu2.Text="Eskaera sortu";
            btnEskaeraSortu2.UseVisualStyleBackColor=false;
            btnEskaeraSortu2.Click+=btnEskaeraSortu2_Click;
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
            // EskaeraResumenForm2
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.BurlyWood;
            BackgroundImageLayout=ImageLayout.Stretch;
            ClientSize=new Size(1644, 1062);
            Controls.Add(labelMesa);
            Controls.Add(labelNombreUsuario);
            Controls.Add(labelLaburpena);
            Controls.Add(flowLayoutPanelPedidos);
            Controls.Add(labelPrezioa);
            Controls.Add(btnAtzera);
            Controls.Add(btnEskaeraSortu2);
            Controls.Add(pictureBoxLogo);
            FormBorderStyle=FormBorderStyle.None;
            Name="EskaeraResumenForm2";
            WindowState=FormWindowState.Maximized;
            Load+=EskaeraResumenForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
         
        }
    }
}
