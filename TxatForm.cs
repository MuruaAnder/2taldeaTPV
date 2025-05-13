using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography; //hay que importar este paquete de punto net para poder generar la clave AES
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _2taldea
{
    public partial class TxatForm : Form
    {

        // Constantes para cifrado(mismas que en Java)
        private const string SHA_CRYPT = "SHA256";
        private const string AES_ALGORITHM = "AES";
        private const int IV_LENGTH_ENCRYPT = 12;
        private const int TAG_LENGTH_ENCRYPT = 16;
        private const string LOCAL_PASSPHRASE = "mySecurePassphrase123!";
        private Dictionary<string, string> imagenesRecibidas = new Dictionary<string, string>();// Debe almacenarse de forma segura


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

            // Conectar explícitamente el evento SelectedIndexChanged
            lstMessages.SelectedIndexChanged += lstMessages_SelectedIndexChanged;

            // Configurar el modo de selección del ListBox
            lstMessages.SelectionMode = SelectionMode.One;
        }
        // Genera una clave AES a partir de la frase de paso
        private byte[] GenerarClaveAesDesdePassphrase()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] keyBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(LOCAL_PASSPHRASE));
                return keyBytes;
            }
        }

        // Cifrado del mensaje
        private string Encriptacion(string mensaje)
        {
            try
            {
                // Generar un IV aleatorio
                byte[] iv = new byte[IV_LENGTH_ENCRYPT];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(iv);
                }

                // Generar la clave AES desde la frase de paso
                byte[] keyBytes = GenerarClaveAesDesdePassphrase();

                // Cifrar el mensaje usando AES-GCM
                byte[] mensajeBytes = Encoding.UTF8.GetBytes(mensaje);
                byte[] cipherText;

                using (AesGcm aesGcm = new AesGcm(keyBytes))
                {
                    cipherText = new byte[mensajeBytes.Length];
                    byte[] tag = new byte[TAG_LENGTH_ENCRYPT];

                    aesGcm.Encrypt(iv, mensajeBytes, cipherText, tag);

                    // Combinar IV, texto cifrado y tag
                    byte[] combinedData = new byte[iv.Length + cipherText.Length + tag.Length];
                    Buffer.BlockCopy(iv, 0, combinedData, 0, iv.Length);
                    Buffer.BlockCopy(cipherText, 0, combinedData, iv.Length, cipherText.Length);
                    Buffer.BlockCopy(tag, 0, combinedData, iv.Length + cipherText.Length, tag.Length);

                    return Convert.ToBase64String(combinedData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la encriptación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Descifrado del mensaje
        private string Desencriptacion(string mensajeCifrado)
        {
            try
            {
                // Decodificar el mensaje cifrado de Base64
                byte[] combinedData = Convert.FromBase64String(mensajeCifrado);

                // Extraer IV, texto cifrado y tag
                byte[] iv = new byte[IV_LENGTH_ENCRYPT];
                Buffer.BlockCopy(combinedData, 0, iv, 0, iv.Length);

                int cipherTextLength = combinedData.Length - iv.Length - TAG_LENGTH_ENCRYPT;
                byte[] cipherText = new byte[cipherTextLength];
                Buffer.BlockCopy(combinedData, iv.Length, cipherText, 0, cipherTextLength);

                byte[] tag = new byte[TAG_LENGTH_ENCRYPT];
                Buffer.BlockCopy(combinedData, iv.Length + cipherTextLength, tag, 0, tag.Length);

                // Generar la clave AES desde la frase de paso
                byte[] keyBytes = GenerarClaveAesDesdePassphrase();

                // Descifrar el mensaje
                byte[] plainText = new byte[cipherTextLength];
                using (AesGcm aesGcm = new AesGcm(keyBytes))
                {
                    aesGcm.Decrypt(iv, cipherText, tag, plainText);
                    return Encoding.UTF8.GetString(plainText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la desencriptación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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
                client = new TcpClient("192.168.115.154", 5555);
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
                MessageBox.Show("Error al conectar con el servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    ProcesarMensaje(message);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ProcesarMensaje(string mensaje)
        {
            // Si es un mensaje de imagen
            if (mensaje.StartsWith("IMG_FILE:"))
            {
                string[] partesMensajeImagen = mensaje.Split(new char[] { ':' }, 4);
                if (partesMensajeImagen.Length == 4)
                {
                    string usuario = partesMensajeImagen[1];
                    string archivo = partesMensajeImagen[2];
                    string base64Data = partesMensajeImagen[3];

                    // Guardar la imagen temporalmente
                    string tempPath = Path.GetTempPath();
                    string tempFileName = Path.Combine(tempPath, archivo);

                    try
                    {
                        byte[] imagenBytes = Convert.FromBase64String(base64Data);
                        File.WriteAllBytes(tempFileName, imagenBytes);

                        // Mensaje final para mostrar
                        string mensajeFinal = $"{usuario}: [Imagen recibida: {archivo}] - Haz clic para descargar";

                        // Guardar referencia a la imagen recibida
                        imagenesRecibidas[mensajeFinal] = tempFileName;

                        // Mostrar en la lista de mensajes
                        Invoke(new Action(() => lstMessages.Items.Add(mensajeFinal)));
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                            MessageBox.Show("Error al procesar imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                    }
                }
            }
            else
            {
                // Mensaje de texto normal
                string[] partes = mensaje.Split(new string[] { ": " }, 2, StringSplitOptions.None);
                if (partes.Length == 2)
                {
                    string usuario = partes[0];
                    string mensajeCifrado = partes[1];

                    try
                    {
                        // Desencriptar el mensaje
                        string mensajeOriginal = Desencriptacion(mensajeCifrado);
                        string mensajeCompleto = $"{usuario}: {mensajeOriginal}";

                        // Mostrar el mensaje descifrado
                        Invoke(new Action(() => lstMessages.Items.Add(mensajeCompleto)));
                    }
                    catch (Exception ex)
                    {
                        // Si hay error en el descifrado, mostrar el mensaje tal cual
                        Invoke(new Action(() => lstMessages.Items.Add(mensaje)));
                    }
                }
                else
                {
                    // Si no tiene el formato esperado, mostrar el mensaje tal cual
                    Invoke(new Action(() => lstMessages.Items.Add(mensaje)));
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                try
                {
                    // Cifrar el mensaje antes de enviarlo
                    string mensajeCifrado = Encriptacion(txtMessage.Text);

                    // Enviar el mensaje cifrado al servidor con el nombre de usuario
                    string messageToSend = $"{nombreUsuario}: {mensajeCifrado}";
                    writer.WriteLine(messageToSend);

                    // Mostrar el mensaje original en la lista de mensajes (localmente)
                    lstMessages.Items.Add($"{nombreUsuario}: {txtMessage.Text}");

                    // Limpiar el campo de texto
                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar el mensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para manejar el clic en un mensaje de imagen
        private void lstMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstMessages.SelectedIndex != -1)
                {
                    string selectedMessage = lstMessages.SelectedItem.ToString();
                    Console.WriteLine($"Mensaje seleccionado: {selectedMessage}");

                    // Comprobar si es una imagen recibida
                    if (imagenesRecibidas.ContainsKey(selectedMessage))
                    {
                        string rutaArchivo = imagenesRecibidas[selectedMessage];
                        Console.WriteLine($"Ruta de archivo encontrada: {rutaArchivo}");

                        // Verificar si el archivo existe
                        if (File.Exists(rutaArchivo))
                        {
                            Console.WriteLine("El archivo existe, iniciando descarga...");
                            // Ofrecer descargar la imagen
                            DescargarImagen(rutaArchivo);
                        }
                        else
                        {
                            MessageBox.Show($"El archivo no existe en la ubicación: {rutaArchivo}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No es una imagen para descargar");
                    }

                    // Desseleccionar después de procesar
                    lstMessages.ClearSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la selección: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para descargar la imagen
        private void DescargarImagen(string rutaArchivo)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string nombreArchivo = Path.GetFileName(rutaArchivo);
                saveFileDialog.FileName = nombreArchivo;

                // Configurar filtros según extensión
                string extension = Path.GetExtension(rutaArchivo).ToLower();
                switch (extension)
                {
                    case ".png":
                        saveFileDialog.Filter = "Archivos PNG|*.png";
                        break;
                    case ".jpg":
                    case ".jpeg":
                        saveFileDialog.Filter = "Archivos JPEG|*.jpg";
                        break;
                    case ".gif":
                        saveFileDialog.Filter = "Archivos GIF|*.gif";
                        break;
                    default:
                        saveFileDialog.Filter = "Todas las imágenes|.";
                        break;
                }

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(rutaArchivo, saveFileDialog.FileName, true);
                        MessageBox.Show($"Imagen guardada correctamente en: {saveFileDialog.FileName}", "Imagen guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void TxatForm_Load_1(object sender, EventArgs e)
        {

        }

        private void labelMenua_Click(object sender, EventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSendImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.Title = "Seleccione una imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Leer el archivo y convertirlo a Base64
                        byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                        string base64Data = Convert.ToBase64String(imageBytes);

                        // Preparar el mensaje de imagen
                        string nombreArchivo = Path.GetFileName(openFileDialog.FileName);
                        string mensajeImagen = $"IMG_FILE:{nombreUsuario}:{nombreArchivo}:{base64Data}";

                        // Enviar al servidor
                        writer.WriteLine(mensajeImagen);

                        // Mostrar localmente
                        lstMessages.Items.Add($"{nombreUsuario}: [Imagen enviada: {nombreArchivo}]");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al enviar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}