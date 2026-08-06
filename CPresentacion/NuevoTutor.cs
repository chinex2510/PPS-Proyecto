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
    public partial class NuevoTutor : Form
    {
        public NuevoTutor()
        {
            InitializeComponent();
            
            txt_ObraSocial.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_ObraSocial.Items.AddRange(new string[] { "OSECAC", "IPSST", "RED", "ASUNT", "Boreal Salud", "OSDE", "Prensa" });
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

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

        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            var validator = new TutorValidation();
            ValidationResult results = validator.Validate(this);

            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    MessageBox.Show(error.ErrorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                TutorCL tutor = new TutorCL
                {
                    DniTutor_C = int.Parse(txt_DniTutor.Text),
                    ApellidoTutor_C = txt_ApellidoTutor.Text,
                    NombreTutor_C = txt_NombreTutor.Text,
                    TelefonoTutor_C = txt_Telefono.Text,
                    EmailTutor_C = txt_Email.Text,
                    Obrasocial_C = txt_ObraSocial.Text
                };

                tutor.GuardarOModificarTutor(tutor, true);
                MessageBox.Show("Tutor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var validator = new TutorValidation();
            ValidationResult results = validator.Validate(this);

            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    MessageBox.Show(error.ErrorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                TutorCL tutor = new TutorCL
                {
                    DniTutor_C = int.Parse(txt_DniTutor.Text),
                    ApellidoTutor_C = txt_ApellidoTutor.Text,
                    NombreTutor_C = txt_NombreTutor.Text,
                    TelefonoTutor_C = txt_Telefono.Text,
                    EmailTutor_C = txt_Email.Text,
                    Obrasocial_C = txt_ObraSocial.Text
                };

                tutor.GuardarOModificarTutor(tutor, false);
                MessageBox.Show("Tutor modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DniTutor.Text) || !int.TryParse(txt_DniTutor.Text, out int dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI válido para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DniTutor.Focus();
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Está seguro que desea eliminar este tutor?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    TutorCL tutor = new TutorCL { DniTutor_C = dni };
                    tutor.EliminarTutor(tutor);
                    MessageBox.Show("Tutor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_BuscarTutor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DniTutor.Text) || txt_DniTutor.Text.Length < 7)
            {
                MessageBox.Show("Por favor, ingrese un DNI válido para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int dni = int.Parse(txt_DniTutor.Text);
                TutorCL tutorLogic = new TutorCL();
                TutorCL tutor = tutorLogic.BuscarTutor(dni);

                if (tutor != null)
                {
                    txt_ApellidoTutor.Text = tutor.ApellidoTutor_C;
                    txt_NombreTutor.Text = tutor.NombreTutor_C;
                    txt_Telefono.Text = tutor.TelefonoTutor_C;
                    txt_Email.Text = tutor.EmailTutor_C;
                    txt_ObraSocial.Text = tutor.Obrasocial_C;
                    MessageBox.Show("Tutor encontrado y datos cargados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontró ningún tutor con ese DNI.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_ApellidoTutor.Text = "";
                    txt_NombreTutor.Text = "";
                    txt_Telefono.Text = "";
                    txt_Email.Text = "";
                    txt_ObraSocial.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el tutor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_DniTutor.Text = "";
            txt_ApellidoTutor.Text = "";
            txt_NombreTutor.Text = "";
            txt_Telefono.Text = "";
            txt_Email.Text = "";
            txt_ObraSocial.Text = "";
        }

        public class TutorValidation : AbstractValidator<NuevoTutor>
        {
            public TutorValidation()
            {
                RuleFor(x => x.txt_DniTutor.Text)
                    .NotEmpty().WithMessage("El DNI es obligatorio.")
                    .Matches(@"^\d{7,8}$").WithMessage("El DNI debe tener entre 7 y 8 dígitos.");

                RuleFor(x => x.txt_ApellidoTutor.Text)
                    .NotEmpty().WithMessage("El apellido es obligatorio.")
                    .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("El apellido solo debe contener letras.");

                RuleFor(x => x.txt_NombreTutor.Text)
                    .NotEmpty().WithMessage("El nombre es obligatorio.")
                    .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("El nombre solo debe contener letras.");


                RuleFor(x => x.txt_Telefono.Text)
                    .NotEmpty().WithMessage("El teléfono es obligatorio.")
                    .Matches(@"^\d{8,15}$").WithMessage("El teléfono debe tener entre 8 y 15 dígitos.");

                RuleFor(x => x.txt_Email.Text)
                    .NotEmpty().WithMessage("El email es obligatorio.")
                    .EmailAddress().WithMessage("Debe ingresar un formato de email válido.");

                RuleFor(x => x.txt_ObraSocial.Text)
                    .NotEmpty().WithMessage("Ingresar no si no cuenta con obra social.");
            }
        }
    }
}
