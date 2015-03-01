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
        datacontract.municipalityList municipality;
        ISpatialReference wgs;
        ISpatialReference lam72;
        List<string> cities;

        geopunt4arcgisExtension gpExtension;

        public gipodForm()
        {
            //globals 
            view = ArcMap.Document.ActiveView;

            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            wgs = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);
            lam72 = spatialReferenceFactory.CreateProjectedCoordinateSystem(31370);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
            gipod = new dataHandler.gipod(timeout: gpExtension.timeout);

            InitializeComponent();
            // set the rest of the GUI
            initGUI();
        }

        private void initGUI() 
        {
            dataHandler.capakey capakey = new dataHandler.capakey(timeout: gpExtension.timeout);
            municipality = capakey.getMunicipalities();
            var qry = from datacontract.municipality t in municipality.municipalities select t.municipalityName;

            //lists 
            cities = qry.ToList();
            cities.Insert(0, "");
            List<string> provinces = new List<string>() { "Antwerpen", "Limburg", "Vlaams-Brabant", "Oost-Vlaanderen", "West-Vlaanderen" };
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
            startdatePicker.MinDate = DateTime.Today;
            enddatePicker.Value = nextMonth;
            enddatePicker.MinDate = DateTime.Today;
        }

        #region "overrides"
        protected override void OnClosed(EventArgs e)
        {
            gpExtension.gipodDlg = null;
            base.OnClosed(e);
        }

        #endregion

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
            try
            {
                string shapeCreated;
                shapeCreated = geopuntHelper.ShowSaveDataDialog("Opslaan als");

                //if user canceled shapeCreated is null
                if (shapeCreated == null) return;

                bool deleted = geopuntHelper.deleteFeatureClass(shapeCreated);

                if (!deleted)
                {
                    MessageBox.Show("Kan file de onderaande file niet deleten: \n" + shapeCreated  );
                    return;
                }
                FileInfo featureClassPath = new FileInfo(shapeCreated);

                dataHandler.gipodParam param = getGipodParam();

                List<datacontract.gipodResponse> gipodRecords = fetchGipod(param);

                if (gipodRecords.Count > 0)
                {
                    messageLbl.Text = String.Format("{0} objecten gevonden in GIPOD, aan het schrijven naar shapefile", gipodRecords.Count);

                    //create shapefile or FeatureClass
                    List<IField> gipodfields;
                    IFeatureClass gipodFC;
                    if ( shapeCreated.ToLowerInvariant().EndsWith(".shp") )
                    {
                        gipodfields = gipodIFields(param.gipodType, true);
                        gipodFC = geopuntHelper.createShapeFile(shapeCreated, gipodfields, view.FocusMap.SpatialReference, 
                                                                                        esriGeometryType.esriGeometryPoint);
                    }
                    else if (featureClassPath.DirectoryName.ToLowerInvariant().EndsWith(".gdb"))
                    {
                        gipodfields = gipodIFields(param.gipodType, false);
                        gipodFC = geopuntHelper.createFeatureClass(featureClassPath.DirectoryName, featureClassPath.Name , 
                                                            gipodfields, view.FocusMap.SpatialReference, esriGeometryType.esriGeometryPoint);
                    }
                    else
                    {
                        throw new Exception("Is geen feature class of shapefile.");
                    }

                    populateGipodShape(gipodFC, gipodRecords, param.gipodType);

                    geopuntHelper.addFeatureClassToMap(view, gipodFC, false);
                    view.Refresh();
                    this.Close();
                }
                else
                {
                    saveAsShapeBtn.Enabled = true;
                    messageLbl.Text = "Geen records gevonden in gipod, die voldoen aan deze parameters";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }

        private void provinceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (provinceCombo.Text)
            {
                case "Antwerpen":
                    cities = (from datacontract.municipality t in municipality.municipalities 
                              where t.municipalityCode.StartsWith("1")
                              select t.municipalityName).ToList();
                    break;
                case "Limburg":
                    cities = (from datacontract.municipality t in municipality.municipalities
                              where t.municipalityCode.StartsWith("7")
                              select t.municipalityName).ToList();
                    break;
                case "Vlaams-Brabant":
                    cities = (from datacontract.municipality t in municipality.municipalities
                              where t.municipalityCode.StartsWith("2")
                              select t.municipalityName).ToList();
                    break;
                case "Oost-Vlaanderen":
                    cities = (from datacontract.municipality t in municipality.municipalities
                              where t.municipalityCode.StartsWith("4")
                              select t.municipalityName).ToList();
                    break;
                case "West-Vlaanderen":
                    cities = (from datacontract.municipality t in municipality.municipalities
                              where t.municipalityCode.StartsWith("3")
                              select t.municipalityName).ToList();
                    break;
                default:
                    cities = (from datacontract.municipality t in municipality.municipalities
                              select t.municipalityName).ToList();
                    break;
            }
            cities.Insert(0, "");
            cityCombo.DataSource = cities;
        }

        private void HelpLbl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.geopunt.be/voor-experts/geopunt-plug-ins/functionaliteiten/gipod");
        }
        #endregion

        #region "private functions"
        private List<datacontract.gipodResponse> fetchGipod(dataHandler.gipodParam param)
        {
            //get parameters form GUI
            string city = param.city;
            string province = param.province;
            string owner = param.owner;

            string eventtype = param.eventtype;

            DateTime startdate = param.startdate;
            DateTime enddate = param.enddate;

            dataHandler.CRS crs = param.crs;

            //get data from gipod
            List<datacontract.gipodResponse> response;
            if (param.bbox == null)
            {
                if (param.gipodType == dataHandler.gipodtype.manifestation)
                {
                    response = gipod.allManifestations(startdate, enddate, city, province, owner, eventtype, crs);
                    return response;
                }
                else if (param.gipodType == dataHandler.gipodtype.workassignment)
                {
                    response = gipod.allWorkassignments(startdate, enddate, city, province, owner, crs);
                    return response;
                }
                else return null;
            }
            else
            {
                if (param.gipodType == dataHandler.gipodtype.manifestation)
                {
                    response = gipod.allManifestations(startdate, enddate, city, province, owner, eventtype, crs, param.bbox);
                    return response;
                }
                else if (param.gipodType == dataHandler.gipodtype.workassignment)
                {
                    response = gipod.allWorkassignments(startdate, enddate, city, province, owner, crs, param.bbox);
                    return response;
                }
                else return null;
            }
        }

        /// <summary>Create the the fields for teh gipod Shapefile</summary>
        private List<IField> gipodIFields(dataHandler.gipodtype gtype, bool shp = true)
        {
            List<IField> fields = new List<IField>();

            IField gipodID = geopuntHelper.createField("gipodID", esriFieldType.esriFieldTypeInteger);
            fields.Add(gipodID);
            IField eigenaar = geopuntHelper.createField("eigenaar", esriFieldType.esriFieldTypeString, 254);
            fields.Add(eigenaar);

            int descriptLen = 1600;
            if (shp) descriptLen = 254;
            IField descript = geopuntHelper.createField("info", esriFieldType.esriFieldTypeString, descriptLen);
            fields.Add(descript);
            IField startDate = geopuntHelper.createField("start", esriFieldType.esriFieldTypeDate);
            fields.Add(startDate);
            IField endDate = geopuntHelper.createField("einde", esriFieldType.esriFieldTypeDate);
            fields.Add(endDate);
            IField hinder = geopuntHelper.createField("hinder", esriFieldType.esriFieldTypeSmallInteger);
            fields.Add(hinder);
            IField detail = geopuntHelper.createField("detail", esriFieldType.esriFieldTypeString, 254);
            fields.Add(detail);
            IField cities = geopuntHelper.createField("cities", esriFieldType.esriFieldTypeString, 254);
            fields.Add(cities);

            if (gtype == dataHandler.gipodtype.manifestation) {
                IField initiator = geopuntHelper.createField("initiator", esriFieldType.esriFieldTypeString, 254);
                fields.Add(initiator);
                IField eventType = geopuntHelper.createField("eventType", esriFieldType.esriFieldTypeString, 254);
                fields.Add(eventType);
                IField recurrencePattern = geopuntHelper.createField("patroon", esriFieldType.esriFieldTypeString, 254);
                fields.Add(recurrencePattern);
            }
            return fields;
        }

        /// <summary>Get the gipod parameters </summary>
        private dataHandler.gipodParam getGipodParam()
        {
            //get parameters form GUI
            dataHandler.gipodParam param = new dataHandler.gipodParam();
            param.city = cityCombo.Text;
            param.province = provinceCombo.Text;
            param.owner = ownerCombo.Text;
            param.startdate = startdatePicker.Value;
            param.enddate = enddatePicker.Value;

            param.crs = dataHandler.CRS.Lambert72;

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
                IEnvelope arcGIsBbox = geopuntHelper.Transform2Lam72(view.Extent) as IEnvelope;
                param.bbox = new boundingBox(arcGIsBbox);
            }
            else
            {
                param.bbox = null;
            }
            return param;
        }

        /// <summary>insert the records from the GIPOD service into the shapefile </summary>
        private void populateGipodShape(IFeatureClass gipodFC, List<datacontract.gipodResponse> gipodRecords, dataHandler.gipodtype gtype)
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

                foreach (datacontract.gipodResponse row in gipodRecords)
                {
                    Double x = row.coordinate.coordinates[0];
                    Double y = row.coordinate.coordinates[1];
                    IPoint pt = new PointClass() { X = x, Y = y, SpatialReference = lam72 };
                    IPoint toPt =  geopuntHelper.Transform(pt, srs) as IPoint;

                    featureBuffer.Shape = toPt;

                    int id = row.gipodId;
                    int idIdx = gipodFC.FindField("gipodID");
                    featureBuffer.set_Value(idIdx, id);

                    string owner = row.owner;
                    if (owner.Length > 254) owner = owner.Substring(0, 254);
                    int ownerIdx = gipodFC.FindField("eigenaar");
                    featureBuffer.set_Value(ownerIdx, owner);

                    //sometime very long, handle that
                    string description = row.description;
                    int descriptionIdx = gipodFC.FindField("info");
                    int maxLen = featureBuffer.Fields.get_Field(descriptionIdx).Length;
                    if (description.Length > maxLen)
                    {
                        description = description.Substring(0, maxLen);
                    }
                    featureBuffer.set_Value(descriptionIdx, description);

                    DateTime startDate = row.startDateTime;
                    int startDateIdx = gipodFC.FindField("start");
                    featureBuffer.set_Value(startDateIdx, startDate);

                    DateTime endDate = row.endDateTime;
                    int endDateIdx = gipodFC.FindField("einde");
                    featureBuffer.set_Value(endDateIdx, endDate);

                    int hinder = row.importantHindrance ? 1 : 0;
                    int hinderIdx = gipodFC.FindField("hinder");
                    featureBuffer.set_Value(hinderIdx, hinder);

                    string detail = row.detail;
                    if (detail.Length > 254) detail = detail.Substring(0, 254);
                    int detailIdx = gipodFC.FindField("detail");
                    featureBuffer.set_Value(detailIdx, detail);

                    string cities = string.Join(", ", row.cities.ToArray());
                    if (cities.Length > 254) cities = cities.Substring(0, 254);
                    int citiesIdx = gipodFC.FindField("cities");
                    featureBuffer.set_Value(citiesIdx, cities);

                    if (gtype == dataHandler.gipodtype.manifestation) 
                    {
                        string initiator = row.initiator ;
                        if (initiator != null) {
                            if (initiator.Length > 254) initiator = initiator.Substring(0, 254);
                            int initiatorIdx = gipodFC.FindField("initiator");
                            featureBuffer.set_Value(initiatorIdx, initiator);
                        }
                        string eventType = row.eventType ;
                        if (eventType != null) {
                            if (eventType.Length > 254) eventType = eventType.Substring(0, 254);
                            int eventTypeIdx = gipodFC.FindField("eventType");
                            featureBuffer.set_Value(eventTypeIdx, eventType);
                        }
                        string recurrencePattern = row.recurrencePattern ;
                        if (recurrencePattern != null) {
                            if (recurrencePattern.Length > 254) recurrencePattern = recurrencePattern.Substring(0, 254);
                            int recurrencePatternIdx = gipodFC.FindField("patroon");
                            featureBuffer.set_Value(recurrencePatternIdx, recurrencePattern);
                        }
                    }

                    insertCursor.InsertFeature(featureBuffer);
                }
                insertCursor.Flush();
            }
        }
        #endregion

    }

}
