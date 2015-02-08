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
    class poi
    {
        public WebClient client;
        NameValueCollection qryValues;
        string baseUrl;

        public poi(string proxyUrl = "", int port = 80)
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
            baseUrl = "http://poi.api.geopunt.be/core";
        }

        public datacontract.poiCategories listThemes()
        {
            Uri poiUri = new Uri( baseUrl + "/themes");
            string json = client.DownloadString(poiUri);

            datacontract.poiCategories poiResponse = JsonConvert.DeserializeObject<datacontract.poiCategories>(json);

            client.QueryString.Clear();
            return poiResponse;
        }

        public datacontract.poiCategories listCategories(string themeid = null) 
        {
            Uri poiUri;
            if (themeid == null || themeid == "" ) poiUri = new Uri(baseUrl + "/categories");
            else poiUri = new Uri(baseUrl + string.Format("/themes/{0}/categories", themeid));
            string json = client.DownloadString(poiUri);

            datacontract.poiCategories poiResponse = JsonConvert.DeserializeObject<datacontract.poiCategories>(json);

            client.QueryString.Clear();
            return poiResponse;
        }

        public datacontract.poiCategories listPOItypes(string themeid = null, string categoryid = null)
        {
            Uri poiUri;
            if ((themeid != "" && themeid != null) && (categoryid != "" && categoryid != null))
            {
                poiUri = new Uri(baseUrl + string.Format("/themes/{0}/categories/{1}/poitypes", themeid, categoryid));
            }
            else
            {
                poiUri = new Uri(baseUrl +"/poitypes");
            }

            string json = client.DownloadString(poiUri);

            datacontract.poiCategories poiResponse = JsonConvert.DeserializeObject<datacontract.poiCategories>(json);

            client.QueryString.Clear();
            return poiResponse;
        }

        public datacontract.poiMinResponse getMinmodel(string q = null, string theme = null, string category = null, 
            string POItype = null, CRS srs = CRS.WGS84, int? id = null, string niscode = null, boundingBox bbox = null)
        {
            setQueryValues(q, 1000, false, theme, category, POItype, srs, id, niscode, bbox );
            client.QueryString = qryValues;

            Uri poiUri = new Uri("http://poi.api.geopunt.be/core");

            string json = client.DownloadString(poiUri);

            datacontract.poiMinResponse poiResponse = JsonConvert.DeserializeObject<datacontract.poiMinResponse>(json);

            client.QueryString.Clear();

            return poiResponse;
        }

        public datacontract.poiMaxResponse getMaxmodel(string q = null, int c = 30, string theme = null, string category = null,
            string POItype = null, CRS srs = CRS.WGS84, int? id = null, string niscode = null, boundingBox bbox = null)
        {
            setQueryValues(q, c, true, theme, category, POItype, srs, id, niscode, bbox);
            client.QueryString = qryValues;

            Uri poiUri = new Uri("http://poi.api.geopunt.be/core");

            string json = client.DownloadString(poiUri);

            datacontract.poiMaxResponse poiResponse = JsonConvert.DeserializeObject<datacontract.poiMaxResponse>(json);

            client.QueryString.Clear();

            return poiResponse;
        }

        private void setQueryValues( string q = "", int c = 30 , bool maxModel = false,
             string theme = null, string category = null, string POItype = null, CRS srs = CRS.WGS84, 
             int? id = null, string niscode = null, boundingBox bbox = null)
        {
            if (q != null || q != "") qryValues.Add("keyword", q);
            
            //srs
            qryValues.Add("srsIn", Convert.ToString((int)srs));
            qryValues.Add("srsOut", Convert.ToString((int)srs));
            //string lists
            if (id != null ) qryValues.Add("id", id.ToString());
            if (niscode != null || niscode != "") qryValues.Add("region", niscode);
            if (theme != null || theme != "" ) qryValues.Add("theme", theme);
            if (category != null || category != "" ) qryValues.Add("category", category);
            if (POItype != null || POItype != "" ) qryValues.Add("POItype", POItype);
            qryValues.Add("maxcount", c.ToString());

            if (maxModel)
            {
                qryValues.Add("maxmodel", "true");
            }
            else
            {
                qryValues.Add("maxmodel", "false");
            }

            if (bbox != null) qryValues.Add("bbox", bbox.ToBboxString("|", "|"));
        }
    }
}
