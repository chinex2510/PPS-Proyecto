using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultorioPsicopedagogico.CPresentacion;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnConcurrentes_Click(object sender, EventArgs e)
        {
            CPresentacion.Concurrentes concurrentes = new CPresentacion.Concurrentes();
            concurrentes.Show();
            this.Hide();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblmin2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Planes_Click(object sender, EventArgs e)
        {
            CPresentacion.CrearInformes crearInformes = new CPresentacion.CrearInformes();
            crearInformes.Show();
            this.Hide();
        }

        private void btn_Turnos_Click(object sender, EventArgs e)
        {
            CPresentacion.Turnos turnos = new CPresentacion.Turnos();
            turnos.Show();
            this.Hide();
        }
<<<<<<< Updated upstream

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
=======
>>>>>>> Stashed changes
    }
}
