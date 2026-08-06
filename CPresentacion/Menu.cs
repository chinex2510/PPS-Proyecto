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
        private string _rolUsuario = "";

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(string rol)
        {
            InitializeComponent();
            _rolUsuario = rol;
            AplicarPermisosRol();
            ConfigurarEfectosHover();
        }

        private void ConfigurarEfectosHover()
        {
            AgregarEfectosHover(btnConcurrentes, Color.FromArgb(115, 35, 150), Color.FromArgb(135, 55, 170));
            AgregarEfectosHover(btn_Planes, Color.FromArgb(115, 35, 150), Color.FromArgb(135, 55, 170));
            AgregarEfectosHover(btn_Turnos, Color.FromArgb(115, 35, 150), Color.FromArgb(135, 55, 170));
            AgregarEfectosHover(btn_Tutor, Color.FromArgb(115, 35, 150), Color.FromArgb(135, 55, 170));
            AgregarEfectosHover(btn_Salir, Color.White, Color.FromArgb(240, 240, 240));
        }

        private void AgregarEfectosHover(Button btn, Color normal, Color hover)
        {
            btn.MouseEnter += (s, e) => { btn.BackColor = hover; };
            btn.MouseLeave += (s, e) => { btn.BackColor = normal; };
        }

        private void AplicarPermisosRol()
        {
            if (_rolUsuario == "Secretaria/o")
            {
                // Ocultar botones y sus iconos respectivos
                btnConcurrentes.Visible = false;
                pictureBox2.Visible = false;
                
                btn_Planes.Visible = false;
                pictureBox3.Visible = false;
                
                btn_Tutor.Visible = false;
                pictureBox4.Visible = false; // Ocultamos el icono pequeño

                // Convertir el botón de turnos en un gran panel central interactivo
                btn_Turnos.Location = new System.Drawing.Point(45, 100);
                btn_Turnos.Size = new System.Drawing.Size(280, 140);
                btn_Turnos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
                btn_Turnos.Text = "GESTIÓN DE\r\nTURNOS"; // Salto de línea para que se vea mejor
            }
        }

        private void btnConcurrentes_Click(object sender, EventArgs e)
        {
            CPresentacion.Concurrentes concurrentes = new CPresentacion.Concurrentes();
            this.Hide();
            concurrentes.ShowDialog();
            this.Show();
        }

        private void btn_Tutor_Click(object sender, EventArgs e)
        {
            CPresentacion.NuevoTutor nuevoTutor = new CPresentacion.NuevoTutor();
            this.Hide();
            nuevoTutor.ShowDialog();
            this.Show();
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
            this.Hide();
            crearInformes.ShowDialog();
            this.Show();
        }

        private void btn_Turnos_Click(object sender, EventArgs e)
        {
            CPresentacion.Turnos turnos = new CPresentacion.Turnos();
            this.Hide();
            turnos.ShowDialog();
            this.Show();
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

    }
}
