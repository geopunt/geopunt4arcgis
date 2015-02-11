using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Catalog;

using ZedGraph;

namespace geopunt4Arcgis
{
    public partial class elevationForm : Form
    {
        ISpatialReferenceFactory3 spatialReferenceFactory;
        IActiveView view;
        IMap map;
        ISpatialReference lam72;
        IFeatureClass pointsFC;
        IFeatureClass lineFC;

        ESRI.ArcGIS.Framework.ICommandItem oldCmd = null;
        ESRI.ArcGIS.Framework.ICommandItem mouseCmd = null;

        geopunt4arcgisExtension gpExtension;
        List<List<double>> profileData;
        LineItem grpCurve;
        PointPairList profileLine;
        IElement grapic;

        public elevationForm()
        {
            //set global objects
            view = ArcMap.Document.ActiveView;
            map = view.FocusMap;

            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            lam72 = spatialReferenceFactory.CreateProjectedCoordinateSystem(31370);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
            lineFC = gpExtension.profileLineLayer;
            pointsFC = gpExtension.profilePointsLayer;

            ESRI.ArcGIS.Framework.ICommandBars commandBars = ArcMap.Application.Document.CommandBars;
            UID toolID = new UIDClass();
            toolID.Value = ThisAddIn.IDs.geopuntElevationTool;
            mouseCmd = commandBars.Find(toolID, false, false);

            InitializeComponent();
            initGui();
        }

        public void initGui()
        {
            //the GraphPane
            profileLine = new PointPairList();
            grpCurve = profileGrp.GraphPane.AddCurve("Profiel", profileLine, Color.Red, SymbolType.Diamond);
            profileGrp.GraphPane.Legend.IsVisible = false;
            profileGrp.GraphPane.XAxis.Title.Text = "Afstand (m)";
            profileGrp.GraphPane.YAxis.Title.Text = "Hoogte (m)";
        }

        public void setData(IPolyline profileLineGeom, List<List<double>> data )
        {
            profileData = data;
            ArcMap.Application.CurrentTool = oldCmd;
            this.WindowState = FormWindowState.Normal;

            addLineGrapic(profileLineGeom);
            createGraph(profileData);
        }

        public void createGraph( List<List<double>> data )
        {
            // Set the Titles
            profileGrp.GraphPane.Title.Text = "Hoogte Profiel 1";

            // Make up some data arrays based on the Sine function
            profileLine.Clear();
            foreach (List<double> rec in data)
            {
                double x = rec[0];
                double h = rec[3];
                profileLine.Add(x, h);
            }
            // Tell the graph to refigure the axes since the data have changed
            profileGrp.AxisChange();
        }

        #region "overrides"
        protected override void OnClosed(EventArgs e)
        {
            if (ArcMap.Application.CurrentTool == mouseCmd)
            {
                ArcMap.Application.CurrentTool = oldCmd;
            }
            clearGraphics();
            view.Refresh();
            base.OnClosed(e);
        }
        #endregion

        #region "event handlers"

        private void drawbtn_Click(object sender, EventArgs e)
        {
            if (mouseCmd == null)  return;

            this.WindowState = FormWindowState.Minimized;

            oldCmd = ArcMap.Application.CurrentTool;
            ArcMap.Application.CurrentTool = mouseCmd;
        }

        private void helpLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.geopunt.be/voor-experts/geopunt-plug-ins/functionaliteiten/hoogteprofiel");
        }
        #endregion

        #region "private functions"
        private void addLineGrapic(IPolyline line)
        {
            IGeometry geom = (IGeometry)line;
            IRgbColor rgb = new RgbColorClass() { Red = 255 };
            clearGraphics();
            grapic = (IElement)geopuntHelper.AddGraphicToMap(view.FocusMap, geom, rgb, rgb, 2, true);
            view.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void clearGraphics()
        {
            IGraphicsContainer graphicsContainer = (IGraphicsContainer)map;

            if (grapic == null) return;
            try
            {
                graphicsContainer.DeleteElement(grapic);
                grapic = null;
            }
            catch (Exception)
            {
                Console.Write("Element was already deleted");
            }
        }
        #endregion

    }
}
