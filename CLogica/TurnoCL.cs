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
        private int idTurno_C;
        private int dniConcurrenteTurno_C;
        private int dniUsuario_C;
        private string fechaTurno_C;
        private string horaTurno_C;

        private string nombreConcurrenteTurno_C;

        public int IdTurno_C { get => idTurno_C; set => idTurno_C = value; }
        public int DniConcurrenteTurno_C { get => dniConcurrenteTurno_C; set => dniConcurrenteTurno_C = value; }
        public int DniUsuario_C { get => dniUsuario_C; set => dniUsuario_C = value; }
        public string FechaTurno_C { get => fechaTurno_C; set => fechaTurno_C = value; }
        public string HoraTurno_C { get => horaTurno_C; set => horaTurno_C = value; }
        public string NombreConcurrenteTurno_C { get => nombreConcurrenteTurno_C; set => nombreConcurrenteTurno_C = value; }

        private Turnos_CD PasarDatos(TurnoCL t)
        {
            return new Turnos_CD
            {
                IdTurno_D = t.IdTurno_C,
                DniConcurrenteTurno_D = t.DniConcurrenteTurno_C,
                DniUsuario_D = t.DniUsuario_C,
                FechaTurno_D = t.FechaTurno_C,
                HoraTurno_D = t.HoraTurno_C,
                NombreConcurrenteTurno_D = t.NombreConcurrenteTurno_C
            };
        }

        private TurnoCL PasarLogica(Turnos_CD t)
        {
            return new TurnoCL
            {
                IdTurno_C = t.IdTurno_D,
                DniConcurrenteTurno_C = t.DniConcurrenteTurno_D,
                DniUsuario_C = t.DniUsuario_D,
                FechaTurno_C = t.FechaTurno_D,
                HoraTurno_C = t.HoraTurno_D,
                NombreConcurrenteTurno_C = t.NombreConcurrenteTurno_D
            };
        }

        public void GuardarOModificarTurno(TurnoCL turno, bool esNuevo)
        {
            Turnos_CD datos = new Turnos_CD();
            datos.Guardar_Modificar_Turno(PasarDatos(turno), esNuevo);
        }

        // Eliminar turno por ID
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

        /// <summary>
        /// Obtiene la lista de horas disponibles (de 9:00 a 18:00 cada 30 min) para un especialista y fecha dados.
        /// </summary>
        public List<string> ObtenerHorasDisponibles(int dniEspecialista, string fecha)
        {
            // Definir lista completa de horarios (de 09:00 a 18:00 cada media hora)
            List<string> todasLasHoras = new List<string>
            {
                "09:00", "09:30", "10:00", "10:30", "11:00", "11:30",
                "12:00", "12:30", "13:00", "13:30", "14:00", "14:30",
                "15:00", "15:30", "16:00", "16:30", "17:00", "17:30",
                "18:00"
            };

            Turnos_CD datos = new Turnos_CD();
            List<string> horasOcupadas = datos.ObtenerHorasOcupadas(dniEspecialista, fecha);

            // Filtrar y retornar solo las que no están en la lista de ocupadas
            return todasLasHoras.Where(h => !horasOcupadas.Contains(h)).ToList();
        }
    }
}
