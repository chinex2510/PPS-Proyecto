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
        private List<InformeArea_CD> informeAreas_D;

        public int Id_Informe_D { get => id_Informe_D; set => id_Informe_D = value; }
        public int Dni_C_D { get => dni_C_D; set => dni_C_D = value; }
        public string Fecha_Informe_D { get => fecha_Informe_D; set => fecha_Informe_D = value; }
        public Concurrentes_CD Concurrente_D { get => concurrente_D; set => concurrente_D = value; }
        public Tutor_CD Tutor_D { get => tutor_D; set => tutor_D = value; }
        public List<InformeArea_CD> InformeAreas_D { get => informeAreas_D; set => informeAreas_D = value; }

        private string connectionString = Conexion.ConnectionString;

        public bool CargarInformeCompleto(int idInforme)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT i.ID_Informe, i.Fecha_Informe,
                               c.*, t.*
                        FROM Informes i
                        JOIN Concurrentes c ON i.DNI_C = c.DNI_C
                        LEFT JOIN Tutor t ON c.DNI_Tutor = t.DNI_Tutor
                        WHERE i.ID_Informe = @ID";

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
                                Domicilio_D = reader["Domicilio"].ToString(),
                                Obrasocial_D = reader["Obrasocial"].ToString()
                            };

                            tutor_D = new Tutor_CD
                            {
                                DniTutor_D = reader.GetInt32("DNI_Tutor"),
                                ApellidoTutor_D = reader["Apellido"].ToString(),
                                NombreTutor_D = reader["Nombre"].ToString(),
                                ParentezcoTutor_D = reader["Parentesco"].ToString(),
                                TelefonoTutor_D = reader["Telefono"].ToString(),
                                EmailTutor_D = reader["Email"].ToString()
                            };
                        }
                    }

                    informeAreas_D = ObtenerAreasDelInforme(id_Informe_D, connection);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el informe: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private List<InformeArea_CD> ObtenerAreasDelInforme(int idInforme, MySqlConnection connection)
        {
            var lista = new List<InformeArea_CD>();

            string query = @"
                SELECT ia.Texto_Area, a.ID_Area, a.Nombre_Area
                FROM Informe_Area ia
                JOIN Areas a ON ia.ID_Area = a.ID_Area
                WHERE ia.ID_Informe = @ID";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ID", idInforme);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var area = new Area_CD
                        {
                            Id_Area_D = reader.GetInt32("ID_Area"),
                            Nombre_Area_D = reader.GetString("Nombre_Area")
                        };

                        lista.Add(new InformeArea_CD
                        {
                            Id_Informe_D = idInforme,
                            Id_Area_D = area.Id_Area_D,
                            Texto_Area_D = reader.GetString("Texto_Area"),
                            Area_D = area
                        });
                    }
                }
            }

            return lista;
        }

    }
}
