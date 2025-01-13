namespace _2taldea
{
    partial class ProduktuakForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProduktuakForm));
            labelIzena = new Label();
            labelProduktuak = new Label();
            btnAtzera = new Button();
            btnFiltratu = new Button();
            dataGridViewProduktuak = new DataGridView();
            pictureBoxLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduktuak).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // labelIzena
            // 
            labelIzena.AutoSize = true;
            labelIzena.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelIzena.Location = new Point(1600, 50);
            labelIzena.Name = "labelIzena";
            labelIzena.Size = new Size(75, 32);
            labelIzena.TabIndex = 4;
            labelIzena.Text = "Izena";
            labelIzena.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelProduktuak
            // 
            labelProduktuak.AutoSize = true;
            labelProduktuak.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelProduktuak.Location = new Point(800, 50);
            labelProduktuak.Name = "labelProduktuak";
            labelProduktuak.Size = new Size(196, 45);
            labelProduktuak.TabIndex = 5;
            labelProduktuak.Text = "Produktuak";
            labelProduktuak.ForeColor = Color.Gray; // Cambié el color a gris
            // 
            // btnAtzera
            // 
            btnAtzera.BackColor = Color.Red;
            btnAtzera.FlatStyle = FlatStyle.Flat;
            btnAtzera.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAtzera.ForeColor = Color.White;
            btnAtzera.Location = new Point(1700, 900); // Ajuste de posición para mejor alineación
            btnAtzera.Name = "btnAtzera";
            btnAtzera.Size = new Size(131, 47);
            btnAtzera.TabIndex = 6;
            btnAtzera.Text = "Atzera";
            btnAtzera.UseVisualStyleBackColor = false;
            btnAtzera.Click += btnAtzera_Click;
            // 
            // btnFiltratu
            // 
            btnFiltratu.BackColor = Color.SaddleBrown;
            btnFiltratu.FlatStyle = FlatStyle.Flat;
            btnFiltratu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnFiltratu.ForeColor = Color.White;
            btnFiltratu.Location = new Point(1600, 200); // Ajuste para mejor separación visual
            btnFiltratu.Name = "btnFiltratu";
            btnFiltratu.Size = new Size(100, 50);
            btnFiltratu.TabIndex = 7;
            btnFiltratu.Text = "Filtratu";
            btnFiltratu.UseVisualStyleBackColor = false;
            btnFiltratu.Click += btnFiltratu_Click;
            // 
            // dataGridViewProduktuak
            // 
            dataGridViewProduktuak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduktuak.Location = new Point(200, 300);
            dataGridViewProduktuak.Name = "dataGridViewProduktuak";
            dataGridViewProduktuak.Size = new Size(1300, 600); // Ajustado para ocupar espacio más proporcional
            dataGridViewProduktuak.TabIndex = 8;
            dataGridViewProduktuak.ReadOnly = true; // Para evitar ediciones accidentales
            dataGridViewProduktuak.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(50, 30); // Ajustado a la izquierda
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(250, 200); // Haciendo el logo un poco más pequeño
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 9;
            pictureBoxLogo.TabStop = false;
            // 
            // ProduktuakForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BurlyWood;
            ClientSize = new Size(1920, 1080);
            Controls.Add(pictureBoxLogo);
            Controls.Add(dataGridViewProduktuak);
            Controls.Add(btnFiltratu);
            Controls.Add(btnAtzera);
            Controls.Add(labelProduktuak);
            Controls.Add(labelIzena);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProduktuakForm";
            Text = "Produktuak";
            WindowState = FormWindowState.Maximized;
            Load += ProduktuakForm_Load;
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
        private DataGridView dataGridViewProduktuak;
        private PictureBox pictureBoxLogo;
    }
}

