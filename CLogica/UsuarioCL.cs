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
        public string Matricula { get; set; }
        public string NombreApellido { get; set; }
        public string Email { get; set; }
        public string Especialidad { get; set; }
        public string Contrasena { get; set; }
        public string ConfirmarContrasena { get; set; }
        public int PreguntaId { get; set; }
        public string Respuesta { get; set; }

        /// <summary>
        /// Obtiene todas las preguntas de seguridad desde la capa de datos.
        /// </summary>
        public DataTable ObtenerPreguntas()
        {
            Usuario_CD datos = new Usuario_CD();
            return datos.ObtenerPreguntas();
        }

        /// <summary>
        /// Registra un nuevo usuario en la base de datos tras verificar que el DNI y la matrícula no estén ya registrados.
        /// </summary>
        public bool Registrar(UsuarioCL usuario)
        {
            Usuario_CD datos = new Usuario_CD();

            if (datos.ExisteDni(usuario.Dni))
            {
                throw new InvalidOperationException("El DNI ingresado ya está registrado.");
            }

            if (datos.ExisteMatricula(usuario.Matricula))
            {
                throw new InvalidOperationException("La matrícula ingresada ya está registrada.");
            }

            Usuario_CD nuevo = new Usuario_CD
            {
                Dni = usuario.Dni,
                Matricula = usuario.Matricula,
                NombreApellido = usuario.NombreApellido,
                Email = usuario.Email,
                Especialidad = usuario.Especialidad,
                Contrasena = usuario.Contrasena,
                PreguntaId = usuario.PreguntaId,
                Respuesta = usuario.Respuesta
            };

            datos.RegistrarUsuario(nuevo);
            return true;
        }

        /// <summary>
        /// Obtiene la pregunta de seguridad asociada a la matrícula de un usuario.
        /// </summary>
        public string ObtenerPreguntaPorMatricula(string matricula)
        {
            Usuario_CD datos = new Usuario_CD();
            return datos.ObtenerPreguntaPorMatricula(matricula);
        }

        /// <summary>
        /// Valida si la respuesta a la pregunta de seguridad ingresada es correcta.
        /// </summary>
        public bool ValidarRespuestaSeguridad(string matricula, string respuesta)
        {
            Usuario_CD datos = new Usuario_CD();
            return datos.ValidarRespuestaSeguridad(matricula, respuesta);
        }

        /// <summary>
        /// Actualiza la contraseña en la base de datos para la matrícula provista.
        /// </summary>
        public bool ActualizarContrasena(string matricula, string nuevaContrasena)
        {
            Usuario_CD datos = new Usuario_CD();
            return datos.ActualizarContrasena(matricula, nuevaContrasena);
        }
    }

    public class UsuarioValidation : AbstractValidator<UsuarioCL>
    {
        public UsuarioValidation()
        {
            // Matrícula
            RuleFor(u => u.Matricula)
                .NotEmpty().WithMessage("La matrícula es requerida.")
                .Must(m => m != "Ingrese su matrícula").WithMessage("Debe ingresar una matrícula válida.")
                .Matches(@"^\d{5}$").WithMessage("La matrícula debe ser un número de exactamente 5 dígitos.");

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

            // Especialidad
            RuleFor(u => u.Especialidad)
                .NotEmpty().WithMessage("La especialidad es requerida.")
                .Must(e => e != "Ingrese su especialidad profesional").WithMessage("Debe ingresar una especialidad válida.")
                .MaximumLength(100).WithMessage("La especialidad no puede superar los 100 caracteres.");

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
        }
    }
}
