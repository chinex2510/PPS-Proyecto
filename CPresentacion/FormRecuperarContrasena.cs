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

            // Redirecciones y botones principales
            btnCancelar.Click += btnCancelar_Click;
            btnConfirmar.Click += btnConfirmar_Click;

            // --- REDISEÑO DE BÚSQUEDA ---
            // 1. Reducir el ancho de txtUsuario para dejar espacio al botón buscar
            txtUsuario.Width = 280;

            // 2. Crear el botón de Buscar dinámicamente
            Button btnBuscar = new Button();
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Text = "Buscar";
            btnBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBuscar.BackColor = Color.FromArgb(55, 45, 85); // Mismo púrpura que btnCancelar
            btnBuscar.ForeColor = Color.White;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(325, 41);
            btnBuscar.Size = new Size(110, 29);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.UseVisualStyleBackColor = false;

            // 3. Suscribir evento Click al botón buscar
            btnBuscar.Click += btnBuscar_Click;

            // 4. Pintar bordes redondeados al botón de buscar
            btnBuscar.Paint += (s, e) => RedondearControl(btnBuscar, 10);

            // 5. Agregar el botón al panel de campos
            panelTarjetaCampos.Controls.Add(btnBuscar);

            // 6. Deshabilitar el campo respuesta inicialmente
            txtRespuesta.Enabled = false;

            // 7. Limpiar campos al cambiar el usuario (obliga a buscar de nuevo)
            txtUsuario.TextChanged += (s, e) => {
                txtPregunta.Text = "";
                txtRespuesta.Text = "";
                txtRespuesta.Enabled = false;
            };

            // 8. Evento Enter en usuario dispara la búsqueda
            txtUsuario.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // Evitar sonido bip de Windows
                    btnBuscar.PerformClick();
                }
            };

            // 9. Evento Enter en respuesta dispara la confirmación
            txtRespuesta.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnConfirmar.PerformClick();
                }
            };
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

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegresarLogin()
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPreguntaUsuario();
        }

        private bool CargarPreguntaUsuario()
        {
            string usuario = txtUsuario.Text.Trim();
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Debe ingresar su usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            try
            {
                UsuarioCL logica = new UsuarioCL();
                string pregunta = logica.ObtenerPreguntaPorUsuario(usuario);

                if (!string.IsNullOrEmpty(pregunta))
                {
                    txtPregunta.Text = pregunta;
                    txtPregunta.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
                    txtRespuesta.Enabled = true;
                    txtRespuesta.Focus();
                    return true;
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado o sin pregunta registrada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPregunta.Text = "";
                    txtRespuesta.Text = "";
                    txtRespuesta.Enabled = false;
                    txtUsuario.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar cargar la pregunta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPregunta.Text = "";
                txtRespuesta.Text = "";
                txtRespuesta.Enabled = false;
                return false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string respuesta = txtRespuesta.Text.Trim();

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Debe ingresar su usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (!txtRespuesta.Enabled)
            {
                MessageBox.Show("Debe realizar la búsqueda de su usuario primero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
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
                bool respuestaValida = logica.ValidarRespuestaSeguridad(usuario, respuesta);

                if (respuestaValida)
                {
                    string nuevaContra = CustomPasswordDialog.ShowDialog("Ingrese la nueva contraseña:", "Restablecer Contraseña");

                    if (!string.IsNullOrEmpty(nuevaContra))
                    {
                        bool exito = logica.ActualizarContrasena(usuario, nuevaContra);
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
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(58, 15, 58)
            };

            TextBox textBox = new TextBox() 
            { 
                Left = 30, 
                Top = 45, 
                Width = 340, 
                UseSystemPasswordChar = true,
                Font = new Font("Segoe UI", 11F)
            };

            Label confirmLabel = new Label()
            {
                Left = 30,
                Top = 85,
                Text = "Confirme la nueva contraseña:",
                Width = 340,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(58, 15, 58)
            };

            TextBox confirmTextBox = new TextBox()
            {
                Left = 30,
                Top = 115,
                Width = 340,
                UseSystemPasswordChar = true,
                Font = new Font("Segoe UI", 11F)
            };

            Button confirmation = new Button() 
            { 
                Text = "Aceptar", 
                Left = 140, 
                Width = 120, 
                Top = 155, 
                Height = 30,
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(75, 165, 100),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            confirmation.Paint += (s, e) => {
                GraphicsPath forma = new GraphicsPath();
                forma.StartFigure();
                forma.AddArc(new Rectangle(0, 0, 10, 10), 180, 90);
                forma.AddArc(new Rectangle(confirmation.Width - 10, 0, 10, 10), 270, 90);
                forma.AddArc(new Rectangle(confirmation.Width - 10, confirmation.Height - 10, 10, 10), 0, 90);
                forma.AddArc(new Rectangle(0, confirmation.Height - 10, 10, 10), 90, 90);
                forma.CloseFigure();
                confirmation.Region = new Region(forma);
            };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmTextBox);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(confirmLabel);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            confirmation.Click += (sender, e) => {
                string p1 = textBox.Text.Trim();
                string p2 = confirmTextBox.Text.Trim();

                if (string.IsNullOrEmpty(p1))
                {
                    MessageBox.Show("La contraseña no puede estar vacía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    prompt.DialogResult = DialogResult.None;
                    textBox.Focus();
                    return;
                }

                if (p1.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    prompt.DialogResult = DialogResult.None;
                    textBox.Focus();
                    return;
                }

                if (p1 != p2)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    prompt.DialogResult = DialogResult.None;
                    confirmTextBox.Focus();
                    return;
                }
            };

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : "";
        }
    }
}
