using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Catalog;

namespace geopunt4Arcgis
{
    public partial class catalogForm : Form
    {
        ISpatialReferenceFactory3 spatialReferenceFactory;
        IActiveView view;
        IMap map;
        ISpatialReference wgs;
        geopunt4arcgisExtension gpExtension;

        dataHandler.catalog clg;

        public catalogForm()
        {
            view = ArcMap.Document.ActiveView;
            map = view.FocusMap;

            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            wgs = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
            clg = new dataHandler.catalog();

            InitializeComponent();
        }

        #region "eventHandlers"

        private void zoekBtn_Click(object sender, EventArgs e)
        {
            string zoekString = keywordTxt.Text;
            List<datacontract.metadata> metaList =  clg.search(zoekString);
            string[] msg = metaList.Select( c => c.title).ToArray();
            MessageBox.Show( String.Join(",", msg  )  );
        }

        private void helpLbl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                "http://www.geopunt.be/nl/voor-experts/geopunt-plug-ins/functionaliteiten/catalogus");
        }
        #endregion
    }
}
