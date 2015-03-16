using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Globalization;
using Newtonsoft.Json;

namespace geopunt4Arcgis 
{
    class versionChecker
    {
        public gpWebClient client;

        string versionJSurl = "http://www.geopunt.be/~/media/geopunt/voor-experts/plugins/bestanden/arcgis%20plugin/geopunt4arcgis.json";

        public versionChecker(string proxyUrl = "", int port = 80, int timeout = 5000) 
        {
            if (proxyUrl == null || proxyUrl == "")
            {
                client = new gpWebClient() { Encoding = System.Text.Encoding.UTF8, timeout = timeout };
            }
            else
            {
                client = new gpWebClient()
                {
                    Encoding = System.Text.Encoding.UTF8,
                    Proxy = new System.Net.WebProxy(proxyUrl, port),
                    timeout = timeout
                };
            }
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string json = e.Result;
                string currentVersion = ThisAddIn.Version;
                Dictionary<string, string> versionJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                if (currentVersion != versionJson["Version"])
                {
                    DialogResult dlg = MessageBox.Show("De geopunt plugin is niet meer up to date, wenst u de nieuwe versie te downloaden? "
                                        , ThisAddIn.Name + " " + currentVersion, MessageBoxButtons.YesNo);

                    if (dlg == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("http://www.geopunt.be/voor-experts");
                    }
                }
            }
        }

        public void checkVersion() 
        {
            client.DownloadStringAsync( new Uri ( versionJSurl) );
        }

    }
}
