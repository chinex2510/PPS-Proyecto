using ConsultorioPsicopedagogico.CLogica;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class NuevoConcurrente : Form
    {
        private bool tutorVerificado = false;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private bool formCargado = false;
        private int? _dniOriginal = null;
        private List<string> todasLasEscuelas = new List<string>();

        public NuevoConcurrente()
        {
            InitializeComponent();
            
            try
            {
                string path = System.IO.Path.Combine(Application.StartupPath, @"..\..\resources\escuelas_capital_tafiviejo.txt");
                if (System.IO.File.Exists(path))
                {
                    todasLasEscuelas = System.IO.File.ReadAllLines(path).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                }
            }
            catch { }

            txt_colegio.TextUpdate += Txt_colegio_TextUpdate;
            
            txt_anio.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_anio.Items.AddRange(new string[] { "1er año", "2do año", "3er año", "4to año", "5to año", "6to año", "7to año" });
            
            txt_nivel.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_nivel.Items.AddRange(new string[] { "Jardín", "Primario", "Secundario" });
            txt_nivel.SelectedIndexChanged += txt_nivel_SelectedIndexChanged;

            date_naci.MaxDate = DateTime.Today;
            date_naci.MinDate = DateTime.Today.AddYears(-40);

            SetFieldsEnabled(false);
            InitializeHelpSystem();
            this.Shown += (s, e) => {
                formCargado = true;
                txt_DniTutor.Focus();
            };
        }

        public NuevoConcurrente(int dni) : this()
        {
            _dniOriginal = dni;
            CargarDatos(dni);
        }

        private void CargarDatos(int dni)
        {
            var verificador = new CLogica.ConcurrentesCL();
            var concurrente = verificador.SeleccionarPorDni(dni);
            if (concurrente != null && concurrente.Dni_C != 0)
            {
                txt_dni.Text = concurrente.Dni_C.ToString();
                txt_ape.Text = concurrente.Apellido_C;
                txt_nom.Text = concurrente.Nombre_C;
                if (DateTime.TryParse(concurrente.FechaNac_C, out DateTime result)) {
                    date_naci.Value = result;
                }
                txt_diagnostico.Text = concurrente.Diagnostico_C;
                txt_colegio.Text = concurrente.Escuela_C;
                if (concurrente.AñoEscolar_C >= 1 && concurrente.AñoEscolar_C <= 7)
                {
                    txt_anio.SelectedIndex = concurrente.AñoEscolar_C - 1;
                }
                else
                {
                    txt_anio.SelectedIndex = -1;
                }
                txt_nivel.Text = concurrente.NivelEscolar_C;
                txt_domicilio.Text = concurrente.Domicilio_C;
                txt_DniTutor.Text = concurrente.DniTutor_C;
                cmb_Parentesco.Text = concurrente.Parentezco_C;
                
                try
                {
                    int dniTutor = int.Parse(concurrente.DniTutor_C);
                    var tutorLogic = new CLogica.TutorCL();
                    var tutor = tutorLogic.BuscarTutor(dniTutor);
                    if (tutor != null)
                    {
                        txt_tutor.Text = tutor.NombreTutor_C + " " + tutor.ApellidoTutor_C;
                        txt_contTutor.Text = tutor.TelefonoTutor_C;
                        tutorVerificado = true;
                        SetFieldsEnabled(true);
                    }
                }
                catch { }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!tutorVerificado)
            {
                toolTipHelp.Show("Debe verificar la existencia del tutor para agregar un concurrente", btn_guardar, 0, -45, 3000);
                txt_DniTutor.Focus();
                return;
            }

            var validator = new ConcurrenteValidation();
            ValidationResult results = validator.Validate(this);

            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    MessageBox.Show(error.ErrorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                try
                {
                    var concurrente = new ConcurrentesCL
                    {
                        Dni_C = int.Parse(txt_dni.Text),
                        OriginalDni_C = _dniOriginal ?? 0,
                        Apellido_C = txt_ape.Text,
                        Nombre_C = txt_nom.Text,
                        FechaNac_C = date_naci.Value.ToString("yyyy-MM-dd"),
                        Diagnostico_C = txt_diagnostico.Text,
                        Escuela_C = txt_colegio.Text,
                        AñoEscolar_C = int.Parse(txt_anio.Text.Substring(0, 1)),
                        NivelEscolar_C = txt_nivel.Text,
                        Domicilio_C = txt_domicilio.Text,
                        DniTutor_C = txt_DniTutor.Text,
                        Parentezco_C = cmb_Parentesco.Text
                    };

                    bool isEdit = _dniOriginal.HasValue;

                    if (isEdit)
                    {
                        concurrente.ModificarDatos(concurrente);
                        MessageBox.Show("Datos modificados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var verificador = new ConcurrentesCL();
                        var concurrenteExistente = verificador.SeleccionarPorDni(concurrente.Dni_C);

                        if (concurrenteExistente != null && concurrenteExistente.Dni_C != 0)
                        {
                            MessageBox.Show("Ya existe un paciente con este DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        concurrente.CargarEnSql(concurrente);
                        MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    this.Hide();
                    txt_anio.SelectedIndex = -1;
                    txt_nom.Text = "";
                    txt_ape.Text = "";
                    txt_domicilio.Text = "";
                    txt_diagnostico.Text = "";
                    txt_tutor.Text = "";
                    txt_colegio.Text = "";
                    txt_dni.Text = "";
                    txt_nivel.Text = "";
                    txt_contTutor.Text = "";
                    txt_DniTutor.Text = "";
                    cmb_Parentesco.SelectedIndex = -1;

                    SetFieldsEnabled(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public class ConcurrenteValidation : AbstractValidator<NuevoConcurrente>
        {
            public ConcurrenteValidation()
            {
                RuleFor(x => x.txt_dni.Text)
                    .NotEmpty().WithMessage("El DNI es obligatorio.")
                    .Matches(@"^\d{7,8}$").WithMessage("El DNI debe tener entre 7 y 8 dígitos.\nNo ingresar puntos.");
                RuleFor(x => x.txt_nom.Text)
                    .NotEmpty().WithMessage("El nombre es obligatorio.");
                RuleFor(x => x.txt_ape.Text)
                    .NotEmpty().WithMessage("El apellido es obligatorio.");
                RuleFor(x => x.date_naci.Value)
                    .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.")
                    .LessThan(DateTime.Now.Date).WithMessage("La fecha de nacimiento debe ser anterior a la fecha actual.");
                RuleFor(x => x.txt_diagnostico.Text)
                    .NotEmpty().WithMessage("El diagnostico es obligatorio.");
                RuleFor(x => x.txt_domicilio.Text)
                    .NotEmpty().WithMessage("La dirección es obligatoria.");
                RuleFor(x => x.txt_colegio.Text)
                    .NotEmpty().WithMessage("El colegio es obligatorio.");
                RuleFor(x => x.txt_anio.Text)
                    .NotEmpty().WithMessage("El año es obligatorio.");
                RuleFor(x => x.txt_nivel.Text)
                    .NotEmpty().WithMessage("El nivel es obligatorio.");               
                RuleFor(x => x.txt_tutor.Text)
                    .NotEmpty().WithMessage("El nombre del tutor es obligatorio.");
                RuleFor(x => x.txt_contTutor.Text)
                    .NotEmpty().WithMessage("El contacto del tutor es obligatorio.")
                    .Matches(@"^\d{10}$").WithMessage("El contacto del tutor debe tener exactamente 10 dígitos y solo contener números.");
                RuleFor(x => x.txt_DniTutor.Text)
                    .NotEmpty().WithMessage("El DNI del tutor es obligatorio.")
                    .Matches(@"^\d{7,8}$").WithMessage("El DNI del tutor debe tener entre 7 y 8 dígitos.");
                RuleFor(x => x.cmb_Parentesco.Text)
                    .NotEmpty().WithMessage("El parentesco es obligatorio.");
            }
        }

        private void btn_NuevoTutor_Click(object sender, EventArgs e)
        {
            NuevoTutor nuevoTutorForm = new NuevoTutor();
            nuevoTutorForm.ShowDialog();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                using (Pen pen = new Pen(Color.FromArgb(218, 200, 228), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
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

        private void SetFieldsEnabled(bool enabled)
        {
            tutorVerificado = enabled;
            Color backColor = enabled ? Color.White : Color.FromArgb(245, 245, 245);

            txt_dni.ReadOnly = !enabled;
            txt_dni.BackColor = backColor;

            txt_nom.ReadOnly = !enabled;
            txt_nom.BackColor = backColor;

            txt_ape.ReadOnly = !enabled;
            txt_ape.BackColor = backColor;

            txt_diagnostico.ReadOnly = !enabled;
            txt_diagnostico.BackColor = backColor;

            txt_domicilio.ReadOnly = !enabled;
            txt_domicilio.BackColor = backColor;

            txt_colegio.Enabled = enabled;
            txt_colegio.BackColor = backColor;

            txt_anio.Enabled = enabled && txt_nivel.Text != "Jardín";
            txt_anio.BackColor = backColor;

            txt_nivel.Enabled = enabled;
            txt_nivel.BackColor = backColor;

            cmb_Parentesco.Enabled = enabled;
            cmb_Parentesco.BackColor = backColor;

            date_naci.Enabled = enabled;
        }

        private void InitializeHelpSystem()
        {
            toolTipHelp = new System.Windows.Forms.ToolTip();
            toolTipHelp.IsBalloon = true;
            toolTipHelp.ToolTipTitle = "Verificación Requerida";
            toolTipHelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;

            toolTipHelp.SetToolTip(lbl_helpIcon, "Debe verificar la existencia del tutor para agregar un concurrente");
        }

        private void btn_verificarTutor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DniTutor.Text))
            {
                MessageBox.Show("Por favor, ingrese el DNI del tutor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DniTutor.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txt_DniTutor.Text, @"^\d{7,8}$"))
            {
                MessageBox.Show("El DNI del tutor debe tener entre 7 y 8 dígitos y no contener puntos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DniTutor.Focus();
                return;
            }
            int dni = int.Parse(txt_DniTutor.Text);

            try
            {
                TutorCL tutorLogic = new TutorCL();
                TutorCL tutor = tutorLogic.BuscarTutor(dni);

                if (tutor != null)
                {
                    txt_tutor.Text = tutor.NombreTutor_C + " " + tutor.ApellidoTutor_C;
                    txt_contTutor.Text = tutor.TelefonoTutor_C;

                    SetFieldsEnabled(true);
                    MessageBox.Show("Tutor verificado con éxito. Ya puede completar los datos del concurrente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_dni.Focus();
                }
                else
                {
                    SetFieldsEnabled(false);
                    txt_tutor.Text = "";
                    txt_contTutor.Text = "";
                    MessageBox.Show("El tutor no existe en el sistema. Debe registrar al tutor primero.", "Tutor No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el tutor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lbl_helpIcon_Paint(object sender, PaintEventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(Color.FromArgb(240, 173, 78)))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, label.Width - 1, label.Height - 1);
                }
                using (Font font = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    SizeF textSize = e.Graphics.MeasureString("!", font);
                    e.Graphics.DrawString("!", font, textBrush, (label.Width - textSize.Width) / 2, (label.Height - textSize.Height) / 2);
                }
            }
        }

        private void DisabledField_Enter(object sender, EventArgs e)
        {
            if (formCargado && !tutorVerificado)
            {
                Control control = sender as Control;
                if (control != null)
                {
                    toolTipHelp.Show("Debe verificar la existencia del tutor para agregar un concurrente", control, 0, -45, 3000);
                    txt_DniTutor.Focus();
                }
            }
        }

        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Txt_colegio_TextUpdate(object sender, EventArgs e)
        {
            string busqueda = txt_colegio.Text.ToLower();
            
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                txt_colegio.DroppedDown = false;
                return;
            }

            var coincidentes = todasLasEscuelas
                .Where(x => x.ToLower().Contains(busqueda))
                .Take(20)
                .ToArray();

            string currentText = txt_colegio.Text;
            int cursorPosition = txt_colegio.SelectionStart;

            txt_colegio.Items.Clear();
            if (coincidentes.Length > 0)
            {
                txt_colegio.Items.AddRange(coincidentes);
                txt_colegio.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                txt_colegio.DroppedDown = false;
            }

            txt_colegio.Text = currentText;
            txt_colegio.SelectionStart = cursorPosition;
        }

        private void txt_nivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_nivel.Text == "Jardín")
            {
                txt_anio.SelectedIndex = 0; // "1er año"
                txt_anio.Enabled = false;
            }
            else
            {
                txt_anio.Enabled = tutorVerificado;
            }
        }
    }
}


