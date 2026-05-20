using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultorioPsicopedagogico.CDatos;
using System.Data;

namespace ConsultorioPsicopedagogico.CLogica
{
    internal class InformeCL
    {
        private int id_Informe_D;
        private string fecha_Informe_D;
        private Concurrentes_CD concurrente_D;
        private Tutor_CD tutor_D;
        private List<InformeArea_CD> informeAreas_D;

        public int Id_Informe_D { get => id_Informe_D; set => id_Informe_D = value; }
        public string Fecha_Informe_D { get => fecha_Informe_D; set => fecha_Informe_D = value; }
        public Concurrentes_CD Concurrente_D { get => concurrente_D; set => concurrente_D = value; }
        public Tutor_CD Tutor_D { get => tutor_D; set => tutor_D = value; }
        public List<InformeArea_CD> InformeAreas_D { get => informeAreas_D; set => informeAreas_D = value; }

        // Método público que usa la clase de datos para obtener y cargar los datos
        public bool CargarInformePorId(int idInforme)
        {
            Informes_CD datos = new Informes_CD();

            bool cargado = datos.CargarInformeCompleto(idInforme);

            if (cargado)
            {
                Id_Informe_D = datos.Id_Informe_D;
                Fecha_Informe_D = datos.Fecha_Informe_D;
                Concurrente_D = datos.Concurrente_D;
                Tutor_D = datos.Tutor_D;
                InformeAreas_D = datos.InformeAreas_D;
            }

            return cargado;
        }
    }
}
