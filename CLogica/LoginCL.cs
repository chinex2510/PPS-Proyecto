using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ConsultorioPsicopedagogico.CLogica
{
    public class LoginCL
    {
        // Constantes de validación (credenciales - idealmente deberían venir de BD)
        private const string MatriculaValida = "celeste";
        private const string ContraseñaValida = "123456";

        /// <summary>
        /// Autentica un usuario validando su matrícula y contraseña contra los datos almacenados.
        /// </summary>
        /// <param name="matricula">Matrícula del usuario</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <returns>True si la autenticación es exitosa, False en caso contrario</returns>
        public bool Autenticar(string matricula, string contrasena)
        {
            // Aquí se podría llamar a la capa de datos (CDatos) para validar contra la BD
            // CDatos.VerificarUsuario(matricula, contrasena);

            // Por ahora, validación contra constantes
            return matricula.Equals(MatriculaValida) && contrasena.Equals(ContraseñaValida);
        }
    }

    public class LoginValidation : AbstractValidator<string[]>
    {
        public LoginValidation()
        {
            // [0] -> Matrícula
            RuleFor(campos => campos[0])
                .NotEmpty().WithMessage("El campo Matrícula no puede estar vacío.")
                .Must(TextoGris).WithMessage("Debe ingresar una matrícula válida.");

            // [1] -> Contraseña
            RuleFor(campos => campos[1])
                .NotEmpty().WithMessage("El campo Contraseña no puede estar vacío.")
                .Must(TextoGris).WithMessage("Debe ingresar una contraseña válida.");
        }

        private bool TextoGris(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return true;
            return !texto.Equals("Ingrese su matrícula") && !texto.Equals("Ingrese su contraseña");
        }
    }
}
