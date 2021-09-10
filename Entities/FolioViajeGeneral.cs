using System;
using System.Collections.Generic;

#nullable disable

namespace EDS_API.Entities
{
    public partial class FolioViajeGeneral
    {
        public int ClaveFolioViaje { get; set; }
        public string FolioViaje { get; set; }
        public string Operador { get; set; }
        public string Unidad { get; set; }
        public string Placa { get; set; }
        public string Ruta { get; set; }
        public DateTime? SalidaProgramada { get; set; }
    }
}
