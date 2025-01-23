namespace _2taldea
{
    partial class ProduktuaAddForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtIzena;
        private TextBox txtStock;
        private TextBox txtPrezioa;
        private TextBox txtMax;
        private TextBox txtMin;
        private Button btnGorde;
        private Button btnUtzi;
        private Label labelTitle;
        private Label labelIzena;
        private Label labelStock;
        private Label labelMax;
        private Label labelMin;
        private Label labelPrezioa;
        private PictureBox pictureBox;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProduktuaAddForm));
            txtIzena=new TextBox();
            txtStock=new TextBox();
            txtPrezioa=new TextBox();
            txtMax=new TextBox();
            txtMin=new TextBox();
            btnGorde=new Button();
            btnUtzi=new Button();
            labelTitle=new Label();
            labelIzena=new Label();
            labelStock=new Label();
            labelMax=new Label();
            labelMin=new Label();
            labelPrezioa=new Label();
            pictureBox=new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // txtIzena
            // 
            txtIzena.Location=new Point(850, 400);
            txtIzena.Name="txtIzena";
            txtIzena.Size=new Size(350, 23);
            txtIzena.TabIndex=0;
            // 
            // txtStock
            // 
            txtStock.Location=new Point(850, 450);
            txtStock.Name="txtStock";
            txtStock.Size=new Size(350, 23);
            txtStock.TabIndex=1;
            // 
            // txtPrezioa
            // 
            txtPrezioa.Location=new Point(850, 500);
            txtPrezioa.Name="txtPrezioa";
            txtPrezioa.Size=new Size(350, 23);
            txtPrezioa.TabIndex=2;
            // 
            // txtMax
            // 
            txtMax.Location=new Point(850, 550);
            txtMax.Name="txtMax";
            txtMax.Size=new Size(350, 23);
            txtMax.TabIndex=3;
            // 
            // txtMin
            // 
            txtMin.Location=new Point(850, 600);
            txtMin.Name="txtMin";
            txtMin.Size=new Size(350, 23);
            txtMin.TabIndex=4;
            // 
            // btnGorde
            // 
            btnGorde.BackColor=Color.Green;
            btnGorde.FlatStyle=FlatStyle.Flat;
            btnGorde.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnGorde.ForeColor=Color.White;
            btnGorde.Location=new Point(500, 800);
            btnGorde.Name="btnGorde";
            btnGorde.Size=new Size(150, 50);
            btnGorde.TabIndex=5;
            btnGorde.Text="Gorde";
            btnGorde.UseVisualStyleBackColor=false;
            btnGorde.Click+=btnGorde_Click;
            // 
            // btnUtzi
            // 
            btnUtzi.BackColor=Color.Red;
            btnUtzi.FlatStyle=FlatStyle.Flat;
            btnUtzi.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnUtzi.ForeColor=Color.White;
            btnUtzi.Location=new Point(1300, 800);
            btnUtzi.Name="btnUtzi";
            btnUtzi.Size=new Size(150, 50);
            btnUtzi.TabIndex=6;
            btnUtzi.Text="Utzi";
            btnUtzi.UseVisualStyleBackColor=false;
            btnUtzi.Click+=btnUtzi_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize=true;
            labelTitle.Font=new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor=Color.Gray;
            labelTitle.Location=new Point(850, 50);
            labelTitle.Name="labelTitle";
            labelTitle.Size=new Size(286, 45);
            labelTitle.TabIndex=7;
            labelTitle.Text="Produktua Gehitu";
            // 
            // labelIzena
            // 
            labelIzena.AutoSize=true;
            labelIzena.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelIzena.Location=new Point(600, 400);
            labelIzena.Name="labelIzena";
            labelIzena.Size=new Size(64, 25);
            labelIzena.TabIndex=8;
            labelIzena.Text="Izena:";
            // 
            // labelStock
            // 
            labelStock.AutoSize=true;
            labelStock.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelStock.Location=new Point(600, 450);
            labelStock.Name="labelStock";
            labelStock.Size=new Size(68, 25);
            labelStock.TabIndex=9;
            labelStock.Text="Stock:";
            // 
            // labelMax
            // 
            labelMax.AutoSize=true;
            labelMax.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelMax.Location=new Point(600, 550);
            labelMax.Name="labelMax";
            labelMax.Size=new Size(100, 25);
            labelMax.TabIndex=11;
            labelMax.Text="Maximoa:";
            // 
            // labelMin
            // 
            labelMin.AutoSize=true;
            labelMin.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelMin.Location=new Point(600, 600);
            labelMin.Name="labelMin";
            labelMin.Size=new Size(96, 25);
            labelMin.TabIndex=12;
            labelMin.Text="Minimoa:";
            // 
            // labelPrezioa
            // 
            labelPrezioa.AutoSize=true;
            labelPrezioa.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelPrezioa.Location=new Point(600, 500);
            labelPrezioa.Name="labelPrezioa";
            labelPrezioa.Size=new Size(83, 25);
            labelPrezioa.TabIndex=10;
            labelPrezioa.Text="Prezioa:";
            // 
            // pictureBox
            // 
            pictureBox.Image=(Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location=new Point(50, 30);
            pictureBox.Name="pictureBox";
            pictureBox.Size=new Size(250, 200);
            pictureBox.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex=13;
            pictureBox.TabStop=false;
            // 
            // ProduktuaAddForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.BurlyWood;
            ClientSize=new Size(1920, 1061);
            Controls.Add(labelTitle);
            Controls.Add(labelIzena);
            Controls.Add(txtIzena);
            Controls.Add(labelStock);
            Controls.Add(txtStock);
            Controls.Add(labelPrezioa);
            Controls.Add(txtPrezioa);
            Controls.Add(labelMax);
            Controls.Add(txtMax);
            Controls.Add(labelMin);
            Controls.Add(txtMin);
            Controls.Add(btnGorde);
            Controls.Add(btnUtzi);
            Controls.Add(pictureBox);
            FormBorderStyle=FormBorderStyle.FixedDialog;
            Name="ProduktuaAddForm";
            Text="Produktua Gehitu";
            WindowState=FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}




