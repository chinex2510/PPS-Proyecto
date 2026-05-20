
using ConsultorioPsicopedagogico.CLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.tool.xml;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;


namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class CrearInformes : Form
    {
        public CrearInformes()
        {
            InitializeComponent();
        }

        private void btn_DescargarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txt_DNI.Text, out int dni))
                {
                    MessageBox.Show("Ingrese un DNI válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cargar los datos del informe
                InformeCL informe = new InformeCL();
                if (!informe.CargarInformePorId(3))
                {
                    MessageBox.Show("No se encontró el informe correspondiente a ese DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener HTML de la plantilla
                string html = Properties.Resources.plantilla.ToString();

                // Reemplazar datos estáticos
                html = html.Replace("@fechaemision", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                html = html.Replace("@nombre", $"{informe.Concurrente_D.Nombre_D} {informe.Concurrente_D.Apellido_D}");
                html = html.Replace("@edad", CalcularEdad(informe.Concurrente_D.FechaNac_D).ToString());
                html = html.Replace("@dni", informe.Concurrente_D.Dni_D.ToString());
                html = html.Replace("@diagnostico", informe.Concurrente_D.Diagnostico_D);
                html = html.Replace("@institucion", informe.Concurrente_D.Escuela_D);
                html = html.Replace("@grado", $"{informe.Concurrente_D.NivelEscolar_D} / {informe.Concurrente_D.AñoEscolar_D}");
                html = html.Replace("@obrasocial", informe.Concurrente_D.Obrasocial_D);

                // Logo base64 desde Resources
                if (Properties.Resources.MAria_ELena_Quintana != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Properties.Resources.MAria_ELena_Quintana.Save(ms, ImageFormat.Png);
                        string base64Logo = Convert.ToBase64String(ms.ToArray());
                        string dataUri = $"data:image/png;base64,{base64Logo}";
                        html = html.Replace("@logo", dataUri);
                    }
                }
                else
                {
                    html = html.Replace("@logo", "");
                }

                // Armar las secciones dinámicas de áreas
                string secciones = "";
                foreach (var area in informe.InformeAreas_D)
                {
                    secciones += $"<div class='seccion'><h3>{area.Area_D.Nombre_Area_D}</h3><p>{area.Texto_Area_D}</p></div>";
                }
                html = html.Replace("@areasdinamicas", secciones);

                // Guardar PDF
                SaveFileDialog saveFile = new SaveFileDialog
                {
                    FileName = $"Informe_{informe.Concurrente_D.Dni_D}.pdf",
                    Filter = "PDF Files|*.pdf"
                };

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    // Crear documento PDF desde HTML
                    PdfDocument pdf = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);

                    // Guardar el archivo
                    pdf.Save(saveFile.FileName);

                    MessageBox.Show("PDF generado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Función para calcular edad desde string fecha
        private int CalcularEdad(string fechaNacStr)
        {
            if (DateTime.TryParse(fechaNacStr, out DateTime fechaNac))
            {
                int edad = DateTime.Today.Year - fechaNac.Year;
                if (DateTime.Today < fechaNac.AddYears(edad)) edad--;
                return edad;
            }
            return 0;
        }
    }
}           

      
      


