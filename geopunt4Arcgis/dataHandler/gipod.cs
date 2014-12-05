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
    class gipod
    {
        public WebClient client;
        NameValueCollection qryValues;

        public gipod(string proxyUrl = "", int port = 80)
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
            qryValues = new NameValueCollection();
        }

        public List<string> getReferencedata(gipodReferencedata typeReferenceData)
        {
            string tail;
            switch (typeReferenceData)
            {
                case gipodReferencedata.city:
                    tail = "city"; break;
                case gipodReferencedata.province:
                    tail = "province"; break;
                case gipodReferencedata.owner:
                    tail = "owner"; break;
                case gipodReferencedata.eventtype:
                    tail = "eventtype"; break;
                default: return null;
            }

            client.QueryString = qryValues;
            Uri gipodUri = new Uri("http://gipod.api.agiv.be/ws/v1/referencedata/" + tail);
            string json = client.DownloadString(gipodUri);
            List<string> gipodResponse = JsonConvert.DeserializeObject<List<string>>(json);
            return gipodResponse;
        }

        public List<datacontract.manifestation> getManifestation( DateTime? startdate = null, DateTime? enddate = null,
                string city = "", string province = "", string owner = "", string eventtype = "",
                gipodCRS CRS = gipodCRS.WGS84, int c = 50, int offset = 0)
        {
            setQueryValues(startdate, enddate, city, province, owner, eventtype, CRS, c, offset);

            client.QueryString = qryValues;
            Uri gipodUri = new Uri("http://gipod.api.agiv.be/ws/v1/manifestation");
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
            if (startdate != null) qryValues.Add("startdate", startdate.Value.ToString("yyyy-MM-dd"));
            if (enddate != null) qryValues.Add("enddate", enddate.Value.ToString("yyyy-MM-dd"));
        }

    }
}
