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
