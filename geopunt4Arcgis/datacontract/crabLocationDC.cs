using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geopunt4Arcgis.datacontract
{

    public class crabXY
    {
        public Double Lat_WGS84 { get; set; }
        public Double Lon_WGS84 { get; set; }
        public Double X_Lambert72 { get; set; }
        public Double Y_Lambert72 { get; set; }
    }

    public class crabBoundingBox
    {
        public crabXY LowerLeft { get; set; }
        public crabXY UpperRight { get; set; }
    }

    public class locationResult
    {
        public string FormattedAddress { get; set; }
        public crabXY Location { get; set; }
        public string LocationType { get; set; }
        public crabBoundingBox BoundingBox { get; set; }
    }

    public class crabLocation
    {
        public List<locationResult> LocationResult { get; set; }
    }
}
