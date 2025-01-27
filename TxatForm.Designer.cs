namespace _2taldea
{
    partial class TxatForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label labelMenua;
        private System.Windows.Forms.PictureBox pictureBoxLogo;

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
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.labelMenua = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();

            this.SuspendLayout();

            // Configuración de la ventana principal
            this.ClientSize = new System.Drawing.Size(1920, 1080); // Resolución estándar 1080p
            this.BackColor = System.Drawing.Color.BurlyWood; // Fondo burlywood
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized; // Pantalla completa
            this.Name = "TxatForm";
            this.Text = "Chat Client";

            // Centramos horizontalmente
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // labelMenua
            this.labelMenua.AutoSize = true;
            this.labelMenua.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMenua.ForeColor = System.Drawing.Color.LightSlateGray;
            this.labelMenua.Location = new System.Drawing.Point(centerX - 100, 50); // Centrado horizontalmente
            this.labelMenua.Name = "labelMenua";
            this.labelMenua.Size = new System.Drawing.Size(123, 45);
            this.labelMenua.TabIndex = 5;
            this.labelMenua.Text = "Txata";

            // lstMessages
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.Location = new System.Drawing.Point(centerX - 450, centerY - 200); // Centrado con ancho total ajustado
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(900, 400); // Ancho total
            this.lstMessages.TabIndex = 2;

            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(centerX - 350, centerY + 220); // Centrado horizontalmente
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(640, 30); // Espacio amplio para escribir
            this.txtMessage.TabIndex = 3;
            this.txtMessage.Enabled = false;
            this.txtMessage.Font = new System.Drawing.Font("Arial", 10);

            // btnSend
            this.btnSend.Location = new System.Drawing.Point(centerX + 300, centerY + 220); // A la derecha de txtMessage
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 30);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.BackColor = System.Drawing.Color.SaddleBrown; // Color saddleBrown
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Enabled = false;
            this.btnSend.ForeColor = System.Drawing.Color.White; // Texto blanco
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // btnLogout (botón de "Atrás")
            this.btnLogout.BackColor = System.Drawing.Color.Red; // Color rojo
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.Color.White; // Texto blanco
            this.btnLogout.Location = new System.Drawing.Point(1700, 900); // Abajo a la derecha con margen
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(131, 47); // Tamaño
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Atzera"; // Texto del botón
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // pictureBoxLogo
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TxatForm));
            this.pictureBoxLogo.Image = (System.Drawing.Image)resources.GetObject("pictureBoxLogo.Image");
            this.pictureBoxLogo.Location = new System.Drawing.Point(50, 30);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(250, 200);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 6;
            this.pictureBoxLogo.TabStop = false;

            // Agregar controles a la ventana
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.labelMenua);
            this.Controls.Add(this.pictureBoxLogo);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}