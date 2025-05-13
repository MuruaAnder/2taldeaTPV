using NHibernate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _2taldea
{
    public partial class Eguraldia : Form
    {
        private string nombreUsuario;
        private ISessionFactory sessionFactory;
        private List<XmlNode> dias = new List<XmlNode>();
        private XmlDocument xmlDoc;
        private Panel panelRecomendaciones;

        public Eguraldia(string nombreUsuario, ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario;
            this.sessionFactory = sessionFactory;

            // Crear panel de recomendaciones
            panelRecomendaciones = new Panel
            {
                BackColor = Color.SaddleBrown,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(1322, 450),
                Size = new Size(300, 200),
                TabIndex = 7
            };
            this.Controls.Add(panelRecomendaciones);

            // Configuración inicial
            this.Text = "Eguraldia";
            labelNombreUsuario.Text = nombreUsuario;
            this.Shown += async (sender, e) => await CargarTiempoDesdeXML();
        }

        private async Task CargarTiempoDesdeXML()
        {
            try
            {
                string ftpServer = "192.168.115.154";
                string ftpUsername = "ikasleak";
                string ftpPassword = "ikasleak";
                int ftpPort = 21;
                string fileName = "tiempoErronka2.xml";
                string ftpUrl = $"ftp://{ftpServer}:{ftpPort}/{fileName}";

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.Timeout = 5000;

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                using (Stream responseStream = response.GetResponseStream())
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await responseStream.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;

                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(memoryStream);

                    // Agrupar datos por día
                    XmlNodeList temperaturaNodes = xmlDoc.SelectNodes("//temperatura");
                    dias.Clear();

                    foreach (XmlNode tempNode in temperaturaNodes)
                    {
                        XmlElement diaVirtual = xmlDoc.CreateElement("dia");
                        diaVirtual.AppendChild(tempNode.Clone());

                        // Buscar humedad
                        XmlNode humedadNode = tempNode.NextSibling;
                        while (humedadNode != null && humedadNode.Name != "humedad_relativa")
                        {
                            humedadNode = humedadNode.NextSibling;
                        }
                        if (humedadNode != null) diaVirtual.AppendChild(humedadNode.Clone());

                        // Buscar estado_cielo válido
                        XmlNode estadoCieloNode = tempNode.NextSibling;
                        while (estadoCieloNode != null &&
                              (estadoCieloNode.Name != "estado_cielo" ||
                               string.IsNullOrEmpty(estadoCieloNode.Attributes["descripcion"]?.Value)))
                        {
                            estadoCieloNode = estadoCieloNode.NextSibling;
                        }
                        if (estadoCieloNode != null) diaVirtual.AppendChild(estadoCieloNode.Clone());

                        dias.Add(diaVirtual);
                    }

                    // Configurar ComboBox
                    cmbDias.Items.Clear();
                    cmbDias.Items.Add("Gaur");
                    if (dias.Count > 1) cmbDias.Items.Add("Bihar");
                    if (dias.Count > 2) cmbDias.Items.Add("Etzi");
                    cmbDias.SelectedIndex = 0;
                }
            }
            catch (WebException ex) when (ex.Response is FtpWebResponse ftpResponse)
            {
                MessageBox.Show($"Error FTP: {ftpResponse.StatusCode} - {ftpResponse.StatusDescription}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDias.SelectedIndex >= 0 && cmbDias.SelectedIndex < dias.Count)
            {
                ActualizarDatos(cmbDias.SelectedIndex);
            }
        }

        private void ActualizarDatos(int indiceDia)
        {
            if (indiceDia >= dias.Count || xmlDoc == null) return;

            XmlNode dia = dias[indiceDia];
            List<string> recomendaciones = new List<string>();

            // Extraer datos
            string estadoCielo = dia.SelectSingleNode(".//estado_cielo[@descripcion!='']")?.Attributes["descripcion"]?.Value
                ?? "Desconocido";
            string tempMin = dia.SelectSingleNode(".//temperatura/minima")?.InnerText ?? "N/A";
            string tempMax = dia.SelectSingleNode(".//temperatura/maxima")?.InnerText ?? "N/A";
            string humMin = dia.SelectSingleNode(".//humedad_relativa/minima")?.InnerText ?? "N/A";
            string humMax = dia.SelectSingleNode(".//humedad_relativa/maxima")?.InnerText ?? "N/A";

            // Lógica de recomendaciones
            if (int.TryParse(tempMax, out int temp))
            {
                if (temp < 15) recomendaciones.Add("• Berogailua piztu");
                if (temp > 25) recomendaciones.Add("• Ureztatze-sistema aktibatu");
            }

            if (estadoCielo.Contains("lluvia"))
            {
                recomendaciones.Add("• Toldoa itxi");
                recomendaciones.Add("• Haize-geldotzea itxi");
            }
            else if (estadoCielo.Contains("Despejado"))
            {
                recomendaciones.Add("• Toldoa ireki");
                recomendaciones.Add("• Haize-geldotzea ireki");
            }

            if (int.TryParse(humMax, out int humedad) && humedad > 80)
            {
                recomendaciones.Add("• Itxaron ureztatzea");
            }

            // Actualizar UI
            this.Invoke((MethodInvoker)(() =>
            {
                // Limpiar paneles
                panelEstadoCielo.Controls.Clear();
                panelTemperatura.Controls.Clear();
                panelHumedad.Controls.Clear();
                panelRecomendaciones.Controls.Clear();

                // Actualizar contenido
                CrearContenido(panelEstadoCielo, "Zeruaren egoera", estadoCielo);
                CrearContenido(panelTemperatura, "Tenperatura", $"{tempMin}°C - {tempMax}°C");
                CrearContenido(panelHumedad, "Hezetasn erlatiboa", $"{humMin}% - {humMax}%");

                // Panel de recomendaciones
                CrearContenido(panelRecomendaciones, "Oharrak",
                    recomendaciones.Count > 0 ?
                    string.Join("\n", recomendaciones) :
                    "Ez dago gomendiorik");
            }));
        }

        private void CrearContenido(Panel panel, string titulo, string descripcion)
        {
            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 10, 0, 0)
            };

            Label lblDescripcion = new Label
            {
                Text = descripcion,
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.LightGray,
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 10, 0, 0)
            };

            panel.Controls.Add(lblDescripcion);
            panel.Controls.Add(lblTitulo);
        }

        private void BtnAtzera_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}