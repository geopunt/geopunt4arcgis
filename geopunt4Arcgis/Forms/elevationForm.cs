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
        IElement lineGrapic;
        IElement pntGrapic;

        ESRI.ArcGIS.Framework.ICommandItem oldCmd = null;
        ESRI.ArcGIS.Framework.ICommandItem mouseCmd = null;

        geopunt4arcgisExtension gpExtension;
        List<List<double>> profileData;
        LineItem grpCurve;
        LineItem userClickCurve;
        PointPairList profileLine;
        PointPairList userClickrList;
        TextObj hlabel;
        double maxH;
        double minH;

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
            userClickrList = new PointPairList();
            grpCurve = profileGrp.GraphPane.AddCurve("Profiel", profileLine, Color.Red, SymbolType.Diamond);
            userClickCurve = profileGrp.GraphPane.AddCurve(" ", userClickrList, Color.Blue, SymbolType.None);
            profileGrp.GraphPane.Legend.IsVisible = false;
            profileGrp.GraphPane.XAxis.Title.Text = "Afstand (m)";
            profileGrp.GraphPane.YAxis.Title.Text = "Hoogte (m)";

            hlabel = new TextObj() { ZOrder = ZOrder.A_InFront };
            profileGrp.GraphPane.GraphObjList.Add(hlabel);
        }

        public void setData(IPolyline profileLineGeom, List<List<double>> data )
        {
            profileData = data;
            ArcMap.Application.CurrentTool = oldCmd;
            this.WindowState = FormWindowState.Normal;

            maxH = data.Select(c => c[3]).Max();
            minH = data.Where(c => c[3] > -998 ).Select(c => c[3]).Min();
            profileGrp.GraphPane.YAxis.Scale.Max = maxH;
            profileGrp.GraphPane.YAxis.Scale.Min = minH;

            addLineGrapic(profileLineGeom);
            createGraph(profileData);
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

        private void profileGrp_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                int index = 0;
                CurveItem nearestobject = null;
                PointF clickedPoint = new PointF(e.X, e.Y);
                profileGrp.GraphPane.FindNearestPoint(clickedPoint, grpCurve, out nearestobject, out index);

                if (nearestobject == null)
                {
                    userClickCurve.IsVisible = false;
                    hlabel.IsVisible = false;
                    profileGrp.Refresh();
                    if (pntGrapic != null)
                    {
                        IGraphicsContainer graphicsContainer = (IGraphicsContainer)map;
                        graphicsContainer.DeleteElement(pntGrapic);
                        pntGrapic = null;
                        view.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                    }
                    msgLbl.Text = "";
                    return;
                }
                double x = nearestobject.Points[index].X;
                double h = nearestobject.Points[index].Y;

                userClickCurve.IsVisible = true;
                hlabel.IsVisible = true;

                //set the label
                hlabel.Text = h.ToString("f2");
                hlabel.Location.X = x;
                hlabel.Location.Y = h;
                hlabel.FontSpec.Fill = new Fill(Color.Azure);
                //draw the line
                userClickrList.Clear();
                userClickrList.Add(x, h);
                userClickrList.Add(x, profileGrp.GraphPane.YAxis.Scale.Min);

                interpolateLineAndAddPoint(x);

                profileGrp.Refresh();

                msgLbl.Text = string.Format("Afstand: {0:0.00} m, Hoogte: {1:0.00} m", x, h);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setTitleBtn_Click(object sender, EventArgs e)
        {
            string title = inputForm.showInputDlg("Geef de titel van dit profiel op:", this);
            if (title == null) return;
            profileGrp.GraphPane.Title.Text = title;
            profileGrp.Refresh();
        }

        private void savePrfAsImageBtn_Click(object sender, EventArgs e)
        {
            string prfPicName = profileGrp.GraphPane.Title.Text + ".png";
            profileGrp.SaveAs(prfPicName);
        }

        private void helpLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.geopunt.be/voor-experts/geopunt-plug-ins/functionaliteiten/hoogteprofiel");
        }
        #endregion

        #region "private functions"

        private void interpolateLineAndAddPoint(double dist)
        {
            if (lineGrapic == null) return;
            try
            {
                IPolyline4 geom = (IPolyline4) lineGrapic.Geometry;
                IPoint pnt = new PointClass();
                geom.QueryPoint(esriSegmentExtension.esriNoExtension, dist, false, pnt);
                //check if null
                if (pnt == null) return;

                IRgbColor rgb = new RgbColorClass() { Blue= 255 };
                IRgbColor black = new RgbColorClass() { Blue= 0, Green= 0, Red= 0 };
                if (pntGrapic != null)
                {
                    IGraphicsContainer graphicsContainer = (IGraphicsContainer)map;
                    graphicsContainer.DeleteElement(pntGrapic);
                    pntGrapic = null;
                }
                pntGrapic = geopuntHelper.AddGraphicToMap(view.FocusMap, (IGeometry)pnt, rgb, black, 6, true);
                view.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message + " : " + ex.StackTrace );
            }

        }
        
        private void addLineGrapic(IPolyline line)
        {
            IGeometry geom = (IGeometry)line;
            IRgbColor rgb = new RgbColorClass() { Red = 255 };
            clearGraphics();
            lineGrapic = (IElement)geopuntHelper.AddGraphicToMap(view.FocusMap, geom, rgb, rgb, 2, true);
            view.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void createGraph(List<List<double>> data)
        {
            // Set the Title
            gpExtension.profileCounter += 1;
            profileGrp.GraphPane.Title.Text = string.Format("Hoogte Profiel {0}", gpExtension.profileCounter);

            // Make the data array
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

        private void clearGraphics()
        {
            IGraphicsContainer graphicsContainer = (IGraphicsContainer)map;

            if (lineGrapic == null && pntGrapic == null) return;
            try
            {
                if (lineGrapic != null)
                {
                    graphicsContainer.DeleteElement(lineGrapic);
                    lineGrapic = null;
                }
                if (pntGrapic != null)
                {
                    graphicsContainer.DeleteElement(pntGrapic);
                    pntGrapic = null;
                }
            }
            catch (Exception)
            {
                Console.Write("Element was already deleted");
            }
        }
        #endregion

        private void unZoomBtn_Click(object sender, EventArgs e)
        {
            profileGrp.ZoomOutAll( profileGrp.GraphPane );
        }

        private void zoomRectActivateBtn_Click(object sender, EventArgs e)
        {
            profileGrp.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            profileGrp.ZoomModifierKeys = Keys.None;
            profileGrp.PanButtons = System.Windows.Forms.MouseButtons.Left;
            profileGrp.PanModifierKeys = Keys.Control;
        }

        private void PanActivateBtn_Click(object sender, EventArgs e)
        {
            profileGrp.PanButtons = System.Windows.Forms.MouseButtons.Left;
            profileGrp.PanModifierKeys = Keys.None;
            profileGrp.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            profileGrp.ZoomModifierKeys = Keys.Control;
        }

        private void prevZoomBtn_Click(object sender, EventArgs e)
        {
            profileGrp.ZoomOut(profileGrp.GraphPane);
        }



    }
}
