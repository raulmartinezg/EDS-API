using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class Calidad
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public int Excelente { get; set; }
        public int Bueno { get; set; }
        public int Regular { get; set; }
        public int Deficiente { get; set; }

    }
}
