using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class ReporteTipoEncuesta
    {
        public string Id { get; set; }
        public string FolioViaje { get; set; }
        public int Unidad { get; set; }
        public string Operador { get; set; }
        public DateTime SalidaProgramada { get; set; }
        public string NumeroConcesionario { get; set; }
        public string RazonSocial { get; set; }
        public DateTime FechaEncuesta { get; set; }
        public string TipoEncuesta { get; set; }

    }
}
