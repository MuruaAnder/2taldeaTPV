namespace _2taldea
{
    partial class EskaeraResumenForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelMesa;
        private Label labelNombreUsuario;
        private Label labelLaburpena;
        private FlowLayoutPanel flowLayoutPanelPedidos;
        private Label labelPrezioa;
        private Button btnAtzera;
        private Button btnEskaeraSortu;
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
            labelMesa=new Label();
            labelNombreUsuario=new Label();
            labelLaburpena=new Label();
            flowLayoutPanelPedidos=new FlowLayoutPanel();
            labelPrezioa=new Label();
            btnAtzera=new Button();
            btnEskaeraSortu=new Button();
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
            // 
            // labelLaburpena
            // 
            labelLaburpena.AutoSize=true;
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
            // btnEskaeraSortu
            // 
            btnEskaeraSortu.BackColor=Color.Green;
            btnEskaeraSortu.FlatStyle=FlatStyle.Flat;
            btnEskaeraSortu.Font=new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEskaeraSortu.ForeColor=Color.White;
            btnEskaeraSortu.Location=new Point(150, 900);
            btnEskaeraSortu.Name="btnEskaeraSortu";
            btnEskaeraSortu.Size=new Size(150, 50);
            btnEskaeraSortu.TabIndex=6;
            btnEskaeraSortu.Text="Eskaera sortu";
            btnEskaeraSortu.UseVisualStyleBackColor=false;
            btnEskaeraSortu.Click+=btnEskaeraSortu_Click;
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
            // EskaeraResumenForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.BurlyWood;
            ClientSize=new Size(1644, 1062);
            Controls.Add(labelMesa);
            Controls.Add(labelNombreUsuario);
            Controls.Add(labelLaburpena);
            Controls.Add(flowLayoutPanelPedidos);
            Controls.Add(labelPrezioa);
            Controls.Add(btnAtzera);
            Controls.Add(btnEskaeraSortu);
            Controls.Add(pictureBoxLogo);
            FormBorderStyle=FormBorderStyle.None;
            Name="EskaeraResumenForm";
            WindowState=FormWindowState.Maximized;
            Load+=EskaeraResumenForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
