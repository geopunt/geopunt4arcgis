using System;
using System.Collections.Generic;
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

namespace geoPunt4Arcgis
{
    public partial class reverseZoekForm : Form
    {
        public locationResult location;
        private IActiveView view;

        public reverseZoekForm( )
        {
            location = null;
            view = ArcMap.Document.ActiveView;
            InitializeComponent();
        }

        public void setText(string text) {
            resultBox.Text = text;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add2MapBtn_Click(object sender, EventArgs e)
        {
            IPoint XY; IPoint mapXY;
            IRgbColor innerClr; IRgbColor outlineClr;
            ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();

            try
            {

                if (location != null)
                {
                    XY = new ESRI.ArcGIS.Geometry.Point()
                    {
                        X = location.Location.Lon_WGS84,
                        Y = location.Location.Lat_WGS84,
                        SpatialReference = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326)
                    };
                    mapXY = geopuntHelper.Transform(XY as IGeometry, view.Extent.SpatialReference) as IPoint;
                    innerClr = new RgbColor() { Red = 255, Blue = 0, Green = 255 };
                    outlineClr = new RgbColor() { Red = 0, Blue = 0, Green = 0 };
                    geopuntHelper.AddGraphicToMap(view.FocusMap, mapXY, innerClr, outlineClr, 12);
                    geopuntHelper.AddTextElement(view.FocusMap, mapXY, location.FormattedAddress);
                    view.Refresh();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show(ex.StackTrace, msg );
            }
        }
    }
}
