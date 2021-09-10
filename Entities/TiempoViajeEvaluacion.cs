using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class TiempoViajeEvaluacion
    {
        public int Secuencia { get; set; }
        public int NumeroConcesionario { get; set; }
        public string Concesionario { get; set; }
        public string Ciudad { get; set; }
        public int TotalOrdenEmbarque { get; set; }
        public int TotalGarantiaDevolucion { get; set; }
        public DateTime LlegadaEstimada { get; set; }
        public DateTime LlegadaReal { get; set; }
        public string EvalLlegada { get; set; }
        public DateTime SalidaEstimada { get; set; }
        public DateTime SalidaReal { get; set; }
        public string EstanciaConc { get; set; }
        public string PersonaRecibe { get; set; }
        public int ClaveFolioViaje { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Entregado { get; set; }
    }
}
