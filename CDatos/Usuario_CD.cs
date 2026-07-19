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
    internal class Usuario_CD
    {
        private int dni;
        private string matricula;
        private string nombreApellido;
        private string email;
        private string especialidad;
        private string contrasena;
        private int preguntaId;
        private string respuesta;

        public int Dni { get => dni; set => dni = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public string Email { get => email; set => email = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public int PreguntaId { get => preguntaId; set => preguntaId = value; }
        public string Respuesta { get => respuesta; set => respuesta = value; }

        /// <summary>
        /// Verifica si existe un usuario con la matrícula y contraseña provistas en la base de datos.
        /// </summary>
        public bool VerificarUsuario(string matricula, string contrasena)
        {
            bool esValido = false;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Usuario WHERE Matricula = @Matricula AND Contrasena = @Contrasena";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Matricula", matricula);
                        comando.Parameters.AddWithValue("@Contrasena", contrasena);

                        int count = Convert.ToInt32(comando.ExecuteScalar());
                        esValido = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al conectar con la base de datos para validar credenciales: " + ex.Message, 
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esValido;
        }

        /// <summary>
        /// Registra un nuevo usuario en la base de datos.
        /// </summary>
        public void RegistrarUsuario(Usuario_CD usuarioNuevo)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = @"INSERT INTO Usuario 
                            (DNI, Matricula, NombreApellido, Email, Especialidad, Contrasena, PreguntaID, Respuesta)
                            VALUES 
                            (@Dni, @Matricula, @NombreApellido, @Email, @Especialidad, @Contrasena, @PreguntaId, @Respuesta)";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", usuarioNuevo.Dni);
                        comando.Parameters.AddWithValue("@Matricula", usuarioNuevo.Matricula);
                        comando.Parameters.AddWithValue("@NombreApellido", usuarioNuevo.NombreApellido);
                        comando.Parameters.AddWithValue("@Email", usuarioNuevo.Email);
                        comando.Parameters.AddWithValue("@Especialidad", usuarioNuevo.Especialidad);
                        comando.Parameters.AddWithValue("@Contrasena", usuarioNuevo.Contrasena);
                        comando.Parameters.AddWithValue("@PreguntaId", usuarioNuevo.PreguntaId);
                        comando.Parameters.AddWithValue("@Respuesta", usuarioNuevo.Respuesta);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Se ha registrado exitosamente el nuevo usuario", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Verifica si un DNI ya existe en la base de datos.
        /// </summary>
        public bool ExisteDni(int dni)
        {
            bool existe = false;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Usuario WHERE DNI = @Dni";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", dni);
                        int count = Convert.ToInt32(comando.ExecuteScalar());
                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al verificar si existe el DNI: " + ex.Message, 
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return existe;
        }

        /// <summary>
        /// Verifica si una matrícula ya existe en la base de datos.
        /// </summary>
        public bool ExisteMatricula(string matricula)
        {
            bool existe = false;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Usuario WHERE Matricula = @Matricula";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Matricula", matricula);
                        int count = Convert.ToInt32(comando.ExecuteScalar());
                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al verificar si existe la matrícula: " + ex.Message, 
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return existe;
        }

        /// <summary>
        /// Obtiene todas las preguntas de seguridad de la base de datos.
        /// </summary>
        public DataTable ObtenerPreguntas()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT PreguntaID, PreguntaTexto FROM PreguntaSeguridad";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al obtener las preguntas de seguridad: " + ex.Message, 
                                "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Obtiene el texto de la pregunta de seguridad configurada para la matrícula de un usuario.
        /// </summary>
        public string ObtenerPreguntaPorMatricula(string matricula)
        {
            string preguntaText = "";
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = @"SELECT ps.PreguntaTexto 
                                    FROM Usuario u 
                                    INNER JOIN PreguntaSeguridad ps ON u.PreguntaID = ps.PreguntaID 
                                    WHERE u.Matricula = @Matricula";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Matricula", matricula);
                        object result = comando.ExecuteScalar();
                        if (result != null)
                        {
                            preguntaText = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al obtener la pregunta de seguridad: " + ex.Message, 
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return preguntaText;
        }

        /// <summary>
        /// Valida si la respuesta a la pregunta de seguridad coincide con la almacenada.
        /// </summary>
        public bool ValidarRespuestaSeguridad(string matricula, string respuesta)
        {
            bool esCorrecta = false;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Usuario WHERE Matricula = @Matricula AND LOWER(Respuesta) = LOWER(@Respuesta)";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Matricula", matricula);
                        comando.Parameters.AddWithValue("@Respuesta", respuesta.Trim());
                        esCorrecta = Convert.ToInt32(comando.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al validar la respuesta: " + ex.Message, 
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esCorrecta;
        }

        /// <summary>
        /// Actualiza la contraseña en la base de datos para la matrícula dada.
        /// </summary>
        public bool ActualizarContrasena(string matricula, string nuevaContrasena)
        {
            bool exito = false;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "UPDATE Usuario SET Contrasena = @Contrasena WHERE Matricula = @Matricula";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Contrasena", nuevaContrasena);
                        comando.Parameters.AddWithValue("@Matricula", matricula);
                        int rows = comando.ExecuteNonQuery();
                        exito = rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al actualizar la contraseña: " + ex.Message, 
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return exito;
        }
    }
}
