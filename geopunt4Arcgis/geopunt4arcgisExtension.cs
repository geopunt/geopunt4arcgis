using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace geopunt4Arcgis
{
    public class geopunt4arcgisExtension : ESRI.ArcGIS.Desktop.AddIns.Extension
    {
        public geopunt4arcgisExtension()
        {
        }

        protected override void OnStartup()
        {
            //
            // TODO: Uncomment to start listening to document events
            //
            // WireDocumentEvents();
        }

        private void WireDocumentEvents()
        {
            //
            // TODO: Sample document event wiring code. Change as needed
            //

            // Named event handler
            ArcMap.Events.NewDocument += delegate() { ArcMap_NewDocument(); };

            // Anonymous event handler
            ArcMap.Events.BeforeCloseDocument += delegate()
            {
                // Return true to stop document from closing
                ESRI.ArcGIS.Framework.IMessageDialog msgBox = new ESRI.ArcGIS.Framework.MessageDialogClass();
                return msgBox.DoModal("BeforeCloseDocument Event", "Abort closing?", "Yes", "No", ArcMap.Application.hWnd);
            };

        }

        void ArcMap_NewDocument()
        {
            // TODO: Handle new document event
        }

    }

}
