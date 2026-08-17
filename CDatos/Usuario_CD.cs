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
        private string usuario;
        private string nombreApellido;
        private string email;
        private string contrasena;
        private int preguntaId;
        private string respuesta;
        private string rol;
        private string disponibilidadHoraria;

        public int Dni { get => dni; set => dni = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public string Email { get => email; set => email = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public int PreguntaId { get => preguntaId; set => preguntaId = value; }
        public string Respuesta { get => respuesta; set => respuesta = value; }
        public string Rol { get => rol; set => rol = value; }
        public string DisponibilidadHoraria { get => disponibilidadHoraria; set => disponibilidadHoraria = value; }

        /// <summary>
        /// Verifica si existe un usuario con el nombre de usuario y contraseña provistas en la base de datos.
        /// </summary>
        public string VerificarUsuario(string usuario, string contrasena)
        {
            string rolUsuario = null;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT DNI, Rol, NombreApellido FROM Usuario WHERE BINARY Usuario = @Usuario AND BINARY Contrasena = @Contrasena";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Usuario", usuario);
                        comando.Parameters.AddWithValue("@Contrasena", contrasena);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                rolUsuario = reader["Rol"].ToString();
                                
                                // Set global session context
                                ConsultorioPsicopedagogico.CLogica.SessionContext.RolActual = rolUsuario;
                                ConsultorioPsicopedagogico.CLogica.SessionContext.DniUsuarioActual = Convert.ToInt32(reader["DNI"]);
                                ConsultorioPsicopedagogico.CLogica.SessionContext.NombreApellidoActual = reader["NombreApellido"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al conectar con la base de datos para validar credenciales: " + ex.Message, 
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rolUsuario;
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
                            (DNI, Usuario, NombreApellido, Email, Contrasena, PreguntaID, Respuesta, Rol, disponibilidadHoraria)
                            VALUES 
                            (@Dni, @Usuario, @NombreApellido, @Email, @Contrasena, @PreguntaId, @Respuesta, @Rol, @DisponibilidadHoraria)";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Dni", usuarioNuevo.Dni);
                        comando.Parameters.AddWithValue("@Usuario", usuarioNuevo.Usuario);
                        comando.Parameters.AddWithValue("@NombreApellido", usuarioNuevo.NombreApellido);
                        comando.Parameters.AddWithValue("@Email", usuarioNuevo.Email);
                        comando.Parameters.AddWithValue("@Contrasena", usuarioNuevo.Contrasena);
                        comando.Parameters.AddWithValue("@PreguntaId", usuarioNuevo.PreguntaId);
                        comando.Parameters.AddWithValue("@Respuesta", usuarioNuevo.Respuesta);
                        comando.Parameters.AddWithValue("@Rol", usuarioNuevo.Rol);
                        comando.Parameters.AddWithValue("@DisponibilidadHoraria", string.IsNullOrEmpty(usuarioNuevo.DisponibilidadHoraria) ? (object)DBNull.Value : usuarioNuevo.DisponibilidadHoraria);

                        comando.ExecuteNonQuery();
                    }

                    // El éxito se notificará en la capa de presentación
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error al intentar registrar el usuario: " + ex.Message, ex);
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
        /// Verifica si un nombre de usuario ya existe en la base de datos.
        /// </summary>
        public bool ExisteUsuario(string usuario)
        {
            bool existe = false;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Usuario", usuario);
                        int count = Convert.ToInt32(comando.ExecuteScalar());
                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al verificar si existe el usuario: " + ex.Message, 
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
        /// Obtiene el texto de la pregunta de seguridad configurada para el usuario dado.
        /// </summary>
        public string ObtenerPreguntaPorUsuario(string usuario)
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
                                    WHERE BINARY u.Usuario = @Usuario OR CAST(u.DNI AS CHAR) = @Usuario";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Usuario", usuario);
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
        public bool ValidarRespuestaSeguridad(string usuario, string respuesta)
        {
            bool esCorrecta = false;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Usuario WHERE (BINARY Usuario = @Usuario OR CAST(DNI AS CHAR) = @Usuario) AND LOWER(Respuesta) = LOWER(@Respuesta)";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Usuario", usuario);
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
        /// Actualiza la contraseña en la base de datos para el usuario dado.
        /// </summary>
        public bool ActualizarContrasena(string usuario, string nuevaContrasena)
        {
            bool exito = false;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "UPDATE Usuario SET Contrasena = @Contrasena WHERE BINARY Usuario = @Usuario OR CAST(DNI AS CHAR) = @Usuario";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Contrasena", nuevaContrasena);
                        comando.Parameters.AddWithValue("@Usuario", usuario);
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

        /// <summary>
        /// Obtiene todos los especialistas (usuarios con su respectivo rol) de la base de datos.
        /// </summary>
        public DataTable ObtenerEspecialistas()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT DNI, NombreApellido, Rol FROM Usuario WHERE Rol = 'Especialista' ORDER BY NombreApellido ASC";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al obtener los especialistas: " + ex.Message, 
                                "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}
