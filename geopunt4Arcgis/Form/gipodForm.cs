using System;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

namespace geopunt4Arcgis
{
    public partial class gipodForm : Form
    {
        ISpatialReferenceFactory spatialReferenceFactory;
        IActiveView view;
        dataHandler.gipod gipod;
        ISpatialReference wgs;

        geopunt4arcgisExtension gpExtension;

        public gipodForm()
        {
            //globals 
            gipod = new dataHandler.gipod();
            view = ArcMap.Document.ActiveView;

            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory2;

            wgs = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();

            InitializeComponent();
            // set the rest of the GUI
            initGUI();
        }

        private void initGUI() 
        {
            //lists
            List<string> cities = gipod.getReferencedata(dataHandler.gipodReferencedata.city);
            cities.Insert(0,"");
            List<string> provinces = gipod.getReferencedata(dataHandler.gipodReferencedata.province);
            provinces.Insert(0, "");
            List<string> owners = gipod.getReferencedata(dataHandler.gipodReferencedata.owner);
            owners.Insert(0, "");
            List<string> eventTypes = gipod.getReferencedata(dataHandler.gipodReferencedata.eventtype);
            eventTypes.Insert(0, "");

            cityCombo.DataSource = cities;
            provinceCombo.DataSource = provinces;
            ownerCombo.DataSource = owners;
            eventTypeCombo.DataSource = eventTypes;

            //time
            DateTime nextMonth = DateTime.Today.Add(new TimeSpan(30, 0, 0, 0, 0));

            startdatePicker.Value = DateTime.Today;
            startdatePicker.MaxDate = nextMonth;
            enddatePicker.Value = nextMonth;
            enddatePicker.MinDate = DateTime.Today;
        }

        #region "eventhandlers"

        private void workassignmentRadio_CheckedChanged(object sender, EventArgs e)
        {
            eventTypeCombo.Enabled = manifestationRadio.Checked;
        }

        private void enddatePicker_ValueChanged(object sender, EventArgs e)
        {
            startdatePicker.MaxDate = enddatePicker.Value;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsShapeBtn_Click(object sender, EventArgs e)
        {
            string shapeCreated;
            shapeCreated = createShapeName();

            //if user canceled shapeCreated is null
            if (shapeCreated == null) return;

            if (File.Exists(shapeCreated))
            {
                //messageLbl.Text = string.Format("Kan {0} niet overschrijven.", shapeCreated);
                //return;
                geopuntHelper.deleteShapeFile(shapeCreated);
            }

            gipodParam param = getGipodParam();

            //disable button to prevent multiple runs and start waiting animation
            saveAsShapeBtn.Enabled = false;
            messageLbl.Text = "Data ophalen van GIPOD";
            progress.MarqueeAnimationSpeed = 100;

            List<gipodResponse> gipodRecords = fetchGipod(param);

            if (gipodRecords.Count > 0)
            {
                messageLbl.Text = String.Format("{0} objecten gevonden in GIPOD, aan het schrijven naar shapefile", gipodRecords.Count);

                //create shapefile
                List<IField> gipodfields = gipodIFields();
                IFeatureClass gipodFC = geopuntHelper.createShapeFile(shapeCreated, gipodfields,
                                            view.FocusMap.SpatialReference, esriGeometryType.esriGeometryPoint);

                populateGipodShape(gipodFC, gipodRecords);

                geopuntHelper.addFeatureClassToMap(view, gipodFC, true);
                this.Close();
            }
            else
            {
                saveAsShapeBtn.Enabled = true;
                progress.MarqueeAnimationSpeed = 0;
                messageLbl.Text = "Geen records gevonden in gipod";
            }
        }

        #endregion

        #region "private functions"
        private List<datacontract.manifestation> fetchGipod(dataHandler.gipodParam param)
        {
            //get parameters form GUI
            string city = param.city;
            string province = param.province;
            string owner = param.owner;

            string eventtype = param.eventtype;

            DateTime startdate = param.startdate;
            DateTime enddate = param.startdate;

            dataHandler.gipodCRS crs = param.crs;

            //get data from gipod
            List<dataHandler.gipodParam> response;
            if (param.bbox == null)
            {
                if (param.gipodType == dataHandler.gipodtype.workassignment)
                {
                    response = gipod.allWorkassignments(startdate, enddate, city, province, owner, crs);
                    return response;
                }
                else if (param.gipodType == gipodtype.manifestation)
                {
                    response = gipod.allManifestations(startdate, enddate, city, province, owner, eventtype, crs);
                    return response;
                }
                else return null;
            }
            else
            {
                boundingBox bbox = param.bbox;
                if (param.gipodType == gipodtype.workassignment)
                {
                    response = gipod.allWorkassignments(bbox, startdate, enddate, city, province, owner, crs);
                    return response;
                }
                else if (param.gipodType == gipodtype.manifestation)
                {
                    response = gipod.allManifestations(bbox, startdate, enddate, city, province, owner, eventtype, crs);
                    return response;
                }
                else return null;
            }

        }

        /// <summary>get the filename for gipod shapefile and delete existing shape if needed </summary>
        private string createShapeName()
        {
            //get shapefile path
            SaveFileDialog saveDlg = new SaveFileDialog()
            {
                Filter = "shapefile (*.shp)|*.shp",
                Title = "Opslaan naar een shapefile",
                CheckFileExists = false
            };
            saveDlg.ShowDialog();

            //write shapefile 
            if (saveDlg.FileName == "")
            {
                return null;
            }

            return saveDlg.FileName;
        }

        /// <summary>Create the the fields for teh gipod Shapefile</summary>
        private List<IField> gipodIFields()
        {
            List<IField> fields = new List<IField>();

            IField gipodID = geopuntHelper.createField("gipodID", esriFieldType.esriFieldTypeInteger);
            fields.Add(gipodID);
            IField eigenaar = geopuntHelper.createField("eigenaar", esriFieldType.esriFieldTypeString, 255);
            fields.Add(eigenaar);
            IField descript = geopuntHelper.createField("descript", esriFieldType.esriFieldTypeString, 255);
            fields.Add(descript);
            IField startDate = geopuntHelper.createField("startDate", esriFieldType.esriFieldTypeDate);
            fields.Add(startDate);
            IField endDate = geopuntHelper.createField("endDate", esriFieldType.esriFieldTypeDate);
            fields.Add(endDate);
            IField hinder = geopuntHelper.createField("hinder", esriFieldType.esriFieldTypeSmallInteger);
            fields.Add(hinder);
            IField detail = geopuntHelper.createField("detail", esriFieldType.esriFieldTypeString, 140);
            fields.Add(detail);
            IField cities = geopuntHelper.createField("cities", esriFieldType.esriFieldTypeString, 255);
            fields.Add(cities);

            return fields;
        }

        private dataHandler.gipodParam getGipodParam()
        {
            ISpatialReference bboxCrs;

            //get parameters form GUI
            dataHandler.gipodParam param = new dataHandler.gipodParam();
            param.city = cityCombo.Text;
            param.province = provinceCombo.Text;
            param.owner = ownerCombo.Text;
            param.startdate = startdatePicker.Value;
            param.enddate = enddatePicker.Value;

            if (view.FocusMap.SpatialReference.FactoryCode == 900913 ||
                  view.FocusMap.SpatialReference.FactoryCode == 102100)
            {
                param.crs = dataHandler.gipodCRS.WEBMERCATOR;
                bboxCrs = view.FocusMap.SpatialReference;
            }
            else if (view.FocusMap.SpatialReference.FactoryCode == 31370)
            {
                param.crs = dataHandler.gipodCRS.Lambert72;
                bboxCrs = view.FocusMap.SpatialReference;
            }
            else
            {
                param.crs = dataHandler.gipodCRS.WGS84;
                bboxCrs = wgs;
            }

            if (manifestationRadio.Checked)
            {
                param.gipodType = dataHandler.gipodtype.manifestation;
                param.eventtype = eventTypeCombo.Text;
            }
            else
            {
                param.gipodType = dataHandler.gipodtype.workassignment;
                param.eventtype = "";
            }
            //set bounds
            if (useExtendChk.Checked)
            {
                IEnvelope arcGIsBbox = geopuntHelper.Transform(view.Extent, bboxCrs) as IEnvelope;
                param.bbox = new boundingBox(arcGIsBbox);
            }
            else
            {
                param.bbox = new boundingBox(bboxCrs.FactoryCode);
            }
            return param;
        }

        /// <summary>insert the records from the GIPOD service into the shapefile </summary>
        private void populateGipodShape(IFeatureClass gipodFC, List<datacontract.manifestation> gipodRecords)
        {
            //return if something is null
            if (gipodFC == null || gipodRecords == null) return;

            //get the srs
            ISpatialReference srs = view.FocusMap.SpatialReference;

            using (ComReleaser comReleaser = new ComReleaser())
            {
                // Create a feature buffer.
                IFeatureBuffer featureBuffer = gipodFC.CreateFeatureBuffer();
                comReleaser.ManageLifetime(featureBuffer);

                // Create an insert cursor.
                IFeatureCursor insertCursor = gipodFC.Insert(true);
                comReleaser.ManageLifetime(insertCursor);

                foreach (datacontract.manifestation row in gipodRecords)
                {
                    Double x = row.coordinate.coordinates[0];
                    Double y = row.coordinate.coordinates[1];
                    IPoint pt = new PointClass() { X = x, Y = y, SpatialReference = srs };

                    featureBuffer.Shape = pt;

                    int id = row.gipodId;
                    int idIdx = gipodFC.FindField("gipodID");
                    featureBuffer.set_Value(idIdx, id);

                    string owner = row.owner;
                    int ownerIdx = gipodFC.FindField("eigenaar");
                    featureBuffer.set_Value(ownerIdx, owner);

                    string description = row.description;
                    int descriptionIdx = gipodFC.FindField("descript");
                    featureBuffer.set_Value(descriptionIdx, description);

                    DateTime startDate = row.startDateTime;
                    int startDateIdx = gipodFC.FindField("startDate");
                    featureBuffer.set_Value(startDateIdx, startDate);

                    DateTime endDate = row.endDateTime;
                    int endDateIdx = gipodFC.FindField("endDate");
                    featureBuffer.set_Value(endDateIdx, endDate);

                    int hinder = row.importantHindrance ? 1 : 0;
                    int hinderIdx = gipodFC.FindField("hinder");
                    featureBuffer.set_Value(hinderIdx, hinder);

                    string detail = row.detail;
                    int detailIdx = gipodFC.FindField("detail");
                    featureBuffer.set_Value(detailIdx, detail);

                    string cities = string.Join(", ", row.cities.ToArray());
                    int citiesIdx = gipodFC.FindField("cities");
                    featureBuffer.set_Value(citiesIdx, cities);

                    insertCursor.InsertFeature(featureBuffer);
                }
                insertCursor.Flush();
            }
        }
        #endregion

    }

}
