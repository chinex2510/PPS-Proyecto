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
using ConsultorioPsicopedagogico.CPresentacion;
using FluentValidation;
using FluentValidation.Results;
using Org.BouncyCastle.Crypto.Engines;

namespace ConsultorioPsicopedagogico
{
    public partial class Login : Form
    {
        private LoginCL loginLogica;
        private bool mostrarContrasena = false;
        private bool isEyeHovered = false;
        private ToolTip toolTipOjo = new ToolTip();

        public Login()
        {
            InitializeComponent();
            this.ActiveControl = panelControles;
            this.loginLogica = new LoginCL();

            // Vincular eventos de LinkLabel para navegación
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            
            // Ocultar la opción de crear cuenta desde el login (ahora es exclusivo de Admin)
            linkLabel2.Visible = false;

            ActualizarToolTipOjo();
        }

        private void ActualizarToolTipOjo()
        {
            toolTipOjo.SetToolTip(pic_MostrarOcultar, mostrarContrasena ? "Ocultar contraseña" : "Mostrar contraseña");
        }

        public void LimpiarCampos()
        {
            txt_Usuario.Text = "Ingrese su usuario";
            txt_Usuario.ForeColor = Color.Gray;

            txt_Contraseña.Text = "Ingrese su contraseña";
            txt_Contraseña.ForeColor = Color.Gray;
            txt_Contraseña.UseSystemPasswordChar = false;
            mostrarContrasena = false;
            ActualizarToolTipOjo();
            if (pic_MostrarOcultar != null) pic_MostrarOcultar.Invalidate();

            this.ActiveControl = panelControles;
        }

        private void txt_Usuario_Enter(object sender, EventArgs e)
        {
            if (txt_Usuario.Text == "Ingrese su usuario")
            {
                txt_Usuario.Text = "";
                txt_Usuario.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
            }
        }

        private void txt_Usuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Usuario.Text))
            {
                txt_Usuario.Text = "Ingrese su usuario";
                txt_Usuario.ForeColor = Color.Gray;
            }
        }

        private void txt_Contraseña_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Contraseña.Text))
            {
                txt_Contraseña.Text = "Ingrese su contraseña";
                txt_Contraseña.ForeColor = Color.Gray;
                txt_Contraseña.UseSystemPasswordChar = false;
            }
        }

        private void txt_Contraseña_Enter(object sender, EventArgs e)
        {
            if (txt_Contraseña.Text == "Ingrese su contraseña")
            {
                txt_Contraseña.Text = "";
                txt_Contraseña.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
                txt_Contraseña.UseSystemPasswordChar = !mostrarContrasena;
            }
        }

        private void pic_MostrarOcultar_Click(object sender, EventArgs e)
        {
            mostrarContrasena = !mostrarContrasena;

            if (txt_Contraseña.Text != "Ingrese su contraseña")
            {
                txt_Contraseña.UseSystemPasswordChar = !mostrarContrasena;
            }

            ActualizarToolTipOjo();
            pic_MostrarOcultar.Invalidate();
        }

        private void pic_MostrarOcultar_MouseEnter(object sender, EventArgs e)
        {
            isEyeHovered = true;
            pic_MostrarOcultar.Invalidate();
        }

        private void pic_MostrarOcultar_MouseLeave(object sender, EventArgs e)
        {
            isEyeHovered = false;
            pic_MostrarOcultar.Invalidate();
        }

        private void pic_MostrarOcultar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int w = pic_MostrarOcultar.Width;
            int h = pic_MostrarOcultar.Height;

            Color iconColor = isEyeHovered ? ColorTranslator.FromHtml("#732396") : ColorTranslator.FromHtml("#3A0F3A");

            using (Pen pen = new Pen(iconColor, 2f))
            using (SolidBrush brush = new SolidBrush(iconColor))
            {
                int eyeWidth = 20;
                int eyeHeight = 12;
                int x = (w - eyeWidth) / 2;
                int y = (h - eyeHeight) / 2;

                Rectangle rect = new Rectangle(x, y, eyeWidth, eyeHeight);

                // Dibujar arcos superior e inferior del ojo
                e.Graphics.DrawArc(pen, rect.X, rect.Y - 2, rect.Width, rect.Height + 4, 200, 140);
                e.Graphics.DrawArc(pen, rect.X, rect.Y - 4, rect.Width, rect.Height + 4, 20, 140);

                // Pupila central
                int pupilSize = 6;
                int px = (w - pupilSize) / 2;
                int py = (h - pupilSize) / 2;
                e.Graphics.FillEllipse(brush, px, py, pupilSize, pupilSize);

                // Si la contraseña está OCULTA (!mostrarContrasena), dibujar la barra diagonal que tacha el ojo
                if (!mostrarContrasena)
                {
                    using (Pen slashPen = new Pen(iconColor, 2f))
                    {
                        e.Graphics.DrawLine(slashPen, x - 1, y + eyeHeight + 1, x + eyeWidth + 1, y - 1);
                    }
                }
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

        private void lbl_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbl_Minimizar_MouseEnter(object sender, EventArgs e)
        {
            lbl_Minimizar.BackColor = ColorTranslator.FromHtml("#D2B4DE");
        }

        private void lbl_Minimizar_MouseLeave(object sender, EventArgs e)
        {
            lbl_Minimizar.BackColor = Color.Transparent;
        }

        private void lbl_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            // Armar arreglo de campos para validación
            string[] camposLogin = new string[]
            {
                txt_Usuario.Text.Trim(),
                txt_Contraseña.Text.Trim()
            };

            // Instanciar el validador y validar los campos
            LoginValidation validador = new LoginValidation();
            ValidationResult resultado = validador.Validate(camposLogin);

            // Evaluar el resultado de la validación

            if (!resultado.IsValid) {
                string mensajesError = "";
                foreach (var error in resultado.Errors)
                {
                    mensajesError += "- " + error.ErrorMessage + "\n";
                }

                // Esto se debe ejecutar si hay campos vacíos o con texto gris
                MessageBox.Show(mensajesError, "Validación de campos", MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
                return;
            }

            // Validacion de formato exitosa. Proceder a validar credenciales contra BD
            string usuario = txt_Usuario.Text.Trim();
            string contrasena = txt_Contraseña.Text.Trim();

            string rol = loginLogica.Autenticar(usuario, contrasena);
            if (!string.IsNullOrEmpty(rol))
            {
                // Redirigir al formulario principal (Menu)
                ConsultorioPsicopedagogico.CPresentacion.Menu principalMenu = new ConsultorioPsicopedagogico.CPresentacion.Menu(rol);
                principalMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta.", "Fallo de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Contraseña.Text = "";
                txt_Contraseña.Focus();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecuperarContrasena recuperarForm = new FormRecuperarContrasena();
            this.Hide();
            recuperarForm.ShowDialog();
            this.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Ya no se utiliza desde el login
        }
    }
} 
