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
    internal class TurnoCL
    {
        private int dniConcurrenteTurno_C;
        private string fechaTurno_C;
        private string horaTurno_C;

        public int DniConcurrenteTurno_C { get => dniConcurrenteTurno_C; set => dniConcurrenteTurno_C = value; }
        public string FechaTurno_C { get => fechaTurno_C; set => fechaTurno_C = value; }
        public string HoraTurno_C { get => horaTurno_C; set => horaTurno_C = value; }

        private Turnos_CD PasarDatos(TurnoCL t)
        {
            return new Turnos_CD
            {
                DniConcurrenteTurno_D = t.DniConcurrenteTurno_C,
                FechaTurno_D = t.FechaTurno_C,
                HoraTurno_D = t.HoraTurno_C
            };
        }

        private TurnoCL PasarLogica(Turnos_CD t)
        {
            return new TurnoCL
            {
                DniConcurrenteTurno_C = t.DniConcurrenteTurno_D,
                FechaTurno_C = t.FechaTurno_D,
                HoraTurno_C = t.HoraTurno_D
            };
        }

        public void GuardarOModificarTurno(TurnoCL turno, bool esNuevo)
        {
            Turnos_CD datos = new Turnos_CD();
            datos.Guardar_Modificar_Turno(PasarDatos(turno), esNuevo);
        }

        // Eliminar turno por DNI
        public void EliminarTurno(TurnoCL turno)
        {
            Turnos_CD datos = new Turnos_CD();
            datos.EliminarTurno(PasarDatos(turno));
        }

        // Mostrar todos los turnos
        public DataTable MostrarTurnos()
        {
            Turnos_CD datos = new Turnos_CD();
            return datos.TablaTurnos();
        }

    }
}
