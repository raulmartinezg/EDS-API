using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class RastreoEmbarqueSecond
    {
        public int ClaveFolioViaje { get; set; }
        public DateTime FInicioCarga { get; set; }
        public DateTime FFinCarga { get; set; }
        public DateTime FSalidaProgramada { get; set; }
        public DateTime FSalidaReal { get; set; }
        public int Items { get; set; }
        public double TiempoMinutosViaje { get; set; }
        public DateTime FFinServicio { get; set; }
        public string TiempoViaje { get; set; }
        public string TiempoRutaReal { get; set; }
    }
}
