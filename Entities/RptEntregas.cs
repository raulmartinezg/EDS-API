using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class RptEntregas
    {
        public string Id { get; set; }
        public int ClaveFolioViaje { get; set; }
        public string FolioViaje { get; set; }
        public DateTime FechaEmbarque { get; set; }
        public DateTime InicioViaje { get; set; }
        public int Unidad { get; set; }
        public string Operador { get; set; }
        public string Operador2 { get; set; }
        public string Ayudante1 { get; set; }
        public string Ayudante2 { get; set; }
        public string Ruta { get; set; }
        public string NumeroConcesionario { get; set; }
        public string NombreConcesionario { get; set; }
        public DateTime LlegadaEstimada { get; set; }
        public DateTime LlegadaReal { get; set; }
        public DateTime SalidaEstimada { get; set; }
        public DateTime SalidaReal { get; set; }
        public string Estatus { get; set; }

    }
}
