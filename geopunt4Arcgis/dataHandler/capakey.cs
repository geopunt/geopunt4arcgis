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
    class capakey
    {
        public WebClient client;
        NameValueCollection qryValues;
        string baseUri;

        public capakey(string proxyUrl = "", int port = 80)
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
            baseUri = "http://geo.agiv.be/capakey/api/v0/";
        }

        public datacontract.municipalityList getMunicipalities()
        {
            Uri capkeyUri = new Uri(baseUri + "Municipality/");
            string json = client.DownloadString(capkeyUri);
            datacontract.municipalityList response = JsonConvert.DeserializeObject<datacontract.municipalityList>(json);
            return response;
        }
        public datacontract.municipality getMunicipalitiy(int NIScode, CRS srs, capakeyGeometryType geomType)
        {
            qryValues.Add("srs", Convert.ToString((int)srs));
            if (geomType == capakeyGeometryType.no) qryValues.Add("geometry", "no");
            else if (geomType == capakeyGeometryType.bbox) qryValues.Add("geometry", "bbox");
            else if (geomType == capakeyGeometryType.full) qryValues.Add("geometry", "full");

            client.QueryString = qryValues;
            Uri gipodUri = new Uri(baseUri + "Municipality/" + NIScode.ToString() );
            string json = client.DownloadString(gipodUri);
            datacontract.municipality response = JsonConvert.DeserializeObject<datacontract.municipality>(json);

            client.QueryString.Clear();
            return response;
        }

        public datacontract.departmentList getDepartments(int NIScode) 
        {
            Uri capkeyUri = new Uri(baseUri + "Municipality/" + NIScode.ToString() + "/department");
            string json = client.DownloadString(capkeyUri);
            datacontract.departmentList response = JsonConvert.DeserializeObject<datacontract.departmentList>(json);
            return response;
        }
        public datacontract.department getDepartment(int NIScode, int departmentCode, CRS srs, capakeyGeometryType geomType)
        {
            qryValues.Add("srs", Convert.ToString((int)srs));
            if (geomType == capakeyGeometryType.no) qryValues.Add("geometry", "no");
            else if (geomType == capakeyGeometryType.bbox) qryValues.Add("geometry", "bbox");
            else if (geomType == capakeyGeometryType.full) qryValues.Add("geometry", "full");

            client.QueryString = qryValues;
            Uri gipodUri = new Uri(baseUri + "Municipality/" + NIScode.ToString() + "/department/" + departmentCode.ToString());
            string json = client.DownloadString(gipodUri);
            datacontract.department response = JsonConvert.DeserializeObject<datacontract.department>(json);

            client.QueryString.Clear();
            return response;
        }

        public datacontract.sectionList getSecties(int NIScode, int departmentCode)
        {
            Uri capkeyUri = new Uri(baseUri + "Municipality/" + NIScode.ToString() + "/department/" + departmentCode.ToString() + "/section");
            string json = client.DownloadString(capkeyUri);
            datacontract.sectionList response = JsonConvert.DeserializeObject<datacontract.sectionList>(json);
            return response;
        }
        public datacontract.section getDepartment(int NIScode, int departmentCode, string sectie, CRS srs, capakeyGeometryType geomType)
        {
            qryValues.Add("srs", Convert.ToString((int)srs));
            if (geomType == capakeyGeometryType.no) qryValues.Add("geometry", "no");
            else if (geomType == capakeyGeometryType.bbox) qryValues.Add("geometry", "bbox");
            else if (geomType == capakeyGeometryType.full) qryValues.Add("geometry", "full");

            client.QueryString = qryValues;
            Uri gipodUri = new Uri(baseUri + "Municipality/" + NIScode.ToString() + "/department/" + departmentCode.ToString() + "/section/" + sectie);
            string json = client.DownloadString(gipodUri);
            datacontract.section response = JsonConvert.DeserializeObject<datacontract.section>(json);

            client.QueryString.Clear();
            return response;
        }

        public datacontract.parcelList getParcels(int NIScode, int departmentCode, string sectie)
        {
            Uri capkeyUri = new Uri(baseUri + "Municipality/" + NIScode.ToString() + "/department/" + departmentCode.ToString() + "/section/" + sectie + "/parcel");
            string json = client.DownloadString(capkeyUri);
            datacontract.parcelList response = JsonConvert.DeserializeObject<datacontract.parcelList>(json);
            return response;
        }
        public datacontract.parcel getParcel(int NIScode, int departmentCode, string sectie, string perceelsNr, CRS srs, capakeyGeometryType geomType)
        {
            qryValues.Add("srs", Convert.ToString((int)srs));
            if (geomType == capakeyGeometryType.no) qryValues.Add("geometry", "no");
            else if (geomType == capakeyGeometryType.bbox) qryValues.Add("geometry", "bbox");
            else if (geomType == capakeyGeometryType.full) qryValues.Add("geometry", "full");

            client.QueryString = qryValues;
            Uri gipodUri = new Uri(baseUri + "Municipality/" + NIScode.ToString() + "/department/" + departmentCode.ToString() + "/section/" + sectie + "/parcel/"+ perceelsNr);
            string json = client.DownloadString(gipodUri);
            datacontract.parcel response = JsonConvert.DeserializeObject<datacontract.parcel>(json);

            client.QueryString.Clear();
            return response;
        }
    }
}
