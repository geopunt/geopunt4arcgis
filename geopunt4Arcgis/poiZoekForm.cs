using System;
using System.Security.Permissions;
using Microsoft.Win32;
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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;

namespace geoPunt4Arcgis
{
    public partial class poiZoekForm : Form
    {
        poiRest poiClient;
        IActiveView view;
        poiResponse poisResponse = null;
        IFeatureClass poiFeatureClass = null;

        public poiZoekForm()
        {
            //settings
            RegistryKey geopuntKey = Registry.CurrentUser.OpenSubKey("Software\\geopunt");
            int geopuntTimeOut = (int)geopuntKey.GetValue("geopuntTimeOut", 5000);
            string geopuntProxyUrl = (string)geopuntKey.GetValue("geopuntProxyUrl", "");
            int geopuntProxyPort = (int)geopuntKey.GetValue("geopuntProxyPort", 8080);

            //set global objects
            poiClient = new poiRest(geopuntTimeOut, geopuntProxyUrl, geopuntProxyPort );
            view = ArcMap.Document.ActivatedView;
            
            //init UI
            InitializeComponent();
        }

        #region "event handlers"

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zoekBtn_Click(object sender, EventArgs e)
        {
            zoekPoi();
        }

        private void zoektxt_enterPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                zoekPoi();
            }
        }

        private void add2MapBtn_Click(object sender, EventArgs e)
        {
            if (poisResponse == null || poisResponse.pois.Count == 0)
            {
                messageLbl.Text = "Geen punten om toe te voegen";
                return;
            }
            try
            {
                if (poiFeatureClass == null)
                {
                    //get shapefile path
                    SaveFileDialog saveDlg = new SaveFileDialog()
                    {
                        Filter = "shapefile (*.shp)|*.shp",
                        Title = "Opslaan naar een shapefile"
                    };
                    saveDlg.ShowDialog();

                    //write shapefile
                    if (saveDlg.FileName != "")
                    {
                        createPoiShape(saveDlg.FileName);
                    }
                    else return;
                }
                populatePoiShape();

                //load layer into map
                geopuntHelper.addFeatureClassToMap(view, poiFeatureClass);

                this.Close();
            }
            catch (Exception ex) {
                string msg = ex.Message;
                MessageBox.Show( ex.StackTrace , msg );
            }
        }
 
        #endregion

        /// <summary> find the pois and add to resultsview </summary>
        private void zoekPoi()
        {
            string qry = zoekTxt.Text;
            bool withinCurrentExtend = bboxChk.Checked;

            try
            {
                int epsg;
                if (view.FocusMap.SpatialReference.FactoryCode == 900913 ||
                    view.FocusMap.SpatialReference.FactoryCode == 102100)
                    {
                        epsg = 3857;  //all webmercator
                    }
                else epsg = view.FocusMap.SpatialReference.FactoryCode;

                if (withinCurrentExtend)
                {
                    boundingBox bbox = new boundingBox(view.Extent);
                    poisResponse = poiClient.locate(qry, bbox, 30, epsg);
                }
                else poisResponse = poiClient.locate(qry, 30, epsg);

                resultListView.Items.Clear();
                messageLbl.Text = string.Format("Aantal:{0} (max 30)| totaal aantal resultaten:{1}",
                                    poisResponse.pois.Count, poisResponse.label.value);

                foreach (poi poiRecord in poisResponse.pois)
                {
                    string adres = poiRecord.location.address.value.Replace("<br/>", ", ").Replace("<br />", ", ");

                    ListViewItem item = new ListViewItem();
                    item.Text = poiRecord.labels[0].value;
                    item.SubItems.AddRange(new string[] { poiRecord.id.ToString(), poiRecord.categories[1].value, adres });
                    resultListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.StackTrace, ex.Message);
            }
        }

        /// <summary>create teh shapefiel to hold POi values </summary>
        /// <param name="shapeFile">the path to the shapefile</param>
        private void createPoiShape(String shapeFile)
        {
            List<IField> poiFields = new List<IField>();
            IField id = geopuntHelper.createField("POIID", esriFieldType.esriFieldTypeInteger);
            poiFields.Add(id);
            IField category = geopuntHelper.createField("categorie", esriFieldType.esriFieldTypeString);
            poiFields.Add(category);
            IField name = geopuntHelper.createField("naam", esriFieldType.esriFieldTypeString);
            poiFields.Add(name);
            IField adres = geopuntHelper.createField("adres", esriFieldType.esriFieldTypeString, 256);
            poiFields.Add(adres);

            poiFeatureClass = geopuntHelper.createShapeFile(shapeFile, poiFields,
                                    view.Extent.SpatialReference, esriGeometryType.esriGeometryPoint);
        }

        /// <summary>Load daat into the poi shape</summary>
        private void populatePoiShape()
        {
            if (poiFeatureClass == null || poisResponse == null) return;

            List<string> ids = new List<string>();
            foreach (ListViewItem row in resultListView.CheckedItems)
            {
                string id = row.SubItems[1].Text;
                ids.Add(id);
            }

            var poiList = from t in poisResponse.pois
                          where ids.Contains(t.id.ToString())
                          select t;

            foreach (poi row in poiList)
            {
                Double x = row.location.points[0].Point.coordinates[0];
                Double y = row.location.points[0].Point.coordinates[1];
                IPoint pt = new PointClass() { X = x, Y = y, SpatialReference = view.Extent.SpatialReference };
                IFeature feature = poiFeatureClass.CreateFeature();
                feature.Shape = pt;

                int id = row.id;
                int idIdx = poiFeatureClass.FindField("POIID");
                feature.set_Value(idIdx, id);

                string name = row.labels[0].value;
                int nameIdx = poiFeatureClass.FindField("naam");
                feature.set_Value(nameIdx, name);

                string cat = row.categories[1].value;
                int catIdx = poiFeatureClass.FindField("categorie");
                feature.set_Value(catIdx, cat);

                string adres = row.location.address.value.Replace("<br/>", ", ").Replace("<br />", ", ");
                int adresIdx = poiFeatureClass.FindField("adres");
                feature.set_Value(adresIdx, adres);

                feature.Store();
            }
        }

        private IPoint getPoiLocation(string poiId)
        {
            IPoint pt = null;

            foreach( poi t in poisResponse.pois ) {
                if (t.id.ToString() == poiId)
                {
                    Double x = t.location.points[0].Point.coordinates[0];
                    Double y = t.location.points[0].Point.coordinates[1];
                    pt = new PointClass() { X = x, Y = y, SpatialReference = view.Extent.SpatialReference };
                    break;
                }
            }
            return pt;
           
        }

        private void addAsGrapicBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (poisResponse == null) return;

                foreach (ListViewItem item in resultListView.CheckedItems)
                {
                    string name = item.Text;
                    string ID = item.SubItems[1].Text;
                    IPoint toXY = getPoiLocation(ID);
                    if (toXY != null)
                    {
                        IRgbColor innerClr = new RgbColor() { Red = 255, Blue = 0, Green = 255 };
                        IRgbColor outlineClr = new RgbColor() { Red = 0, Blue = 0, Green = 0 };
                        geopuntHelper.AddGraphicToMap(view.FocusMap, toXY, innerClr, outlineClr, 12);
                        geopuntHelper.AddTextElement(view.FocusMap, toXY, name);
                    }
                }
                view.Refresh();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show(ex.StackTrace, msg);
            }
        }


    }
}
