using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        BindingList<poiDataRow> rows;
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
            rows = new BindingList<poiDataRow>();
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
            string nis = municipality2nis(gemeenteCbx.Text);
            string themeCode = theme2code(themeCbx.Text);
            string catCode = cat2code(categoryCbx.Text);
            string poiTypeCode = poitype2code(typeCbx.Text);
            string keyWord = keywordTxt.Text;
            boundingBox extent;
            if (extentCkb.Checked) {
                IEnvelope env = view.Extent;
                IEnvelope prjEnv = geopuntHelper.Transform2WGS((IGeometry)env).Envelope; 
                extent = new boundingBox(prjEnv); 
            }
            else extent = null;

            try
            {
                //get the data
                poiData = poiDH.getMaxmodel(
                    q: keyWord, theme: themeCode, category: catCode, POItype: poiTypeCode, niscode: nis,
                    bbox: extent, srs: dataHandler.CRS.WGS84);

                List<datacontract.poiMaxModel> pois = poiData.pois;

                rows.Clear();

                //parse results
                foreach (datacontract.poiMaxModel poi in pois)
                {
                    poiDataRow row = new poiDataRow();
                    List<string> qry;
                    datacontract.poiAddress adres;

                    row.id = poi.id;

                    qry = (
                        from datacontract.poiValueGroup n in poi.categories
                        where n.type == "Type"
                        select n.value).ToList();
                    if (qry.Count > 0) row.Type = qry[0];
                    qry = (
                     from datacontract.poiValueGroup n in poi.labels select n.value).ToList();
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
            if (cat == "" || theme == "")
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
                view.Refresh();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }



        }
        #endregion

        #region "overrides"
        protected override void  OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            clearGraphics();
            view.Refresh();
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
                graphicsContainer.DeleteElement(grp);
            }
            graphics.Clear();
        }
        
        #endregion

    }
}
