using System;
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
    public partial class poiSearchForm : Form
    {
        SortableBindingList<poiDataRow> rows;
        IActiveView view;
        IMap map;
        ISpatialReferenceFactory spatialReferenceFactory;
        ISpatialReference wgs;
        List<datacontract.poiValueGroup> themes;
        List<datacontract.poiValueGroup> categories;
        List<datacontract.poiValueGroup> poiTypes;
        dataHandler.poi poiDH;
        datacontract.poiMaxResponse poiData;
        datacontract.municipalityList municipalities;
        List<IElement> graphics;

        geopunt4arcgisExtension gpExtension;

        public poiSearchForm()
        {
            view = ArcMap.Document.ActiveView;
            map = view.FocusMap;
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            wgs = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();

            poiDH = new dataHandler.poi();

            graphics = new List<IElement>();

            InitializeComponent();
            initGui();
        }

        public void initGui()
        {
            rows = new SortableBindingList<poiDataRow>();
            resultGrid.DataSource = rows;

            dataHandler.capakey capa = new dataHandler.capakey();

            municipalities = capa.getMunicipalities();
            List<string> cities = (from datacontract.municipality t in municipalities.municipalities select t.municipalityName).ToList(); 
            cities.Insert(0, "");
            gemeenteCbx.DataSource = cities;

            themes = poiDH.listThemes().categories;
            categories = poiDH.listCategories().categories;
            poiTypes = poiDH.listPOItypes().categories;

            populateFilters();
        }

        #region "eventhandlers"
        private void zoekBtn_Click(object sender, EventArgs e)
        {
            //input
            string themeCode = theme2code(themeCbx.Text);
            string catCode = cat2code(categoryCbx.Text);
            string poiTypeCode = poitype2code(typeCbx.Text);
            string keyWord = keywordTxt.Text;
            string nis;
            boundingBox extent;
            if (extentCkb.Checked) {
                IEnvelope env = view.Extent;
                IEnvelope prjEnv = geopuntHelper.Transform2WGS((IGeometry)env).Envelope; 
                extent = new boundingBox(prjEnv);
                nis = null;
            }
            else
            {
                nis = municipality2nis(gemeenteCbx.Text);
                extent = null;
            }
            int count = 32;
            if (keyWord != "") count = 100;

            try
            {
                //get the data
                poiData = poiDH.getMaxmodel( 
                    q: keyWord, theme: themeCode, category: catCode, POItype: poiTypeCode, niscode: nis,
                    c: count, bbox: extent, srs: dataHandler.CRS.WGS84);

                List<datacontract.poiMaxModel> pois = poiData.pois;

                rows.Clear();

                msgLbl.Text = string.Format("Aantal getoond:{0} - gevonden:{1}", pois.Count, poiData.label.value);

                //parse results
                foreach (datacontract.poiMaxModel poi in pois)
                {
                    poiDataRow row = new poiDataRow();
                    List<string> qry;
                    datacontract.poiAddress adres;

                    row.id = poi.id;

                    qry = ( from datacontract.poiValueGroup n in poi.categories
                            where n.type == "Type"
                            select n.value).ToList();
                    if (qry.Count > 0) row.Type = qry[0];

                    qry = (  from datacontract.poiValueGroup n in poi.categories
                             where n.type == "Categorie"
                             select n.value).ToList();
                    if (qry.Count > 0) row.Category = qry[0];

                    qry = ( from datacontract.poiValueGroup n in poi.categories
                            where n.type == "Thema"
                            select n.value).ToList();
                    if (qry.Count > 0) row.Theme = qry[0];
              
                    qry = (
                     from datacontract.poiValueGroup n in poi.labels 
                     select n.value).ToList();
                    if (qry.Count > 0) row.Naam = qry[0];

                    adres = poi.location.address;
                    if (adres != null)
                    {
                        row.Straat = adres.street;
                        row.Huisnummer = adres.streetnumber;
                        row.Postcode = adres.postalcode;
                        row.Gemeente = adres.municipality;
                    }
                    rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void extentCkb_CheckedChanged(object sender, EventArgs e)
        {
            gemeenteCbx.Enabled = !extentCkb.Checked;
        }

        private void themeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string theme = themeCbx.Text;

            if (theme == "")
            {
                populateFilters();
                return;
            }
            try
            {
                string themeCode = theme2code(theme);

                datacontract.poiCategories qry = poiDH.listCategories(themeCode);
                List<string> categoriesList = (from n in qry.categories select n.value).ToList<string>();
                categoriesList.Insert(0, "");
                categoryCbx.Items.Clear();
                typeCbx.Items.Clear();
                categoryCbx.Items.AddRange(categoriesList.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message +": "+ ex.StackTrace );
            }

        }

        private void categoryCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = categoryCbx.Text;
            string theme = themeCbx.Text;
            if (cat == "")
            {
                populateFilters();
                return;
            }
            try
            {
                string themeCode = theme2code(theme);
                string catCode = cat2code(cat);

                datacontract.poiCategories qry = poiDH.listPOItypes(themeCode, catCode);
                List<string> poiTypeList = (from n in qry.categories select n.value).ToList<string>();
                poiTypeList.Insert(0, "");

                typeCbx.Items.Clear();
                typeCbx.Items.AddRange(poiTypeList.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resultGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                clearGraphics();
                for (int i = 0; i < resultGrid.SelectedRows.Count; i++)
                {
                    DataGridViewRow row = resultGrid.SelectedRows[i];
                    int id = (int) row.Cells[0].Value;

                    List<datacontract.poiLocation> qry = (from n in poiData.pois
                                                          where n.id == id
                                                          select n.location).ToList<datacontract.poiLocation>();
                    if (qry.Count == 0) break;
                    if (qry[0].points == null || qry[0].points.Count == 0) break;

                    datacontract.geojsonPoint jsonPt = qry[0].points[0].Point;
                    IPoint wgsPt = geopuntHelper.geojson2esriPoint(jsonPt, 4326);
                    IPoint prjPt = (IPoint)geopuntHelper.Transform((IGeometry)wgsPt, map.SpatialReference);

                    IRgbColor clr = new RgbColorClass() { Red = 255, Green = 255, Blue = 0 };
                    IRgbColor outclr = new RgbColorClass() { Red = 0, Green = 0, Blue = 0 };

                    IElement grp = geopuntHelper.AddGraphicToMap(view.FocusMap, prjPt, clr, outclr, 5, true);
                    graphics.Add(grp);
                }
                view.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void zoom2selBtn_Click(object sender, EventArgs e)
        {
            if (resultGrid.SelectedRows.Count == 0) return;

            IPointCollection points = new MultipointClass();
            try
            {
                for (int i = 0; i < resultGrid.SelectedRows.Count; i++)
                {
                    DataGridViewRow row = resultGrid.SelectedRows[i];
                    int id = (int)row.Cells[0].Value;

                    List<datacontract.poiLocation> qry = (from n in poiData.pois
                                                          where n.id == id
                                                          select n.location).ToList<datacontract.poiLocation>();
                    if (qry.Count == 0) break;
                    if (qry[0].points == null || qry[0].points.Count == 0) break;

                    datacontract.geojsonPoint jsonPt = qry[0].points[0].Point;
                    IPoint wgsPt = geopuntHelper.geojson2esriPoint(jsonPt, 4326);
                    IPoint prjPt = (IPoint)geopuntHelper.Transform((IGeometry)wgsPt, map.SpatialReference);

                    points.AddPoint(prjPt, Type.Missing, Type.Missing);
                }
                if (points.PointCount == 0)
                {
                    return;
                }
                else if (points.PointCount == 1)
                {
                    IPoint xy = points.get_Point(0);
                    geopuntHelper.ZoomByRatioAndRecenter(view, 0.5, xy.X, xy.Y);
                }
                else
                {
                    IEnvelope extent = ((IGeometry)points).Envelope;
                    view.Extent = extent;
                }
                view.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void addSelection2mapBtn_Click(object sender, EventArgs e)
        {
            if (resultGrid.SelectedRows.Count == 0) return;

            List<int> ids = new List<int>();
            List<datacontract.poiMaxModel> pois;

            try
            {
                for (int i = 0; i < resultGrid.SelectedRows.Count; i++)
                {
                    DataGridViewRow row = resultGrid.SelectedRows[i];
                    int id = (int)row.Cells[0].Value;
                    ids.Add(id);
                }
                pois = (from n in poiData.pois
                        where ids.Contains(n.id)
                        select n).ToList<datacontract.poiMaxModel>();
                if (pois.Count == 0) return;

                IFeatureClass poiFC;

                if (gpExtension.poiLayer == null)
                {
                    String poiPath = geopuntHelper.ShowSaveDataDialog("Opslaan als");
                    if (poiPath == null) return;

                    bool deleted = geopuntHelper.deleteFeatureClass(poiPath);
                    if (!deleted)
                    {
                        MessageBox.Show("Kan file de onderaande file niet deleten: \n" + poiPath);
                        return;
                    }
                    FileInfo featureClassPath = new FileInfo(poiPath);
                    List<IField> fields = poiIMaxFields();

                    if (poiPath.ToLowerInvariant().EndsWith(".shp"))
                    {
                        poiFC = geopuntHelper.createShapeFile(poiPath, fields, view.FocusMap.SpatialReference,
                                                                                        esriGeometryType.esriGeometryPoint);
                    }
                    else if (featureClassPath.DirectoryName.ToLowerInvariant().EndsWith(".gdb"))
                    {
                        poiFC = geopuntHelper.createFeatureClass(featureClassPath.DirectoryName, featureClassPath.Name,
                                                            fields, view.FocusMap.SpatialReference, esriGeometryType.esriGeometryPoint);
                    }
                    else
                    {
                        throw new Exception("Is geen feature class of shapefile.");
                    }
                    gpExtension.poiLayer = poiFC;
                    geopuntHelper.addFeatureClassToMap(view, poiFC, false);
                }
                populateMaxFields(gpExtension.poiLayer, pois);
                view.Refresh();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }

        }

        private void addAll2MapBtn_Click(object sender, EventArgs e)
        {
            //get input
            string themeCode = theme2code(themeCbx.Text);
            string catCode = cat2code(categoryCbx.Text);
            string poiTypeCode = poitype2code(typeCbx.Text);
            string keyWord = keywordTxt.Text;
            string nis;
            boundingBox extent;
            if (extentCkb.Checked)
            {
                IEnvelope env = view.Extent;
                IEnvelope prjEnv = geopuntHelper.Transform2WGS((IGeometry)env).Envelope;
                extent = new boundingBox(prjEnv);
                nis = null;
            }
            else
            {
                nis = municipality2nis(gemeenteCbx.Text);
                extent = null;
            }

            try
            {
                //get the data
                datacontract.poiMinResponse poiMinData = poiDH.getMinmodel( q: keyWord, theme: themeCode, category: catCode, 
                                             POItype: poiTypeCode, niscode: nis, bbox: extent, srs: dataHandler.CRS.WGS84);

                List<datacontract.poiMinModel> pois = poiMinData.pois;
                List<datacontract.cluster> clusters = poiMinData.clusters;

                if (pois.Count == 0 && clusters.Count == 0) return;

                if (gpExtension.poiMinLayer == null)
                {
                    String poiPath = geopuntHelper.ShowSaveDataDialog("Opslaan als");
                    if (poiPath == null) return;

                    FileInfo featureClassPath = new FileInfo(poiPath);
                    List<IField> fields = poiIMinFields();
                    IFeatureClass poiFC;

                    if (poiPath.ToLowerInvariant().EndsWith(".shp"))
                    {
                        poiFC = geopuntHelper.createShapeFile(poiPath, fields, view.FocusMap.SpatialReference,
                                                                                        esriGeometryType.esriGeometryPoint, true);
                    }
                    else if (featureClassPath.DirectoryName.ToLowerInvariant().EndsWith(".gdb"))
                    {
                        poiFC = geopuntHelper.createFeatureClass(featureClassPath.DirectoryName, featureClassPath.Name,
                                                            fields, view.FocusMap.SpatialReference, esriGeometryType.esriGeometryPoint, true);
                    }
                    else
                    {
                        throw new Exception("Is geen feature class of shapefile.");
                    }
                    gpExtension.poiMinLayer = poiFC;
                    geopuntHelper.addFeatureClassToMap(view, poiFC, false);
                }
                populateMinFields(gpExtension.poiMinLayer, pois, clusters);
                view.Refresh();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void helpLbl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.geopunt.be/voor-experts/geopunt-plug-ins/functionaliteiten/catalogus");
        }
        #endregion

        #region "overrides"
        protected override void  OnClosed(EventArgs e)
        {
            gpExtension.poiDlg = null;

            clearGraphics();
            view.Refresh();
            base.OnClosed(e);
        }
        #endregion

        #region "private functions"
        private string theme2code(string theme)
        {
            if (theme == null || theme == "") return "";

            var themeCodes = (from n in themes
                                where n.value == theme
                                select n.term);
            if (themeCodes.Count() == 0) return "";

            return themeCodes.First<string>();
        }

        private string cat2code(string cat)
        {
            if (cat == null || cat == "") return "";

            var catCodes = (from n in categories
                              where n.value == cat
                              select n.term);
            if (catCodes.Count() == 0) return "";

            return  catCodes.First<string>();
        }

        private string poitype2code(string poiType)
        {
            if (poiType == null || poiType == "") return "";

            var typeCodes = (from n in poiTypes
                              where n.value == poiType
                              select n.term);
            if (typeCodes.Count() == 0) return "";

            return typeCodes.First<string>();
        }

        private string municipality2nis(string muniName ) 
        {
            if (muniName == null || muniName == "") return "";

            var niscodes = (
                from n in municipalities.municipalities
                where n.municipalityName == muniName
                select n.municipalityCode);

            if (niscodes.Count() == 0) return "";

            return niscodes.First<string>();
        }

        private void populateFilters()
        {
            List<string> themeList = (from n in themes select n.value).ToList<string>();
            themeList.Insert(0, "");
            List<string> categoriesList = (from n in categories select n.value).ToList<string>();
            categoriesList.Insert(0, "");
            List<string> poiTypeList = (from n in poiTypes select n.value).ToList<string>();
            poiTypeList.Insert(0, "");

            themeCbx.Items.Clear();
            themeCbx.Items.AddRange(themeList.ToArray());
            categoryCbx.Items.Clear();
            categoryCbx.Items.AddRange(categoriesList.ToArray());
            typeCbx.Items.Clear();
            typeCbx.Items.AddRange(poiTypeList.ToArray());
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

        /// <summary>Create the the fields for the poi MaxModel Features</summary>
        private List<IField> poiIMaxFields()
        {
            List<IField> fields = new List<IField>();

            IField poiID = geopuntHelper.createField("poiID", esriFieldType.esriFieldTypeInteger);
            fields.Add(poiID);
            IField auteur = geopuntHelper.createField("auteur", esriFieldType.esriFieldTypeString, 100);
            fields.Add(auteur);
            IField naam = geopuntHelper.createField("naam", esriFieldType.esriFieldTypeString, 100);
            fields.Add(naam);

            IField poithema = geopuntHelper.createField("thema", esriFieldType.esriFieldTypeString, 80);
            fields.Add(poithema);
            IField poiCategory = geopuntHelper.createField("categorie", esriFieldType.esriFieldTypeString, 80);
            fields.Add(poiCategory);
            IField poitype = geopuntHelper.createField("poitype", esriFieldType.esriFieldTypeString, 80);
            fields.Add(poitype);
            //IField info = geopuntHelper.createField("info", esriFieldType.esriFieldTypeString, 254);
            //fields.Add(info);
            IField detail = geopuntHelper.createField("link", esriFieldType.esriFieldTypeString, 254);
            fields.Add(detail);
            //datumes
            IField creatie = geopuntHelper.createField("creatie", esriFieldType.esriFieldTypeDate);
            fields.Add(creatie);
            IField update = geopuntHelper.createField("wijziging", esriFieldType.esriFieldTypeDate);
            fields.Add(update);

            //adres
            IField straat = geopuntHelper.createField("straat", esriFieldType.esriFieldTypeString, 254);
            fields.Add(straat);
            IField huisnr = geopuntHelper.createField("huisnr", esriFieldType.esriFieldTypeString, 80);
            fields.Add(huisnr);
            IField busnr = geopuntHelper.createField("busnr", esriFieldType.esriFieldTypeString, 80);
            fields.Add(busnr);
            IField postcode = geopuntHelper.createField("postcode", esriFieldType.esriFieldTypeString, 16);
            fields.Add(postcode);
            IField gemeente = geopuntHelper.createField("gemeente", esriFieldType.esriFieldTypeString, 254);
            fields.Add(gemeente);
            return fields;
        }

        /// <summary>Create the the fields for the poi MinModel Features</summary>
        private List<IField> poiIMinFields()
        {
            List<IField> fields = new List<IField>();

            IField poiID = geopuntHelper.createField("poiID", esriFieldType.esriFieldTypeInteger);
            fields.Add(poiID);

            IField naam = geopuntHelper.createField("naam", esriFieldType.esriFieldTypeString, 100);
            fields.Add(naam);
            IField poitype = geopuntHelper.createField("poitype", esriFieldType.esriFieldTypeString, 80);
            fields.Add(poitype);
            IField link = geopuntHelper.createField("link", esriFieldType.esriFieldTypeString, 254);
            fields.Add(link);

            //adres
            IField straat = geopuntHelper.createField("straat", esriFieldType.esriFieldTypeString, 254);
            fields.Add(straat);
            IField huisnr = geopuntHelper.createField("huisnr", esriFieldType.esriFieldTypeString, 80);
            fields.Add(huisnr);
            IField busnr = geopuntHelper.createField("busnr", esriFieldType.esriFieldTypeString, 80);
            fields.Add(busnr);
            IField postcode = geopuntHelper.createField("postcode", esriFieldType.esriFieldTypeString, 16);
            fields.Add(postcode);
            IField gemeente = geopuntHelper.createField("gemeente", esriFieldType.esriFieldTypeString, 254);
            fields.Add(gemeente);

            //count of cluster
            IField aantal = geopuntHelper.createField("aantal", esriFieldType.esriFieldTypeInteger);
            fields.Add(aantal);
            return fields;
        }

        private void populateMaxFields(IFeatureClass poiFC, List<datacontract.poiMaxModel> pois)
        {
            using (ComReleaser comReleaser = new ComReleaser())
            {
                //Spatialreference 
                ISpatialReference srs = view.FocusMap.SpatialReference;
                // Create a feature buffer.
                IFeatureBuffer featureBuffer = poiFC.CreateFeatureBuffer();
                comReleaser.ManageLifetime(featureBuffer);

                // Create an insert cursor.
                IFeatureCursor insertCursor = poiFC.Insert(true);
                comReleaser.ManageLifetime(insertCursor);

                foreach (datacontract.poiMaxModel row in pois)
                {
                    if (row.location.points == null || row.location.points.Count == 0) 
                        throw new Exception( "Niet alle punten hebben een coördinaat" );

                    Double x = row.location.points[0].Point.coordinates[0];
                    Double y = row.location.points[0].Point.coordinates[1];
                    IPoint pt = new PointClass() { X = x, Y = y, SpatialReference = wgs };
                    IPoint toPt = geopuntHelper.Transform(pt, srs) as IPoint;

                    featureBuffer.Shape = toPt;

                    int id = row.id;
                    int idIdx = poiFC.FindField("poiID");
                    featureBuffer.set_Value(idIdx, id);

                    if ( row.authors != null  )
                    {
                        List<string> authorQry = (from n in row.authors
                                                  select n.value).ToList<string>();
                        if (authorQry.Count > 0)
                        {
                            string owner = authorQry[0];
                            if (owner.Length > 100)
                                owner = owner.Substring(0, 80);
                            int ownerIdx = poiFC.FindField("auteur");
                            featureBuffer.set_Value(ownerIdx, owner);
                        }
                    }
                    if ( row.labels != null )
                    {
                        List<string> labelQry = (from n in row.labels
                                                 select n.value).ToList<string>();
                        if (labelQry.Count > 0)
                        {
                            string label = labelQry[0];
                            if (label.Length > 100)
                                label = label.Substring(0, 100);
                            int labelIdx = poiFC.FindField("naam");
                            featureBuffer.set_Value(labelIdx, label);
                        }
                    }
                    if (row.categories != null)
                    {
                        List<string> poithemeQry = (from n in row.categories
                                                    where n.type == "Thema"
                                                   select n.value).ToList<string>();
                        List<string> poiCatQry = (from n in row.categories
                                                  where n.type == "Categorie"
                                                   select n.value).ToList<string>();
                        List<string> poitypeQry = (from n in row.categories
                                                   where n.type == "Type"
                                                   select n.value).ToList<string>();

                        if (poithemeQry.Count > 0)
                        {
                            string poitype = poithemeQry[0];
                            if (poitype.Length > 80)
                                poitype = poitype.Substring(0, 80);
                            int poitypeIdx = poiFC.FindField("thema");
                            featureBuffer.set_Value(poitypeIdx, poitype);
                        }
                        if (poiCatQry.Count > 0)
                        {
                            string poitype = poiCatQry[0];
                            if (poitype.Length > 80)
                                poitype = poitype.Substring(0, 80);
                            int poitypeIdx = poiFC.FindField("categorie");
                            featureBuffer.set_Value(poitypeIdx, poitype);
                        }
                        if (poitypeQry.Count > 0)
                        {
                            string poitype = poitypeQry[0];
                            if (poitype.Length > 80)
                                poitype = poitype.Substring(0, 80);
                            int poitypeIdx = poiFC.FindField("poitype");
                            featureBuffer.set_Value(poitypeIdx, poitype);
                        }
                    }
                    if (row.links != null)
                    {
                        List<string> linkQry = (from n in row.links
                                                select n.href).ToList<string>();
                        if (linkQry.Count > 0)
                        {
                            string link = linkQry[0];
                            if (link.Length > 254)
                                link = link.Substring(0, 254);
                            int linkIdx = poiFC.FindField("link");
                            featureBuffer.set_Value(linkIdx, link);
                        }
                    }
                    DateTime startDate = row.created;
                    int startDateIdx = poiFC.FindField("creatie");
                    featureBuffer.set_Value(startDateIdx, startDate);

                    DateTime updateDate = row.updated;
                    int updateDateIdx = poiFC.FindField("wijziging");
                    featureBuffer.set_Value(updateDateIdx, updateDate);

                    //adres
                    if (row.location.address != null)
                    {
                        string straat = row.location.address.street;
                        string huisnr = row.location.address.streetnumber;
                        string busnr = row.location.address.boxnumber;
                        string postcode = row.location.address.postalcode;
                        string gemeente = row.location.address.municipality;
                        int straatIdx = poiFC.FindField("straat");
                        featureBuffer.set_Value(straatIdx, straat);
                        int huisnrIdx = poiFC.FindField("huisnr");
                        featureBuffer.set_Value(huisnrIdx, huisnr);
                        int busnrIdx = poiFC.FindField("busnr");
                        featureBuffer.set_Value(busnrIdx, busnr);
                        int postcodeIdx = poiFC.FindField("postcode");
                        featureBuffer.set_Value(postcodeIdx, postcode);
                        int gemeenteIdx = poiFC.FindField("gemeente");
                        featureBuffer.set_Value(gemeenteIdx, gemeente);
                    }

                    insertCursor.InsertFeature(featureBuffer);
                }
                insertCursor.Flush();
            }
        }

        private void populateMinFields(IFeatureClass poiFC, List<datacontract.poiMinModel> pois , List<datacontract.cluster> clusters)
        {
            using (ComReleaser comReleaser = new ComReleaser())
            {
                //Spatialreference 
                ISpatialReference srs = view.FocusMap.SpatialReference;
                // Create a feature buffer.
                IFeatureBuffer featureBuffer = poiFC.CreateFeatureBuffer();
                comReleaser.ManageLifetime(featureBuffer);

                // Create an insert cursor.
                IFeatureCursor insertCursor = poiFC.Insert(true);
                comReleaser.ManageLifetime(insertCursor);

                foreach (datacontract.poiMinModel row in pois)
                {
                    if (row.location.points == null || row.location.points.Count == 0)
                        throw new Exception("Niet alle punten hebben een coördinaat");

                    Double x = row.location.points[0].Point.coordinates[0];
                    Double y = row.location.points[0].Point.coordinates[1];
                    IPoint pt = new PointClass() { X = x, Y = y, SpatialReference = wgs };
                    IPoint toPt = geopuntHelper.Transform(pt, srs) as IPoint;

                    featureBuffer.Shape = toPt;

                    int id = row.id;
                    int idIdx = poiFC.FindField("poiID");
                    featureBuffer.set_Value(idIdx, id);

                    if (row.labels != null)
                    {
                        List<string> labelQry = (from n in row.labels
                                                 select n.value).ToList<string>();
                        if (labelQry.Count > 0)
                        {
                            string label = labelQry[0];
                            if (label.Length > 100)
                                label = label.Substring(0, 100);
                            int labelIdx = poiFC.FindField("naam");
                            featureBuffer.set_Value(labelIdx, label);
                        }
                    }
                    if (row.categories != null)
                    {
                        List<string> poitypeQry = (from n in row.categories
                                                   where n.type == "Type"
                                                   select n.value).ToList<string>();
                        if (poitypeQry.Count > 0)
                        {
                            string poitype = poitypeQry[0];
                            if (poitype.Length > 80)
                                poitype = poitype.Substring(0, 80);
                            int poitypeIdx = poiFC.FindField("poitype");
                            featureBuffer.set_Value(poitypeIdx, poitype);
                        }
                    }
                    if (row.links != null)
                    {
                        List<string> linkQry = (from n in row.links
                                                select n.href).ToList<string>();
                        if (linkQry.Count > 0)
                        {
                            string link = linkQry[0];
                            if (link.Length > 254)
                                link = link.Substring(0, 254);
                            int linkIdx = poiFC.FindField("link");
                            featureBuffer.set_Value(linkIdx, link);
                        }
                    }

                    //adres
                    if (row.location.address != null)
                    {
                        string straat = row.location.address.street;
                        string huisnr = row.location.address.streetnumber;
                        string busnr = row.location.address.boxnumber;
                        string postcode = row.location.address.postalcode;
                        string gemeente = row.location.address.municipality;
                        int straatIdx = poiFC.FindField("straat");
                        featureBuffer.set_Value(straatIdx, straat);
                        int huisnrIdx = poiFC.FindField("huisnr");
                        featureBuffer.set_Value(huisnrIdx, huisnr);
                        int busnrIdx = poiFC.FindField("busnr");
                        featureBuffer.set_Value(busnrIdx, busnr);
                        int postcodeIdx = poiFC.FindField("postcode");
                        featureBuffer.set_Value(postcodeIdx, postcode);
                        int gemeenteIdx = poiFC.FindField("gemeente");
                        featureBuffer.set_Value(gemeenteIdx, gemeente);
                    }

                    int cIdx = poiFC.FindField("aantal");
                    featureBuffer.set_Value(cIdx, 1);

                    insertCursor.InsertFeature(featureBuffer);
                }

                foreach (datacontract.cluster row in clusters)
                {
                    Double x = row.point.Point.coordinates[0];
                    Double y = row.point.Point.coordinates[1];
                    IPoint pt = new PointClass() { X = x, Y = y, SpatialReference = wgs };
                    IPoint toPt = geopuntHelper.Transform(pt, srs) as IPoint;

                    featureBuffer.Shape = toPt;

                    int c = row.count;
                    int cIdx = poiFC.FindField("aantal");
                    featureBuffer.set_Value(cIdx, c);
                    int poitypeIdx = poiFC.FindField("poitype");
                    featureBuffer.set_Value(poitypeIdx, "Cluster");

                    //set others to null
                    int idIdx = poiFC.FindField("poiID");
                    featureBuffer.set_Value(idIdx, null);
                    int labelIdx = poiFC.FindField("naam");
                    featureBuffer.set_Value(labelIdx, null);
                    int linkIdx = poiFC.FindField("link");
                    featureBuffer.set_Value(linkIdx, null);
                    //adres
                    int straatIdx = poiFC.FindField("straat");
                    featureBuffer.set_Value(straatIdx, null);
                    int huisnrIdx = poiFC.FindField("huisnr");
                    featureBuffer.set_Value(huisnrIdx, null);
                    int busnrIdx = poiFC.FindField("busnr");
                    featureBuffer.set_Value(busnrIdx, null);
                    int postcodeIdx = poiFC.FindField("postcode");
                    featureBuffer.set_Value(postcodeIdx, null);
                    int gemeenteIdx = poiFC.FindField("gemeente");
                    featureBuffer.set_Value(gemeenteIdx, null);

                    insertCursor.InsertFeature(featureBuffer);
                }

                insertCursor.Flush();
            }
        }
        #endregion

    }
}
