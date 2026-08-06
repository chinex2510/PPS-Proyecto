using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using ConsultorioPsicopedagogico.CLogica;
using ConsultorioPsicopedagogico.CPresentacion;

namespace ConsultorioPsicopedagogico.CDatos
{
    internal class Informes_CD
    {
        private int id_Informe_D;
        private int dni_C_D;
        private string fecha_Informe_D;
        private Concurrentes_CD concurrente_D;
        private Tutor_CD tutor_D;
        public int Id_Informe_D { get => id_Informe_D; set => id_Informe_D = value; }
        public int Dni_C_D { get => dni_C_D; set => dni_C_D = value; }
        public string Fecha_Informe_D { get => fecha_Informe_D; set => fecha_Informe_D = value; }
        public Concurrentes_CD Concurrente_D { get => concurrente_D; set => concurrente_D = value; }
        public Tutor_CD Tutor_D { get => tutor_D; set => tutor_D = value; }

        private string connectionString = Conexion.ConnectionString;

        public bool CargarInformeCompleto(int idInforme)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT i.idInforme AS ID_Informe, i.fechaInforme AS Fecha_Informe,
                                c.dniConcurrente AS DNI_C, c.apellido AS Apellido, c.nombre AS Nombre, c.fechaNacimiento AS FechaNac, c.diagnostico AS Diagnostico, c.escuela AS Escuela, c.anioEscolar AS AñoEscolar, c.nivelEscolar AS NivelEscolar, c.domicilio AS Domicilio,
                                t.dniTutor AS DNI_Tutor, t.apellido AS ApellidoTutor, t.nombre AS NombreTutor, t.telefono AS Telefono, t.email AS Email, t.obraSocial AS Obrasocial,
                               p.relacion AS Parentesco
                        FROM Informe i
                        JOIN Concurrente c ON i.dniConcurrente = c.dniConcurrente
                        LEFT JOIN Parentesco p ON c.dniConcurrente = p.dniConcurrente
                        LEFT JOIN Tutor t ON p.dniTutor = t.dniTutor
                        WHERE i.idInforme = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", idInforme);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read()) return false;

                            id_Informe_D = reader.GetInt32("ID_Informe");
                            fecha_Informe_D = reader.GetDateTime("Fecha_Informe").ToString("yyyy-MM-dd");
                            dni_C_D = reader.GetInt32("DNI_C");

                            concurrente_D = new Concurrentes_CD
                            {
                                Dni_D = reader.GetInt32("DNI_C"),
                                Apellido_D = reader.GetString("Apellido"),
                                Nombre_D = reader.GetString("Nombre"),
                                FechaNac_D = reader.GetDateTime("FechaNac").ToString("yyyy-MM-dd"),
                                Diagnostico_D = reader["Diagnostico"].ToString(),
                                Escuela_D = reader["Escuela"].ToString(),
                                AñoEscolar_D = Convert.ToInt32(reader["AñoEscolar"]),
                                NivelEscolar_D = reader["NivelEscolar"].ToString(),
                                Domicilio_D = reader["Domicilio"].ToString()
                            };

                            tutor_D = new Tutor_CD
                            {
                                DniTutor_D = reader.IsDBNull(reader.GetOrdinal("DNI_Tutor")) ? 0 : reader.GetInt32("DNI_Tutor"),
                                ApellidoTutor_D = reader["ApellidoTutor"].ToString(),
                                NombreTutor_D = reader["NombreTutor"].ToString(),
                                ParentezcoTutor_D = reader["Parentesco"].ToString(),
                                TelefonoTutor_D = reader["Telefono"].ToString(),
                                EmailTutor_D = reader["Email"].ToString(),
                                Obrasocial_D = reader["Obrasocial"].ToString()
                            };
                        }
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar el informe: " + ex.Message, ex);
            }
        }

        public void GuardarInforme(int idConcurrente, string titulo, string rutaWord, string fecha)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO Informe (idConcurrente, fechaInforme, titulo, rutaWord)
                        VALUES (@idConcurrente, @fecha, @titulo, @rutaWord)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idConcurrente", idConcurrente);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@titulo", titulo);
                        cmd.Parameters.AddWithValue("@rutaWord", rutaWord);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el informe en la base de datos: " + ex.Message, ex);
            }
        }

        public DataTable ObtenerInformesPorDni(string dni)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT i.idInforme, DATE_FORMAT(i.fechaInforme, '%d/%m/%Y') AS Fecha, i.titulo AS Título, i.rutaWord AS Ruta
                        FROM Informe i
                        JOIN Concurrente c ON i.idConcurrente = c.idConcurrente
                        WHERE c.dniConcurrente = @Dni
                        ORDER BY i.fechaInforme DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Dni", dni);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los informes: " + ex.Message, ex);
            }
            return dt;
        }

    }
}
