using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ConsultorioPsicopedagogico.CDatos;
using System.Data;

namespace ConsultorioPsicopedagogico.CLogica
{
    public class UsuarioCL
    {
        public int Dni { get; set; }
        public string Usuario { get; set; }
        public string NombreApellido { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string ConfirmarContrasena { get; set; }
        public int PreguntaId { get; set; }
        public string Respuesta { get; set; }
        public string Rol { get; set; }
        public string DisponibilidadHoraria { get; set; }

        /// <summary>
        /// Obtiene todas las preguntas de seguridad desde la capa de datos.
        /// </summary>
        public DataTable ObtenerPreguntas()
        {
            Usuario_CD datos = new Usuario_CD();
            return datos.ObtenerPreguntas();
        }

        /// <summary>
        /// Registra un nuevo usuario en la base de datos tras verificar que el DNI y el usuario no estén ya registrados.
        /// </summary>
        public bool Registrar(UsuarioCL usuario)
        {
            Usuario_CD datos = new Usuario_CD();

            if (datos.ExisteDni(usuario.Dni))
            {
                throw new InvalidOperationException("El DNI ingresado ya está registrado.");
            }

            if (datos.ExisteUsuario(usuario.Usuario))
            {
                throw new InvalidOperationException("El usuario ingresado ya está registrado.");
            }

            Usuario_CD nuevo = new Usuario_CD
            {
                Dni = usuario.Dni,
                Usuario = usuario.Usuario,
                NombreApellido = usuario.NombreApellido,
                Email = usuario.Email,
                Contrasena = usuario.Contrasena,
                PreguntaId = usuario.PreguntaId,
                Respuesta = usuario.Respuesta,
                Rol = usuario.Rol,
                DisponibilidadHoraria = usuario.DisponibilidadHoraria
            };

            datos.RegistrarUsuario(nuevo);
            return true;
        }

        /// <summary>
        /// Obtiene la pregunta de seguridad asociada al nombre de usuario.
        /// </summary>
        public string ObtenerPreguntaPorUsuario(string usuario)
        {
            Usuario_CD datos = new Usuario_CD();
            return datos.ObtenerPreguntaPorUsuario(usuario);
        }

        /// <summary>
        /// Valida si la respuesta a la pregunta de seguridad ingresada es correcta.
        /// </summary>
        public bool ValidarRespuestaSeguridad(string usuario, string respuesta)
        {
            Usuario_CD datos = new Usuario_CD();
            return datos.ValidarRespuestaSeguridad(usuario, respuesta);
        }

        /// <summary>
        /// Actualiza la contraseña en la base de datos para el usuario provisto.
        /// </summary>
        public bool ActualizarContrasena(string usuario, string nuevaContrasena)
        {
            Usuario_CD datos = new Usuario_CD();
            return datos.ActualizarContrasena(usuario, nuevaContrasena);
        }

        /// <summary>
        /// Obtiene todos los especialistas desde la capa de datos.
        /// </summary>
        public DataTable ObtenerEspecialistas()
        {
            Usuario_CD datos = new Usuario_CD();
            return datos.ObtenerEspecialistas();
        }
    }

    public class UsuarioValidation : AbstractValidator<UsuarioCL>
    {
        public UsuarioValidation()
        {
            // Usuario
            RuleFor(u => u.Usuario)
                .NotEmpty().WithMessage("El usuario es requerido.")
                .Must(m => m != "Ingrese su usuario").WithMessage("Debe ingresar un usuario válido.")
                .MaximumLength(50).WithMessage("El usuario no puede superar los 50 caracteres.");

            // DNI
            RuleFor(u => u.Dni.ToString())
                .NotEmpty().WithMessage("El DNI es requerido.")
                .Must(d => d != "Ingrese su DNI" && d != "0").WithMessage("Debe ingresar un DNI válido.")
                .Matches(@"^\d{7,8}$").WithMessage("El DNI debe ser numérico y tener entre 7 y 8 dígitos.");

            // Nombre y Apellido
            RuleFor(u => u.NombreApellido)
                .NotEmpty().WithMessage("El nombre y apellido son requeridos.")
                .Must(n => n != "Ingrese su nombre completo").WithMessage("Debe ingresar un nombre válido.")
                .MaximumLength(150).WithMessage("El nombre no puede superar los 150 caracteres.");

            // Email
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("El correo electrónico es requerido.")
                .Must(e => e != "Ingrese su correo electrónico").WithMessage("Debe ingresar un correo válido.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(150).WithMessage("El correo no puede superar los 150 caracteres.");

            // Contraseña
            RuleFor(u => u.Contrasena)
                .NotEmpty().WithMessage("La contraseña es requerida.")
                .Must(c => c != "Ingrese su contraseña").WithMessage("Debe ingresar una contraseña válida.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");

            // Confirmar Contraseña
            RuleFor(u => u.ConfirmarContrasena)
                .NotEmpty().WithMessage("Debe confirmar su contraseña.")
                .Must(cc => cc != "Confirme su contraseña").WithMessage("Debe confirmar su contraseña.")
                .Equal(u => u.Contrasena).WithMessage("Las contraseñas no coinciden.");

            // Pregunta Secreta
            RuleFor(u => u.PreguntaId)
                .GreaterThan(0).WithMessage("Debe seleccionar una pregunta secreta de la lista.");

            // Respuesta
            RuleFor(u => u.Respuesta)
                .NotEmpty().WithMessage("La respuesta a la pregunta secreta es requerida.")
                .Must(r => r != "Ingrese la respuesta").WithMessage("Debe ingresar una respuesta de seguridad válida.");

            // Rol
            RuleFor(u => u.Rol)
                .NotEmpty().WithMessage("El rol es requerido.")
                .Must(r => r == "Especialista" || r == "Secretaria/o").WithMessage("El rol seleccionado no es válido.");
        }
    }
}
