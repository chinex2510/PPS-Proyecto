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

        public Login()
        {
            InitializeComponent();
            this.ActiveControl = panelControles;
            this.loginLogica = new LoginCL();

            // Vincular eventos de LinkLabel para navegación
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
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
                txt_Contraseña.UseSystemPasswordChar = true;
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

            if (loginLogica.Autenticar(usuario, contrasena))
            {
                MessageBox.Show("¡Login exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Redirigir al formulario principal (Menu)
                ConsultorioPsicopedagogico.CPresentacion.Menu principalMenu = new ConsultorioPsicopedagogico.CPresentacion.Menu();
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
            FormNuevoUsuario nuevoForm = new FormNuevoUsuario();
            this.Hide();
            nuevoForm.ShowDialog();
            this.Show();
        }
    }
} 
