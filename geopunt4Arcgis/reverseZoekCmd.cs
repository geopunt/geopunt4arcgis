using System;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using RestSharp;
using System.Windows.Forms;

namespace geoPunt4Arcgis
{
    public class reverseZoekCmd : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        crabRest crab;
        IActiveView activeView;
        ISpatialReferenceFactory spatialReferenceFactory;
        reverseZoekForm resultForm;

        public reverseZoekCmd()
        {
            //settings
            RegistryKey geopuntKey = Registry.CurrentUser.OpenSubKey("Software\\geopunt");
            int geopuntTimeOut = (int)geopuntKey.GetValue("geopuntTimeOut", 5000);
            string geopuntProxyUrl = (string)geopuntKey.GetValue("geopuntProxyUrl", "");
            int geopuntProxyPort = (int)geopuntKey.GetValue("geopuntProxyPort", 8080);

            //set global objects
            crab = new crabRest(geopuntTimeOut, geopuntProxyUrl, geopuntProxyPort);
            spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            activeView = ArcMap.Document.ActiveView;
            resultForm = new reverseZoekForm();
        }

        protected override void  OnActivate()
        {
            if (activeView.Extent.SpatialReference == null)
            {
                MessageBox.Show("Je moet eerst een Coördinaatsysteem instellen");
                return;
            }
            base.OnActivate();
        }

        protected override void OnMouseDown(MouseEventArgs arg)
        {
            try
            {
                if (activeView.Extent.SpatialReference == null) return;

                IDisplayTransformation displayTransformation = activeView.ScreenDisplay.DisplayTransformation;

                if (resultForm.IsDisposed) resultForm = new reverseZoekForm();

                IPoint mapPoint = displayTransformation.ToMapPoint(arg.X, arg.Y);
                IPoint wgsPoint = geopuntHelper.Transform2WGS(mapPoint) as IPoint;
                crabResponse locations = crab.reverseGeolocate(wgsPoint.X, wgsPoint.Y, 1);

                if (locations.LocationResult != null && locations.LocationResult.Count > 0)
                {
                    string adresMessage = locations.LocationResult[0].FormattedAddress + "\n\n" + locations.LocationResult[0].LocationType;
                    resultForm.setText(adresMessage);
                    resultForm.location = locations.LocationResult[0];
                    if (!resultForm.Visible) resultForm.Show();
                }
                else 
                {
                    resultForm.Close();
                    MessageBox.Show("Geen adres gevonden","Waarschuwing");
                }
            }
            catch (Exception ex) {
                MessageBox.Show( ex.StackTrace ,ex.Message);
            }
        }

    }

}
