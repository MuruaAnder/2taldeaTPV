namespace _2taldea
{
    partial class Form1
    {
        private TextBox txtName;
        private TextBox txtPassword;
        private Button btnLogin;
        private PictureBox pictureBoxLogo;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtName=new TextBox();
            txtPassword=new TextBox();
            btnLogin=new Button();
            pictureBoxLogo=new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location=new Point(244, 302);
            txtName.Name="txtName";
            txtName.PlaceholderText="Izena";
            txtName.Size=new Size(300, 23);
            txtName.TabIndex=1;
            // 
            // txtPassword
            // 
            txtPassword.Location=new Point(244, 354);
            txtPassword.Name="txtPassword";
            txtPassword.PlaceholderText="Pasahitza";
            txtPassword.Size=new Size(300, 23);
            txtPassword.TabIndex=2;
            txtPassword.UseSystemPasswordChar=true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor=Color.FromArgb(105, 71, 44);
            btnLogin.FlatStyle=FlatStyle.Popup;
            btnLogin.ForeColor=SystemColors.ButtonHighlight;
            btnLogin.Location=new Point(244, 406);
            btnLogin.Name="btnLogin";
            btnLogin.Size=new Size(300, 40);
            btnLogin.TabIndex=3;
            btnLogin.Text="Saioa hasi";
            btnLogin.UseVisualStyleBackColor=false;
            btnLogin.Click+=btnLogin_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image=(Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location=new Point(244, 46);
            pictureBoxLogo.Name="pictureBoxLogo";
            pictureBoxLogo.Size=new Size(183, 148);
            pictureBoxLogo.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex=0;
            pictureBoxLogo.TabStop=false;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.FromArgb(191, 171, 146);
            ClientSize=new Size(784, 561);
            Controls.Add(pictureBoxLogo);
            Controls.Add(txtName);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Name="Form1";
            Text="Login - Restaurante";
            WindowState=FormWindowState.Maximized;
            Load+=Form1_Load;
            Resize+=Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterControls(); // Centra los controles al inicio
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterControls(); // Reposiciona si la ventana cambia de tamaño
        }

        private void CenterControls()
        {
            int centerX = ClientSize.Width / 2; // Centro horizontal
            int centerY = ClientSize.Height / 2; // Centro vertical

            // Centrar PictureBox arriba
            pictureBoxLogo.Location = new Point(centerX - pictureBoxLogo.Width / 2, centerY - 200);

            // Centrar TextBox "Izena"
            txtName.Location = new Point(centerX - txtName.Width / 2, centerY - 40);

            // Centrar TextBox "Pasahitza"
            txtPassword.Location = new Point(centerX - txtPassword.Width / 2, centerY + 10);

            // Centrar Botón "Saioa hasi"
            btnLogin.Location = new Point(centerX - btnLogin.Width / 2, centerY + 60);
        }


    }
}
