namespace _2taldea
{
    partial class MesaDetallesForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label mesaLabel;
        private TabControl tabControl;
        private TabPage bebidasTab;
        private TabPage primerPlatoTab;
        private TabPage segundoPlatoTab;

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
            mesaLabel=new Label();
            tabControl=new TabControl();
            bebidasTab=new TabPage();
            primerPlatoTab=new TabPage();
            segundoPlatoTab=new TabPage();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // mesaLabel
            // 
            mesaLabel.Anchor=AnchorStyles.Top|AnchorStyles.Right;
            mesaLabel.AutoSize=true;
            mesaLabel.Font=new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            mesaLabel.ForeColor=Color.DarkSlateGray;
            mesaLabel.Location=new Point(900, 10);
            mesaLabel.Name="mesaLabel";
            mesaLabel.Size=new Size(79, 25);
            mesaLabel.TabIndex=0;
            mesaLabel.Text="Mesa: 0";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(bebidasTab);
            tabControl.Controls.Add(primerPlatoTab);
            tabControl.Controls.Add(segundoPlatoTab);
            tabControl.Dock=DockStyle.Fill;
            tabControl.Location=new Point(0, 0);
            tabControl.Name="tabControl";
            tabControl.SelectedIndex=0;
            tabControl.Size=new Size(1024, 768);
            tabControl.TabIndex=0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // bebidasTab
            // 
            bebidasTab.BackColor=Color.BurlyWood;
            bebidasTab.Location=new Point(4, 24);
            bebidasTab.Name="bebidasTab";
            bebidasTab.Size=new Size(1016, 740);
            bebidasTab.TabIndex=0;
            bebidasTab.Text="Edaria";
            // 
            // primerPlatoTab
            // 
            primerPlatoTab.BackColor=Color.BurlyWood;
            primerPlatoTab.Location=new Point(4, 24);
            primerPlatoTab.Name="primerPlatoTab";
            primerPlatoTab.Size=new Size(1016, 740);
            primerPlatoTab.TabIndex=1;
            primerPlatoTab.Text="Lehenengo platera";
            // 
            // segundoPlatoTab
            // 
            segundoPlatoTab.BackColor=Color.BurlyWood;
            segundoPlatoTab.Location=new Point(4, 24);
            segundoPlatoTab.Name="segundoPlatoTab";
            segundoPlatoTab.Size=new Size(1016, 740);
            segundoPlatoTab.TabIndex=2;
            segundoPlatoTab.Text="Bigarren platera";
            // 
            // MesaDetallesForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1024, 768);
            Controls.Add(tabControl);
            Controls.Add(mesaLabel);
            Name="MesaDetallesForm";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Detalles de la Mesa";
            Load+=MesaDetallesForm_Load;
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
