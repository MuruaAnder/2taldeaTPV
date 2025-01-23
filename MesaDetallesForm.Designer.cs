namespace _2taldea
{
    partial class MesaDetallesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label mesaLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage bebidasTab;
        private System.Windows.Forms.TabPage primerPlatoTab;
        private System.Windows.Forms.TabPage segundoPlatoTab;

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
            this.mesaLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.bebidasTab = new System.Windows.Forms.TabPage();
            this.primerPlatoTab = new System.Windows.Forms.TabPage();
            this.segundoPlatoTab = new System.Windows.Forms.TabPage();

            this.SuspendLayout();

            // 
            // mesaLabel
            // 
            this.mesaLabel.AutoSize = true;
            this.mesaLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mesaLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.mesaLabel.Location = new System.Drawing.Point(900, 10);
            this.mesaLabel.Name = "mesaLabel";
            this.mesaLabel.Size = new System.Drawing.Size(100, 30);
            this.mesaLabel.TabIndex = 0;
            this.mesaLabel.Text = "Mesa: 0";
            this.mesaLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.TabPages.AddRange(new System.Windows.Forms.TabPage[] {
                this.bebidasTab,
                this.primerPlatoTab,
                this.segundoPlatoTab
            });

            // 
            // bebidasTab
            // 
            this.bebidasTab.Text = "Edariak";
            this.bebidasTab.BackColor = System.Drawing.Color.BurlyWood;

            // 
            // primerPlatoTab
            // 
            this.primerPlatoTab.Text = "Lehenengo platera";
            this.primerPlatoTab.BackColor = System.Drawing.Color.BurlyWood;

            // 
            // segundoPlatoTab
            // 
            this.segundoPlatoTab.Text = "Bigarren platera";
            this.segundoPlatoTab.BackColor = System.Drawing.Color.BurlyWood;

            // 
            // MesaDetallesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.mesaLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "MesaDetallesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles de la Mesa";
            this.Load += new System.EventHandler(this.MesaDetallesForm_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
