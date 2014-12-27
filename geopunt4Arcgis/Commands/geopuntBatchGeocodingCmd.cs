using System;
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

        public geopuntBatchGeocodingCmd()
        {
            view = ArcMap.Document.ActiveView;
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
                batchDlg.Show();
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
