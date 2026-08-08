using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ConsultorioPsicopedagogico.CDatos;

namespace ConsultorioPsicopedagogico.CLogica
{
    public class LoginCL
    {
        /// <summary>
        /// Autentica un usuario validando su nombre de usuario y contraseña contra los datos almacenados en la base de datos.
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <returns>True si la autenticación es exitosa, False en caso contrario</returns>
        public string Autenticar(string usuario, string contrasena)
        {
            Usuario_CD usuarioDatos = new Usuario_CD();
            return usuarioDatos.VerificarUsuario(usuario, contrasena);
        }
    }

    public class LoginValidation : AbstractValidator<string[]>
    {
        public LoginValidation()
        {
            // [0] -> Usuario
            RuleFor(campos => campos[0])
                .NotEmpty().WithMessage("El campo Usuario no puede estar vacío.")
                .Must(TextoGris).WithMessage("Debe ingresar un usuario válido.");

            // [1] -> Contraseña
            RuleFor(campos => campos[1])
                .NotEmpty().WithMessage("El campo Contraseña no puede estar vacío.")
                .Must(TextoGris).WithMessage("Debe ingresar una contraseña válida.");
        }

        private bool TextoGris(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return true;
            return !texto.Equals("Ingrese su usuario") && !texto.Equals("Ingrese su contraseña");
        }
    }
}
