using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Entities
{
    public class MensualCVRObject
    {
        public List<MensualCVR> Table0 { get; set; }
        public List<MensualCVRSecond> Table1 { get; set; }
        public List<MensualCVRThird> Table2 { get; set; }
    }
}
