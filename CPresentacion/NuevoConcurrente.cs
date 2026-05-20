using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class NuevoConcurrente : Form
    {
        public NuevoConcurrente()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            //int ValConcurrente = 0, ValEscolaridad = 0, ValTutor = 0;
            var validator = new ConcurrenteValidation();
            ValidationResult results = validator.Validate(this);

            if (!results.IsValid)
            {
                //StringBuilder sb = new StringBuilder();{
                foreach (var error in results.Errors)
                {
                    MessageBox.Show(error.ErrorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_anio.Text = "";
                txt_nom.Text = "";
                txt_ape.Text = "";
                txt_domicilio.Text = "";
                txt_diagnostico.Text = "";
                txt_tutor.Text = "";
                txt_colegio.Text = "";
                txt_dni.Text = "";
                txt_nivel.Text = "";
                txt_contTutor.Text = "";
                txt_obs.Text = "";

                // Código para guardar los datos
            }
        }

        public class ConcurrenteValidation : AbstractValidator<NuevoConcurrente>
        {
            public ConcurrenteValidation()
            {
                RuleFor(x => x.txt_dni.Text)
                    .NotEmpty().WithMessage("El DNI es obligatorio.")
                    .Matches(@"^\d{8}$").WithMessage("El DNI debe tener exactamente 8 dígitos.\nNo ingresar puntos.");
                RuleFor(x => x.txt_nom.Text)
                    .NotEmpty().WithMessage("El nombre es obligatorio.");
                RuleFor(x => x.txt_ape.Text)
                    .NotEmpty().WithMessage("El apellido es obligatorio.");
                RuleFor(x => x.date_naci.Value)
                    .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.")
                    .LessThan(DateTime.Now.Date).WithMessage("La fecha de nacimiento debe ser anterior a la fecha actual.");
                RuleFor(x => x.txt_diagnostico.Text)
                    .NotEmpty().WithMessage("El diagnostico es obligatorio.");
                RuleFor(x => x.txt_domicilio.Text)
                    .NotEmpty().WithMessage("La dirección es obligatoria.");
                RuleFor(x => x.txt_colegio.Text)
                    .NotEmpty().WithMessage("El colegio es obligatorio.");
                RuleFor(x => x.txt_anio.Text)
                    .NotEmpty().WithMessage("El año es obligatorio.")
                    .Matches(@"^[1-6]$").WithMessage("El año debe ser un número entre 1 y 6.");
                RuleFor(x => x.txt_nivel.Text)
                    .NotEmpty().WithMessage("El nivel es obligatorio.");               
                RuleFor(x => x.txt_tutor.Text)
                    .NotEmpty().WithMessage("El nombre del tutor es obligatorio.");
                RuleFor(x => x.txt_contTutor.Text)
                    .NotEmpty().WithMessage("El contacto del tutor es obligatorio.")
                    .Matches(@"^\d{10}$").WithMessage("El contacto del tutor debe tener exactamente 10 dígitos y solo contener números.");
                RuleFor(x => x.txt_obs.Text)
                    .NotEmpty().WithMessage("Ingresar no si no cuenta con obra.");


            }
        }
    }
}


