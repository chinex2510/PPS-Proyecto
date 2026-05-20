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
    internal class ConcurrentesCL
    {

        private int dni_C;
        private string apellido_C;
        private string nombre_C;
        private string fechaNac_C; //Problablemente se cambie de string a data 
        private string diagnostico_C;
        private string escuela_C;
        private int añoEscolar_C;
        private string nivelEscolar_C;
        private string domicilio_C;
        private string obrasocial_C;

        public int Dni_C { get => dni_C; set => dni_C = value; }
        public string Apellido_C { get => apellido_C; set => apellido_C = value; }
        public string Nombre_C { get => nombre_C; set => nombre_C = value; }
        public string FechaNac_C { get => fechaNac_C; set => fechaNac_C = value; }
        public string Diagnostico_C { get => diagnostico_C; set => diagnostico_C = value; }
        public string Escuela_C { get => escuela_C; set => escuela_C = value; }
        public int AñoEscolar_C { get => añoEscolar_C; set => añoEscolar_C = value; }
        public string NivelEscolar_C { get => nivelEscolar_C; set => nivelEscolar_C = value; }
        public string Domicilio_C { get => domicilio_C; set => domicilio_C = value; }
        public string Obrasocial_C { get => obrasocial_C; set => obrasocial_C = value; }

        private Concurrentes_CD PasarDatos(ConcurrentesCL c)
        {
            return new Concurrentes_CD
            {
                Dni_D = c.Dni_C,
                Apellido_D = c.Apellido_C,
                Nombre_D = c.Nombre_C,
                FechaNac_D = c.FechaNac_C,
                Diagnostico_D = c.Diagnostico_C,
                Escuela_D = c.Escuela_C,
                AñoEscolar_D = c.AñoEscolar_C,
                NivelEscolar_D = c.NivelEscolar_C,
                Domicilio_D = c.Domicilio_C,
                Obrasocial_D = c.Obrasocial_C
            };
        }

        private ConcurrentesCL PasarLogica(Concurrentes_CD c)
        {
            return new ConcurrentesCL
            {
                Dni_C = c.Dni_D,
                Apellido_C = c.Apellido_D,
                Nombre_C = c.Nombre_D,
                FechaNac_C = c.FechaNac_D,
                Diagnostico_C = c.Diagnostico_D,
                Escuela_C = c.Escuela_D,
                AñoEscolar_C = c.AñoEscolar_D,
                NivelEscolar_C = c.NivelEscolar_D,
                Domicilio_C = c.Domicilio_D,
                Obrasocial_C = c.Obrasocial_D
            };
        }

        public void CargarEnSql(ConcurrentesCL concurrente)
        {
            Concurrentes_CD datos = new Concurrentes_CD();
            datos.CargarEnSql(PasarDatos(concurrente));
        }

        public DataTable MostrarTodos()
        {
            Concurrentes_CD datos = new Concurrentes_CD();
            return datos.TablaNuevoConcurrente();
        }

        public ConcurrentesCL SeleccionarPorDni(int dni)
        {
            Concurrentes_CD datos = new Concurrentes_CD();
            var seleccionado = datos.SelectorNuevoConcurrente(dni);
            return PasarLogica(seleccionado);
        }

        public void ModificarDatos(ConcurrentesCL concurrente)
        {
            Concurrentes_CD datos = new Concurrentes_CD();
            datos.ModificarDatos(PasarDatos(concurrente));
        }

        public void EliminarPorDni(ConcurrentesCL concurrente)
        {
            Concurrentes_CD datos = new Concurrentes_CD();
            datos.EliminarNuevoConcurrente(PasarDatos(concurrente));
        }

        public DataTable BuscarConcurrentePorDni(int dni)
        {
            Concurrentes_CD datos = new Concurrentes_CD();
            return datos.BusquedaNuevoConcurrente(dni);
        }


    }
}
