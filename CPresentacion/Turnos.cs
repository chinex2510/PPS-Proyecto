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
        private int idTurnoSeleccionado = 0;

        public Turnos()
        {
            InitializeComponent();
        }

        private void Turnos_Load(object sender, EventArgs e)
        {
            
            

            CargarEspecialistas();

            // Configurar combo de filtro de fechas
            cbo_FiltroFecha.Items.Clear();
            cbo_FiltroFecha.Items.Add("Todos");
            cbo_FiltroFecha.Items.Add("Próximos 15 días");
            cbo_FiltroFecha.Items.Add("Próximos 30 días");
            cbo_FiltroFecha.Items.Add("Próximos 60 días");
            cbo_FiltroFecha.SelectedIndex = 0;

            // Suscribir eventos antes de inicializar para que cargue las horas automáticamente
            cbo_Especialista.SelectedIndexChanged += (s, ev) => ActualizarHorasDisponibles();
            dtp_FechaTurno.ValueChanged += (s, ev) => ActualizarHorasDisponibles();
            cbo_FiltroFecha.SelectedIndexChanged += (s, ev) => FiltrarTurnos();

            CargarTurnos();
            LimpiarCampos();
            lbl_NombreConcurrente.Visible = false;
        }

        private void CargarEspecialistas()
        {
            try
            {
                UsuarioCL usuarioLogica = new UsuarioCL();
                DataTable dt = usuarioLogica.ObtenerEspecialistas();

                if (dt != null && dt.Rows.Count > 0)
                {
                    cbo_Especialista.DataSource = dt;
                    cbo_Especialista.DisplayMember = "NombreApellido";
                    cbo_Especialista.ValueMember = "DNI";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialistas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarHorasDisponibles()
        {
            if (cbo_Especialista.SelectedValue == null || !int.TryParse(cbo_Especialista.SelectedValue.ToString(), out int dniEspecialista))
            {
                cbo_HoraTurno.DataSource = null;
                return;
            }

            try
            {
                string fecha = dtp_FechaTurno.Value.ToString("dd/MM/yyyy");
                List<string> horasLibres = turnoCL.ObtenerHorasDisponibles(dniEspecialista, fecha);

                // Si estamos editando un turno existente, el horario actualmente seleccionado
                // para ese turno debe mostrarse disponible aunque esté ocupado en la BD.
                if (idTurnoSeleccionado > 0 && dtg_turnos.CurrentRow != null)
                {
                    DataGridViewRow row = dtg_turnos.CurrentRow;
                    if (row.Cells["DNI_Especialista"].Value != null && row.Cells["FechaTurno"].Value != null && row.Cells["HoraTurno"].Value != null)
                    {
                        int currentDniEsp = Convert.ToInt32(row.Cells["DNI_Especialista"].Value);
                        string currentFecha = row.Cells["FechaTurno"].Value.ToString();
                        string currentHora = row.Cells["HoraTurno"].Value.ToString();

                        if (currentDniEsp == dniEspecialista && currentFecha == fecha)
                        {
                            if (!horasLibres.Contains(currentHora))
                            {
                                horasLibres.Add(currentHora);
                                horasLibres.Sort();
                            }
                        }
                    }
                }

                cbo_HoraTurno.DataSource = horasLibres;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar horarios disponibles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTurnos()
        {
            try
            {
                DataTable dt = turnoCL.MostrarTurnos();
                if (dt != null)
                {
                    dtg_turnos.DataSource = dt;
                    
                    if (dtg_turnos.Columns.Contains("idTurno"))
                    {
                        dtg_turnos.Columns["idTurno"].Visible = false;
                    }
                    if (dtg_turnos.Columns.Contains("DNI_Concurrente"))
                    {
                        dtg_turnos.Columns["DNI_Concurrente"].HeaderText = "DNI Concurrente";
                        dtg_turnos.Columns["DNI_Concurrente"].Width = 100;
                    }
                    if (dtg_turnos.Columns.Contains("Nombre_Concurrente"))
                    {
                        dtg_turnos.Columns["Nombre_Concurrente"].HeaderText = "Nombre Concurrente";
                        dtg_turnos.Columns["Nombre_Concurrente"].Width = 140;
                    }
                    if (dtg_turnos.Columns.Contains("DNI_Especialista"))
                    {
                        dtg_turnos.Columns["DNI_Especialista"].Visible = false;
                    }
                    if (dtg_turnos.Columns.Contains("Nombre_Especialista"))
                    {
                        dtg_turnos.Columns["Nombre_Especialista"].HeaderText = "Especialista";
                        dtg_turnos.Columns["Nombre_Especialista"].Width = 140;
                    }
                    if (dtg_turnos.Columns.Contains("FechaTurno"))
                    {
                        dtg_turnos.Columns["FechaTurno"].HeaderText = "Fecha";
                        dtg_turnos.Columns["FechaTurno"].Width = 100;
                    }
                    if (dtg_turnos.Columns.Contains("HoraTurno"))
                    {
                        dtg_turnos.Columns["HoraTurno"].HeaderText = "Hora";
                        dtg_turnos.Columns["HoraTurno"].Width = 80;
                    }
                    if (dtg_turnos.Columns.Contains("nombreConcurrente"))
                    {
                        dtg_turnos.Columns["nombreConcurrente"].Visible = false;
                    }
                    if (dtg_turnos.Columns.Contains("FechaRaw"))
                    {
                        dtg_turnos.Columns["FechaRaw"].Visible = false;
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
            if (string.IsNullOrWhiteSpace(txt_DniConcurrente.Text) || !int.TryParse(txt_DniConcurrente.Text, out int _))
            {
                MessageBox.Show("Ingrese un DNI numérico válido para buscar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FiltrarTurnos();
        }

        private bool ValidarInputs()
        {
            if (string.IsNullOrWhiteSpace(txt_DniConcurrente.Text) || !int.TryParse(txt_DniConcurrente.Text, out int _))
            {
                MessageBox.Show("Ingrese un DNI numérico válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_NombreConcurrente.Text))
            {
                MessageBox.Show("Ingrese el nombre completo del concurrente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarInputs())
                return;

            if (cbo_Especialista.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un especialista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                    DniUsuario_C = Convert.ToInt32(cbo_Especialista.SelectedValue),
                    FechaTurno_C = dtp_FechaTurno.Value.ToString("dd/MM/yyyy"),
                    HoraTurno_C = cbo_HoraTurno.SelectedItem.ToString(),
                    NombreConcurrenteTurno_C = txt_NombreConcurrente.Text.Trim()
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
            if (idTurnoSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un turno de la lista para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarInputs())
                return;

            if (cbo_Especialista.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un especialista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbo_HoraTurno.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una hora para el turno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TurnoCL modTurno = new TurnoCL
                {
                    IdTurno_C = idTurnoSeleccionado,
                    DniConcurrenteTurno_C = int.Parse(txt_DniConcurrente.Text),
                    DniUsuario_C = Convert.ToInt32(cbo_Especialista.SelectedValue),
                    FechaTurno_C = dtp_FechaTurno.Value.ToString("dd/MM/yyyy"),
                    HoraTurno_C = cbo_HoraTurno.SelectedItem.ToString(),
                    NombreConcurrenteTurno_C = txt_NombreConcurrente.Text.Trim()
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
            if (idTurnoSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un turno de la lista para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                "¿Está seguro que desea eliminar el turno seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.OK)
            {
                try
                {
                    TurnoCL delTurno = new TurnoCL { IdTurno_C = idTurnoSeleccionado };
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
            idTurnoSeleccionado = 0;
            txt_DniConcurrente.Clear();
            txt_DniConcurrente.Enabled = true;
            txt_NombreConcurrente.Clear();
            txt_NombreConcurrente.Enabled = true;
            lbl_NombreConcurrente.Text = "Concurrente no verificado";
            lbl_NombreConcurrente.ForeColor = Color.FromArgb(120, 60, 160);
            
            // Restringir fechas: mínimo mañana, máximo 6 meses a futuro
            dtp_FechaTurno.MinDate = DateTime.Today.AddDays(1);
            dtp_FechaTurno.MaxDate = DateTime.Today.AddMonths(6);
            dtp_FechaTurno.Value = DateTime.Today.AddDays(1);

            if (cbo_Especialista.Items.Count > 0)
                cbo_Especialista.SelectedIndex = 0;

            if (cbo_FiltroFecha.Items.Count > 0)
                cbo_FiltroFecha.SelectedIndex = 0;

            ActualizarHorasDisponibles();

            btn_Guardar.Enabled = true;
            btn_Modificar.Enabled = false;
            btn_Eliminar.Enabled = false;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtg_turnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtg_turnos.Rows[e.RowIndex];
                if (row.Cells["idTurno"].Value != null)
                {
                    idTurnoSeleccionado = Convert.ToInt32(row.Cells["idTurno"].Value);
                    txt_DniConcurrente.Text = row.Cells["DNI_Concurrente"].Value.ToString();
                    txt_DniConcurrente.Enabled = false; // Bloquear DNI al editar

                    if (row.Cells["nombreConcurrente"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["nombreConcurrente"].Value.ToString()))
                    {
                        txt_NombreConcurrente.Text = row.Cells["nombreConcurrente"].Value.ToString();
                    }
                    else
                    {
                        txt_NombreConcurrente.Text = "";
                    }
                    txt_NombreConcurrente.Enabled = true;

                    if (row.Cells["DNI_Especialista"].Value != null)
                    {
                        cbo_Especialista.SelectedValue = Convert.ToInt32(row.Cells["DNI_Especialista"].Value);
                    }

                    if (row.Cells["FechaTurno"].Value != null)
                    {
                        string fechaStr = row.Cells["FechaTurno"].Value.ToString();
                        if (DateTime.TryParse(fechaStr, out DateTime f))
                        {
                            // Permitir la fecha del turno seleccionado aunque sea en el pasado/hoy
                            dtp_FechaTurno.MinDate = f < DateTime.Today.AddDays(1) ? f : DateTime.Today.AddDays(1);
                            // MaxDate siempre 6 meses desde hoy, o la fecha del turno si está más allá
                            dtp_FechaTurno.MaxDate = f > DateTime.Today.AddMonths(6) ? f : DateTime.Today.AddMonths(6);
                            dtp_FechaTurno.Value = f;
                        }
                    }

                    // Forzar recarga de horas ocupadas/libres
                    ActualizarHorasDisponibles();

                    if (row.Cells["HoraTurno"].Value != null)
                    {
                        cbo_HoraTurno.Text = row.Cells["HoraTurno"].Value.ToString();
                    }

                    btn_Guardar.Enabled = false;
                    btn_Modificar.Enabled = true;
                    btn_Eliminar.Enabled = true;
                }
            }
        }

        private void FiltrarTurnos()
        {
            if (!(dtg_turnos.DataSource is DataTable dt))
                return;

            List<string> filters = new List<string>();

            // 1. Filtro por DNI (se aplica si no se está editando un registro específico)
            if (idTurnoSeleccionado <= 0 && !string.IsNullOrWhiteSpace(txt_DniConcurrente.Text))
            {
                string dniText = new string(txt_DniConcurrente.Text.Where(char.IsDigit).ToArray());
                if (!string.IsNullOrEmpty(dniText))
                {
                    filters.Add($"Convert(DNI_Concurrente, 'System.String') LIKE '*{dniText}*'");
                }
            }

            // 2. Filtro por Rango de Fechas
            if (cbo_FiltroFecha.SelectedIndex > 0)
            {
                DateTime fechaInicio = DateTime.Today;
                DateTime? fechaFin = null;

                switch (cbo_FiltroFecha.SelectedIndex)
                {
                    case 1: // Próximos 15 días
                        fechaFin = DateTime.Today.AddDays(15);
                        break;
                    case 2: // Próximos 30 días
                        fechaFin = DateTime.Today.AddDays(30);
                        break;
                    case 3: // Próximos 60 días
                        fechaFin = DateTime.Today.AddDays(60);
                        break;
                }

                if (fechaFin.HasValue)
                {
                    string strInicio = fechaInicio.ToString("yyyy-MM-dd");
                    string strFin = fechaFin.Value.ToString("yyyy-MM-dd");
                    filters.Add($"FechaRaw >= #{strInicio}# AND FechaRaw <= #{strFin}#");
                }
            }

            // Combinar y aplicar los filtros
            if (filters.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Join(" AND ", filters);
            }
            else
            {
                dt.DefaultView.RowFilter = "";
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
