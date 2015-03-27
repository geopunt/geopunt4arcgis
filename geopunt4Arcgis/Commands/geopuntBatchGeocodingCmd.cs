using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;

namespace geopunt4Arcgis
{
    public class geopuntBatchGeocodingCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IActiveView view;
        batchGeocodeForm batchDlg;
        geopunt4arcgisExtension gpExtension;

        public geopuntBatchGeocodingCmd()
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
                if (batchDlg != null)
                {
                    if (batchDlg.IsDisposed)
                    {
                        batchDlg = null;
                    }
                    else
                    {
                        if (!batchDlg.Visible) batchDlg.Show();
                        batchDlg.WindowState = FormWindowState.Normal;
                        batchDlg.Focus();
                        return;
                    }
                }
                batchDlg = new batchGeocodeForm();

                gpExtension.batchGeocodeDlg = batchDlg;

                batchDlg.Show( );
                batchDlg.WindowState = FormWindowState.Normal;
                batchDlg.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }
    }
}
