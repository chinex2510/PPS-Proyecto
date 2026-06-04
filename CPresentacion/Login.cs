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
        public Login()
        {
            InitializeComponent();
            this.ActiveControl = panelControles;
        }

        private const string MatriculaValida = "celeste";
        private const string ContraseñaValida = "123456";

        private void txt_Mat_Enter(object sender, EventArgs e)
        {
            if (txt_Mat.Text == "Ingrese su matrícula")
            {
                txt_Mat.Text = "";
                txt_Mat.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
            }
        }

        private void txt_Mat_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Mat.Text))
            {
                txt_Mat.Text = "Ingrese su matrícula";
                txt_Mat.ForeColor = Color.Gray;
            }
        }

        private void txt_Contraseña_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Contraseña.Text))
            {
                txt_Contraseña.Text = "Ingrese su contraseña";
                txt_Contraseña.ForeColor = Color.Gray;
            }
        }

        private void txt_Contraseña_Enter(object sender, EventArgs e)
        {
            if (txt_Contraseña.Text == "Ingrese su contraseña")
            {
                txt_Contraseña.Text = "";
                txt_Contraseña.ForeColor = ColorTranslator.FromHtml("#3A0F3A");
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
                txt_Mat.Text.Trim(),
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

            // Validacion exitosa
            MessageBox.Show("Login exitoso", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_Mat.Text = "Ingrese su matrícula";
            txt_Contraseña.Text = "Ingrese su contraseña";

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
} 
