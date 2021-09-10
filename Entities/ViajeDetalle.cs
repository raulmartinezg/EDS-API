using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class ViajeDetalle
    {
        public string OrdenEmbarque { get; set; }
        public string Descripcion { get; set; }
        public string SKU { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaProcesada { get; set; }
    }
}
