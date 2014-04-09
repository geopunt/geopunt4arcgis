using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using ESRI.ArcGIS.Geometry;

namespace geoPunt4Arcgis
{
    #region "poi.api.geopunt.be reply template"

    public class poiResponse
    {
        public List<poi> pois { get; set; }
        public labelClass label { get; set; }
    }

    public class poi
    {
        public int id { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public List<labelClass> labels { get; set; }
        public List<categoryClass> categories { get; set; }
        public List<linkClass> links { get; set; }
        public locationClass location { get; set; }
    }

    public class labelClass 
    {
        public string term { get; set; }
        public string value  { get; set; }
    }

    public class categoryClass
    {
        public string term { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
    }

    public class linkClass
    {
        public string term { get; set; }
        public string href { get; set; }
        public string value { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
    }

    public class locationClass
    {
        public List<poiPointsClass> points { get; set; }
        public adresClass address { get; set; }
    }
    public class poiPointsClass
    {
        public string term { get; set; }
        public string type { get; set; }
        public poiPointClass Point { get; set; }
    }
    public class poiPointClass
    {
        public List<double> coordinates { get; set; }
        public string type { get; set; }
    }

    public class adresClass 
    {   
        public string value { get; set; }
        public DateTime created { get; set; }
        public string term { get; set; }
        public DateTime updated { get; set; }
    } 

    #endregion
    
    
    class poiRest
    {
        public IRestClient client;

        public poiRest(int timeOut, string proxyUrl="", int port=8080)
        {
            client = new RestClient("http://poi.api.geopunt.be");
            client.Timeout = timeOut;
            if ( proxyUrl != "")
             {
                client.Proxy = new System.Net.WebProxy( proxyUrl, port );
             }
        }

        public poiResponse locate(string q, int c = 5, int srs = 4326, string POIType = "", bool maxModel = true)
        {
            var request = new RestRequest("core", Method.GET);
            request.AddParameter("label", q);
            request.AddParameter("maxcount", c);
            request.AddParameter("srsOut", srs);
            request.AddParameter("srsIn", srs);
            request.AddParameter("POItype", POIType);
            request.AddParameter("maxModel", maxModel.ToString());

            var response = client.Execute<poiResponse>(request);
            poiResponse result = response.Data;
            return result;
        }
        public poiResponse locate(string q, boundingBox bbox, int c=5, int srs=4326, string POIType="", bool maxModel = true )
        {
            var request = new RestRequest("core", Method.GET);
            request.AddParameter("label", q);
            request.AddParameter("maxcount", c);
            request.AddParameter("srsOut", srs);
            request.AddParameter("srsIn", srs);
            request.AddParameter("POItype", POIType);
            request.AddParameter("maxModel", maxModel.ToString());
            request.AddParameter("bbox", bbox.ToString());

            var response = client.Execute<poiResponse>(request);
            poiResponse result = response.Data;
            return result;
        }
    }
}
