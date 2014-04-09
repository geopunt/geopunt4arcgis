using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace geoPunt4Arcgis
{
    #region "loc.api.geopunt.be reply template"

    public class crabLocation
    {
        public Double Lat_WGS84 { get; set; }
        public Double Lon_WGS84 { get; set; }
        public Double X_Lambert72 { get; set; }
        public Double Y_Lambert72 { get; set; }
    }

    public class crabBoundingBox
    {
        public crabLocation LowerLeft { get; set; }
        public crabLocation UpperRight { get; set; }
    }

    public class locationResult
    {
        public string FormattedAddress { get; set; }
        public crabLocation Location { get; set; }
        public string LocationType { get; set; }
        public crabBoundingBox BoundingBox { get; set; }
    }

    public class crabResponse
    {
        public List<locationResult> LocationResult { get; set; }
    }

    public class crabSuggestion {
        public List<string> SuggestionResult { get; set; }
    }

    #endregion

    class crabRest
    {
        public IRestClient client;

        public crabRest(int timeOut, string proxyUrl = "", int port = 8080)
        {
            client = new RestClient("http://loc.api.geopunt.be");
            client.Timeout = timeOut;
            if (proxyUrl != "")
            {
                client.Proxy = new System.Net.WebProxy(proxyUrl, port);
            }
        }

        public crabResponse geolocate(  string q , int c) {
            var request = requestGeolocate(q, c);
            var response = client.Execute<crabResponse>(request);
            crabResponse result = response.Data;
            return result;
        }

        public static RestRequest requestGeolocate(string q, int c)
        {
            var request = new RestRequest("geolocation/Location", Method.GET);
            request.AddParameter("q", q);
            request.AddParameter("c", c);
            return request;
        }

        public crabResponse reverseGeolocate( Double x_wgs, double y_wgs, int c)
        {
            string q = string.Format("{0},{1}", y_wgs, x_wgs);
            var request = requestGeolocate(q, c);
            var response = client.Execute<crabResponse>(request);
            crabResponse result = response.Data;
            return result;
        } 


        public crabSuggestion suggestion(string q, int c)
        {
            var request = requestSuggestion(q, c);
            var response = client.Execute<crabSuggestion>(request);
            crabSuggestion result = response.Data;
            return result;
        }

        public static RestRequest requestSuggestion(string q, int c)
        {
            var request = new RestRequest("geolocation/Suggestion", Method.GET);
            request.AddParameter("q", q);
            request.AddParameter("c", c);
            return request;
        }

    }
}
