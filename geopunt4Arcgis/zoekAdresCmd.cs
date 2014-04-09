using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace geoPunt4Arcgis
{
    public class zoekAdresCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IActiveView view;

        public zoekAdresCmd()
        {
            view = ArcMap.Document.ActiveView;
        }

        protected override void OnClick()
        {
            try 
            {
                if (view.Extent.SpatialReference == null)
                { 
                    MessageBox.Show("Je moet eerst een Coördinaatsysteem instellen" );
                    return;
                }

                zoekAdresForm zoekAdresFrm = new zoekAdresForm(view);
                zoekAdresFrm.Show();
            }
             catch (Exception ex) {
                 MessageBox.Show( ex.StackTrace , ex.Message);
            }
        }

    }

}
