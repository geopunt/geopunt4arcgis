using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace geopunt4Arcgis
{
    public class geopuntReverse : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        public geopuntReverse()
        {
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
