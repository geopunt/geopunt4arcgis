using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;

namespace geopunt4Arcgis
{
    public class geopuntAddressCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IActiveView view;
        zoekAdresForm zoekAdresDlg;
        geopunt4arcgisExtension gpExtension;

        public geopuntAddressCmd()
        {
            view = ArcMap.Document.ActiveView;
            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
        }

        protected override void OnClick()
        {
            try
            {
                if (view.FocusMap.SpatialReference == null)
                {
                    view.FocusMap.SpatialReference = geopuntHelper.lam72;
                }
                if (zoekAdresDlg != null  ) 
                {
                    if (zoekAdresDlg.IsDisposed)
                    {
                        zoekAdresDlg = null;
                    }
                    else
                    {
                        if (!zoekAdresDlg.Visible) zoekAdresDlg.Show();
                        zoekAdresDlg.WindowState = FormWindowState.Normal;
                        zoekAdresDlg.Focus();
                        return;
                    }
                }
                zoekAdresDlg = new zoekAdresForm();
                gpExtension.zoekAdresDlg = zoekAdresDlg;
                zoekAdresDlg.Show();
                zoekAdresDlg.WindowState = FormWindowState.Normal;
                zoekAdresDlg.Focus();
            }   
            catch (Exception ex) {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }

    }

}
