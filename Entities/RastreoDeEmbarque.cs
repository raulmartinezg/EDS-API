using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class RastreoDeEmbarque
    {
        
        public string Placas { get; set; }
        public int ClaveFolioViaje { get; set; }
        public string FolioViaje { get; set; }
        public string Ruta { get; set; }
        public int Unidad { get; set; }
        public string Operador { get; set; }
        public string Destino { get; set; }
        public int NoParadas { get; set; }
        public int Bultos { get; set; }
        public DateTime FFinCargar { get; set; }
        public DateTime InicioViaje { get; set; }
        public DateTime LlegadaProgramada { get; set; }
        public int EstatusFolio { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Localidad { get; set; }
        public DateTime FechaPosicion { get; set; }
        public int Porciento { get; set; }
        public int Pictograma { get; set; }
        public double Porciento2 { get; set; }
        public DateTime PrimerParada { get; set; }
        public DateTime UltimaParada { get; set; }
        public int CvEncuesta { get; set; }
    }
}
