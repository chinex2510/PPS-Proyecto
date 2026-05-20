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
        private int dniConcurrenteTurno_D;
        private string fechaTurno_D;
        private string horaTurno_D;

        public int DniConcurrenteTurno_D { get => dniConcurrenteTurno_D; set => dniConcurrenteTurno_D = value; }
        public string FechaTurno_D { get => fechaTurno_D; set => fechaTurno_D = value; }
        public string HoraTurno_D { get => horaTurno_D; set => horaTurno_D = value; }

        public void Guardar_Modificar_Turno(Turnos_CD turno, bool esNuevo)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = esNuevo
                        ? @"INSERT INTO Turnos (DNI_Concurrente, FechaTurno, HoraTurno)
                   VALUES (@Dni, @Fecha, @Hora)"
                        : @"UPDATE Turnos SET 
                        FechaTurno = @Fecha,
                        HoraTurno = @Hora
                   WHERE DNI_Concurrente = @Dni";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", turno.DniConcurrenteTurno_D);
                        comando.Parameters.AddWithValue("@Fecha", turno.FechaTurno_D);
                        comando.Parameters.AddWithValue("@Hora", turno.HoraTurno_D);

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

                    string query = "DELETE FROM Turnos WHERE DNI_Concurrente = @Dni";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", turno.DniConcurrenteTurno_D);
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

                    string query = "SELECT * FROM Turnos";

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
