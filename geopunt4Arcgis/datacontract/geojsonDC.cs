using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geopunt4Arcgis.datacontract
{
    public class geojsonPoint
    {
        public List<double> coordinates { get; set; }
        public string type  { get; set; }

        public geojsonCRS crs  { get; set; }
     }

    public class geojsonLine
    {
        public List<List<double>> coordinates { get; set; }
        public string type  { get; set; }

        public geojsonCRS crs  { get; set; }
    }

    public class geojsonCRS
    {
        public string type  { get; set; }
        IDictionary<string, string> properties { get; set; }
    }

}
