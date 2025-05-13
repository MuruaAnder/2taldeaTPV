namespace _2taldea
{
    partial class PlateraAddForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtIzena;
        private TextBox txtKategoria;
        private TextBox txtKantitatea;
        private TextBox txtPrezioa;
        private Button btnGorde;
        private Button btnUtzi;
        private Label labelTitle;
        private Label labelIzena;
        private Label labelKategoria;
        private Label labelKantitatea;
        private Label labelPrezioa;
        private PictureBox pictureBox;
        private ComboBox cmbKategoria;
        private ListBox lstProduktuak;
        private Label labelProduktuak;
        private TextBox txtProduktuKantitatea;
        private Label labelProduktuKantitatea;
        private Button btnGehituProduktua;
        private DataGridView dgvPlateraProduktuak;
        private Label labelPlateraProduktuak;
        private Button btnSeleccionarImagen;
        private PictureBox pictureBoxPreview;

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
            txtIzena=new TextBox();
            cmbKategoria=new ComboBox();
            txtKantitatea=new TextBox();
            txtPrezioa=new TextBox();
            btnGorde=new Button();
            btnUtzi=new Button();
            labelTitle=new Label();
            labelIzena=new Label();
            labelKategoria=new Label();
            labelKantitatea=new Label();
            labelPrezioa=new Label();
            pictureBox=new PictureBox();
            lstProduktuak=new ListBox();
            labelProduktuak=new Label();
            txtProduktuKantitatea=new TextBox();
            labelProduktuKantitatea=new Label();
            btnGehituProduktua=new Button();
            dgvPlateraProduktuak=new DataGridView();
            labelPlateraProduktuak=new Label();
            btnSeleccionarImagen=new Button();
            pictureBoxPreview=new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPlateraProduktuak).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            SuspendLayout();
            // 
            // txtIzena
            // 
            txtIzena.BackColor=Color.White;
            txtIzena.ForeColor=Color.Black;
            txtIzena.Location=new Point(850, 400);
            txtIzena.Name="txtIzena";
            txtIzena.Size=new Size(350, 23);
            txtIzena.TabIndex=0;
            // 
            // cmbKategoria
            // 
            cmbKategoria.BackColor=Color.White;
            cmbKategoria.ForeColor=Color.Black;
            cmbKategoria.Items.AddRange(new object[] { "Edaria", "Lehenengo platera", "Bigarren platera", "Postrea" });
            cmbKategoria.Location=new Point(850, 450);
            cmbKategoria.Name="cmbKategoria";
            cmbKategoria.Size=new Size(350, 23);
            cmbKategoria.TabIndex=1;
            // 
            // txtKantitatea
            // 
            txtKantitatea.BackColor=Color.White;
            txtKantitatea.ForeColor=Color.Black;
            txtKantitatea.Location=new Point(850, 500);
            txtKantitatea.Name="txtKantitatea";
            txtKantitatea.Size=new Size(350, 23);
            txtKantitatea.TabIndex=2;
            // 
            // txtPrezioa
            // 
            txtPrezioa.BackColor=Color.White;
            txtPrezioa.ForeColor=Color.Black;
            txtPrezioa.Location=new Point(850, 550);
            txtPrezioa.Name="txtPrezioa";
            txtPrezioa.Size=new Size(350, 23);
            txtPrezioa.TabIndex=3;
            txtPrezioa.TextChanged+=txtPrezioa_TextChanged;
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
            btnGorde.TabIndex=7;
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
            btnUtzi.TabIndex=8;
            btnUtzi.Text="Utzi";
            btnUtzi.UseVisualStyleBackColor=false;
            btnUtzi.Click+=btnUtzi_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize=true;
            labelTitle.BackColor=Color.Transparent;
            labelTitle.Font=new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor=Color.Gray;
            labelTitle.Location=new Point(850, 50);
            labelTitle.Name="labelTitle";
            labelTitle.Size=new Size(233, 45);
            labelTitle.TabIndex=7;
            labelTitle.Text="Platera Gehitu";
            // 
            // labelIzena
            // 
            labelIzena.AutoSize=true;
            labelIzena.BackColor=Color.Transparent;
            labelIzena.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelIzena.Location=new Point(600, 400);
            labelIzena.Name="labelIzena";
            labelIzena.Size=new Size(64, 25);
            labelIzena.TabIndex=8;
            labelIzena.Text="Izena:";
            // 
            // labelKategoria
            // 
            labelKategoria.AutoSize=true;
            labelKategoria.BackColor=Color.Transparent;
            labelKategoria.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelKategoria.Location=new Point(600, 450);
            labelKategoria.Name="labelKategoria";
            labelKategoria.Size=new Size(103, 25);
            labelKategoria.TabIndex=9;
            labelKategoria.Text="Kategoria:";
            // 
            // labelKantitatea
            // 
            labelKantitatea.AutoSize=true;
            labelKantitatea.BackColor=Color.Transparent;
            labelKantitatea.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelKantitatea.Location=new Point(600, 500);
            labelKantitatea.Name="labelKantitatea";
            labelKantitatea.Size=new Size(107, 25);
            labelKantitatea.TabIndex=12;
            labelKantitatea.Text="Kantitatea:";
            // 
            // labelPrezioa
            // 
            labelPrezioa.AutoSize=true;
            labelPrezioa.BackColor=Color.Transparent;
            labelPrezioa.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelPrezioa.Location=new Point(600, 550);
            labelPrezioa.Name="labelPrezioa";
            labelPrezioa.Size=new Size(83, 25);
            labelPrezioa.TabIndex=10;
            labelPrezioa.Text="Prezioa:";
            // 
            // pictureBox
            // 
            pictureBox.BackColor=Color.Transparent;
            pictureBox.Image=Properties.Resources.thebulls_logo;
            pictureBox.Location=new Point(50, 30);
            pictureBox.Name="pictureBox";
            pictureBox.Size=new Size(250, 200);
            pictureBox.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex=13;
            pictureBox.TabStop=false;
            // 
            // lstProduktuak
            // 
            lstProduktuak.BackColor=Color.White;
            lstProduktuak.FormattingEnabled=true;
            lstProduktuak.ItemHeight=15;
            lstProduktuak.Location=new Point(200, 400);
            lstProduktuak.Name="lstProduktuak";
            lstProduktuak.Size=new Size(300, 154);
            lstProduktuak.TabIndex=4;
            // 
            // labelProduktuak
            // 
            labelProduktuak.AutoSize=true;
            labelProduktuak.BackColor=Color.Transparent;
            labelProduktuak.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelProduktuak.Location=new Point(200, 370);
            labelProduktuak.Name="labelProduktuak";
            labelProduktuak.Size=new Size(125, 25);
            labelProduktuak.TabIndex=15;
            labelProduktuak.Text="Produktuak:";
            // 
            // txtProduktuKantitatea
            // 
            txtProduktuKantitatea.BackColor=Color.White;
            txtProduktuKantitatea.Location=new Point(200, 608);
            txtProduktuKantitatea.Name="txtProduktuKantitatea";
            txtProduktuKantitatea.Size=new Size(100, 23);
            txtProduktuKantitatea.TabIndex=5;
            // 
            // labelProduktuKantitatea
            // 
            labelProduktuKantitatea.AutoSize=true;
            labelProduktuKantitatea.BackColor=Color.Transparent;
            labelProduktuKantitatea.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelProduktuKantitatea.Location=new Point(200, 568);
            labelProduktuKantitatea.Name="labelProduktuKantitatea";
            labelProduktuKantitatea.Size=new Size(107, 25);
            labelProduktuKantitatea.TabIndex=16;
            labelProduktuKantitatea.Text="Kantitatea:";
            // 
            // btnGehituProduktua
            // 
            btnGehituProduktua.BackColor=Color.SaddleBrown;
            btnGehituProduktua.FlatStyle=FlatStyle.Flat;
            btnGehituProduktua.Font=new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGehituProduktua.ForeColor=Color.White;
            btnGehituProduktua.Location=new Point(320, 599);
            btnGehituProduktua.Name="btnGehituProduktua";
            btnGehituProduktua.Size=new Size(180, 35);
            btnGehituProduktua.TabIndex=6;
            btnGehituProduktua.Text="Gehitu produktua";
            btnGehituProduktua.UseVisualStyleBackColor=false;
            btnGehituProduktua.Click+=btnGehituProduktua_Click;
            // 
            // dgvPlateraProduktuak
            // 
            dgvPlateraProduktuak.BackgroundColor=Color.White;
            dgvPlateraProduktuak.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlateraProduktuak.Location=new Point(1300, 400);
            dgvPlateraProduktuak.Name="dgvPlateraProduktuak";
            dgvPlateraProduktuak.RowTemplate.Height=25;
            dgvPlateraProduktuak.Size=new Size(500, 300);
            dgvPlateraProduktuak.TabIndex=17;
            // 
            // labelPlateraProduktuak
            // 
            labelPlateraProduktuak.AutoSize=true;
            labelPlateraProduktuak.BackColor=Color.Transparent;
            labelPlateraProduktuak.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlateraProduktuak.Location=new Point(1300, 370);
            labelPlateraProduktuak.Name="labelPlateraProduktuak";
            labelPlateraProduktuak.Size=new Size(192, 25);
            labelPlateraProduktuak.TabIndex=18;
            labelPlateraProduktuak.Text="Platera produktuak:";
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.BackColor=Color.SaddleBrown;
            btnSeleccionarImagen.FlatStyle=FlatStyle.Flat;
            btnSeleccionarImagen.Font=new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSeleccionarImagen.ForeColor=Color.White;
            btnSeleccionarImagen.Location=new Point(587, 653);
            btnSeleccionarImagen.Name="btnSeleccionarImagen";
            btnSeleccionarImagen.Size=new Size(200, 35);
            btnSeleccionarImagen.TabIndex=9;
            btnSeleccionarImagen.Text="Argazkia aukeratu";
            btnSeleccionarImagen.UseVisualStyleBackColor=false;
            btnSeleccionarImagen.Click+=btnSeleccionarImagen_Click;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.BackColor=Color.White;
            pictureBoxPreview.BorderStyle=BorderStyle.FixedSingle;
            pictureBoxPreview.Location=new Point(850, 599);
            pictureBoxPreview.Name="pictureBoxPreview";
            pictureBoxPreview.Size=new Size(150, 150);
            pictureBoxPreview.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBoxPreview.TabIndex=19;
            pictureBoxPreview.TabStop=false;
            // 
            // PlateraAddForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.FromArgb(243, 245, 248);
            BackgroundImageLayout=ImageLayout.Stretch;
            ClientSize=new Size(1920, 1061);
            Controls.Add(labelPlateraProduktuak);
            Controls.Add(dgvPlateraProduktuak);
            Controls.Add(btnGehituProduktua);
            Controls.Add(labelProduktuKantitatea);
            Controls.Add(txtProduktuKantitatea);
            Controls.Add(labelProduktuak);
            Controls.Add(lstProduktuak);
            Controls.Add(labelTitle);
            Controls.Add(txtIzena);
            Controls.Add(cmbKategoria);
            Controls.Add(txtKantitatea);
            Controls.Add(txtPrezioa);
            Controls.Add(labelIzena);
            Controls.Add(labelKategoria);
            Controls.Add(labelKantitatea);
            Controls.Add(labelPrezioa);
            Controls.Add(btnGorde);
            Controls.Add(btnUtzi);
            Controls.Add(pictureBox);
            Controls.Add(btnSeleccionarImagen);
            Controls.Add(pictureBoxPreview);
            Name="PlateraAddForm";
            Text="Platera Gehitu";
            WindowState=FormWindowState.Maximized;
            Load+=PlateraAddForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPlateraProduktuak).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}