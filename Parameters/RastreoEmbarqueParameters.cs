using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Parameters
{
    public class RastreoEmbarqueParameters
    {
        public string OrdenEmbarque { get; set; }
        public string NumeroPlacas { get; set; }
        public string FolioViaje { get; set; }
        public int? NumeroUnidad { get; set; }
        public string NoCon { get; set; }
        public int? NumeroOperador { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
    }
}
