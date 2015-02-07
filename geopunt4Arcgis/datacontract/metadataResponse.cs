using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace geopunt4Arcgis.datacontract
{
    public class metadata
    {
        public string sourceID { get; set; }
        public List<string> links { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class metadataResponse
    {
        public List<metadata> metadataRecords { get; set; }
        public int maxCount { get; set; }
        public int from { get; set; }
        public int to { get; set; }


        public bool geturl(string searchText, string stype, out string wmsUrl, out string wmsLayer)
        {
            wmsUrl = wmsLayer = null;

            if (metadataRecords == null) return false;

            string selVal = searchText;
            List<datacontract.metadata> metaObjs = (from n in metadataRecords
                                                    where n.title == selVal
                                                    select n).ToList();

            if (metaObjs.Count > 0 && metaObjs[0].links.Count > 0)
            {
                datacontract.metadata metaObj = metaObjs[0];
                List<List<string>> linkList = metaObj.links.Select(c => c.Split('|').ToList()).ToList();
                bool hasWMS = false;

                for( int c = 1; c < linkList.Count; c++)
                {
                    List<string> link = linkList[c];
                    for (int i = 1; i < link.Count; i++)
                    {
                        if (link[i].ToUpper().Contains(stype) && link[i - 1].ToLower().Contains("http"))
                        {
                            hasWMS = true;
                            wmsUrl = link[i - 1];
                            wmsLayer = link[0];
                            if (c > 1) return hasWMS;
                        }
                    }
                }
                return hasWMS;
            }
            else return false;
        }

        public bool geturl(string searchText, string stype)
        {
            if (metadataRecords == null) return false;

            string selVal = searchText;
            List<datacontract.metadata> metaObjs = (from n in metadataRecords
                                                    where n.title == selVal
                                                    select n).ToList();

            if (metaObjs.Count > 0 && metaObjs[0].links.Count > 0)
            {
                datacontract.metadata metaObj = metaObjs[0];
                List<List<string>> linkList = metaObj.links.Select(c => c.Split('|').ToList()).ToList();
                for (int c = 1; c < linkList.Count; c++)
                {
                    List<string> link = linkList[c];
                    for (int i = 1; i < link.Count; i++)
                    {
                        if (link[i].ToUpper().Contains(stype) && link[i - 1].ToLower().Contains("http"))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else return false;
        }
    }
}
