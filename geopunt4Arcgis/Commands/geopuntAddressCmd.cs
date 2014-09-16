using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;

namespace geopunt4Arcgis
{
    public class geopuntAddressCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IActiveView view;
        geopunt4arcgisExtension extension;
        zoekAdresForm zoekAdresDlg;

        public geopuntAddressCmd()
        {
            view = ArcMap.Document.ActiveView;
            extension = geopunt4arcgisExtension.getGeopuntExtension();
        }

        protected override void OnClick()
        {
            try
            {
                IActiveView activeView = ArcMap.Document.ActiveView;

                if (activeView.FocusMap.SpatialReference == null)
                {
                    MessageBox.Show("Je moet eerst een Coördinaatsysteem instellen");
                    return;
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

                zoekAdresDlg = new zoekAdresForm(view);
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
