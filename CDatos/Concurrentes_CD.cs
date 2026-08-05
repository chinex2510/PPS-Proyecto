using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ConsultorioPsicopedagogico.CDatos
{
    internal class Concurrentes_CD
    {
        private int dni_D;
        private int originalDni_D;
        private string apellido_D;
        private string nombre_D;
        private string fechaNac_D;
        private string diagnostico_D;
        private string escuela_D;
        private int anioEscolar_D;
        private string nivelEscolar_D;
        private string domicilio_D;
        private string dniTutor_D;
        private string contactoTutor_D;
        private string parentezco_D;

        public int Dni_D { get => dni_D; set => dni_D = value; }
        public int OriginalDni_D { get => originalDni_D; set => originalDni_D = value; }
        public string Apellido_D { get => apellido_D; set => apellido_D = value; }
        public string Nombre_D { get => nombre_D; set => nombre_D = value; }
        public string FechaNac_D { get => fechaNac_D; set => fechaNac_D = value; }
        public string Diagnostico_D { get => diagnostico_D; set => diagnostico_D = value; }
        public string Escuela_D { get => escuela_D; set => escuela_D = value; }
        public int AñoEscolar_D { get => anioEscolar_D; set => anioEscolar_D = value; }
        public string NivelEscolar_D { get => nivelEscolar_D; set => nivelEscolar_D = value; }
        public string Domicilio_D { get => domicilio_D; set => domicilio_D = value; }
        public string DniTutor_D { get => dniTutor_D; set => dniTutor_D = value; }
        public string ContactoTutor_D { get => contactoTutor_D; set => contactoTutor_D = value; }
        public string Parentezco_D { get => parentezco_D; set => parentezco_D = value; }

        public void CargarEnSql(Concurrentes_CD concurrenteN)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string queryConcurrente = @"INSERT INTO Concurrente 
                            (dniConcurrente, apellido, nombre, fechaNacimiento, diagnostico, escuela, anioEscolar, nivelEscolar, domicilio)
                            VALUES 
                            (@Dni, @Apellido, @Nombre, @FechaNac, @Diagnostico, @Escuela, @AñoEscolar, @NivelEscolar, @Domicilio)";

                    string queryParentesco = @"INSERT INTO Parentesco (idConcurrente, idTutor, relacion) SELECT c.idConcurrente, t.idTutor, @Parentezco FROM Concurrente c, Tutor t WHERE c.dniConcurrente = @Dni AND t.dniTutor = @DniTutor";

                    using (MySqlCommand comando = new MySqlCommand(queryConcurrente, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", concurrenteN.Dni_D);
                        comando.Parameters.AddWithValue("@Apellido", concurrenteN.Apellido_D);
                        comando.Parameters.AddWithValue("@Nombre", concurrenteN.Nombre_D);
                        comando.Parameters.AddWithValue("@FechaNac", concurrenteN.FechaNac_D);
                        comando.Parameters.AddWithValue("@Diagnostico", concurrenteN.Diagnostico_D);
                        comando.Parameters.AddWithValue("@Escuela", concurrenteN.Escuela_D);
                        comando.Parameters.AddWithValue("@AñoEscolar", concurrenteN.AñoEscolar_D);
                        comando.Parameters.AddWithValue("@NivelEscolar", concurrenteN.NivelEscolar_D);
                        comando.Parameters.AddWithValue("@Domicilio", concurrenteN.Domicilio_D);

                        comando.ExecuteNonQuery();
                    }

                    if (!string.IsNullOrEmpty(concurrenteN.DniTutor_D))
                    {
                        using (MySqlCommand comando = new MySqlCommand(queryParentesco, conexion))
                        {
                            comando.Parameters.AddWithValue("@Dni", concurrenteN.Dni_D);
                            comando.Parameters.AddWithValue("@DniTutor", concurrenteN.DniTutor_D);
                            comando.Parameters.AddWithValue("@Parentezco", concurrenteN.Parentezco_D);
                            comando.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Se ha registrado exitosamente el nuevo concurrente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar registrar al concurrente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable TablaNuevoConcurrente()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString);
                conexion.Open();

                string cadena = @"
                SELECT 
                    c.dniConcurrente AS 'DNI_C',
                    CONCAT(c.apellido, ' ', c.nombre) AS 'ApellidoNombre',
                    c.fechaNacimiento AS 'FechaNac',
                    c.diagnostico AS 'Diagnostico',
                    c.escuela AS 'Escuela',
                    c.anioEscolar AS 'AnioEscolar',
                    c.nivelEscolar AS 'NivelEscolar',
                    c.domicilio AS 'Domicilio',
                    p.relacion AS 'Parentesco',
                    CONCAT(t.apellido,' ', t.nombre) AS 'Tutor', 
                    t.dniTutor AS 'DNI_Tutor',
                    t.telefono AS 'ContactoTutor',
                    t.obraSocial AS 'ObraSocial'
                FROM Concurrente c
                LEFT JOIN Parentesco p ON c.idConcurrente = p.idConcurrente
                LEFT JOIN Tutor t ON p.idTutor = t.idTutor WHERE c.activo = TRUE"; 
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                MySqlDataReader leerFilas = comando.ExecuteReader();
                DataTable tablaSQL = new DataTable();
                tablaSQL.Load(leerFilas);
                conexion.Close();

                return tablaSQL;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en el intento de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public Concurrentes_CD SelectorNuevoConcurrente(int dni)
        {
            try
            {
                Concurrentes_CD concurrenteSeleccionado = new Concurrentes_CD();
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    string cadena = @"
                SELECT 
                    c.dniConcurrente AS 'DNI_C',
                    c.apellido AS 'Apellido',
                    c.nombre AS 'Nombre',
                    c.fechaNacimiento AS 'FechaNac',
                    c.diagnostico AS 'Diagnostico',
                    c.escuela AS 'Escuela',
                    c.anioEscolar AS 'AñoEscolar',
                    c.nivelEscolar AS 'NivelEscolar',
                    c.domicilio AS 'Domicilio',
                    p.relacion AS 'Parentesco',
                    t.obraSocial AS 'Obrasocial',
                    CONCAT(t.apellido, ' ', t.nombre) AS 'TutorCompleto',
                    t.dniTutor AS 'DNI_Tutor',
                    t.telefono AS 'ContactoTutor'
                FROM Concurrente c
                LEFT JOIN Parentesco p ON c.idConcurrente = p.idConcurrente
                LEFT JOIN Tutor t ON p.idTutor = t.idTutor
                WHERE c.dniConcurrente = @dni";
                    conexion.Open();

                    using (MySqlCommand comando = new MySqlCommand(cadena, conexion))
                    {
                        comando.Parameters.AddWithValue("@dni", dni);
                        using (MySqlDataReader registro = comando.ExecuteReader())
                        {
                            while (registro.Read())
                            {
                                concurrenteSeleccionado.Dni_D = Convert.ToInt32(registro["DNI_C"]);
                                concurrenteSeleccionado.Apellido_D = registro["Apellido"].ToString();
                                concurrenteSeleccionado.Nombre_D = registro["Nombre"].ToString();
                                concurrenteSeleccionado.FechaNac_D = registro["FechaNac"].ToString();
                                concurrenteSeleccionado.Diagnostico_D = registro["Diagnostico"].ToString();
                                concurrenteSeleccionado.Escuela_D = registro["Escuela"].ToString();
                                concurrenteSeleccionado.AñoEscolar_D = Convert.ToInt32(registro["AñoEscolar"]);
                                concurrenteSeleccionado.NivelEscolar_D = registro["NivelEscolar"].ToString();
                                concurrenteSeleccionado.Domicilio_D = registro["Domicilio"].ToString();

                                if (registro["DNI_Tutor"] != DBNull.Value)
                                    concurrenteSeleccionado.DniTutor_D = registro["DNI_Tutor"].ToString();
                                if (registro["Parentesco"] != DBNull.Value)
                                    concurrenteSeleccionado.Parentezco_D = registro["Parentesco"].ToString();
                                if (registro["ContactoTutor"] != DBNull.Value)
                                    concurrenteSeleccionado.contactoTutor_D = registro["ContactoTutor"].ToString();
                            }
                        }
                    }
                }
                return concurrenteSeleccionado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en el intento de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void ModificarDatos(Concurrentes_CD concurrente)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = @"UPDATE Concurrente SET 
                            dniConcurrente = @Dni,
                            apellido = @Apellido,
                            nombre = @Nombre,
                            fechaNacimiento = @FechaNac,
                            diagnostico = @Diagnostico,
                            escuela = @Escuela,
                            anioEscolar = @AñoEscolar,
                            nivelEscolar = @NivelEscolar,
                            domicilio = @Domicilio
                         WHERE dniConcurrente = @OriginalDni";

                    string queryParentescoUpdate = @"UPDATE Parentesco p JOIN Concurrente c ON p.idConcurrente = c.idConcurrente SET p.idTutor = (SELECT idTutor FROM Tutor WHERE dniTutor = @DniTutor), p.relacion = @Parentezco WHERE c.dniConcurrente = @Dni";
                    string queryParentescoInsert = @"INSERT INTO Parentesco (idConcurrente, idTutor, relacion) SELECT c.idConcurrente, t.idTutor, @Parentezco FROM Concurrente c, Tutor t WHERE c.dniConcurrente = @Dni AND t.dniTutor = @DniTutor AND NOT EXISTS (SELECT 1 FROM Parentesco px JOIN Concurrente cx ON px.idConcurrente = cx.idConcurrente WHERE cx.dniConcurrente = @Dni)";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", concurrente.Dni_D);
                        comando.Parameters.AddWithValue("@OriginalDni", concurrente.OriginalDni_D != 0 ? concurrente.OriginalDni_D : concurrente.Dni_D);
                        comando.Parameters.AddWithValue("@Apellido", concurrente.Apellido_D);
                        comando.Parameters.AddWithValue("@Nombre", concurrente.Nombre_D);
                        comando.Parameters.AddWithValue("@FechaNac", concurrente.FechaNac_D);
                        comando.Parameters.AddWithValue("@Diagnostico", concurrente.Diagnostico_D);
                        comando.Parameters.AddWithValue("@Escuela", concurrente.Escuela_D);
                        comando.Parameters.AddWithValue("@AñoEscolar", concurrente.AñoEscolar_D);
                        comando.Parameters.AddWithValue("@NivelEscolar", concurrente.NivelEscolar_D);
                        comando.Parameters.AddWithValue("@Domicilio", concurrente.Domicilio_D);

                        comando.ExecuteNonQuery();
                    }

                    if (!string.IsNullOrEmpty(concurrente.DniTutor_D))
                    {
                        using (MySqlCommand comando = new MySqlCommand(queryParentescoUpdate, conexion))
                        {
                            comando.Parameters.AddWithValue("@Dni", concurrente.Dni_D);
                            comando.Parameters.AddWithValue("@DniTutor", concurrente.DniTutor_D);
                            comando.Parameters.AddWithValue("@Parentezco", concurrente.Parentezco_D);
                            comando.ExecuteNonQuery();
                        }
                        
                        using (MySqlCommand comando = new MySqlCommand(queryParentescoInsert, conexion))
                        {
                            comando.Parameters.AddWithValue("@Dni", concurrente.Dni_D);
                            comando.Parameters.AddWithValue("@DniTutor", concurrente.DniTutor_D);
                            comando.Parameters.AddWithValue("@Parentezco", concurrente.Parentezco_D);
                            comando.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al modificar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarNuevoConcurrente(Concurrentes_CD concurrente)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString);
                conexion.Open();

                int dni = concurrente.Dni_D;
                string cadena = $"UPDATE Concurrente SET activo = FALSE WHERE dniConcurrente = {dni}";
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Concurrente eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en el intento de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReactivarNuevoConcurrente(Concurrentes_CD concurrente)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString);
                conexion.Open();

                int dni = concurrente.Dni_D;
                string cadena = $"UPDATE Concurrente SET activo = TRUE WHERE dniConcurrente = {dni}";
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Concurrente reactivado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en el intento de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable TablaBajaConcurrente()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString);
                conexion.Open();

                string cadena = @"
                SELECT 
                    c.dniConcurrente AS 'DNI_C',
                    CONCAT(c.apellido, ' ', c.nombre) AS 'ApellidoNombre',
                    c.fechaNacimiento AS 'FechaNac',
                    p.relacion AS 'Parentesco',
                    CONCAT(t.apellido,' ', t.nombre) AS 'Tutor', 
                    t.dniTutor AS 'DNI_Tutor', 
                    t.telefono AS 'ContactoTutor',  
                    t.obraSocial AS 'ObraSocial'
                FROM Concurrente c
                LEFT JOIN Parentesco p ON c.idConcurrente = p.idConcurrente
                LEFT JOIN Tutor t ON p.idTutor = t.idTutor WHERE c.activo = FALSE";
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                MySqlDataReader leerFilas = comando.ExecuteReader();
                DataTable tablaSQL = new DataTable();
                tablaSQL.Load(leerFilas);
                conexion.Close();

                return tablaSQL;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en el intento de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable BusquedaBaja(int dni)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString);
                conexion.Open();

                string cadena = @"
                SELECT 
                    c.dniConcurrente AS 'DNI_C',
                    CONCAT(c.apellido, ' ', c.nombre) AS 'ApellidoNombre',
                    c.fechaNacimiento AS 'FechaNac',
                    p.relacion AS 'Parentesco',
                    CONCAT(t.apellido,' ', t.nombre) AS 'Tutor', 
                    t.dniTutor AS 'DNI_Tutor', 
                    t.telefono AS 'ContactoTutor',  
                    t.obraSocial AS 'ObraSocial'
                FROM Concurrente c
                LEFT JOIN Parentesco p ON c.idConcurrente = p.idConcurrente
                LEFT JOIN Tutor t ON p.idTutor = t.idTutor WHERE c.dniConcurrente = @dni AND c.activo = FALSE";
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                MySqlDataReader leerFilas = comando.ExecuteReader();
                DataTable tablaSQL = new DataTable();
                tablaSQL.Load(leerFilas);
                conexion.Close();

                return tablaSQL;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en el intento de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable BusquedaNuevoConcurrente(string dni)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString);
                conexion.Open();

                string cadena = @"
                SELECT 
                    c.dniConcurrente AS 'DNI_C',
                    CONCAT(c.apellido, ' ', c.nombre) AS 'ApellidoNombre',
                    c.fechaNacimiento AS 'FechaNac',
                    c.diagnostico AS 'Diagnostico',
                    c.escuela AS 'Escuela',
                    c.anioEscolar AS 'AnioEscolar',
                    c.nivelEscolar AS 'NivelEscolar',
                    c.domicilio AS 'Domicilio',
                    p.relacion AS 'Parentesco',
                    CONCAT(t.apellido,' ', t.nombre) AS 'Tutor',
                    t.dniTutor AS 'DNI_Tutor',
                    t.telefono AS 'ContactoTutor',
                    t.obraSocial AS 'ObraSocial'
                FROM Concurrente c
                LEFT JOIN Parentesco p ON c.idConcurrente = p.idConcurrente
                LEFT JOIN Tutor t ON p.idTutor = t.idTutor WHERE (CAST(c.dniConcurrente AS CHAR) LIKE @DniBusqueda OR CAST(t.dniTutor AS CHAR) LIKE @DniBusqueda) AND c.activo = TRUE";
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@DniBusqueda", dni + "%");
                MySqlDataReader leerFilas = comando.ExecuteReader();
                DataTable tablaSQL = new DataTable();
                tablaSQL.Load(leerFilas);
                conexion.Close();

                return tablaSQL;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en el intento de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
