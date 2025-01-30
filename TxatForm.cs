using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace _2taldea
{
    public partial class TxatForm : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private Thread listenThread;
        private string nombreUsuario;

        public TxatForm(string nombreUsuario)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario ?? throw new ArgumentNullException(nameof(nombreUsuario));
            this.Load += TxatForm_Load; // Asociar el evento Load
        }

        // Evento Load del formulario
        private void TxatForm_Load(object sender, EventArgs e)
        {
            ConnectToServer(); // Conectar automáticamente al servidor
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("192.168.115.158", 5555);
                NetworkStream stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                listenThread = new Thread(ListenForMessages);
                listenThread.IsBackground = true;
                listenThread.Start();

                txtMessage.Enabled = true;
                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListenForMessages()
        {
            try
            {
                while (true)
                {
                    string message = reader.ReadLine();
                    if (message == null) break;

                    // Mostrar el mensaje en la lista de mensajes
                    Invoke(new Action(() => lstMessages.Items.Add(message)));
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                // Enviar el mensaje al servidor con el nombre de usuario
                string messageToSend = $"{nombreUsuario}: {txtMessage.Text}";
                writer.WriteLine(messageToSend);

                // Mostrar el mensaje en la lista de mensajes (localmente)
                lstMessages.Items.Add(messageToSend);

                // Limpiar el campo de texto
                txtMessage.Clear();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Lógica para cerrar la sesión o volver a la pantalla anterior
            this.Close(); // Por defecto, cerramos la ventana actual
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Cerrar la conexión al servidor al cerrar el formulario
            try
            {
                if (client != null && client.Connected)
                {
                    writer?.Close();
                    reader?.Close();
                    client?.Close();
                }
            }
            catch
            {
                // Ignorar posibles excepciones al cerrar
            }
        }
    }
}
