namespace _2taldea
{
    partial class ProduktuakFiltratu
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnPrezioa;
        private Button btnStocka;

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
            this.btnPrezioa = new Button();
            this.btnStocka = new Button();
            this.SuspendLayout();

            // 
            // btnPrezioa
            // 
            this.btnPrezioa.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnPrezioa.FlatStyle = FlatStyle.Flat;
            this.btnPrezioa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrezioa.ForeColor = System.Drawing.Color.White;
            this.btnPrezioa.Location = new System.Drawing.Point(50, 50);
            this.btnPrezioa.Name = "btnPrezioa";
            this.btnPrezioa.Size = new System.Drawing.Size(150, 50);
            this.btnPrezioa.TabIndex = 0;
            this.btnPrezioa.Text = "Filtratu Prezioa";
            this.btnPrezioa.UseVisualStyleBackColor = false;
            this.btnPrezioa.Click += new System.EventHandler(this.btnPrezioa_Click);

            // 
            // btnStocka
            // 
            this.btnStocka.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnStocka.FlatStyle = FlatStyle.Flat;
            this.btnStocka.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStocka.ForeColor = System.Drawing.Color.White;
            this.btnStocka.Location = new System.Drawing.Point(50, 120);
            this.btnStocka.Name = "btnStocka";
            this.btnStocka.Size = new System.Drawing.Size(150, 50);
            this.btnStocka.TabIndex = 1;
            this.btnStocka.Text = "Filtratu Stocka";
            this.btnStocka.UseVisualStyleBackColor = false;
            this.btnStocka.Click += new System.EventHandler(this.btnStocka_Click);

            // 
            // ProduktuakFiltratu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.Controls.Add(this.btnPrezioa);
            this.Controls.Add(this.btnStocka);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "ProduktuakFiltratu";
            this.Text = "Filtratu Produktuak";
            this.ResumeLayout(false);
        }
    }
}
