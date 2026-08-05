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
            this.Hide();
            nuevoConcurrente.ShowDialog();
            this.Show();
            CargarConcurrentes();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DniBusqueda.Text))
            {
                MessageBox.Show("Por favor, ingrese un DNI válido para buscar.");
                return;
            }

            try
            {
                var logica = new ConcurrentesCL();
                var tabla = logica.BuscarConcurrentePorDni(txt_DniBusqueda.Text.Trim());
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
                return;
            }

            try
            {
                var logica = new ConcurrentesCL();
                var tabla = logica.BuscarConcurrentePorDni(txt_DniBusqueda.Text.Trim());
                if (tabla != null)
                {
                    dtg_concurrentes.DataSource = tabla;
                }
            }
            catch (Exception)
            {
                // Silenciar errores durante la búsqueda en tiempo real
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dtg_concurrentes.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este concurrente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int dni = Convert.ToInt32(dtg_concurrentes.SelectedRows[0].Cells[0].Value);
                    var concurrente = new CLogica.ConcurrentesCL();
                    concurrente.Dni_C = dni;
                    concurrente.EliminarPorDni(concurrente);
                    MessageBox.Show("Concurrente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarConcurrentes();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un concurrente de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_inactivos_Click(object sender, EventArgs e)
        {
            var baja = new BajaConcurrente();
            baja.ShowDialog();
            CargarConcurrentes();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dtg_concurrentes.SelectedRows.Count > 0)
            {
                int dni = Convert.ToInt32(dtg_concurrentes.SelectedRows[0].Cells[0].Value);
                CPresentacion.NuevoConcurrente editForm = new CPresentacion.NuevoConcurrente(dni);
                this.Hide();
                editForm.ShowDialog();
                this.Show();
                CargarConcurrentes();
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
