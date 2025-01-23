namespace _2taldea
{
    partial class ResumenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private FlowLayoutPanel flowLayoutPanelPedidos;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanelPedidos=new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowLayoutPanelPedidos
            // 
            flowLayoutPanelPedidos.Dock=DockStyle.Fill;
            flowLayoutPanelPedidos.Location=new Point(0, 0);
            flowLayoutPanelPedidos.Name="flowLayoutPanelPedidos";
            flowLayoutPanelPedidos.Size=new Size(800, 450);
            flowLayoutPanelPedidos.TabIndex=0;
            flowLayoutPanelPedidos.Paint+=flowLayoutPanelPedidos_Paint;
            // 
            // ResumenForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            Controls.Add(flowLayoutPanelPedidos);
            Name="ResumenForm";
            Text="ResumenForm";
            Load+=ResumenForm_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
