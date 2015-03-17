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
    public class geopuntElevationCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IActiveView view;
        elevationForm elevationDlg;
        geopunt4arcgisExtension gpExtension;

        public geopuntElevationCmd()
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
                if (elevationDlg != null)
                {
                    if (elevationDlg.IsDisposed)
                    {
                        elevationDlg = null;
                    }
                    else
                    {
                        if (!elevationDlg.Visible) elevationDlg.Show();
                        elevationDlg.WindowState = FormWindowState.Normal;
                        elevationDlg.Focus();
                        return;
                    }
                }
                elevationDlg = new elevationForm();
                gpExtension.elevationDlg = elevationDlg;
                elevationDlg.Show();
                elevationDlg.WindowState = FormWindowState.Normal;
                elevationDlg.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }

    }
}
