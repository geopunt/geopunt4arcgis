using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geopunt4Arcgis.dataHandler
{
    public enum gipodCRS { Lambert72 = 31370, WGS84 = 4326, WEBMERCATOR = 3857 }

    public enum gipodtype { workassignment, manifestation }

    public enum gipodReferencedata { city, province, eventtype, owner }

    public struct gipodParam
    {
        public gipodtype gipodType;
        public boundingBox bbox;
        public string city;
        public string province;
        public string owner;
        public string eventtype;
        public DateTime startdate;
        public DateTime enddate;
        public gipodCRS crs;
        public string shapePath;
    }
}
