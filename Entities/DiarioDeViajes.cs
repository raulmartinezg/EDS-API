using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class DiarioDeViajes
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string RutaClasificada { get; set; }
        public string FolioViaje { get; set; }
        public int Unidad { get; set; }
        public string TipoUnidad { get; set; }
        public string Nombre { get; set; }
        public int Concesionarios { get; set; }
        public int Embarques { get; set; }
        public int Items { get; set; }
        public int PorcentajeCarga { get; set; }
        public string UltimaCiudad { get; set; }
        public string NumeroConcesionario { get; set; }
        public int Rebotes { get; set; }
        public string DiasTransito { get; set; }
        public string Dealer { get; set; }
    }
}
