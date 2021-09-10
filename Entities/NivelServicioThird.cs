using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class NivelServicioThird
    {
        public int ClaveNivelSerMensual { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string MesL { get; set; }
        public int Total { get; set; }
        public int Atiempo { get; set; }
        public int Tarde { get; set; }
        public int Sindatos { get; set; }
        public int PorcAtiempo { get; set; }
        public int Target { get; set; }

    }
}
