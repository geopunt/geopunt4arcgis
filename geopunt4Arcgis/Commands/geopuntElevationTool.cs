using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;

namespace geopunt4Arcgis
{
    public class geopuntElevationTool : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        IActiveView view;
        geopunt4arcgisExtension gpExtension;
        IPolyline polyline;
        elevationForm dlg;

        public geopuntElevationTool()
        {
            view = ArcMap.Document.ActiveView;
            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
        }

        protected override void  OnMouseDown(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
            try
            {
                dlg = gpExtension.elevationDlg;
                if (dlg == null) return;

                IDisplayTransformation displayTransformation = view.ScreenDisplay.DisplayTransformation;
                //the clicked point in map crs:
                IPoint mapPoint = displayTransformation.ToMapPoint(arg.X, arg.Y);

                //Get the polyline object from the users mouse clicks
                polyline = geopuntHelper.GetPolylineFromMouseClicks(view);

                dlg.getData(polyline);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
            finally
            {
                base.OnMouseDown(arg);
            }
        }
    
    }

}
