using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geopunt4Arcgis.datacontract
{

    public abstract class geojson
    {
        public string type { get; set; }
        public geojsonCRS crs { get; set; }
    }

    public class geojsonPoint : geojson
    {
        public List<double> coordinates { get; set; }
     }

    public class geojsonLine : geojson
    {
        public List<List<double>> coordinates { get; set; }
    }

    public class geojsonPolygon : geojson
    {
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class geojsonCRS 
    {
        public string type  { get; set; }
        public IDictionary<string, string> properties { get; set; }
    }

}
