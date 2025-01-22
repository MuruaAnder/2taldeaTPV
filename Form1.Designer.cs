﻿namespace _2taldea
{
    partial class Form1
    {
        private TextBox txtName;
        private TextBox txtPassword;
        private Button btnLogin;
        private PictureBox pictureBoxLogo;
        private Label lblName;
        private Label lblPassword;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtName=new TextBox();
            txtPassword=new TextBox();
            btnLogin=new Button();
            pictureBoxLogo=new PictureBox();
            lblName=new Label();
            lblPassword=new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location=new Point(284, 310);
            txtName.Name="txtName";
            txtName.PlaceholderText="Izena";
            txtName.Size=new Size(300, 23);
            txtName.TabIndex=1;
            // 
            // txtPassword
            // 
            txtPassword.Location=new Point(284, 370);
            txtPassword.Name="txtPassword";
            txtPassword.PlaceholderText="Pasahitza";
            txtPassword.Size=new Size(300, 23);
            txtPassword.TabIndex=2;
            txtPassword.UseSystemPasswordChar=true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor=Color.SaddleBrown;
            btnLogin.FlatStyle=FlatStyle.Popup;
            btnLogin.ForeColor=SystemColors.ButtonHighlight;
            btnLogin.Location=new Point(284, 420);
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
            pictureBoxLogo.Location=new Point(284, 50);
            pictureBoxLogo.Name="pictureBoxLogo";
            pictureBoxLogo.Size=new Size(250, 200);
            pictureBoxLogo.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex=0;
            pictureBoxLogo.TabStop=false;
            // 
            // lblName
            // 
            lblName.Font=new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblName.Location=new Point(284, 280);
            lblName.Name="lblName";
            lblName.Size=new Size(300, 20);
            lblName.TabIndex=0;
            lblName.Text="Izena:";
            lblName.TextAlign=ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            lblPassword.Font=new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPassword.Location=new Point(284, 340);
            lblPassword.Name="lblPassword";
            lblPassword.Size=new Size(300, 30);
            lblPassword.TabIndex=2;
            lblPassword.Text="Pasahitza:";
            lblPassword.TextAlign=ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.BurlyWood;
            ClientSize=new Size(784, 561);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(pictureBoxLogo);
            Name="Form1";
            Text="Login - Restaurante";
            WindowState=FormWindowState.Maximized;
            Resize+=Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int centerX = (ClientSize.Width - 300) / 2;
            int centerLogoX = (ClientSize.Width - 250) / 2;

            pictureBoxLogo.Location = new Point(centerLogoX, 200);
            lblName.Location = new Point(centerX, 460);
            txtName.Location = new Point(centerX, 490);
            lblPassword.Location = new Point(centerX, 550);
            txtPassword.Location = new Point(centerX, 580);
            btnLogin.Location = new Point(centerX, 660);



        }
    }
}
