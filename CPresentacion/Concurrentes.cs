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
using ConsultorioPsicopedagogico.CLogica;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class Concurrentes : Form
    {
        public Concurrentes()
        {
            InitializeComponent();
            CargarConcurrentes();
        }

        private void CargarConcurrentes()
        {
            try
            {
                var logica = new ConcurrentesCL();
                var tabla = logica.MostrarTodos();
                if (tabla == null)
                {
                    MessageBox.Show("No se pudo obtener datos de la base.");
                    return;
                }
                dtg_concurrentes.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar concurrentes: " + ex.Message);
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            CPresentacion.NuevoConcurrente nuevoConcurrente = new CPresentacion.NuevoConcurrente();
            nuevoConcurrente.Show();
            this.Hide();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DniBusqueda.Text) || !int.TryParse(txt_DniBusqueda.Text, out int dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI válido para buscar.");
                return;
            }

            try
            {
                var logica = new ConcurrentesCL();
                var tabla = logica.BuscarConcurrentePorDni(dni);
                if (tabla == null || tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados.");
                    return;
                }
                dtg_concurrentes.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private void txt_DniBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DniBusqueda.Text))
            {
                CargarConcurrentes();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            var baja = new BajaConcurrente();
            baja.ShowDialog();
            CargarConcurrentes();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            CPresentacion.Menu menu = new CPresentacion.Menu();
            menu.Show();
            this.Close();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dtg_concurrentes.SelectedRows.Count > 0)
            {
                // Si hay una fila seleccionada, podríamos cargar los datos en NuevoConcurrente.
                // Como NuevoConcurrente no recibe parámetros y se autogestiona, simplemente lo abrimos.
                CPresentacion.NuevoConcurrente editForm = new CPresentacion.NuevoConcurrente();
                editForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un concurrente en la lista para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
