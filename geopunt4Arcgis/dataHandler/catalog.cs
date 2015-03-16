using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;


namespace geopunt4Arcgis.dataHandler
{
    class catalog
    {
        public WebClient client;
        NameValueCollection qryValues;

        public string geoNetworkUrl = "https://metadata.geopunt.be/zoekdienst/srv/dut";
        
        public Dictionary<string, string> dataTypes = new Dictionary<string, string>() { 
                   {"Dataset","dataset"}, {"Datasetserie","series"}, 
                   {"Objectencatalogus","model"}, {"Service","service"} };
        
        public List<string> inspireServiceTypes = new List<string>() { "", 
                    "Discovery", "Transformation", "View", "Other", "Invoke" };
        
        public List<string> inpireAnnex = new List<string>(){ "", "i","ii","iii"};

        public catalog(string proxyUrl = "", int port = 80, int timeout = 5000)
        {
            if (proxyUrl == null || proxyUrl == "")
            {
                client = new gpWebClient() { Encoding = System.Text.Encoding.UTF8, timeout= timeout };
            }
            else
            {
                client = new gpWebClient() { Encoding = System.Text.Encoding.UTF8, 
                                           Proxy = new System.Net.WebProxy(proxyUrl, port), timeout= timeout };
            }
            client.Headers["Content-type"] = "application/json";
            qryValues = new NameValueCollection();
        }

        public List<string> getKeyWords(string q = "", string field = "any")
        {
            qryValues.Add("q", q);
            qryValues.Add("field", field);
            client.QueryString = qryValues;

            string url = geoNetworkUrl + "/main.search.suggest" ;

            string jsonString = client.DownloadString(new Uri(url));
            JArray jsonArr = JArray.Parse(jsonString) as JArray;
            JArray keywords = (JArray)jsonArr[1];

            qryValues.Clear();
            client.QueryString.Clear();
            return keywords.Select(c => (string)c).ToList();
        }

        public List<string> getOrganisations() {
            string url = geoNetworkUrl + @"/main.search.suggest?field=orgName";
            string jsonString = client.DownloadString(new Uri(url));
            JArray jsonArr = JArray.Parse(jsonString) as JArray;
            JArray orgs = (JArray)jsonArr[1];
            return orgs.Select(c => (string)c).ToList();
        }

        public List<string> inspireKeywords() 
        {
            List<string> keywords = new List<string>();
            string url = geoNetworkUrl +
                @"/xml.search.keywords?pNewSearch=true&pTypeSearch=1&pThesauri=external.theme.inspire-theme&pKeyword=*";

            string xmlDoc = client.DownloadString(new Uri(url));
            XElement element = XElement.Parse(xmlDoc);
            IEnumerable<XElement> sources = element.Element("descKeys").Elements("keyword");
            foreach (var item in sources)
            {
                string name = item.Element("value").Value;
                keywords.Add(name);
            }
            return keywords;
        }

        public Dictionary<string, string> getSources()
        {
            Dictionary<string, string> sourcesDict = new Dictionary<string, string>();
            string url = geoNetworkUrl + "/xml.info?type=sources";

            string xmlDoc = client.DownloadString(new Uri(url));
            XElement element = XElement.Parse(xmlDoc);
            IEnumerable<XElement> sources = element.Element("sources").Elements("source");
            foreach (var item in sources)
            {
                string uuid =  item.Element("uuid").Value;
                string name = item.Element("name").Value;
                sourcesDict.Add(name,uuid);
            }
            return sourcesDict;
        }

        public List<string> getGDIthemes( string q="" ) {
            List<string> GDIthemes = new List<string>();
            string url = geoNetworkUrl +
                "/xml.search.keywords?pNewSearch=true&pTypeSearch=1&pThesauri=external.theme.GDI-Vlaanderen-trefwoorden&pKeyword=*" + q + "*";
            string xmlDoc = client.DownloadString(new Uri(url));
            XElement element = XElement.Parse(xmlDoc);
            IEnumerable<XElement> sources = element.Element("descKeys").Elements("keyword");
            foreach (var item in sources)
            {
                string name = item.Element("value").Value;
                GDIthemes.Add(name);
            }

            return GDIthemes;
        }

        public datacontract.metadataResponse search(string q, int start = 1, int to = 20, 
            string themekey="", string orgName="", string dataType="", string siteId="", 
            string inspiretheme="", string inspireannex="", string inspireServiceType="") 
        {
            qryValues.Add("fast", "index");
            qryValues.Add("sortBy", "changeDate");
            if (q != "" && q != null) qryValues.Add("any", "*" + q + "*");
            qryValues.Add("from", start.ToString());
            qryValues.Add("to", to.ToString());
            if (themekey != "") qryValues.Add("themekey", ("\"" + themekey + "\"").Replace("&", "%26"));
            if (orgName != "") qryValues.Add("orgName", "\"" + orgName + "\"" );
            if (dataType != "") qryValues.Add("type", dataType);
            if (siteId != "") qryValues.Add("siteId", siteId);
            if (inspiretheme != "") qryValues.Add("inspiretheme", inspiretheme);
            if (inspireannex != "") qryValues.Add("inspireannex", inspireannex);
            if (inspireServiceType != "") qryValues.Add("inspireServiceType", inspireServiceType);

            client.QueryString = qryValues;

            Uri url = new Uri(geoNetworkUrl + "/q");

            string xmlDoc = client.DownloadString(url);
            XElement element = XElement.Parse(xmlDoc);

            int maxCount; int from; int xto ;
            int.TryParse( element.Element("summary").Attribute("count").Value , out maxCount);
            int.TryParse(element.Attribute("from").Value, out from);
            int.TryParse(element.Attribute("to").Value, out xto);

            datacontract.metadataResponse metaResp = new datacontract.metadataResponse() 
                                {from = from, to=xto, maxCount=maxCount };
            List<datacontract.metadata> metaList = new List<datacontract.metadata>();
            IEnumerable<XElement> sources = element.Elements("metadata");
            foreach (var item in sources)
            {
                datacontract.metadata meta = new datacontract.metadata();
                XNamespace ns = "http://www.fao.org/geonetwork";

                var xsource = item.Element(ns + "info");
                var xtitle = item.Element("title");
                var xabstract = item.Element("abstract");

                if (xsource == null || xtitle == null) continue;

                meta.sourceID = xsource.Element("uuid").Value;
                meta.title = xtitle.Value;
                if (xabstract != null) meta.description = xabstract.Value;
                else meta.description = "";
                meta.links = new List<string>();
                foreach (var elem in item.Elements("link"))
                {
                    meta.links.Add(elem.Value);
                }
                metaList.Add(meta);
            }
            metaResp.metadataRecords = metaList ;

            qryValues.Clear();
            client.QueryString.Clear();

            return metaResp;
        }

        public datacontract.metadataResponse searchAll(string q,
            string themekey = "", string orgName = "", string dataType = "", string siteId = "",
            string inspiretheme = "", string inspireannex = "", string inspireServiceType = "") 
        {
            datacontract.metadataResponse metaResp = search(
                q, 1, 20, themekey, orgName, dataType, siteId, inspireannex, inspireServiceType);

            for (int i = 21; i < metaResp.maxCount; i += 20) 
            {
                datacontract.metadataResponse metaResp2 = search(
                    q, i, i + 19, themekey, orgName, dataType, siteId, inspireannex, inspireServiceType);

                metaResp.metadataRecords.AddRange( metaResp2.metadataRecords );
            }
            metaResp.to = metaResp.maxCount;
            return metaResp;
        }
    }
}
