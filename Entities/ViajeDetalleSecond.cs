using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class ViajeDetalleSecond
    {
        public int Guias { get; set; }
        public int Items { get; set; }
        public int Piezas { get; set; }
        public int Entregado { get; set; }
        public int NoCapturado { get; set; }
        public int Danno { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Tiempo { get; set; }
    }
}
