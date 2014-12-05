using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geopunt4Arcgis.datacontract
{
    public class workassignment
    {
        public int gipodId { get; set; }
        public string owner { get; set; }
        public string description { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public bool importantHindrance { get; set; }
        public geojsonPoint coordinate { get; set; }
        public string detail { get; set; }
        public List<string> cities { get; set; }
    }

    public class manifestation : workassignment
    {
        public string initiator { get; set; }
        public string eventType { get; set; }
        public string recurrencePattern { get; set; }
    }

}
