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

        //manifestation
        public List<datacontract.gipodResponse> getManifestation( 
                DateTime? startdate = null, DateTime? enddate = null,
                string city = "", string province = "", string owner = "", string eventtype = "",
                gipodCRS CRS = gipodCRS.WGS84, int c = 50, int offset = 0, boundingBox bbox = null )
        {
            setQueryValues(startdate, enddate, city, province, owner, eventtype, CRS, c, offset, bbox);

            client.QueryString = qryValues;
            
            Uri gipodUri = new Uri("http://gipod.api.agiv.be/ws/v1/manifestation");
            string json = client.DownloadString(gipodUri);

            List<datacontract.gipodResponse> gipodRespons = JsonConvert.DeserializeObject<List<datacontract.gipodResponse>>(json);
            
            client.QueryString.Clear();
            return gipodRespons;
        }

        public List<datacontract.gipodResponse> allManifestations( DateTime? startdate = null, DateTime? enddate = null,
                string city = "", string province = "", string owner = "", string eventtype = "", gipodCRS CRS = gipodCRS.WGS84, boundingBox bbox = null)
        {
            List<datacontract.gipodResponse> allWA = new List<datacontract.gipodResponse>();
            List<datacontract.gipodResponse> WA = getManifestation( startdate, enddate, city, province, owner, eventtype ,CRS, 500, 0, bbox);

            allWA.AddRange(WA);

            int counter = 0;

            while (WA.Count == 500)
            {
                counter += 500;
                WA = getManifestation(startdate, enddate, city, province, owner, eventtype, CRS, 500, counter);
                allWA.AddRange(WA);
            }
            return allWA;
        }

        //workassignments
        public List<datacontract.gipodResponse> getWorkassignment(DateTime? startdate = null, DateTime? enddate = null,
                string city = "", string province = "", string owner = "", gipodCRS CRS = gipodCRS.WGS84, int c = 50, int offset = 0, boundingBox bbox = null)
        {
            setQueryValues(startdate, enddate, city, province, owner, "", CRS, 500, offset, bbox);

            client.QueryString = qryValues;

            Uri gipodUri = new Uri("http://gipod.api.agiv.be/ws/v1/workassignment");
            string json = client.DownloadString(gipodUri);

            List<datacontract.gipodResponse> gipodRespons = JsonConvert.DeserializeObject<List<datacontract.gipodResponse>>(json);

            client.QueryString.Clear();
            return gipodRespons;
        }

        public List<datacontract.gipodResponse> allWorkassignments(DateTime? startdate = null, DateTime? enddate = null,
                string city = "", string province = "", string owner = "", gipodCRS CRS = gipodCRS.WGS84, boundingBox bbox = null)
        {
            List<datacontract.gipodResponse> allWA = new List<datacontract.gipodResponse>();
            List<datacontract.gipodResponse> WA = getWorkassignment(startdate, enddate, city, province, owner, CRS, 500, 0, bbox);

            allWA.AddRange(WA);

            int counter = 0;

            while (WA.Count == 500)
            {
                counter += 500;
                WA = getWorkassignment(startdate, enddate, city, province, owner, CRS, 500, counter);
                allWA.AddRange(WA);
            }
            return allWA;
        }

        private void setQueryValues(DateTime? startdate, DateTime? enddate, 
            string city, string province, string owner, string eventtype, gipodCRS CRS, int c, int offset, boundingBox bbox = null)
        {
            //counters
            qryValues.Add("offset", offset.ToString());
            qryValues.Add("limit", c.ToString());
            //string lists
            if (city != "" || city != null) qryValues.Add("city", city);
            if (province != "" || province != null) qryValues.Add("province", province);
            if (owner != "" || owner != null) qryValues.Add("owner", owner);
            if (eventtype != "" || eventtype != null) qryValues.Add("eventtype", eventtype);
            //CRS
            qryValues.Add("CRS", Convert.ToString((int)CRS));

            //Time
            if (startdate != null) qryValues.Add("startdate", startdate.Value.ToString("yyyy-MM-dd"));
            if (enddate != null) qryValues.Add("enddate", enddate.Value.ToString("yyyy-MM-dd"));

            //bbox
            if (bbox != null) qryValues.Add("bbox", bbox.ToBboxString(",", "|") );
            
        }

    }
}
