using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;

namespace geopunt4Arcgis
{
    public class capakeyCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IActiveView view;
        capakeyForm capakayDlg;

        public capakeyCmd()
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
                if (capakayDlg != null)
                {
                    if (capakayDlg.IsDisposed)
                    {
                        capakayDlg = null;
                    }
                    else
                    {
                        if (!capakayDlg.Visible) capakayDlg.Show();
                        capakayDlg.WindowState = FormWindowState.Normal;
                        capakayDlg.Focus();
                        return;
                    }
                }

                capakayDlg = new capakeyForm();
                capakayDlg.Show();
                capakayDlg.WindowState = FormWindowState.Normal;
                capakayDlg.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }

    }
}
