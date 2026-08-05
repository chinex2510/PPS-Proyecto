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

        private string nombrePacienteTurno_D;

        public int IdTurno_D { get => idTurno_D; set => idTurno_D = value; }
        public int DniConcurrenteTurno_D { get => dniConcurrenteTurno_D; set => dniConcurrenteTurno_D = value; }
        public int DniUsuario_D { get => dniUsuario_D; set => dniUsuario_D = value; }
        public string FechaTurno_D { get => fechaTurno_D; set => fechaTurno_D = value; }
        public string HoraTurno_D { get => horaTurno_D; set => horaTurno_D = value; }
        public string NombrePacienteTurno_D { get => nombrePacienteTurno_D; set => nombrePacienteTurno_D = value; }

        public void Guardar_Modificar_Turno(Turnos_CD turno, bool esNuevo)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = esNuevo
                        ? @"INSERT INTO Turnos (dniConcurrente, dniUsuario, fecha, hora, nombrePaciente, estado, activo)
                            VALUES (@DniConcurrente, @DniUsuario, @Fecha, @Hora, @NombrePaciente, 'Confirmado', 1)"
                        : @"UPDATE Turnos SET 
                                dniConcurrente = @DniConcurrente,
                                dniUsuario = @DniUsuario,
                                fecha = @Fecha,
                                hora = @Hora,
                                nombrePaciente = @NombrePaciente
                            WHERE idTurno = @IdTurno";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        DateTime fechaVal = DateTime.ParseExact(turno.FechaTurno_D, "dd/MM/yyyy", null);
                        TimeSpan horaVal = TimeSpan.Parse(turno.HoraTurno_D);

                        comando.Parameters.AddWithValue("@DniConcurrente", turno.DniConcurrenteTurno_D);
                        comando.Parameters.AddWithValue("@DniUsuario", turno.DniUsuario_D);
                        comando.Parameters.AddWithValue("@Fecha", fechaVal);
                        comando.Parameters.AddWithValue("@Hora", horaVal);
                        comando.Parameters.AddWithValue("@NombrePaciente", (object)turno.NombrePacienteTurno_D ?? DBNull.Value);
                        
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
                                        t.nombrePaciente AS Nombre_Concurrente,
                                        t.dniUsuario AS DNI_Especialista,
                                        u.NombreApellido AS Nombre_Especialista,
                                        DATE_FORMAT(t.fecha, '%d/%m/%Y') AS FechaTurno,
                                        TIME_FORMAT(t.hora, '%H:%i') AS HoraTurno,
                                        t.nombrePaciente,
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

        public static void VerificarYCrearEsquema()
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    // 1. Eliminar llave foránea a Concurrente para permitir registrar cualquier DNI
                    if (ExisteRestriccion(conexion, "FK_Turnos_Concurrente"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("ALTER TABLE turnos DROP FOREIGN KEY FK_Turnos_Concurrente", conexion))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 2. Agregar columna dniUsuario si no existe
                    if (!ExisteColumna(conexion, "turnos", "dniUsuario"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("ALTER TABLE turnos ADD COLUMN dniUsuario INT NULL", conexion))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        
                        // Enlazar llave foránea al especialista (usuario)
                        using (MySqlCommand cmd = new MySqlCommand(@"
                            ALTER TABLE turnos 
                            ADD CONSTRAINT FK_Turnos_Usuario 
                            FOREIGN KEY (dniUsuario) REFERENCES usuario(DNI) 
                            ON DELETE CASCADE ON UPDATE CASCADE", conexion))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 2b. Agregar columna nombrePaciente si no existe
                    if (!ExisteColumna(conexion, "turnos", "nombrePaciente"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("ALTER TABLE turnos ADD COLUMN nombrePaciente VARCHAR(150) NULL", conexion))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 3. Eliminar restricción antigua de fecha y hora única si existe
                    if (ExisteIndice(conexion, "turnos", "UQ_Turno_FechaHora"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("ALTER TABLE turnos DROP INDEX UQ_Turno_FechaHora", conexion))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 4. Crear restricción de fecha y hora única por especialista si no existe
                    if (!ExisteIndice(conexion, "turnos", "UQ_Turno_EspecialistaFechaHora"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(@"
                            ALTER TABLE turnos 
                            ADD CONSTRAINT UQ_Turno_EspecialistaFechaHora UNIQUE (dniUsuario, fecha, hora)", conexion))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 5. Crear restricción de fecha y hora única por paciente si no existe
                    if (!ExisteIndice(conexion, "turnos", "UQ_Turno_PacienteFechaHora"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(@"
                            ALTER TABLE turnos 
                            ADD CONSTRAINT UQ_Turno_PacienteFechaHora UNIQUE (dniConcurrente, fecha, hora)", conexion))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar/migrar el esquema de Turnos: " + ex.Message, 
                                "Migración de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static bool ExisteRestriccion(MySqlConnection conn, string constraintName)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
                WHERE CONSTRAINT_SCHEMA = 'PruebaLogin' AND CONSTRAINT_NAME = @name";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", constraintName);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private static bool ExisteColumna(MySqlConnection conn, string tableName, string columnName)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_SCHEMA = 'PruebaLogin' AND TABLE_NAME = @table AND COLUMN_NAME = @column";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@table", tableName);
                cmd.Parameters.AddWithValue("@column", columnName);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private static bool ExisteIndice(MySqlConnection conn, string tableName, string indexName)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM INFORMATION_SCHEMA.STATISTICS 
                WHERE TABLE_SCHEMA = 'PruebaLogin' AND TABLE_NAME = @table AND INDEX_NAME = @index";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@table", tableName);
                cmd.Parameters.AddWithValue("@index", indexName);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
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
