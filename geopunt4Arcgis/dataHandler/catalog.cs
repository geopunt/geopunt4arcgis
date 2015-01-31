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
        public List<string> inspireServiceTypes = new List<string>() {
                    "Discovery", "Transformation", "View", "Other", "Invoke" };
        public List<string> inpireAnnex = new List<string>(){"i","ii","iii"};

        public catalog(string proxyUrl = "", int port = 80)
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

        public List<string> getKeyWords(string q = "", string field = "any")
        {
            qryValues.Add("q", q);
            qryValues.Add("field", field);
            string url = geoNetworkUrl + "/main.search.suggest" ;

            client.QueryString = qryValues;
            string jsonString = client.DownloadString(new Uri(url));
            JArray jsonArr = JArray.Parse(jsonString) as JArray;
            JArray keywords = (JArray)jsonArr[1];

            client.QueryString.Clear();

            return keywords.Select(c => (string)c).ToList();
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
                sourcesDict.Add(uuid, name);
            }
            return sourcesDict;
        }

        public List<datacontract.metadata> search(string q, int start = 1, int to = 20, 
            string themekey="", string orgName="", string dataType="", string siteId="", 
            string inspiretheme="", string inspireannex="", string inspireServiceType="") 
        {
            qryValues.Add("fast", "index");
            qryValues.Add("sortBy", "changeDate");
            qryValues.Add("q", q);
            qryValues.Add("start", start.ToString());
            qryValues.Add("to", to.ToString());
            if (themekey != "") qryValues.Add("themekey", themekey);
            if (orgName != "") qryValues.Add("orgName", orgName);
            if (dataType != "") qryValues.Add("dataType", dataType);
            if (siteId != "") qryValues.Add("siteId", siteId);
            if (inspiretheme != "") qryValues.Add("inspiretheme", inspiretheme);
            if (inspireannex != "") qryValues.Add("inspireannex", inspireannex);
            if (inspireServiceType != "") qryValues.Add("inspireServiceType", inspireServiceType);

            Uri url = new Uri(geoNetworkUrl + "/q");
            MessageBox.Show( url.AbsoluteUri );
            List<datacontract.metadata> metaList = new List<datacontract.metadata>();

            string xmlDoc = client.DownloadString(url);
            XElement element = XElement.Load(xmlDoc);
            IEnumerable<XElement> sources = element.Elements("metadata");
            foreach (var item in sources)
            {
                datacontract.metadata meta = new datacontract.metadata();

                meta.sourceID = item.Element("source").Value;
                meta.title = item.Element("title").Value;
                meta.description = item.Element("abstract").Value;
                meta.links = new List<string>();
                foreach (var elem in item.Elements("link"))
                {
                    meta.links.Add(elem.Value);
                }
                metaList.Add(meta);
            } 
            qryValues.Clear();
            client.QueryString.Clear();
            return metaList;
        }
    }
}
