using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;

namespace geopunt4Arcgis
{
    public class geopunt4arcgisExtension : ESRI.ArcGIS.Desktop.AddIns.Extension
    {
        private static geopunt4arcgisExtension gpExtension;
        public IFeatureClass adresLayer;
        public IFeatureClass reverseLayer;
        public IFeatureClass poiLayer;
        public IFeatureClass poiMinLayer;

        public geopunt4arcgisExtension()
        {
            gpExtension = this;
            adresLayer = null;
            reverseLayer = null;
            poiLayer = null;
            poiMinLayer = null;
        }

        internal static geopunt4arcgisExtension getGeopuntExtension()
        {
            if (gpExtension == null)
            {
                UID extID = new UIDClass();
                extID.Value = ThisAddIn.IDs.geopunt4arcgisExtension;
                ArcMap.Application.FindExtensionByCLSID(extID);
            }
            return gpExtension;
        }
    }
}
