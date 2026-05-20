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
    internal class Concurrentes_CD
    {
        private int dni_D;
        private string apellido_D;
        private string nombre_D;
        private string fechaNac_D; //Problablemente se cambie de string a data 
        private string diagnostico_D;
        private string escuela_D;
        private int añoEscolar_D;
        private string nivelEscolar_D;
        private string domicilio_D;
        private string obrasocial_D;


        public int Dni_D { get => dni_D; set => dni_D = value; }
        public string Apellido_D { get => apellido_D; set => apellido_D = value; }
        public string Nombre_D { get => nombre_D; set => nombre_D = value; }
        public string FechaNac_D { get => fechaNac_D; set => fechaNac_D = value; }
        public string Diagnostico_D { get => diagnostico_D; set => diagnostico_D = value; }
        public string Escuela_D { get => escuela_D; set => escuela_D = value; }
        public int AñoEscolar_D { get => añoEscolar_D; set => añoEscolar_D = value; }
        public string NivelEscolar_D { get => nivelEscolar_D; set => nivelEscolar_D = value; }
        public string Domicilio_D { get => domicilio_D; set => domicilio_D = value; }
        public string Obrasocial_D { get => obrasocial_D; set => obrasocial_D = value; }

        // Esta funcion atraves de un if puede guardar un concurrente nuevo o modificar uno existente 
        // ya que recibe de paramentro un bool que lo manejara

        //public void Guardar_Modificar_Concurrente(Concurrentes_CD concurrente, bool esNuevo)
        //{
        //    try
        //    {
        //        using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
        //        {
        //            conexion.Open();

        //            string query;

        //            if (esNuevo)
        //            {
        //                query = @"INSERT INTO Concurrentes 
        //                  (DNI_C, Apellido, Nombre, FechaNac, Diagnostico, Escuela, AñoEscolar, NivelEscolar, Domicilio, Obrasocial)
        //                  VALUES
        //                  (@Dni, @Apellido, @Nombre, @FechaNac, @Diagnostico, @Escuela, @AñoEscolar, @NivelEscolar, @Domicilio, @Obrasocial)";
        //            }
        //            else
        //            {
        //                query = @"UPDATE Concurrentes SET 
        //                  Apellido = @Apellido,
        //                  Nombre = @Nombre,
        //                  FechaNac = @FechaNac,
        //                  Diagnostico = @Diagnostico,
        //                  Escuela = @Escuela,
        //                  AñoEscolar = @AñoEscolar,
        //                  NivelEscolar = @NivelEscolar,
        //                  Domicilio = @Domicilio,
        //                  Obrasocial = @Obrasocial
        //                  WHERE DNI_C = @Dni";
        //            }

        //            using (MySqlCommand comando = new MySqlCommand(query, conexion))
        //            {
        //                comando.Parameters.AddWithValue("@Dni", concurrente.Dni_D);
        //                comando.Parameters.AddWithValue("@Apellido", concurrente.Apellido_D);
        //                comando.Parameters.AddWithValue("@Nombre", concurrente.Nombre_D);
        //                comando.Parameters.AddWithValue("@FechaNac", concurrente.FechaNac_D);
        //                comando.Parameters.AddWithValue("@Diagnostico", concurrente.Diagnostico_D);
        //                comando.Parameters.AddWithValue("@Escuela", concurrente.Escuela_D);
        //                comando.Parameters.AddWithValue("@AñoEscolar", concurrente.AñoEscolar_D);
        //                comando.Parameters.AddWithValue("@NivelEscolar", concurrente.NivelEscolar_D);
        //                comando.Parameters.AddWithValue("@Domicilio", concurrente.Domicilio_D);
        //                comando.Parameters.AddWithValue("@Obrasocial", concurrente.Obrasocial_D);

        //                comando.ExecuteNonQuery();
        //            }

        //            string mensaje = esNuevo ? "Concurrente registrado exitosamente" : "Registro modificado exitosamente";
        //            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        public void CargarEnSql(Concurrentes_CD concurrenteN)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = @"INSERT INTO Concurrentes 
                            (DNI_C, Apellido, Nombre, FechaNac, Diagnostico, Escuela, AñoEscolar, NivelEscolar, Domicilio, Obrasocial)
                            VALUES 
                            (@Dni, @Apellido, @Nombre, @FechaNac, @Diagnostico, @Escuela, @AñoEscolar, @NivelEscolar, @Domicilio, @Obrasocial)";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
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
                        comando.Parameters.AddWithValue("@Obrasocial", concurrenteN.Obrasocial_D);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Se ha registrado exitosamente el nuevo concurrente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar registrar al concurrente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método que retorna una DataTable con todos los concurrentes
        public DataTable TablaNuevoConcurrente()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString);
                conexion.Open();

                string cadena = "SELECT * FROM Concurrentes";
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

        // Método para seleccionar un concurrente por DNI y retornar un objeto Concurrentes_CD
        public Concurrentes_CD SelectorNuevoConcurrente(int dni)
        {
            try
            {
                Concurrentes_CD concurrenteSeleccionado = new Concurrentes_CD();
                MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString);
                string cadena = $"SELECT * FROM Concurrentes WHERE DNI_C = {dni}";
                conexion.Open();

                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                MySqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    concurrenteSeleccionado.Dni_D = Convert.ToInt32(registro["DNI_C"].ToString());
                    concurrenteSeleccionado.Apellido_D = registro["Apellido"].ToString();
                    concurrenteSeleccionado.Nombre_D = registro["Nombre"].ToString();
                    concurrenteSeleccionado.FechaNac_D = registro["FechaNac"].ToString();
                    concurrenteSeleccionado.Diagnostico_D = registro["Diagnostico"].ToString();
                    concurrenteSeleccionado.Escuela_D = registro["Escuela"].ToString();
                    concurrenteSeleccionado.AñoEscolar_D = Convert.ToInt32(registro["AñoEscolar"]);
                    concurrenteSeleccionado.NivelEscolar_D = registro["NivelEscolar"].ToString();
                    concurrenteSeleccionado.Domicilio_D = registro["Domicilio"].ToString();
                    concurrenteSeleccionado.Obrasocial_D = registro["Obrasocial"].ToString();
                }
                conexion.Close();
                return concurrenteSeleccionado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en el intento de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Método para modificar los datos de un concurrente existente
        public void ModificarDatos(Concurrentes_CD concurrente)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();

                    string query = @"UPDATE Concurrentes SET 
                            Apellido = @Apellido,
                            Nombre = @Nombre,
                            FechaNac = @FechaNac,
                            Diagnostico = @Diagnostico,
                            Escuela = @Escuela,
                            AñoEscolar = @AñoEscolar,
                            NivelEscolar = @NivelEscolar,
                            Domicilio = @Domicilio,
                            Obrasocial = @Obrasocial
                         WHERE DNI_C = @Dni";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", concurrente.Dni_D);
                        comando.Parameters.AddWithValue("@Apellido", concurrente.Apellido_D);
                        comando.Parameters.AddWithValue("@Nombre", concurrente.Nombre_D);
                        comando.Parameters.AddWithValue("@FechaNac", concurrente.FechaNac_D);
                        comando.Parameters.AddWithValue("@Diagnostico", concurrente.Diagnostico_D);
                        comando.Parameters.AddWithValue("@Escuela", concurrente.Escuela_D);
                        comando.Parameters.AddWithValue("@AñoEscolar", concurrente.AñoEscolar_D);
                        comando.Parameters.AddWithValue("@NivelEscolar", concurrente.NivelEscolar_D);
                        comando.Parameters.AddWithValue("@Domicilio", concurrente.Domicilio_D);
                        comando.Parameters.AddWithValue("@Obrasocial", concurrente.Obrasocial_D);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Registro modificado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al modificar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Método para eliminar un concurrente por DNI
        public void EliminarNuevoConcurrente(Concurrentes_CD concurrente)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString);
                conexion.Open();

                int dni = concurrente.Dni_D;
                string cadena = $"DELETE FROM Concurrentes WHERE DNI_C = {dni}";
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

        // Método que retorna una DataTable con la búsqueda de concurrente por DNI
        public DataTable BusquedaNuevoConcurrente(int dni)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString);
                conexion.Open();

                string cadena = $"SELECT * FROM Concurrentes WHERE DNI_C = {dni}";
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

        // Método que retorna una DataTable con la búsqueda de concurrentes por DNI, Apellido, Nombre o Escuela
        // como se usa: BusquedaNuevoConcurrente(12345678);BusquedaNuevoConcurrente("Gómez")

        //public DataTable BusquedaNuevoConcurrente(int? dni = null, string apellido = null, string nombre = null, string escuela = null)
        //{
        //    try
        //    {
        //        using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
        //        {
        //            conexion.Open();

        //            // Base de la consulta
        //            string consulta = "SELECT * FROM Concurrentes WHERE 1=1";

        //            // Lista de parámetros
        //            List<MySqlParameter> parametros = new List<MySqlParameter>();

        //            if (dni.HasValue)
        //            {
        //                consulta += " AND DNI_C = @dni";
        //                parametros.Add(new MySqlParameter("@dni", dni.Value));
        //            }
        //            if (!string.IsNullOrEmpty(apellido))
        //            {
        //                consulta += " AND Apellido LIKE @apellido";
        //                parametros.Add(new MySqlParameter("@apellido", $"%{apellido}%"));
        //            }
        //            if (!string.IsNullOrEmpty(nombre))
        //            {
        //                consulta += " AND Nombre LIKE @nombre";
        //                parametros.Add(new MySqlParameter("@nombre", $"%{nombre}%"));
        //            }
        //            if (!string.IsNullOrEmpty(escuela))
        //            {
        //                consulta += " AND Escuela LIKE @escuela";
        //                parametros.Add(new MySqlParameter("@escuela", $"%{escuela}%"));
        //            }

        //            MySqlCommand comando = new MySqlCommand(consulta, conexion);
        //            comando.Parameters.AddRange(parametros.ToArray());

        //            MySqlDataReader leerFilas = comando.ExecuteReader();
        //            DataTable tablaSQL = new DataTable();
        //            tablaSQL.Load(leerFilas);

        //            return tablaSQL;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un error en el intento de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

    }
}
