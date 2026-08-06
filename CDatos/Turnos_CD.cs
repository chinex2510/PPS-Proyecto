using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultorioPsicopedagogico.CDatos;
using ConsultorioPsicopedagogico.CLogica;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ConsultorioPsicopedagogico.CDatos
{
    internal class Turnos_CD
    {
        private int idTurno_D;
        private int dniConcurrenteTurno_D;
        private int dniUsuario_D;
        private string fechaTurno_D;
        private string horaTurno_D;

        private string nombreConcurrenteTurno_D;

        public int IdTurno_D { get => idTurno_D; set => idTurno_D = value; }
        public int DniConcurrenteTurno_D { get => dniConcurrenteTurno_D; set => dniConcurrenteTurno_D = value; }
        public int DniUsuario_D { get => dniUsuario_D; set => dniUsuario_D = value; }
        public string FechaTurno_D { get => fechaTurno_D; set => fechaTurno_D = value; }
        public string HoraTurno_D { get => horaTurno_D; set => horaTurno_D = value; }
        public string NombreConcurrenteTurno_D { get => nombreConcurrenteTurno_D; set => nombreConcurrenteTurno_D = value; }

        public void Guardar_Modificar_Turno(Turnos_CD turno, bool esNuevo)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = esNuevo
                        ? @"INSERT INTO Turnos (dniConcurrente, dniUsuario, fecha, hora, nombreConcurrente, estado, activo)
                            VALUES (@DniConcurrente, @DniUsuario, @Fecha, @Hora, @NombreConcurrente, 'Confirmado', 1)"
                        : @"UPDATE Turnos SET 
                                dniConcurrente = @DniConcurrente,
                                dniUsuario = @DniUsuario,
                                fecha = @Fecha,
                                hora = @Hora,
                                nombreConcurrente = @NombreConcurrente
                            WHERE idTurno = @IdTurno";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        DateTime fechaVal = DateTime.ParseExact(turno.FechaTurno_D, "dd/MM/yyyy", null);
                        TimeSpan horaVal = TimeSpan.Parse(turno.HoraTurno_D);

                        comando.Parameters.AddWithValue("@DniConcurrente", turno.DniConcurrenteTurno_D);
                        comando.Parameters.AddWithValue("@DniUsuario", turno.DniUsuario_D);
                        comando.Parameters.AddWithValue("@Fecha", fechaVal);
                        comando.Parameters.AddWithValue("@Hora", horaVal);
                        comando.Parameters.AddWithValue("@NombreConcurrente", (object)turno.NombreConcurrenteTurno_D ?? DBNull.Value);
                        
                        if (!esNuevo)
                        {
                            comando.Parameters.AddWithValue("@IdTurno", turno.IdTurno_D);
                        }

                        comando.ExecuteNonQuery();
                    }

                    string mensaje = esNuevo ? "Turno registrado exitosamente" : "Turno modificado exitosamente";
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar/modificar el turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarTurno(Turnos_CD turno)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = "UPDATE Turnos SET activo = 0 WHERE idTurno = @IdTurno";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdTurno", turno.IdTurno_D);
                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Turno eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable TablaTurnos()
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = @"SELECT 
                                        t.idTurno,
                                        t.dniConcurrente AS DNI_Concurrente,
                                        t.nombreConcurrente AS Nombre_Concurrente,
                                        t.dniUsuario AS DNI_Especialista,
                                        u.NombreApellido AS Nombre_Especialista,
                                        DATE_FORMAT(t.fecha, '%d/%m/%Y') AS FechaTurno,
                                        TIME_FORMAT(t.hora, '%H:%i') AS HoraTurno,
                                        t.nombreConcurrente,
                                        t.fecha AS FechaRaw
                                    FROM Turnos t
                                    INNER JOIN usuario u ON t.dniUsuario = u.DNI
                                    WHERE t.activo = 1
                                    ORDER BY t.fecha ASC, t.hora ASC";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        DataTable tabla = new DataTable();
                        tabla.Load(reader);
                        return tabla;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los turnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Obtiene todas las horas ocupadas para un especialista en una fecha determinada.
        /// </summary>
        public List<string> ObtenerHorasOcupadas(int dniEspecialista, string fecha)
        {
            List<string> horas = new List<string>();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT TIME_FORMAT(hora, '%H:%i') FROM Turnos WHERE dniUsuario = @DniEspecialista AND fecha = @Fecha AND activo = 1";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        DateTime fechaVal = DateTime.ParseExact(fecha, "dd/MM/yyyy", null);
                        comando.Parameters.AddWithValue("@DniEspecialista", dniEspecialista);
                        comando.Parameters.AddWithValue("@Fecha", fechaVal);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                horas.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener horas ocupadas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return horas;
        }


        // Método que retorna una tabla con todos los turnos incluyendo datos del concurrente y su tutor
        // Fecha, Hora, Nombre y Apellido del concurrente, Obra Social, Nombre del Tutor y Teléfono del Tutor

        //public DataTable ObtenerTurnosConDatos()
        //{
        //    try
        //    {
        //        using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
        //        {
        //            conexion.Open();

        //            string consulta = @"
        //        SELECT 
        //            t.Fecha, 
        //            t.Hora, 
        //            c.Nombre AS Nombre_Concurrente, 
        //            c.Apellido AS Apellido_Concurrente, 
        //            c.Obrasocial, 
        //            tu.Nombre AS Nombre_Tutor, 
        //            tu.Apellido AS Apellido_Tutor, 
        //            tu.Telefono 
        //        FROM Turnos t
        //        JOIN Concurrentes c ON t.DNI_C = c.DNI_C
        //        JOIN Tutor tu ON c.DNI_Tutor = tu.DNI_Tutor";

        //            MySqlCommand comando = new MySqlCommand(consulta, conexion);
        //            MySqlDataReader leerFilas = comando.ExecuteReader();

        //            DataTable tablaSQL = new DataTable();
        //            tablaSQL.Load(leerFilas);

        //            return tablaSQL;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al obtener los turnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}


        //----------------------------------------------------------------------------------



        // Método que retorna la cantidad de turnos de el dia actual
        // Como se usa: ObtenerCantidadTurnosPorFecha(DateTime.Today);

        //public int ObtenerCantidadTurnosPorFecha(DateTime fecha)
        //{
        //    try
        //    {
        //        using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
        //        {
        //            conexion.Open();

        //            string consulta = @"
        //        SELECT COUNT(*) AS Total_Turnos
        //        FROM Turnos
        //        WHERE Fecha = @fecha";

        //            MySqlCommand comando = new MySqlCommand(consulta, conexion);
        //            comando.Parameters.AddWithValue("@fecha", fecha.ToString("yyyy-MM-dd"));

        //            int totalTurnos = Convert.ToInt32(comando.ExecuteScalar());
        //            return totalTurnos;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al obtener la cantidad de turnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return -1;
        //    }
        //}

    }
}
