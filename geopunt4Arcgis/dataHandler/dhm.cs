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
    class dhm
    {
        public WebClient client;
        string baseUri;

        public dhm(string proxyUrl = "", int port = 80, int timeout= 5000)
        {
            if (proxyUrl == null || proxyUrl == "")
            {
                client = new gpWebClient() { Encoding = System.Text.Encoding.UTF8 , timeout= timeout};
            }
            else
            {
                client = new gpWebClient() { Encoding = System.Text.Encoding.UTF8, 
                                           Proxy = new System.Net.WebProxy(proxyUrl, port), timeout= timeout };
            }
            baseUri = "http://dhm.beta.agiv.be/api/elevation/v1/";
        }

        public List<List<double>> getDataAlongLine( datacontract.geojsonLine profileLine, int nrSamples = 30, CRS srs = CRS.WGS84)
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";

            Uri dhmUri = new Uri(baseUri + "DHMVMIXED/request/");
            datacontract.dhmRequest dhmMsg = new datacontract.dhmRequest() { 
                Samples = nrSamples, LineString = profileLine, SrsIn= (int)srs , SrsOut= (int)srs };

            string postData = JsonConvert.SerializeObject(dhmMsg);
            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(postData);
            byte[] byteResult = client.UploadData(dhmUri, "POST", byteArray);

            string json = Encoding.ASCII.GetString(byteResult);
            List<List<double>> response = JsonConvert.DeserializeObject<List<List<double>>>(json);

            return response;
        }

    }
}
