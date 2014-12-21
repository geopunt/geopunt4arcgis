using System;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;


namespace geopunt4Arcgis
{
    public class geopuntPoiCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IActiveView view;
        geopunt4arcgisExtension extension;
        poiSearchForm poiDlg;

        public geopuntPoiCmd()
        {
            view = ArcMap.Document.ActiveView;
            extension = geopunt4arcgisExtension.getGeopuntExtension();
        }

        protected override void OnClick()
        {
            try
            {
                if (view.FocusMap.SpatialReference == null)
                {
                    MessageBox.Show("Je moet eerst een Coördinaatsysteem instellen");
                    return;
                }
                if (poiDlg != null)
                {
                    if (poiDlg.IsDisposed)
                    {
                        poiDlg = null;
                    }
                    else
                    {
                        if (!poiDlg.Visible) poiDlg.Show();
                        poiDlg.WindowState = FormWindowState.Normal;
                        poiDlg.Focus();
                        return;
                    }
                }
                poiDlg = new poiSearchForm();
                poiDlg.Show();
                poiDlg.WindowState = FormWindowState.Normal;
                poiDlg.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }
    }
}
