using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultorioPsicopedagogico.CDatos;
using ConsultorioPsicopedagogico.CLogica;
using System.Data;

namespace ConsultorioPsicopedagogico.CLogica
{
    internal class TutorCL
    {

        private int dniTutor_C;
        private string apellidoTutor_C;
        private string nombreTutor_C;
        private string parentezcoTutor_C;
        private string telefonoTutor_C;
        private string emailTutor_C;

        public int DniTutor_C { get => dniTutor_C; set => dniTutor_C = value; }
        public string ApellidoTutor_C { get => apellidoTutor_C; set => apellidoTutor_C = value; }
        public string NombreTutor_C { get => nombreTutor_C; set => nombreTutor_C = value; }
        public string ParentezcoTutor_C { get => parentezcoTutor_C; set => parentezcoTutor_C = value; }
        public string TelefonoTutor_C { get => telefonoTutor_C; set => telefonoTutor_C = value; }
        public string EmailTutor_C { get => emailTutor_C; set => emailTutor_C = value; }

        private Tutor_CD PasarDatos(TutorCL t)
        {
            return new Tutor_CD
            {
                DniTutor_D = t.DniTutor_C,
                ApellidoTutor_D = t.ApellidoTutor_C,
                NombreTutor_D = t.NombreTutor_C,
                ParentezcoTutor_D = t.ParentezcoTutor_C,
                TelefonoTutor_D = t.TelefonoTutor_C,
                EmailTutor_D = t.EmailTutor_C
            };
        }

        // 🔁 Pasar de datos a lógica
        private TutorCL PasarLogica(Tutor_CD t)
        {
            return new TutorCL
            {
                DniTutor_C = t.DniTutor_D,
                ApellidoTutor_C = t.ApellidoTutor_D,
                NombreTutor_C = t.NombreTutor_D,
                ParentezcoTutor_C = t.ParentezcoTutor_D,
                TelefonoTutor_C = t.TelefonoTutor_D,
                EmailTutor_C = t.EmailTutor_D
            };
        }

        // ✅ Guardar o modificar tutor (si esNuevo = true -> guarda, false -> modifica)
        public void GuardarOModificarTutor(TutorCL tutor, bool esNuevo)
        {
            Tutor_CD datos = new Tutor_CD();
            datos.Guardar_Modificar_Tutor(PasarDatos(tutor), esNuevo);
        }

        // ✅ Eliminar tutor por DNI
        public void EliminarTutor(TutorCL tutor)
        {
            Tutor_CD datos = new Tutor_CD();
            datos.EliminarTutor(PasarDatos(tutor));
        }

        // ✅ Buscar un tutor por DNI
        public TutorCL BuscarTutor(int dni)
        {
            Tutor_CD datos = new Tutor_CD();
            Tutor_CD tutorDatos = datos.SelectorTutor(dni);
            return tutorDatos != null ? PasarLogica(tutorDatos) : null;
        }

        // ✅ Mostrar todos los tutores
        public DataTable MostrarTutores()
        {
            Tutor_CD datos = new Tutor_CD();
            return datos.TablaTutores();
        }

    }
}
