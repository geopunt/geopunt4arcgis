using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace geopunt4Arcgis.dataHandler
{
    public class adresSuggestion
    {
        public delegate void adresSuggestionDelegate(object sender, DownloadStringCompletedEventArgs e);
        public WebClient client;

        public adresSuggestion( adresSuggestionDelegate callback, string proxyUrl = ""  , int port = 80)
        {
            if (proxyUrl == null || proxyUrl == "" )
            {
                client = new WebClient() { Encoding = System.Text.Encoding.UTF8 };
            }
            else {
                client = new WebClient() { Encoding = System.Text.Encoding.UTF8, 
                                           Proxy = new System.Net.WebProxy(proxyUrl, port) };
            }
            client.Headers["Content-type"] = "application/json";
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(callback);
         }

        public adresSuggestion( string proxyUrl = "", int port = 80)
        {
            if (proxyUrl == null || proxyUrl == "")
            {
                client = new WebClient() { Encoding = System.Text.Encoding.UTF8 };
            }
            else
            {
                client = new WebClient() { Encoding = System.Text.Encoding.UTF8, 
                                           Proxy = new System.Net.WebProxy(proxyUrl, port) };
            }
            client.Headers["Content-type"] = "application/json";
        }

        public void getAdresSuggestionAsync(string q, int c = 5)
        {
            string adresUrl = string.Format("http://loc.api.geopunt.be/geolocation/Suggestion?c={1}25&q={0}", q, c);
            client.DownloadStringAsync(new Uri( adresUrl ));
        }

        public List<string> getAdresSuggestion(string q, int c = 5)
        {
            string adresUrl = string.Format("http://loc.api.geopunt.be/geolocation/Suggestion?c={1}25&q={0}", q, c);
            string json = client.DownloadString(new Uri(adresUrl));
            datacontract.crabSuggestion crabSug = JsonConvert.DeserializeObject<datacontract.crabSuggestion>(json);
            return crabSug.SuggestionResult;
        }
    }


    public class adresLocation
    {
        public delegate void adresLocationDelegate(object sender, DownloadStringCompletedEventArgs e);
        public WebClient client;

        public adresLocation(adresLocationDelegate callback, string proxyUrl = "", int port = 80)
        {
            if (proxyUrl == null || proxyUrl == "")
            {
                client = new WebClient() { Encoding = System.Text.Encoding.UTF8 };
            }
            else
            {
                client = new WebClient() { Encoding = System.Text.Encoding.UTF8, Proxy = new System.Net.WebProxy(proxyUrl, port) };
            }
            client.Headers["Content-type"] = "application/json";
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(callback);
        }

        public adresLocation(string proxyUrl = "", int port = 80)
        {
            if (proxyUrl == null | proxyUrl == "")
            {
                client = new WebClient() { Encoding = System.Text.Encoding.UTF8 };
            }
            else
            {
                client = new WebClient() { Encoding = System.Text.Encoding.UTF8, Proxy = new System.Net.WebProxy(proxyUrl, port) };
            }

            client.Headers["Content-type"] = "application/json";
        }

        public void getAdresLocationAsync(string q, int c = 1)
        {
            string adresUrl = string.Format("http://loc.api.geopunt.be/geolocation/Location?c={1}&q={0}", q, c);
            client.DownloadStringAsync(new Uri(adresUrl));
        }

        public List<datacontract.locationResult> getAdresLocation(string q, int c = 1)
        {
            string adresUrl = string.Format("http://loc.api.geopunt.be/geolocation/Location?c={1}&q={0}", q, c);
            string json = client.DownloadString(new Uri(adresUrl));
            datacontract.crabLocation crabLoc = JsonConvert.DeserializeObject<datacontract.crabLocation>(json);
            return crabLoc.LocationResult;
        }

        public void getXYadresLocationAsync(Double xLam72, Double yLam72, int c = 1)
        {
            string adresUrl = string.Format("http://loc.api.geopunt.be/geolocation/Location?xy={0},{1}&c={2}", xLam72, yLam72, c);
            client.DownloadStringAsync(new Uri(adresUrl));
        }

        public List<datacontract.locationResult> getXYadresLocation(Double xLam72, Double yLam72, int c = 1)
        {
            string adresUrl = string.Format("http://loc.api.geopunt.be/geolocation/Location?xy={0},{1}&c={2}", xLam72, yLam72, c);
            string json = client.DownloadString(new Uri(adresUrl));
            datacontract.crabLocation crabLoc = JsonConvert.DeserializeObject<datacontract.crabLocation>(json);
            return crabLoc.LocationResult;
        }
    
    }


}
