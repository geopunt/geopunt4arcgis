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
    public class geopuntReverseCmd : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        IActiveView activeView;
        reverseZoekForm resultForm;

        public geopuntReverseCmd()
        {

        }

        protected override void OnActivate()
        {

            try
            {
                activeView = ArcMap.Document.ActiveView;

                //if (!geopuntHelper.IsConnectedToInternet)
                //{
                //    MessageBox.Show("geen internet connectie, misschien moet je een proxy instellen?");
                //    return;
                //}

                if (activeView.FocusMap.SpatialReference == null)
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

                IDisplayTransformation displayTransformation = activeView.ScreenDisplay.DisplayTransformation;

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
                resultForm.Show();
                resultForm.WindowState = FormWindowState.Normal;
                resultForm.Focus();
                resultForm.reverseGeocode(lam72Point);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + " : " + ex.Message);
            }
            finally {
                base.OnMouseDown(arg);
            }

        }

    }

}
