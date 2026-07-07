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
<<<<<<< Updated upstream
        private TurnoCL turnoCL = new TurnoCL();
        private ConcurrentesCL concurrenteCL = new ConcurrentesCL();
=======
        private bool pacienteVerificado = false;
        private bool esModoEdicion = false;
        private TurnoCL turnoLogic = new TurnoCL();
        private ConcurrentesCL concurrenteLogic = new ConcurrentesCL();
>>>>>>> Stashed changes

        public Turnos()
        {
            InitializeComponent();
        }

        private void Turnos_Load(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
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
=======
            CargarTurnos();
            LimpiarFormulario();
>>>>>>> Stashed changes
        }

        private void CargarTurnos()
        {
            try
            {
<<<<<<< Updated upstream
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
=======
                var tabla = turnoLogic.MostrarTurnos();
                if (tabla != null)
                {
                    dtg_Turnos.DataSource = tabla;
                    dtg_Turnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    if (dtg_Turnos.Columns.Contains("DNI_Concurrente"))
                        dtg_Turnos.Columns["DNI_Concurrente"].HeaderText = "DNI Paciente";
                    if (dtg_Turnos.Columns.Contains("FechaTurno"))
                        dtg_Turnos.Columns["FechaTurno"].HeaderText = "Fecha";
                    if (dtg_Turnos.Columns.Contains("HoraTurno"))
                        dtg_Turnos.Columns["HoraTurno"].HeaderText = "Hora";
>>>>>>> Stashed changes
                }
            }
            catch (Exception ex)
            {
<<<<<<< Updated upstream
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
=======
                MessageBox.Show("Error al cargar los turnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txt_DniConcurrente.Text = "";
            txt_DniConcurrente.ReadOnly = false;
            lbl_NombreConcurrente.Text = "(Buscar concurrente...)";
            dtp_Fecha.Value = DateTime.Today;
            txt_Hora.Text = "";
            pacienteVerificado = false;
            esModoEdicion = false;
            btn_Guardar.Text = "Guardar Turno";
        }

        private void btn_buscarConcurrente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DniConcurrente.Text) || !int.TryParse(txt_DniConcurrente.Text, out int dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI válido (sólo números).", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
>>>>>>> Stashed changes
            }

            try
            {
<<<<<<< Updated upstream
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
=======
                var paciente = concurrenteLogic.SeleccionarPorDni(dni);
                if (paciente != null)
                {
                    lbl_NombreConcurrente.Text = $"{paciente.Apellido_C}, {paciente.Nombre_C}";
                    pacienteVerificado = true;
                }
                else
                {
                    lbl_NombreConcurrente.Text = "No encontrado";
                    pacienteVerificado = false;
                    MessageBox.Show("El paciente con ese DNI no se encuentra registrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
>>>>>>> Stashed changes
                }
            }
            catch (Exception ex)
            {
<<<<<<< Updated upstream
                MessageBox.Show("Error al verificar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
=======
                MessageBox.Show("Error al buscar el paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> Stashed changes
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            if (!VerificarConcurrente(true))
                return;

            if (cbo_HoraTurno.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una hora para el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
=======
            if (!pacienteVerificado)
            {
                MessageBox.Show("Debe buscar y verificar un concurrente válido antes de guardar el turno.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Hora.Text))
            {
                MessageBox.Show("Por favor, ingrese la hora del turno.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
>>>>>>> Stashed changes
                return;
            }

            try
            {
<<<<<<< Updated upstream
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
=======
                int dni = int.Parse(txt_DniConcurrente.Text);
                var nuevoTurno = new TurnoCL
                {
                    DniConcurrenteTurno_C = dni,
                    FechaTurno_C = dtp_Fecha.Value.ToString("yyyy-MM-dd"),
                    HoraTurno_C = txt_Hora.Text.Trim()
                };

                turnoLogic.GuardarOModificarTurno(nuevoTurno, !esModoEdicion);
                CargarTurnos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> Stashed changes
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            if (!VerificarConcurrente(true))
                return;

            if (cbo_HoraTurno.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una hora para el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
=======
            if (dtg_Turnos.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un turno de la lista para modificar.", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
>>>>>>> Stashed changes
                return;
            }

            try
            {
<<<<<<< Updated upstream
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
=======
                var row = dtg_Turnos.CurrentRow;
                string dniStr = row.Cells["DNI_Concurrente"].Value.ToString();
                string fechaStr = row.Cells["FechaTurno"].Value.ToString();
                string horaStr = row.Cells["HoraTurno"].Value.ToString();

                txt_DniConcurrente.Text = dniStr;
                txt_DniConcurrente.ReadOnly = true;
                txt_Hora.Text = horaStr;

                if (DateTime.TryParse(fechaStr, out DateTime fecha))
                {
                    dtp_Fecha.Value = fecha;
                }

                // Simular clic de búsqueda para verificar concurrente
                btn_buscarConcurrente_Click(sender, e);

                esModoEdicion = true;
                btn_Guardar.Text = "Guardar Cambios";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos para modificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> Stashed changes
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            if (string.IsNullOrWhiteSpace(txt_DniConcurrente.Text) || !int.TryParse(txt_DniConcurrente.Text, out int dni))
            {
                MessageBox.Show("Ingrese o seleccione un DNI válido para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
=======
            if (dtg_Turnos.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un turno de la lista para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
>>>>>>> Stashed changes
                return;
            }

            var confirmResult = MessageBox.Show(
<<<<<<< Updated upstream
                "¿Está seguro que desea eliminar el turno del concurrente seleccionado?",
=======
                "¿Está seguro que desea eliminar el turno seleccionado?",
>>>>>>> Stashed changes
                "Confirmar eliminación",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.OK)
            {
                try
                {
<<<<<<< Updated upstream
                    TurnoCL delTurno = new TurnoCL { DniConcurrenteTurno_C = dni };
                    turnoCL.EliminarTurno(delTurno);
                    CargarTurnos();
                    LimpiarCampos();
=======
                    var row = dtg_Turnos.CurrentRow;
                    int dni = int.Parse(row.Cells["DNI_Concurrente"].Value.ToString());

                    var turnoAEliminar = new TurnoCL { DniConcurrenteTurno_C = dni };
                    turnoLogic.EliminarTurno(turnoAEliminar);

                    CargarTurnos();
                    LimpiarFormulario();
>>>>>>> Stashed changes
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

<<<<<<< Updated upstream
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
=======
        private void btn_Volver_Click(object sender, EventArgs e)
>>>>>>> Stashed changes
        {
            CPresentacion.Menu menu = new CPresentacion.Menu();
            menu.Show();
            this.Close();
        }

<<<<<<< Updated upstream
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

=======
>>>>>>> Stashed changes
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
