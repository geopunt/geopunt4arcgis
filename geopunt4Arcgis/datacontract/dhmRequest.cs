using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geopunt4Arcgis.datacontract
{
    class dhmRequest
    {
        public int Samples { get; set; }
        public int SrsIn { get; set; }
        public int SrsOut { get; set; }
        public geojsonLine LineString { get; set; }
    }
}
