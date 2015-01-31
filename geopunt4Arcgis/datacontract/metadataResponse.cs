using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace geopunt4Arcgis.datacontract
{
    public class metadata
    {
        public string sourceID { get; set; }
        public List<string> links { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

}
