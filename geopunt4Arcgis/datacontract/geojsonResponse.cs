using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geopunt4Arcgis.datacontract
{

    public class geojson
    {
        public string type { get; set; }
        public geojsonCRS crs { get; set; }
    }

    public class geojsonPoint : geojson
    {
        public  List<double> coordinates { get; set; }
     }

    public class geojsonLine : geojson
    {
        public  List<List<double>> coordinates { get; set; }
    }

    public class geojsonPolygon : geojson
    {
        public  List<List<List<double>>> coordinates { get; set; }
    }

    public class geojsonMultiPolygon : geojson
    {
        public  List<List<List<List<double>>>> coordinates { get; set; }

        public List<geojsonPolygon> toPolygonList() 
        {
            List<geojsonPolygon> polyList = new List<geojsonPolygon>();
            for (int n = 0; n < coordinates.Count; n++) {
                geojsonPolygon poly = new geojsonPolygon()
                {
                    coordinates = coordinates[n],
                    type = "Polygon",
                    crs = crs
                };
                polyList.Add(poly);
            }

            return polyList;
        }
    }

    public class geojsonCRS 
    {
        public string type  { get; set; }
        public IDictionary<string, string> properties { get; set; }
    }

}
