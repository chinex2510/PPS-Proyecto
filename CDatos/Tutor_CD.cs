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
    internal class Tutor_CD
    {
        private int dniTutor_D;
        private string apellidoTutor_D;
        private string nombreTutor_D;
        private string parentezcoTutor_D;
        private string telefonoTutor_D;
        private string emailTutor_D;

        public int DniTutor_D { get => dniTutor_D; set => dniTutor_D = value; }
        public string ApellidoTutor_D { get => apellidoTutor_D; set => apellidoTutor_D = value; }
        public string NombreTutor_D { get => nombreTutor_D; set => nombreTutor_D = value; }
        public string ParentezcoTutor_D { get => parentezcoTutor_D; set => parentezcoTutor_D = value; }
        public string TelefonoTutor_D { get => telefonoTutor_D; set => telefonoTutor_D = value; }
        public string EmailTutor_D { get => emailTutor_D; set => emailTutor_D = value; }

        public void Guardar_Modificar_Tutor(Tutor_CD tutor, bool esNuevo)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = esNuevo
                        ? @"INSERT INTO Tutores (DNI_Tutor, Apellido, Nombre, Parentezco, Telefono, Email)
                   VALUES (@Dni, @Apellido, @Nombre, @Parentezco, @Telefono, @Email)"
                        : @"UPDATE Tutores SET 
                        Apellido = @Apellido,
                        Nombre = @Nombre,
                        Parentezco = @Parentezco,
                        Telefono = @Telefono,
                        Email = @Email
                   WHERE DNI_Tutor = @Dni";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", tutor.DniTutor_D);
                        comando.Parameters.AddWithValue("@Apellido", tutor.ApellidoTutor_D);
                        comando.Parameters.AddWithValue("@Nombre", tutor.NombreTutor_D);
                        comando.Parameters.AddWithValue("@Parentezco", tutor.ParentezcoTutor_D);
                        comando.Parameters.AddWithValue("@Telefono", tutor.TelefonoTutor_D);
                        comando.Parameters.AddWithValue("@Email", tutor.EmailTutor_D);

                        comando.ExecuteNonQuery();
                    }

                    string mensaje = esNuevo ? "Tutor registrado exitosamente" : "Datos del tutor actualizados exitosamente";
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar o modificar el tutor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarTutor(Tutor_CD tutor)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = "DELETE FROM Tutores WHERE DNI_Tutor = @Dni";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", tutor.DniTutor_D);
                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Tutor eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el tutor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Tutor_CD SelectorTutor(int dni)
        {
            try
            {
                Tutor_CD tutor = null;

                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Tutores WHERE DNI_Tutor = @Dni";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", dni);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tutor = new Tutor_CD
                                {
                                    DniTutor_D = Convert.ToInt32(reader["DNI_Tutor"]),
                                    ApellidoTutor_D = reader["Apellido"].ToString(),
                                    NombreTutor_D = reader["Nombre"].ToString(),
                                    ParentezcoTutor_D = reader["Parentezco"].ToString(),
                                    TelefonoTutor_D = reader["Telefono"].ToString(),
                                    EmailTutor_D = reader["Email"].ToString()
                                };
                            }
                        }
                    }
                }

                return tutor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el tutor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable TablaTutores()
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = "SELECT * FROM Tutores";
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
                MessageBox.Show("Error al cargar los tutores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        // Método para buscar tutores por DNI, o por nombre o apellido

        //public DataTable BuscarTutores(int? dni, string texto)
        //{
        //    try
        //    {
        //        using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
        //        {
        //            conexion.Open();

        //            string query = @"
        //        SELECT * FROM Tutores 
        //        WHERE 
        //            (@Dni IS NULL OR DNI_Tutor = @Dni) AND 
        //            (Apellido LIKE @Texto OR Nombre LIKE @Texto)";

        //            using (MySqlCommand comando = new MySqlCommand(query, conexion))
        //            {
        //                comando.Parameters.AddWithValue("@Dni", dni.HasValue ? dni.Value : (object)DBNull.Value);
        //                comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");

        //                using (MySqlDataReader reader = comando.ExecuteReader())
        //                {
        //                    DataTable tabla = new DataTable();
        //                    tabla.Load(reader);
        //                    return tabla;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al buscar tutores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

    }
}
