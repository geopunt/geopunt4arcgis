using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geopunt4Arcgis.datacontract
{
    public class poiValueGroup
    {
        public string term { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }
    
    public class poiLink : poiValueGroup
    {
        public string href { get; set; }
    }
    
    public class poiPoint : poiValueGroup
    {
        public geojsonPoint Point { get; set; }
        public poiValueGroup author { get; set; }
        public string pointQuality { get; set; }
    }
    
    public class poiCategories
    {
        public List<poiValueGroup> categories { get; set; }
    }

    public class poiAddress 
    {
        public string boxnumber { get; set; }
        public string municipality { get; set; }
        public string postalcode { get; set; }
        public string street { get; set; }
        public string streetnumber { get; set; }
        public string term { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string typedescription { get; set; }
    }

    public class poiLocation
    {
        public poiAddress address { get; set; }
        public List<poiPoint> points { get; set; }
    }

    public class cluster
    {
        public int count { get; set; }
        public poiPoint point { get; set; }
    }

    public class poiMinModel 
    {
        public int id { get; set; }
        public List<poiValueGroup> labels { get; set; }
        public List<poiValueGroup> categories { get; set; }
        public List<poiLink> links { get; set; }
        public poiLocation location { get; set; }
    }

    public class poiMaxModel : poiMinModel
    {
        public string phone { get; set; }
        public string email { get; set; }
        public poiValueGroup description { get; set; }

        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public List<poiLink> authors { get; set; }
        public poiLink license { get; set; }
    }

    public class poiMinResponse
    {
        public List<cluster> clusters  { get; set; }
        public poiValueGroup label { get; set; }
        public List<poiMinModel> pois { get; set; }
    }

    public class poiMaxResponse
    {
        public List<poiValueGroup> labels { get; set; }
        public List<poiMaxModel> pois { get; set; }
    }
}
