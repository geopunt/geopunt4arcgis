using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace geopunt4Arcgis.dataHandler
{
    class gipodManifestation
    {
        public delegate void gipodManifestationDelegate(object sender, DownloadStringCompletedEventArgs e);
        public WebClient client;
        NameValueCollection qryValues;
        Uri gipodUri;

        public gipodManifestation(gipodManifestationDelegate callback, string proxyUrl = "", int port = 80)
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
            gipodUri = new Uri("http://gipod.api.agiv.be/ws/v1/manifestation");
            qryValues = new NameValueCollection();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(callback);
        }

        public gipodManifestation(string proxyUrl = "", int port = 80)
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
            gipodUri = new Uri("http://gipod.api.agiv.be/ws/v1/manifestation");
            qryValues = new NameValueCollection();
        }

        public void getManifestationAsync(DateTime? startdate = null, DateTime? enddate = null,
                string city = "", string province = "", string owner = "", string eventtype = "",
                gipodCRS CRS = gipodCRS.WGS84, int c = 50, int offset = 0)
        {
            Uri gipodUri = new Uri("http://gipod.api.agiv.be/ws/v1/manifestation");
        }

        public List<datacontract.manifestation> getManifestation( DateTime? startdate = null, DateTime? enddate = null,
                string city = "", string province = "", string owner = "", string eventtype = "",
                gipodCRS CRS = gipodCRS.WGS84, int c = 50, int offset = 0)
        {

            setQueryValues(startdate, enddate, city, province, owner, eventtype, CRS, c, offset);

            client.QueryString = qryValues;
            string json = client.DownloadString(gipodUri);
            List<datacontract.manifestation> gipodResponse = JsonConvert.DeserializeObject<List<datacontract.manifestation>>(json);
            
            client.QueryString.Clear();
            return gipodResponse;
        }

        private void setQueryValues(DateTime? startdate, DateTime? enddate, 
            string city, string province, string owner, string eventtype, gipodCRS CRS, int c, int offset)
        {
            //counters
            qryValues.Add("offset", offset.ToString());
            qryValues.Add("limit", c.ToString());
            //string lists
            if (city != "") qryValues.Add("city", city);
            if (province != "") qryValues.Add("province", province);
            if (owner != "") qryValues.Add("owner", owner);
            if (eventtype != "") qryValues.Add("eventtype", eventtype);
            //CRS
            qryValues.Add("CRS", Convert.ToString((int)CRS));

            //Time
            if (startdate != null) qryValues.Add("startdate", startdate.Value.ToString("yyyyy-MM-dd"));
            if (enddate != null) qryValues.Add("enddate", enddate.Value.ToString("yyyyy-MM-dd"));
        }

    }
}
