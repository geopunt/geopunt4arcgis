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

        ISpatialReferenceFactory spatialReferenceFactory;
        ISpatialReference lam72;
        IPolyline polyline;
        IElement grp;

        elevationForm dlg;

        dataHandler.dhm dhm;

        public geopuntElevationTool()
        {
            view = ArcMap.Document.ActiveView;
            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
            
            //CRS
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;
            lam72 = spatialReferenceFactory.CreateProjectedCoordinateSystem(31370);

            dhm = new dataHandler.dhm();
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

                IPolyline polyLine72 = (IPolyline)geopuntHelper.Transform((IGeometry)polyline , lam72);

                datacontract.geojsonLine gjs = geopuntHelper.esri2geojsonLine(polyLine72);
                List<List<double>> prf = dhm.getDataAlongLine(gjs, 50, dataHandler.CRS.Lambert72);

                dlg.setData(polyline, prf);

                MessageBox.Show( String.Join( ",", prf.Select(c => c[0].ToString() ).ToArray()) );

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

        protected override bool OnDeactivate()
        {
            return base.OnDeactivate();
        }
    
    }

}
