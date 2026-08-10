using ConsultorioPsicopedagogico.CLogica;
using FluentValidation;
using FluentValidation.Results;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class BajaConcurrente : Form
    {
        public BajaConcurrente()
        {
            InitializeComponent();            
            dtg_Baja.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_Baja.AutoGenerateColumns = false;
            this.Load += BajaConcurrente_Load;
        }

        private void BajaConcurrente_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasGrid();
            CargarInactivos();
        }

        private void ConfigurarColumnasGrid()
        {
            dtg_Baja.Columns.Clear();
            
            if (rbtnConcurrentes.Checked)
            {
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DNI_C", HeaderText = "DNI Concurrente", Name = "DNI_C" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ApellidoNombre", HeaderText = "Apellido y Nombre", Name = "ApellidoNombre" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaNac", HeaderText = "Fecha Nacimiento", Name = "FechaNac" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Tutor", HeaderText = "Tutor", Name = "NomTutor" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DNI_Tutor", HeaderText = "DNI Tutor", Name = "DNI_Tutor" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ContactoTutor", HeaderText = "Contacto Tutor", Name = "ContactoTutor" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ObraSocial", HeaderText = "Obra Social", Name = "ObraSocial" });
            }
            else if (rbtnTutores.Checked)
            {
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "dniTutor", HeaderText = "DNI Tutor", Name = "dniTutor" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "apellido", HeaderText = "Apellido", Name = "apellido" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "nombre", HeaderText = "Nombre", Name = "nombre" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "telefono", HeaderText = "Teléfono", Name = "telefono" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "email", HeaderText = "Email", Name = "email" });
                dtg_Baja.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "obraSocial", HeaderText = "Obra Social", Name = "obraSocial" });
            }
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                txt_DniBusqueda.Clear();
                ConfigurarColumnasGrid();
                CargarInactivos();
            }
        }

        private void CargarInactivos()
        {
            DataTable tabla = null;
            if (rbtnConcurrentes.Checked)
            {
                var logica = new ConcurrentesCL();
                tabla = logica.TablaBajaConcurrente();
            }
            else if (rbtnTutores.Checked)
            {
                var logica = new TutorCL();
                tabla = logica.TablaBajaTutores();
            }
            
            dtg_Baja.DataSource = tabla;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void txt_DniBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            if (dtg_Baja.DataSource is DataTable dt)
            {
                if (string.IsNullOrWhiteSpace(txt_DniBusqueda.Text))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    if (rbtnConcurrentes.Checked)
                    {
                        dt.DefaultView.RowFilter = string.Format("CONVERT(DNI_C, System.String) LIKE '{0}%' OR CONVERT(DNI_Tutor, System.String) LIKE '{0}%'", txt_DniBusqueda.Text);
                    }
                    else if (rbtnTutores.Checked)
                    {
                        dt.DefaultView.RowFilter = string.Format("CONVERT(dniTutor, System.String) LIKE '{0}%'", txt_DniBusqueda.Text);
                    }
                }
            }
        }

        private void btn_activar_Click(object sender, EventArgs e)
        {            
            if (dtg_Baja.SelectedRows.Count > 0)
            {
                int dni = Convert.ToInt32(dtg_Baja.SelectedRows[0].Cells[0].Value);

                if (rbtnConcurrentes.Checked)
                {
                    var dniTutorCell = dtg_Baja.SelectedRows[0].Cells["DNI_Tutor"].Value;
                    if (dniTutorCell != null && dniTutorCell != DBNull.Value)
                    {
                        int dniTutor = Convert.ToInt32(dniTutorCell);
                        var tutorLogic = new CLogica.TutorCL();
                        var tutor = tutorLogic.BuscarTutor(dniTutor);
                        if (tutor == null)
                        {
                            MessageBox.Show("El tutor de este concurrente se encuentra inactivo. Para reactivar al concurrente, primero debe asignarle un tutor activo en la ventana de edición que se abrirá a continuación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            NuevoConcurrente frm = new NuevoConcurrente(dni, true);
                            frm.ShowDialog();
                            CargarInactivos();
                            return;
                        }
                    }
                }

                string entidad = rbtnConcurrentes.Checked ? "concurrente" : "tutor";
                DialogResult dialogResult = MessageBox.Show($"¿Está seguro de que desea reactivar este {entidad}?", "Confirmar Reactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (dialogResult == DialogResult.Yes)
                {
                    if (rbtnConcurrentes.Checked)
                    {
                        var concurrente = new ConcurrentesCL();
                        concurrente.Dni_C = dni;
                        concurrente.ReactivarPorDni(concurrente);
                    }
                    else if (rbtnTutores.Checked)
                    {
                        var tutor = new TutorCL();
                        tutor.DniTutor_C = dni;
                        tutor.ReactivarTutor(tutor);
                    }
                    
                    CargarInactivos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un registro de la lista para reactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_DniBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
