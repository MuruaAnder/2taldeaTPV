namespace _2taldea
{
    partial class ProduktuakForm2 : Form
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
            labelIzena=new Label();
            labelProduktuak=new Label();
            btnAtzera=new Button();
            btnFiltratu=new Button();
            btnEditar=new Button();
            btnAdd=new Button();
            dataGridViewProduktuak=new DataGridView();
            pictureBoxLogo=new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduktuak).BeginInit();
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
            labelIzena.TabIndex=4;
            labelIzena.Text="Izena";
            // 
            // labelProduktuak
            // 
            labelProduktuak.AutoSize=true;
            labelProduktuak.Font=new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelProduktuak.ForeColor=Color.LightSlateGray;
            labelProduktuak.Location=new Point(852, 50);
            labelProduktuak.Name="labelProduktuak";
            labelProduktuak.Size=new Size(196, 45);
            labelProduktuak.TabIndex=5;
            labelProduktuak.Text="Produktuak";
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
            btnAtzera.TabIndex=6;
            btnAtzera.Text="Atzera";
            btnAtzera.UseVisualStyleBackColor=false;
            btnAtzera.Click+=btnAtzera_Click;
            // 
            // btnFiltratu
            // 
            btnFiltratu.BackColor=Color.Blue;
            btnFiltratu.FlatStyle=FlatStyle.Flat;
            btnFiltratu.Font=new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnFiltratu.ForeColor=Color.White;
            btnFiltratu.Location=new Point(1600, 200);
            btnFiltratu.Name="btnFiltratu";
            btnFiltratu.Size=new Size(100, 50);
            btnFiltratu.TabIndex=7;
            btnFiltratu.Text="Filtratu";
            btnFiltratu.UseVisualStyleBackColor=false;
            btnFiltratu.Click+=btnFiltratu_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor=Color.Gray;
            btnEditar.FlatStyle=FlatStyle.Flat;
            btnEditar.Font=new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.ForeColor=Color.White;
            btnEditar.Location=new Point(1710, 200);
            btnEditar.Name="btnEditar";
            btnEditar.Size=new Size(100, 50);
            btnEditar.TabIndex=8;
            btnEditar.Text="Editar";
            btnEditar.UseVisualStyleBackColor=false;
            btnEditar.Click+=btnEditar_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor=Color.Gray;
            btnAdd.FlatStyle=FlatStyle.Flat;
            btnAdd.Font=new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor=Color.White;
            btnAdd.Location=new Point(1490, 200);
            btnAdd.Name="btnAdd";
            btnAdd.Size=new Size(100, 50);
            btnAdd.TabIndex=10;
            btnAdd.Text="Gehitu";
            btnAdd.UseVisualStyleBackColor=false;
            btnAdd.Click+=btnAdd_Click;
            // 
            // dataGridViewProduktuak
            // 
            dataGridViewProduktuak.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduktuak.Location=new Point(200, 300);
            dataGridViewProduktuak.Name="dataGridViewProduktuak";
            dataGridViewProduktuak.ReadOnly=true;
            dataGridViewProduktuak.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProduktuak.Size=new Size(1300, 600);
            dataGridViewProduktuak.TabIndex=9;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location=new Point(50, 30);
            pictureBoxLogo.Name="pictureBoxLogo";
            pictureBoxLogo.Size=new Size(250, 200);
            pictureBoxLogo.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex=10;
            pictureBoxLogo.TabStop=false;
            pictureBoxLogo.Click+=pictureBoxLogo_Click;
            // 
            // ProduktuakForm2
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.BurlyWood;
            ClientSize=new Size(1835, 584);
            Controls.Add(pictureBoxLogo);
            Controls.Add(dataGridViewProduktuak);
            Controls.Add(btnAdd);
            Controls.Add(btnEditar);
            Controls.Add(btnFiltratu);
            Controls.Add(btnAtzera);
            Controls.Add(labelProduktuak);
            Controls.Add(labelIzena);
            FormBorderStyle=FormBorderStyle.None;
            Name="ProduktuakForm2";
            Text="Produktuak";
            WindowState=FormWindowState.Maximized;
            Load+=ProduktuakForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduktuak).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelIzena;
        private Label labelProduktuak;
        private Button btnAtzera;
        private Button btnFiltratu;
        private Button btnEditar;
        private Button btnAdd;
        private DataGridView dataGridViewProduktuak;
        private PictureBox pictureBoxLogo;
    }
}





