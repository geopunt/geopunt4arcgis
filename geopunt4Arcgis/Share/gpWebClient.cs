using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace geopunt4Arcgis
{
    class gpWebClient : WebClient
    {
        public int timeout { get; set; }

        public gpWebClient()
        {
        }

        public gpWebClient(Uri uri, int millisecTimeOut = 5000) 
        {
            var objWebClient = GetWebRequest(uri); 
        }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            var objWebRequest = base.GetWebRequest(uri);
            objWebRequest.Timeout = this.timeout;
            return objWebRequest;
        }
    }
}
