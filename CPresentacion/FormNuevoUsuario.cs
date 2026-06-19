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
    public partial class FormNuevoUsuario : Form
    {
        public FormNuevoUsuario()
        {
            InitializeComponent();
            this.ActiveControl = panelDerecho;
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
            Application.Exit();//Cambiar metodo para regresar al formulario previo
        }
    }
}
