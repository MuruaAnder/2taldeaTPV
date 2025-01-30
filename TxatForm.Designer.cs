namespace _2taldea
{
    partial class TxatForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox lstMessages;
        private TextBox txtMessage;
        private Button btnSend;
        private Button btnLogout;
        private Label labelMenua;
        private PictureBox pictureBoxLogo;

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
            lstMessages=new ListBox();
            txtMessage=new TextBox();
            btnSend=new Button();
            btnLogout=new Button();
            labelMenua=new Label();
            pictureBoxLogo=new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // lstMessages
            // 
            lstMessages.FormattingEnabled=true;
            lstMessages.ItemHeight=15;
            lstMessages.Location=new Point(502, 325);
            lstMessages.Name="lstMessages";
            lstMessages.Size=new Size(900, 349);
            lstMessages.TabIndex=2;
            // 
            // txtMessage
            // 
            txtMessage.Enabled=false;
            txtMessage.Font=new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMessage.Location=new Point(529, 691);
            txtMessage.Name="txtMessage";
            txtMessage.Size=new Size(750, 23);
            txtMessage.TabIndex=3;
            txtMessage.TextChanged+=txtMessage_TextChanged;
            // 
            // btnSend
            // 
            btnSend.BackColor=Color.SaddleBrown;
            btnSend.Enabled=false;
            btnSend.FlatStyle=FlatStyle.Flat;
            btnSend.ForeColor=Color.White;
            btnSend.Location=new Point(1302, 687);
            btnSend.Name="btnSend";
            btnSend.Size=new Size(100, 30);
            btnSend.TabIndex=4;
            btnSend.Text="Bidali";
            btnSend.UseVisualStyleBackColor=false;
            btnSend.Click+=btnSend_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor=Color.Red;
            btnLogout.FlatStyle=FlatStyle.Flat;
            btnLogout.Font=new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.ForeColor=Color.White;
            btnLogout.Location=new Point(1700, 900);
            btnLogout.Name="btnLogout";
            btnLogout.Size=new Size(131, 47);
            btnLogout.TabIndex=5;
            btnLogout.Text="Atzera";
            btnLogout.UseVisualStyleBackColor=false;
            btnLogout.Click+=btnLogout_Click;
            // 
            // labelMenua
            // 
            labelMenua.AutoSize=true;
            labelMenua.Font=new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelMenua.ForeColor=Color.LightSlateGray;
            labelMenua.Location=new Point(894, 50);
            labelMenua.Name="labelMenua";
            labelMenua.Size=new Size(101, 45);
            labelMenua.TabIndex=5;
            labelMenua.Text="Txata";
            labelMenua.Click+=labelMenua_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image=Properties.Resources.logo;
            pictureBoxLogo.Location=new Point(50, 30);
            pictureBoxLogo.Name="pictureBoxLogo";
            pictureBoxLogo.Size=new Size(250, 200);
            pictureBoxLogo.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex=6;
            pictureBoxLogo.TabStop=false;
            // 
            // TxatForm
            // 
            BackColor=Color.BurlyWood;
            ClientSize=new Size(1920, 1061);
            Controls.Add(lstMessages);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(btnLogout);
            Controls.Add(labelMenua);
            Controls.Add(pictureBoxLogo);
            Name="TxatForm";
            Text="Chat Client";
            WindowState=FormWindowState.Maximized;
            Load+=TxatForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}