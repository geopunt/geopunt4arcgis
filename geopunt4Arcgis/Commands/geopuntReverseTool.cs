using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;

namespace geopunt4Arcgis
{
    public class geopuntReverseTool : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        IActiveView view;
        reverseZoekForm resultForm;
        geopunt4arcgisExtension gpExtension;

        public geopuntReverseTool()
        {
            view = ArcMap.Document.ActiveView;
            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
        }

        protected override void OnActivate()
        {

            try
            {
                if (view.FocusMap.SpatialReference == null)
                {
                    MessageBox.Show("Je moet eerst een Coördinaatsysteem instellen");
                    return;
                }
            }
            finally
            {
                base.OnActivate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs arg)
        {
            try
            {
                IDisplayTransformation displayTransformation = view.ScreenDisplay.DisplayTransformation;

                IPoint mapPoint = displayTransformation.ToMapPoint(arg.X, arg.Y);
                IPoint lam72Point = geopuntHelper.Transform2Lam72(mapPoint) as IPoint;

                if (resultForm != null)
                {
                    if (resultForm.IsDisposed)
                    {
                        resultForm = null;
                    }
                    else
                    {
                        if (!resultForm.Visible) resultForm.Show();
                        resultForm.WindowState = FormWindowState.Normal;
                        resultForm.Focus();
                        resultForm.reverseGeocode(lam72Point);
                        return;
                    }
                }
                resultForm = new reverseZoekForm();
                gpExtension.reverseDlg = resultForm;
                resultForm.Show();
                resultForm.WindowState = FormWindowState.Normal;
                resultForm.Focus();
                resultForm.reverseGeocode(lam72Point);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
            finally {
                base.OnMouseDown(arg);
            }
        }

    }
}
