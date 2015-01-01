using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Catalog;

namespace geopunt4Arcgis
{
    public class geopuntBatchGeocodingTool : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        IActiveView view;
        geopunt4arcgisExtension gpExtension;

        public geopuntBatchGeocodingTool()
        {
            view = ArcMap.Document.ActiveView;
            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }

        protected override void OnMouseDown(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
            IScreenDisplay screenDisplay = view.ScreenDisplay;
            batchGeocodeForm batchDlg = gpExtension.batchGeocodeDlg;
            IDisplayTransformation displayTransformation = view.ScreenDisplay.DisplayTransformation;

            if (batchDlg != null)
            {
                IPoint mapPoint = displayTransformation.ToMapPoint(arg.X, arg.Y);
                IPoint lam72Point = geopuntHelper.Transform2Lam72(mapPoint) as IPoint;
                batchDlg.getXYasValidAdres(lam72Point.X, lam72Point.Y);
            }
            base.OnMouseDown(arg);
        }
    }
}
