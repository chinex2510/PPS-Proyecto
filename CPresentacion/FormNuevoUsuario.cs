using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultorioPsicopedagogico.CLogica;
using FluentValidation.Results;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class FormNuevoUsuario : Form
    {
        public FormNuevoUsuario()
        {
            InitializeComponent();
            this.ActiveControl = panelDerecho;

            // Vincular eventos de botones
            btnCrearUsuario.Click += btnCrearUsuario_Click;
            btnCancelar.Click += btnCancelar_Click;

            // Vincular eventos de placeholders para TextBox
            txtUsuario.Enter += txtUsuario_Enter;
            txtUsuario.Leave += txtUsuario_Leave;

            txtDni.Enter += txtDni_Enter;
            txtDni.Leave += txtDni_Leave;

            txtNombreApellido.Enter += txtNombreApellido_Enter;
            txtNombreApellido.Leave += txtNombreApellido_Leave;

            txtMail.Enter += txtMail_Enter;
            txtMail.Leave += txtMail_Leave;

            txtContrasena.Enter += txtContrasena_Enter;
            txtContrasena.Leave += txtContrasena_Leave;

            txtConfirmarContrasena.Enter += txtConfirmarContrasena_Enter;
            txtConfirmarContrasena.Leave += txtConfirmarContrasena_Leave;

            txtRespuesta.Enter += txtRespuesta_Enter;
            txtRespuesta.Leave += txtRespuesta_Leave;

            // Cargar preguntas de seguridad dinámicamente
            CargarPreguntasSeguridad();

            // Cargar roles por defecto
            CargarRoles();

            // Cargar horarios
            CargarHorarios();

            // Evento para cambiar visibilidad de disponibilidad
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged;

            EstablecerColoresPlaceholders();

            // Restringir ingreso de letras en campos numéricos (DNI)
            txtDni.KeyPress += SoloNumeros_KeyPress;
        }

        private void CargarRoles()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Especialista");
            cmbRol.Items.Add("Secretaria/o");
            cmbRol.Items.Add("Admin");
            cmbRol.SelectedIndex = 0;
        }

        private void CargarHorarios()
        {
            cmbHoraInicio.Items.Clear();
            cmbHoraFin.Items.Clear();
            
            for (int i = 9; i <= 18; i++)
            {
                string hora = i.ToString("D2") + ":00";
                cmbHoraInicio.Items.Add(hora);
                cmbHoraFin.Items.Add(hora);
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rol = cmbRol.SelectedItem?.ToString();
            bool mostrarHorarios = (rol == "Especialista" || rol == "Secretaria/o");
            
            lblDisponibilidad.Visible = mostrarHorarios;
            lblHoraInicio.Visible = mostrarHorarios;
            cmbHoraInicio.Visible = mostrarHorarios;
            lblHoraFin.Visible = mostrarHorarios;
            cmbHoraFin.Visible = mostrarHorarios;
        }

        private void EstablecerColoresPlaceholders()
        {
            txtUsuario.ForeColor = Color.Gray;
            txtDni.ForeColor = Color.Gray;
            txtNombreApellido.ForeColor = Color.Gray;
            txtMail.ForeColor = Color.Gray;
            
            txtContrasena.ForeColor = Color.Gray;
            txtContrasena.UseSystemPasswordChar = false;
            
            txtConfirmarContrasena.ForeColor = Color.Gray;
            txtConfirmarContrasena.UseSystemPasswordChar = false;
            
            txtRespuesta.ForeColor = Color.Gray;
        }

        // --- EVENTOS PLACEHOLDER USUARIO ---
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Ingrese su usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "Ingrese su usuario";
                txtUsuario.ForeColor = Color.Gray;
            }
        }

        // --- EVENTOS PLACEHOLDER DNI ---
        private void txtDni_Enter(object sender, EventArgs e)
        {
            if (txtDni.Text == "Ingrese su DNI")
            {
                txtDni.Text = "";
                txtDni.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
            }
        }

        private void txtDni_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                txtDni.Text = "Ingrese su DNI";
                txtDni.ForeColor = Color.Gray;
            }
        }

        // --- EVENTOS PLACEHOLDER NOMBRE Y APELLIDO ---
        private void txtNombreApellido_Enter(object sender, EventArgs e)
        {
            if (txtNombreApellido.Text == "Ingrese su nombre completo")
            {
                txtNombreApellido.Text = "";
                txtNombreApellido.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
            }
        }

        private void txtNombreApellido_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreApellido.Text))
            {
                txtNombreApellido.Text = "Ingrese su nombre completo";
                txtNombreApellido.ForeColor = Color.Gray;
            }
        }

        // --- EVENTOS PLACEHOLDER CORREO ---
        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "Ingrese su correo electrónico")
            {
                txtMail.Text = "";
                txtMail.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
            }
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                txtMail.Text = "Ingrese su correo electrónico";
                txtMail.ForeColor = Color.Gray;
            }
        }

        // --- EVENTOS PLACEHOLDER CONTRASEÑA ---
        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "Ingrese su contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                txtContrasena.Text = "Ingrese su contraseña";
                txtContrasena.ForeColor = Color.Gray;
                txtContrasena.UseSystemPasswordChar = false;
            }
        }

        // --- EVENTOS PLACEHOLDER CONFIRMAR CONTRASEÑA ---
        private void txtConfirmarContrasena_Enter(object sender, EventArgs e)
        {
            if (txtConfirmarContrasena.Text == "Confirme su contraseña")
            {
                txtConfirmarContrasena.Text = "";
                txtConfirmarContrasena.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
                txtConfirmarContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtConfirmarContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                txtConfirmarContrasena.Text = "Confirme su contraseña";
                txtConfirmarContrasena.ForeColor = Color.Gray;
                txtConfirmarContrasena.UseSystemPasswordChar = false;
            }
        }

        // --- EVENTOS PLACEHOLDER RESPUESTA ---
        private void txtRespuesta_Enter(object sender, EventArgs e)
        {
            if (txtRespuesta.Text == "Ingrese la respuesta")
            {
                txtRespuesta.Text = "";
                txtRespuesta.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
            }
        }

        private void txtRespuesta_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                txtRespuesta.Text = "Ingrese la respuesta";
                txtRespuesta.ForeColor = Color.Gray;
            }
        }

        private void lbl_Cerrar_MouseEnter(object sender, EventArgs e)
        {
            lbl_Cerrar.BackColor = Color.Red;
            lbl_Cerrar.ForeColor = Color.White;
        }

        private void lbl_Cerrar_MouseLeave(object sender, EventArgs e)
        {
            lbl_Cerrar.BackColor = Color.Transparent;
            lbl_Cerrar.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
        }

        private void lbl_Minimizar_MouseEnter(object sender, EventArgs e)
        {
            lbl_Minimizar.BackColor = ColorTranslator.FromHtml("#D2B4DE");
        }

        private void lbl_Minimizar_MouseLeave(object sender, EventArgs e)
        {
            lbl_Minimizar.BackColor = Color.Transparent;
        }

        private void lbl_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbl_Cerrar_Click(object sender, EventArgs e)
        {
            RegresarLogin();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            RegresarLogin();
        }

        private void RegresarLogin()
        {
            this.Close();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Instanciar modelo de lógica
            UsuarioCL usuario = new UsuarioCL
            {
                Usuario = txtUsuario.Text.Trim(),
                NombreApellido = txtNombreApellido.Text.Trim(),
                Email = txtMail.Text.Trim(),
                Rol = cmbRol.SelectedItem != null ? cmbRol.SelectedItem.ToString() : "",
                Contrasena = txtContrasena.Text.Trim(),
                ConfirmarContrasena = txtConfirmarContrasena.Text.Trim(),
                PreguntaId = cmbPreguntaSecreta.SelectedValue != null ? Convert.ToInt32(cmbPreguntaSecreta.SelectedValue) : 0,
                Respuesta = txtRespuesta.Text.Trim()
            };

            // Validar disponibilidad horaria si es Especialista o Secretaria/o
            if (usuario.Rol == "Especialista" || usuario.Rol == "Secretaria/o")
            {
                if (cmbHoraInicio.SelectedItem == null || cmbHoraFin.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un horario de inicio y un horario de fin.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string horaInicio = cmbHoraInicio.SelectedItem.ToString();
                string horaFin = cmbHoraFin.SelectedItem.ToString();

                int horaI = int.Parse(horaInicio.Split(':')[0]);
                int horaF = int.Parse(horaFin.Split(':')[0]);

                int diferencia = horaF - horaI;

                if (diferencia < 6 || diferencia > 8)
                {
                    MessageBox.Show("La jornada laboral debe ser de corrido y tener un mínimo de 6 horas y un máximo de 8 horas.", "Error de horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                usuario.DisponibilidadHoraria = $"{horaInicio}-{horaFin}";
            }
            else
            {
                usuario.DisponibilidadHoraria = null;
            }

            // Intentar parsear el DNI
            int dniVal = 0;
            int.TryParse(txtDni.Text.Trim(), out dniVal);
            usuario.Dni = dniVal;

            // Validar con FluentValidation
            UsuarioValidation validador = new UsuarioValidation();
            ValidationResult resultado = validador.Validate(usuario);

            if (!resultado.IsValid)
            {
                string mensajesError = "";
                foreach (var error in resultado.Errors)
                {
                    mensajesError += "- " + error.ErrorMessage + "\n";
                }

                MessageBox.Show(mensajesError, "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Registrar el usuario llamando a la lógica
                if (usuario.Registrar(usuario))
                {
                    MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Regresar al Login
                    RegresarLogin();
                }
            }
            catch (InvalidOperationException ex)
            {
                // Manejar error de duplicidad de DNI o usuario de manera amigable
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtiene y carga el listado de preguntas de seguridad de la base de datos en el ComboBox.
        /// </summary>
        private void CargarPreguntasSeguridad()
        {
            try
            {
                UsuarioCL logica = new UsuarioCL();
                DataTable dt = logica.ObtenerPreguntas();

                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbPreguntaSecreta.DataSource = dt;
                    cmbPreguntaSecreta.DisplayMember = "PreguntaTexto";
                    cmbPreguntaSecreta.ValueMember = "PreguntaID";
                }
                else
                {
                    // Fallback en caso de que la tabla esté vacía
                    DataTable dtFallback = new DataTable();
                    dtFallback.Columns.Add("PreguntaID", typeof(int));
                    dtFallback.Columns.Add("PreguntaTexto", typeof(string));
                    dtFallback.Rows.Add(0, "-- Seleccione una pregunta de seguridad --");
                    cmbPreguntaSecreta.DataSource = dtFallback;
                    cmbPreguntaSecreta.DisplayMember = "PreguntaTexto";
                    cmbPreguntaSecreta.ValueMember = "PreguntaID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar cargar las preguntas de seguridad: " + ex.Message, 
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
