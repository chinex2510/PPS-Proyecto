using ConsultorioPsicopedagogico.CLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class CrearInformes : Form
    {
        private ConcurrentesCL concurrenteSeleccionado = null;
        private const string PLACEHOLDER_TITULO = "Título de informe";

        public CrearInformes()
        {
            InitializeComponent();
        }

        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void volver_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Form menu = Application.OpenForms["Menu"];
            if (menu != null)
            {
                menu.Show();
            }
        }

        // Placeholder behaviors
        private void txt_TituloArea_Enter(object sender, EventArgs e)
        {
            if (txt_TituloArea.Text == PLACEHOLDER_TITULO)
            {
                txt_TituloArea.Text = "";
                txt_TituloArea.ForeColor = Color.Black;
            }
        }

        private void txt_TituloArea_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TituloArea.Text))
            {
                txt_TituloArea.Text = PLACEHOLDER_TITULO;
                txt_TituloArea.ForeColor = Color.Gray;
            }
        }

        private void btn_select_DNI_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DNI.Text) || !int.TryParse(txt_DNI.Text, out int dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI válido (solo números) para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DNI.Focus();
                return;
            }

            try
            {
                ConcurrentesCL logic = new ConcurrentesCL();
                var concurrente = logic.SeleccionarPorDni(dni);

                if (concurrente != null)
                {
                    concurrenteSeleccionado = concurrente;
                    lbl_NombreConcurrente.Text = concurrente.Nombre_C + " " + concurrente.Apellido_C;
                    lbl_NombreConcurrente.ForeColor = Color.FromArgb(60, 60, 60);
                    int edad = CalcularEdad(concurrente.FechaNac_C);
                    lbl_Edad.Text = $"{edad} años";
                    CargarHistorial();
                }
                else
                {
                    concurrenteSeleccionado = null;
                    lbl_NombreConcurrente.Text = "";
                    lbl_NombreConcurrente.ForeColor = Color.FromArgb(60, 60, 60);
                    lbl_Edad.Text = "";
                    CargarHistorial();
                    MessageBox.Show("Concurrente no encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar concurrente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorial()
        {
            if (concurrenteSeleccionado == null)
            {
                dtg_Informes.SelectionChanged -= dtg_Informes_SelectionChanged;
                dtg_Informes.DataSource = null;
                dtg_Informes.SelectionChanged += dtg_Informes_SelectionChanged;
                return;
            }
            try
            {
                // Desactivar temporalmente el evento para evitar disparadores innecesarios durante el data binding
                dtg_Informes.SelectionChanged -= dtg_Informes_SelectionChanged;

                InformeCL logic = new InformeCL();
                DataTable dt = logic.ObtenerInformesPorDni(concurrenteSeleccionado.Dni_C.ToString());

                // Aplicar filtro por fecha si el checkbox del DateTimePicker está marcado
                if (date_naci.Checked)
                {
                    string filterDate = date_naci.Value.ToString("dd/MM/yyyy");
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = $"Fecha = '{filterDate}'";
                    dtg_Informes.DataSource = dv.ToTable();
                }
                else
                {
                    dtg_Informes.DataSource = dt;
                }

                if (dtg_Informes.Columns.Contains("idInforme"))
                    dtg_Informes.Columns["idInforme"].Visible = false;
                if (dtg_Informes.Columns.Contains("Ruta"))
                    dtg_Informes.Columns["Ruta"].Visible = false;

                // Limpiar la pre-selección automática de la primera fila
                dtg_Informes.ClearSelection();

                // Reactivar el evento
                dtg_Informes.SelectionChanged += dtg_Informes_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_agregarArea_Click(object sender, EventArgs e)
        {
            if (concurrenteSeleccionado == null)
            {
                MessageBox.Show("Primero debe seleccionar un concurrente válido buscando por DNI.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DNI.Focus();
                return;
            }

            if (txt_TituloArea.Text == PLACEHOLDER_TITULO || string.IsNullOrWhiteSpace(txt_TituloArea.Text))
            {
                MessageBox.Show("Por favor, complete el título del informe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TituloArea.Focus();
                return;
            }

            try
            {
                string plantillaPath = ObtenerRutaPlantilla();
                VerificarYCrearPlantilla(plantillaPath);

                string destinoFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Informes");
                if (!Directory.Exists(destinoFolder))
                {
                    Directory.CreateDirectory(destinoFolder);
                }

                string sanitizedTitle = string.Join("_", txt_TituloArea.Text.Split(Path.GetInvalidFileNameChars()));
                string destinoPath = Path.Combine(destinoFolder, $"Informe_{concurrenteSeleccionado.Dni_C}_{DateTime.Today:yyyyMMdd}_{sanitizedTitle}.docx");

                // Copiar plantilla a destino
                File.Copy(plantillaPath, destinoPath, true);

                // Formatear la fecha de nacimiento para que no contenga la hora
                string fechaNacFormateada = "";
                if (DateTime.TryParse(concurrenteSeleccionado.FechaNac_C, out DateTime fn))
                {
                    fechaNacFormateada = fn.ToString("dd/MM/yyyy");
                }
                else
                {
                    fechaNacFormateada = concurrenteSeleccionado.FechaNac_C;
                }

                // Reemplazar marcadores en el archivo destino
                var reemplazos = new Dictionary<string, string>
                {
                    { "[Nombre]", concurrenteSeleccionado.Nombre_C + " " + concurrenteSeleccionado.Apellido_C },
                    { "[DNI]", concurrenteSeleccionado.Dni_C.ToString() },
                    { "[Edad]", CalcularEdad(concurrenteSeleccionado.FechaNac_C).ToString() + " años" },
                    { "[FechaNacimiento]", fechaNacFormateada },
                    { "[NivelEscolar]", concurrenteSeleccionado.NivelEscolar_C + " / " + concurrenteSeleccionado.AñoEscolar_C }
                };

                ReemplazarMarcadores(destinoPath, reemplazos);

                // Guardar en Base de Datos
                InformeCL logic = new InformeCL();
                logic.GuardarInforme(
                    concurrenteSeleccionado.IdConcurrente_C,
                    txt_TituloArea.Text,
                    destinoPath,
                    DateTime.Today.ToString("yyyy-MM-dd")
                );

                // Abrir archivo en Word
                Process.Start(destinoPath);

                MessageBox.Show("Informe Word generado y guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar y recargar
                txt_TituloArea.Text = PLACEHOLDER_TITULO;
                txt_TituloArea.ForeColor = Color.Gray;
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el informe: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_BuscarArea_Click(object sender, EventArgs e)
        {
            if (dtg_Informes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un informe de la lista para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string ruta = dtg_Informes.SelectedRows[0].Cells["Ruta"].Value.ToString();
                if (File.Exists(ruta))
                {
                    Process.Start(ruta);
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo físico de Word en la ruta:\n" + ruta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el informe: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtg_Informes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btn_BuscarArea_Click(sender, e);
            }
        }

        private void dtg_Informes_SelectionChanged(object sender, EventArgs e)
        {
            if (dtg_Informes.SelectedRows.Count > 0)
            {
                var row = dtg_Informes.SelectedRows[0];
                if (row.Cells["Título"].Value != null && row.Cells["Título"].Value != DBNull.Value)
                {
                    txt_TituloArea.Text = row.Cells["Título"].Value.ToString();
                    txt_TituloArea.ForeColor = Color.Black;
                }
            }
        }

        private void btn_DescargarPDF_Click(object sender, EventArgs e)
        {
            if (dtg_Informes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un informe de la lista para descargar como PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string wordPath = dtg_Informes.SelectedRows[0].Cells["Ruta"].Value.ToString();
                string titulo = dtg_Informes.SelectedRows[0].Cells["Título"].Value.ToString();

                if (!File.Exists(wordPath))
                {
                    MessageBox.Show("No se encontró el archivo de Word en la ruta especificada:\n" + wordPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog saveFile = new SaveFileDialog
                {
                    FileName = $"Informe_{concurrenteSeleccionado.Dni_C}_{DateTime.Today:yyyyMMdd}_{titulo}.pdf",
                    Filter = "Archivos PDF|*.pdf"
                };

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string pdfPath = saveFile.FileName;

                    // Convertir DOCX a PDF usando Word Interop
                    Microsoft.Office.Interop.Word.Application wordApp = null;
                    Microsoft.Office.Interop.Word.Document doc = null;
                    try
                    {
                        wordApp = new Microsoft.Office.Interop.Word.Application();
                        wordApp.Visible = false;
                        doc = wordApp.Documents.Open(wordPath);

                        // Exportar a PDF
                        doc.SaveAs2(pdfPath, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);

                        MessageBox.Show("PDF generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        if (doc != null) doc.Close(false);
                        if (wordApp != null) wordApp.Quit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerRutaPlantilla()
        {
            // Ruta 1: Carpeta de ejecución (Resources/PlantillaInforme.docx)
            string localPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "PlantillaInforme.docx");
            if (File.Exists(localPath)) return localPath;

            // Ruta 2: Carpeta de desarrollo (../../Resources/PlantillaInforme.docx)
            string devPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Resources", "PlantillaInforme.docx");
            if (File.Exists(devPath))
            {
                string destDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
                if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);
                File.Copy(devPath, localPath, true);
                return localPath;
            }

            return localPath; // fallback (se creará programáticamente)
        }

        private void VerificarYCrearPlantilla(string path)
        {
            string dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (File.Exists(path)) return;

            Microsoft.Office.Interop.Word.Application wordApp = null;
            Microsoft.Office.Interop.Word.Document doc = null;
            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = false;
                doc = wordApp.Documents.Add();

                // Agregar contenido inicial de la plantilla
                var pTitle = doc.Content.Paragraphs.Add();
                pTitle.Range.Text = "INFORME PSICOPEDAGÓGICO";
                pTitle.Range.Font.Bold = 1;
                pTitle.Range.Font.Size = 16;
                pTitle.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                pTitle.Range.InsertParagraphAfter();

                var pSub = doc.Content.Paragraphs.Add();
                pSub.Range.Text = "CONSULTORIO PSICOPEDAGÓGICO";
                pSub.Range.Font.Bold = 0;
                pSub.Range.Font.Size = 12;
                pSub.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                pSub.Range.InsertParagraphAfter();

                var pSeparator1 = doc.Content.Paragraphs.Add();
                pSeparator1.Range.Text = "==================================================";
                pSeparator1.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                pSeparator1.Range.InsertParagraphAfter();

                var pDatos = doc.Content.Paragraphs.Add();
                pDatos.Range.Text = "DATOS DEL CONCURRENTE:\n" +
                                    "Nombre y Apellido: [Nombre]\n" +
                                    "DNI: [DNI]\n" +
                                    "Edad: [Edad]\n" +
                                    "Fecha de Nacimiento: [FechaNacimiento]\n" +
                                    "Nivel Escolar: [NivelEscolar]\n";
                pDatos.Range.Font.Size = 11;
                pDatos.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                pDatos.Range.InsertParagraphAfter();

                var pSeparator2 = doc.Content.Paragraphs.Add();
                pSeparator2.Range.Text = "----------------------------------------------------------------------------------------------------";
                pSeparator2.Range.InsertParagraphAfter();

                var pCuerpo = doc.Content.Paragraphs.Add();
                pCuerpo.Range.Text = "DETALLES DEL INFORME Y EVOLUCIÓN:\n" +
                                     "[Escriba aquí los detalles del informe del concurrente...]";
                pCuerpo.Range.Font.Size = 11;
                pCuerpo.Range.InsertParagraphAfter();

                doc.SaveAs2(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear plantilla base de Word: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc != null) doc.Close();
                if (wordApp != null) wordApp.Quit();
            }
        }

        private void ReemplazarMarcadores(string docPath, Dictionary<string, string> reemplazos)
        {
            Microsoft.Office.Interop.Word.Application wordApp = null;
            Microsoft.Office.Interop.Word.Document doc = null;
            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = false;
                doc = wordApp.Documents.Open(docPath);

                foreach (var par in reemplazos)
                {
                    Microsoft.Office.Interop.Word.Find findObject = wordApp.Selection.Find;
                    findObject.ClearFormatting();
                    findObject.Text = par.Key;
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = par.Value;

                    object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                    findObject.Execute(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                       Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                       ref replaceAll, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                doc.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reemplazar datos en el informe: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc != null) doc.Close();
                if (wordApp != null) wordApp.Quit();
            }
        }

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

        private void PanelCard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                using (Pen pen = new Pen(Color.FromArgb(232, 224, 238), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_DNI.Text = "";
            txt_TituloArea.Text = PLACEHOLDER_TITULO;
            txt_TituloArea.ForeColor = Color.Gray;
            lbl_NombreConcurrente.Text = "";
            lbl_Edad.Text = "";
            concurrenteSeleccionado = null;

            // Desvincular eventos para evitar bucles durante el reset
            date_naci.ValueChanged -= date_naci_ValueChanged;
            date_naci.Checked = false;
            date_naci.Value = DateTime.Today;
            date_naci.ValueChanged += date_naci_ValueChanged;

            dtg_Informes.SelectionChanged -= dtg_Informes_SelectionChanged;
            dtg_Informes.DataSource = null;
            dtg_Informes.ClearSelection();
            dtg_Informes.SelectionChanged += dtg_Informes_SelectionChanged;
        }

        private void date_naci_ValueChanged(object sender, EventArgs e)
        {
            CargarHistorial();
        }
    }
}
