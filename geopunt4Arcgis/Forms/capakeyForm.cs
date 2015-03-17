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
    public partial class capakeyForm : Form
    {
        ISpatialReferenceFactory3 spatialReferenceFactory;
        IActiveView view;
        IMap map;
        ISpatialReference wgs;
        
        dataHandler.capakey capakey;
        List<IElement> graphics;
        geopunt4arcgisExtension gpExtension;
        
        List<datacontract.municipality> municipalities;
        List<datacontract.department> departments;
        List<datacontract.parcel> parcels;
        datacontract.parcel perceel;

        public capakeyForm()
        {
            //set global objects
            view = ArcMap.Document.ActiveView;
            map = view.FocusMap;

            wgs = geopuntHelper.wgs84;

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();

            capakey = new dataHandler.capakey(timeout: gpExtension.timeout);

            InitializeComponent();

            initGui();
        }

        private void initGui()
        {
            municipalities = capakey.getMunicipalities().municipalities;
            perceel = null;
            graphics = new List<IElement>();
            gemeenteCbx.Items.Clear();
            gemeenteCbx.Items.AddRange((from n in municipalities select n.municipalityName).ToArray());
        }

        #region "overrides"
        protected override void OnClosed(EventArgs e)
        {
            gpExtension.capakayDlg = null;
            clearGraphics();
            view.Refresh();
            base.OnClosed(e);
        }

        #endregion

        #region "Event handlers"
        private void gemeenteCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            add2mapBtn.Enabled = false;
            addMarkerBtn.Enabled = false;

            msgLbl.Text = "";
            perceel = null;

            if (niscode == ""|| niscode == null) return;

            try
            {
                departments = capakey.getDepartments(int.Parse(niscode)).departments;
                departementCbx.Items.Clear(); departementCbx.Text = "";
                sectieCbx.Items.Clear(); sectieCbx.Text = "";
                parcelCbx.Items.Clear(); parcelCbx.Text = "";
                departementCbx.Items.AddRange((from n in departments select n.departmentName).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void departementCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            string depName = departementCbx.Text;
            string depCode = department2code(depName);

            add2mapBtn.Enabled = false;
            addMarkerBtn.Enabled = false;

            msgLbl.Text = "";
            perceel = null;

            if (niscode == "" || depCode == "" || niscode == null || depCode == null) return;

            try
            {
                List<datacontract.section> secties = capakey.getSecties(int.Parse(niscode), int.Parse(depCode)).sections;
                sectieCbx.Items.Clear(); sectieCbx.Text = "";
                parcelCbx.Items.Clear(); parcelCbx.Text = "";
                sectieCbx.Items.AddRange((from n in secties select n.sectionCode).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void sectieCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            string depName = departementCbx.Text;
            string depCode = department2code(depName);

            string sectie = sectieCbx.Text;

            add2mapBtn.Enabled = false;
            addMarkerBtn.Enabled = false;

            msgLbl.Text = "";
            perceel = null;

            if (niscode == "" || depCode == "" || sectie == "" ||
                niscode == null || depCode == null || sectie == null ) return;

            try
            {
                parcelCbx.Items.Clear();
                parcelCbx.Text = "";
                parcels = capakey.getParcels(int.Parse(niscode), int.Parse(depCode), sectie).parcels;
                parcelCbx.Items.AddRange((from n in parcels select n.perceelnummer).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void parcelCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            string depName = departementCbx.Text;
            string depCode = department2code(depName);

            string sectie = sectieCbx.Text;
            string parcelNr = parcelCbx.Text;

            if (niscode == "" || depCode == "" || sectie == "" || parcelNr == "" ||
                niscode == null || depCode == null || sectie == null || parcelNr == null) return;

            add2mapBtn.Enabled = true;
            addMarkerBtn.Enabled = true;

            try
            {
                perceel = capakey.getParcel(int.Parse(niscode), int.Parse(depCode), sectie, parcelNr,
                                                    dataHandler.CRS.WGS84, dataHandler.capakeyGeometryType.full);

                msgLbl.Text = string.Join(" - ", perceel.adres.ToArray());
            }
            catch (Exception ex)
            {
                perceel = null;
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gemeenteZoomBtn_Click(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            if (niscode == "" || niscode == null) return;

            try
            {
                datacontract.municipality municipality = capakey.getMunicipalitiy(int.Parse(niscode), 
                                                        dataHandler.CRS.WGS84, dataHandler.capakeyGeometryType.full);
                datacontract.geojson municipalityGeom = JsonConvert.DeserializeObject<datacontract.geojson>(municipality.geometry.shape);

                createGrapicAndZoomTo(municipality.geometry.shape, municipalityGeom);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void departementZoomBtn_Click(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            string depName = departementCbx.Text;
            string depCode = department2code(depName);

            if (niscode == "" || depCode == "" || niscode == null || depCode == null) return;

            try
            {
                datacontract.department dep = capakey.getDepartment(int.Parse(niscode), int.Parse(depCode), 
                                                        dataHandler.CRS.WGS84, dataHandler.capakeyGeometryType.full);
                datacontract.geojson depGeom = JsonConvert.DeserializeObject<datacontract.geojson>(dep.geometry.shape);

                createGrapicAndZoomTo(dep.geometry.shape, depGeom);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void sectieZoomBtn_Click(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            string depName = departementCbx.Text;
            string depCode = department2code(depName);

            string sectie = sectieCbx.Text;

            if (niscode == "" || depCode == "" || sectie == "" ||
                niscode == null || depCode == null || sectie == null) return;

            try
            {
                datacontract.section sec = capakey.getSectie(int.Parse(niscode), int.Parse(depCode), sectie,
                                                        dataHandler.CRS.WGS84, dataHandler.capakeyGeometryType.full);
                datacontract.geojson secGeom = JsonConvert.DeserializeObject<datacontract.geojson>(sec.geometry.shape);

                createGrapicAndZoomTo(sec.geometry.shape, secGeom);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void parcelZoomBtn_Click(object sender, EventArgs e)
        {
            try
            {
                datacontract.geojson secGeom = JsonConvert.DeserializeObject<datacontract.geojson>(perceel.geometry.shape);
                createGrapicAndZoomTo(perceel.geometry.shape, secGeom);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void add2mapBtn_Click(object sender, EventArgs e)
        {
            try 
            {
                if (gpExtension.parcelLayer == null && perceel != null)
                {
                    String perceelPath = geopuntHelper.ShowSaveDataDialog("Opslaan als");
                    if (perceelPath == null) return;

                    bool deleted = geopuntHelper.deleteFeatureClass(perceelPath);
                    if (!deleted)
                    {
                        MessageBox.Show("Kan file de onderaande file niet deleten: \n" + perceelPath);
                        return;
                    }
                    FileInfo featureClassPath = new FileInfo(perceelPath);
                    List<IField> fields = parcelFields();
                    IFeatureClass parcelFC;

                    if (perceelPath.ToLowerInvariant().EndsWith(".shp"))
                    {
                        parcelFC = geopuntHelper.createShapeFile(perceelPath, fields, view.FocusMap.SpatialReference,
                                                                                        esriGeometryType.esriGeometryPolygon);
                    }
                    else if (featureClassPath.DirectoryName.ToLowerInvariant().EndsWith(".gdb"))
                    {
                        parcelFC = geopuntHelper.createFeatureClass(featureClassPath.DirectoryName, featureClassPath.Name,
                                                            fields, view.FocusMap.SpatialReference, esriGeometryType.esriGeometryPolygon);
                    }
                    else 
                    {
                        throw new Exception("Is geen feature class of shapefile.");
                    }
                    gpExtension.parcelLayer = parcelFC;
                    geopuntHelper.addFeatureClassToMap(view, gpExtension.parcelLayer, false);
                }
                appendParcelField(gpExtension.parcelLayer);
                view.Refresh();
            }
            catch (Exception ex)  
            {
                  MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void addMarkerBtn_Click(object sender, EventArgs e)
        {
            if (perceel == null) return;

            datacontract.geojsonPolygon jsPoly = JsonConvert.DeserializeObject<datacontract.geojsonPolygon>(perceel.geometry.shape);
            IPolygon wgsShape = geopuntHelper.geojson2esriPolygon(jsPoly, (int)dataHandler.CRS.WGS84);
            IPolygon mapShape = (IPolygon)geopuntHelper.Transform(wgsShape, map.SpatialReference);

            string adres = string.Join("-", perceel.adres.ToArray()) ;
            if (adres.Length > 120) adres = adres.Substring(0, 120);

            IRgbColor innerClr = new RgbColor() { Red = 0, Blue = 0, Green = 0 };
            IRgbColor outlineClr = new RgbColor() { Red = 0, Blue = 200, Green = 0 };

            IPoint center = ((IArea)mapShape).LabelPoint;

            geopuntHelper.AddGraphicToMap(map, mapShape, innerClr, outlineClr, 2, false);
            geopuntHelper.AddTextElement(map, center, perceel.capakey + "\r\n" + adres);

            view.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void helpLbl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                "http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/zoek-een-perceel");
        }
        #endregion

        #region "private functions"
        private void createGrapicAndZoomTo(string capakeyResponse, datacontract.geojson Geom)
        {
            IRgbColor inClr = new RgbColorClass() { Red = 0, Blue = 100, Green = 0 }; ;
            IRgbColor outLine = new RgbColorClass() { Red = 0, Blue = 200, Green = 0, Transparency = 240 };

            if (Geom.type == "MultiPolygon")
            {
                datacontract.geojsonMultiPolygon muniPolygons =
                                  JsonConvert.DeserializeObject<datacontract.geojsonMultiPolygon>(capakeyResponse);

                IGeometryCollection multiPoly = new GeometryBagClass();

                clearGraphics();
                foreach (datacontract.geojsonPolygon poly in muniPolygons.toPolygonList())
                {
                    IPolygon wgsPoly = geopuntHelper.geojson2esriPolygon(poly, (int)dataHandler.CRS.WGS84);
                    wgsPoly.SimplifyPreserveFromTo();
                    IGeometry prjGeom = geopuntHelper.Transform((IGeometry)wgsPoly, map.SpatialReference);

                    IElement muniGrapic = geopuntHelper.AddGraphicToMap(map, prjGeom, inClr, outLine, 2, true);
                    graphics.Add(muniGrapic);

                    multiPoly.AddGeometry(prjGeom);
                }
                view.Extent = ((IGeometryBag)multiPoly).Envelope;
                view.Refresh();
            }
            else if (Geom.type == "Polygon")
            {
                datacontract.geojsonPolygon municipalityPolygon =
                            JsonConvert.DeserializeObject<datacontract.geojsonPolygon>(capakeyResponse);
                IPolygon wgsPoly = geopuntHelper.geojson2esriPolygon(municipalityPolygon, (int)dataHandler.CRS.WGS84);
                wgsPoly.SimplifyPreserveFromTo();
                IPolygon prjPoly = (IPolygon)geopuntHelper.Transform((IGeometry)wgsPoly, map.SpatialReference);
                view.Extent = prjPoly.Envelope;

                clearGraphics();
                IElement muniGrapic = geopuntHelper.AddGraphicToMap(map, (IGeometry)prjPoly, inClr, outLine, 3, true);
                graphics.Add(muniGrapic);
                view.Refresh();
            }
        }

        private List<IField> parcelFields() 
        {
            List<IField> fields = new List<IField>();

            IField capakey = geopuntHelper.createField("capakey", esriFieldType.esriFieldTypeString, 60);
            fields.Add(capakey);
            IField perceelnr = geopuntHelper.createField("perceelnr", esriFieldType.esriFieldTypeString, 40);
            fields.Add(perceelnr);
            IField grondnr = geopuntHelper.createField("grondnr", esriFieldType.esriFieldTypeString, 8);
            fields.Add(grondnr);
            IField exponent = geopuntHelper.createField("exponent", esriFieldType.esriFieldTypeString, 8);
            fields.Add(exponent);
            IField macht = geopuntHelper.createField("macht", esriFieldType.esriFieldTypeInteger);
            fields.Add(macht);
            IField bisnr = geopuntHelper.createField("bisnr", esriFieldType.esriFieldTypeInteger);
            fields.Add(bisnr);
            IField perceeltype = geopuntHelper.createField("perceeltype", esriFieldType.esriFieldTypeString, 8);
            fields.Add(perceeltype);
            IField adres = geopuntHelper.createField("adres", esriFieldType.esriFieldTypeString, 254);
            fields.Add(adres);

            return fields;
        }

        private void appendParcelField(IFeatureClass parcelFC) 
        {
            if (perceel == null) return;

            IFeatureCursor insertCursor = parcelFC.Insert(false);

            datacontract.geojsonPolygon jsPoly = JsonConvert.DeserializeObject<datacontract.geojsonPolygon>(perceel.geometry.shape);
            IPolygon wgsShape = geopuntHelper.geojson2esriPolygon( jsPoly , (int)dataHandler.CRS.WGS84 );
            IPolygon mapShape = (IPolygon) geopuntHelper.Transform(wgsShape, map.SpatialReference);

            IFeature feature = parcelFC.CreateFeature();
            feature.Shape = (IGeometry)mapShape;

            int capakeyIdx = parcelFC.FindField("capakey");
            feature.set_Value(capakeyIdx, perceel.capakey);

            int perceelnrIdx = parcelFC.FindField("perceelnr");
            feature.set_Value(perceelnrIdx, perceel.perceelnummer);

            int grondnrIdx = parcelFC.FindField("grondnr");
            feature.set_Value(grondnrIdx, perceel.grondnummer);

            int exponentIdx = parcelFC.FindField("exponent");
            feature.set_Value(exponentIdx, perceel.exponent);

            int machtIdx = parcelFC.FindField("macht");
            feature.set_Value(machtIdx, perceel.macht);

            int bisnrIdx = parcelFC.FindField("bisnr");
            feature.set_Value(bisnrIdx, perceel.bisnummer);

            int perceeltypeIdx = parcelFC.FindField("perceeltype");
            feature.set_Value(perceeltypeIdx, perceel.type);

            string adres = string.Join("-", perceel.adres.ToArray()) ;
            if (adres.Length > 254)
                adres = adres.Substring(0, 254);

            int adresIdx = parcelFC.FindField("adres");
            feature.set_Value(adresIdx, adres);

            feature.Store();
        }

        private string municipality2nis(string muniName)
        {
            if (muniName == null || muniName == "") return "";

            var niscodes = (
                from n in municipalities
                where n.municipalityName == muniName
                select n.municipalityCode);

            if (niscodes.Count() == 0) return "";

            return niscodes.First<string>();
        }

        private string department2code(string depName )
        {
            if (depName == null || depName == "") return "";

            var depcodes = (
                from n in departments
                where n.departmentName == depName
                select n.departmentCode);

            if (depcodes.Count() == 0) return "";

            return depcodes.First<string>();
        }

        private void clearGraphics()
        {
            IGraphicsContainer graphicsContainer = (IGraphicsContainer)map;

            foreach (IElement grp in graphics)
            {
                if (grp == null) break;
                //grp.Locked = false;
                try
                {
                    graphicsContainer.DeleteElement(grp);
                }
                catch (Exception)
                {
                    Console.Write("Element was already deleted");
                }
            }
            graphics.Clear();
        }
        #endregion

    }
}
