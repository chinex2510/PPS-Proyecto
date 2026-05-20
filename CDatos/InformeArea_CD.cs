using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioPsicopedagogico.CDatos
{
    internal class InformeArea_CD
    {
        private int id_Informe_D;
        private int id_Area_D;
        private string texto_Area_D;
        private Area_CD area_D;

        public int Id_Informe_D { get => id_Informe_D; set => id_Informe_D = value; }
        public int Id_Area_D { get => id_Area_D; set => id_Area_D = value; }
        public string Texto_Area_D { get => texto_Area_D; set => texto_Area_D = value; }
        internal Area_CD Area_D { get => area_D; set => area_D = value; }
    }
}
