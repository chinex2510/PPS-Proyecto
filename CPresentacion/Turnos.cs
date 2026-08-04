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

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class Turnos : Form
    {
        private TurnoCL turnoCL = new TurnoCL();
        private ConcurrentesCL concurrenteCL = new ConcurrentesCL();

        public Turnos()
        {
            InitializeComponent();
        }

        private void Turnos_Load(object sender, EventArgs e)
        {
            CargarHoras();
            CargarTurnos();
            LimpiarCampos();
        }

        private void CargarHoras()
        {
            cbo_HoraTurno.Items.Clear();
            string[] horas = {
                "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30",
                "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30",
                "16:00", "16:30", "17:00", "17:30", "18:00"
            };
            foreach (var h in horas)
            {
                cbo_HoraTurno.Items.Add(h);
            }
            if (cbo_HoraTurno.Items.Count > 0)
                cbo_HoraTurno.SelectedIndex = 0;
        }

        private void CargarTurnos()
        {
            try
            {
                DataTable dt = turnoCL.MostrarTurnos();
                if (dt != null)
                {
                    dtg_turnos.DataSource = dt;
                    // Format headers and widths if columns exist
                    if (dtg_turnos.Columns.Contains("DNI_Concurrente"))
                    {
                        dtg_turnos.Columns["DNI_Concurrente"].HeaderText = "DNI Paciente";
                        dtg_turnos.Columns["DNI_Concurrente"].Width = 120;
                    }
                    if (dtg_turnos.Columns.Contains("FechaTurno"))
                    {
                        dtg_turnos.Columns["FechaTurno"].HeaderText = "Fecha";
                        dtg_turnos.Columns["FechaTurno"].Width = 140;
                    }
                    if (dtg_turnos.Columns.Contains("HoraTurno"))
                    {
                        dtg_turnos.Columns["HoraTurno"].HeaderText = "Hora";
                        dtg_turnos.Columns["HoraTurno"].Width = 120;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar listado de turnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_verificarConcurrente_Click(object sender, EventArgs e)
        {
            VerificarConcurrente(true);
        }

        private bool VerificarConcurrente(bool mostrarMensajeNoEncontrado)
        {
            if (string.IsNullOrWhiteSpace(txt_DniConcurrente.Text) || !int.TryParse(txt_DniConcurrente.Text, out int dni))
            {
                lbl_NombreConcurrente.Text = "DNI Inválido";
                lbl_NombreConcurrente.ForeColor = Color.Red;
                if (mostrarMensajeNoEncontrado)
                    MessageBox.Show("Ingrese un DNI numérico válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                var paciente = concurrenteCL.SeleccionarPorDni(dni);
                if (paciente != null)
                {
                    lbl_NombreConcurrente.Text = $"{paciente.Apellido_C}, {paciente.Nombre_C}";
                    lbl_NombreConcurrente.ForeColor = Color.FromArgb(90, 25, 120);
                    return true;
                }
                else
                {
                    lbl_NombreConcurrente.Text = "Paciente no encontrado";
                    lbl_NombreConcurrente.ForeColor = Color.Red;
                    if (mostrarMensajeNoEncontrado)
                        MessageBox.Show("El concurrente con el DNI ingresado no existe en la base de datos.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!VerificarConcurrente(true))
                return;

            if (cbo_HoraTurno.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una hora para el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TurnoCL nuevoTurno = new TurnoCL
                {
                    DniConcurrenteTurno_C = int.Parse(txt_DniConcurrente.Text),
                    FechaTurno_C = dtp_FechaTurno.Value.ToString("dd/MM/yyyy"),
                    HoraTurno_C = cbo_HoraTurno.SelectedItem.ToString()
                };

                turnoCL.GuardarOModificarTurno(nuevoTurno, true);
                CargarTurnos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (!VerificarConcurrente(true))
                return;

            if (cbo_HoraTurno.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una hora para el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TurnoCL modTurno = new TurnoCL
                {
                    DniConcurrenteTurno_C = int.Parse(txt_DniConcurrente.Text),
                    FechaTurno_C = dtp_FechaTurno.Value.ToString("dd/MM/yyyy"),
                    HoraTurno_C = cbo_HoraTurno.SelectedItem.ToString()
                };

                turnoCL.GuardarOModificarTurno(modTurno, false);
                CargarTurnos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DniConcurrente.Text) || !int.TryParse(txt_DniConcurrente.Text, out int dni))
            {
                MessageBox.Show("Ingrese o seleccione un DNI válido para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                "¿Está seguro que desea eliminar el turno del concurrente seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.OK)
            {
                try
                {
                    TurnoCL delTurno = new TurnoCL { DniConcurrenteTurno_C = dni };
                    turnoCL.EliminarTurno(delTurno);
                    CargarTurnos();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txt_DniConcurrente.Clear();
            txt_DniConcurrente.Enabled = true;
            lbl_NombreConcurrente.Text = "Paciente no verificado";
            lbl_NombreConcurrente.ForeColor = Color.FromArgb(120, 60, 160);
            dtp_FechaTurno.Value = DateTime.Today;
            if (cbo_HoraTurno.Items.Count > 0)
                cbo_HoraTurno.SelectedIndex = 0;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            CPresentacion.Menu menu = new CPresentacion.Menu();
            menu.Show();
            this.Close();
        }


        private void dtg_turnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtg_turnos.Rows[e.RowIndex];
                if (row.Cells["DNI_Concurrente"].Value != null)
                {
                    txt_DniConcurrente.Text = row.Cells["DNI_Concurrente"].Value.ToString();
                    txt_DniConcurrente.Enabled = false; // Bloquear DNI para evitar modificación accidental de llave primaria

                    if (row.Cells["FechaTurno"].Value != null)
                    {
                        string fechaStr = row.Cells["FechaTurno"].Value.ToString();
                        if (DateTime.TryParse(fechaStr, out DateTime f))
                        {
                            dtp_FechaTurno.Value = f;
                        }
                    }

                    if (row.Cells["HoraTurno"].Value != null)
                    {
                        cbo_HoraTurno.Text = row.Cells["HoraTurno"].Value.ToString();
                    }

                    VerificarConcurrente(false);
                }
            }
        }


        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
