using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultorioPsicopedagogico.CLogica;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class FormRecuperarContrasena : Form
    {
        public FormRecuperarContrasena()
        {
            InitializeComponent();

            panelTarjetaCampos.Paint += (s, e) => RedondearControl(panelTarjetaCampos, 40);
            btnConfirmar.Paint += (s, e) => RedondearControl(btnConfirmar, 18);
            btnCancelar.Paint += (s, e) => RedondearControl(btnCancelar, 18);

            // Redirecciones y botones
            btnCancelar.Click += btnCancelar_Click;
            btnConfirmar.Click += btnConfirmar_Click;

            // Vincular evento de matrícula para buscar la pregunta secreta
            txtMatricula.Leave += txtMatricula_Leave;

            // Restringir ingreso de letras en matrícula
            txtMatricula.KeyPress += SoloNumeros_KeyPress;
        }

        private void RedondearControl(Control control, int radio)
        {
            GraphicsPath forma = new GraphicsPath();
            forma.StartFigure();
            forma.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            forma.AddArc(new Rectangle(control.Width - radio, 0, radio, radio), 270, 90);
            forma.AddArc(new Rectangle(control.Width - radio, control.Height - radio, radio, radio), 0, 90);
            forma.AddArc(new Rectangle(0, control.Height - radio, radio, radio), 90, 90);
            forma.CloseFigure();
            control.Region = new Region(forma);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            RegresarLogin();
        }

        private void RegresarLogin()
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void txtMatricula_Leave(object sender, EventArgs e)
        {
            CargarPreguntaUsuario();
        }

        private void CargarPreguntaUsuario()
        {
            string matricula = txtMatricula.Text.Trim();
            if (string.IsNullOrEmpty(matricula))
            {
                txtPregunta.Text = "";
                return;
            }

            try
            {
                UsuarioCL logica = new UsuarioCL();
                string pregunta = logica.ObtenerPreguntaPorMatricula(matricula);

                if (!string.IsNullOrEmpty(pregunta))
                {
                    txtPregunta.Text = pregunta;
                    txtPregunta.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
                }
                else
                {
                    txtPregunta.Text = "Matrícula no encontrada o sin pregunta registrada";
                    txtPregunta.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar cargar la pregunta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string matricula = txtMatricula.Text.Trim();
            string respuesta = txtRespuesta.Text.Trim();

            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("Debe ingresar su matrícula.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatricula.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPregunta.Text) || txtPregunta.Text == "Matrícula no encontrada o sin pregunta registrada")
            {
                MessageBox.Show("Debe cargar una matrícula válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatricula.Focus();
                return;
            }

            if (string.IsNullOrEmpty(respuesta))
            {
                MessageBox.Show("Debe escribir la respuesta de seguridad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRespuesta.Focus();
                return;
            }

            try
            {
                UsuarioCL logica = new UsuarioCL();
                bool respuestaValida = logica.ValidarRespuestaSeguridad(matricula, respuesta);

                if (respuestaValida)
                {
                    // Mostrar diálogo para ingresar la nueva contraseña
                    string nuevaContra = CustomPasswordDialog.ShowDialog("Ingrese la nueva contraseña:", "Restablecer Contraseña");

                    if (!string.IsNullOrEmpty(nuevaContra))
                    {
                        // Actualizar la contraseña en la BD
                        bool exito = logica.ActualizarContrasena(matricula, nuevaContra);
                        if (exito)
                        {
                            MessageBox.Show("Contraseña reestablecida correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RegresarLogin();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar la contraseña. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La respuesta de seguridad es incorrecta.", "Fallo de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRespuesta.Focus();
                    txtRespuesta.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar la solicitud: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public static class CustomPasswordDialog
    {
        public static string ShowDialog(string promptText, string title)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 230,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LavenderBlush,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() 
            { 
                Left = 30, 
                Top = 15, 
                Text = promptText, 
                Width = 340, 
                Font = new Font("Segoe UI", 10, FontStyle.Bold), 
                ForeColor = ColorTranslator.FromHtml("#3A0F3A") 
            };

            TextBox txtPassword = new TextBox() 
            { 
                Left = 30, 
                Top = 40, 
                Width = 340, 
                UseSystemPasswordChar = true, 
                Font = new Font("Segoe UI", 10) 
            };

            Label textLabel2 = new Label() 
            { 
                Left = 30, 
                Top = 75, 
                Text = "Confirme la nueva contraseña:", 
                Width = 340, 
                Font = new Font("Segoe UI", 10, FontStyle.Bold), 
                ForeColor = ColorTranslator.FromHtml("#3A0F3A") 
            };

            TextBox txtConfirmPassword = new TextBox() 
            { 
                Left = 30, 
                Top = 100, 
                Width = 340, 
                UseSystemPasswordChar = true, 
                Font = new Font("Segoe UI", 10) 
            };

            Button confirmation = new Button() 
            { 
                Text = "Guardar", 
                Left = 220, 
                Width = 150, 
                Top = 145, 
                Height = 35, 
                FlatStyle = FlatStyle.Flat, 
                BackColor = Color.FromArgb(75, 165, 100), 
                ForeColor = Color.White, 
                Font = new Font("Segoe UI", 9.75F, FontStyle.Bold) 
            };

            Button cancel = new Button() 
            { 
                Text = "Cancelar", 
                Left = 30, 
                Width = 150, 
                Top = 145, 
                Height = 35, 
                FlatStyle = FlatStyle.Flat, 
                ForeColor = ColorTranslator.FromHtml("#3A0F3A"), 
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9.75F, FontStyle.Bold) 
            };

            confirmation.FlatAppearance.BorderSize = 0;
            cancel.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#3A0F3A");

            confirmation.Click += (sender, e) => {
                string pass = txtPassword.Text.Trim();
                string confirm = txtConfirmPassword.Text.Trim();

                if (string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("La contraseña no puede estar vacía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (pass.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (pass != confirm)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                prompt.DialogResult = DialogResult.OK;
                prompt.Close();
            };

            cancel.Click += (sender, e) => {
                prompt.DialogResult = DialogResult.Cancel;
                prompt.Close();
            };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(txtPassword);
            prompt.Controls.Add(textLabel2);
            prompt.Controls.Add(txtConfirmPassword);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return txtPassword.Text.Trim();
            }

            return null;
        }

        private static void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
