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

        /*filters lists*/
        List<string> gdiThemes;
        List<string> orgNames;
        Dictionary<string, string> dataBronnen;
        Dictionary<string, string> dataTypes;
        List<string> inspKeyw;

        AutoCompleteStringCollection keyWords;

        dataHandler.catalog clg;
        datacontract.metadataResponse metaList = null;

        public catalogForm()
        {
            view = ArcMap.Document.ActiveView;
            map = view.FocusMap;

            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            wgs = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();

            InitializeComponent();
            initGui();
        }

        public void initGui()
        {
            clg = new dataHandler.catalog(timeout: gpExtension.timeout);
            keyWords = new AutoCompleteStringCollection();
            keyWords.AddRange(  clg.getKeyWords().ToArray() );
            keywordTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            keywordTxt.AutoCompleteCustomSource = keyWords;
            gdiThemes = clg.getGDIthemes();
            gdiThemes.Insert(0, "");
            GDIthemeCbx.DataSource = gdiThemes;

            orgNames = clg.getOrganisations();
            orgNames.Insert(0, "");
            orgNameCbx.DataSource = orgNames;

            dataBronnen = clg.getSources();
            List<string> bronnen = dataBronnen.Select(c => c.Key).ToList();
            bronnen.Insert(0, "");
            bronCatCbx.DataSource = bronnen;

            dataTypes = clg.dataTypes;
            List<string> dtypes = dataTypes.Select(c => c.Key).ToList();
            dtypes.Insert(0, "");
            typeCbx.DataSource = dtypes;

            inspKeyw = clg.inspireKeywords();
            inspKeyw.Insert(0, "");
            INSPIREthemeCbx.DataSource = inspKeyw;

            INSPIREannexCbx.DataSource = clg.inpireAnnex;

            INSPIREserviceCbx.DataSource = clg.inspireServiceTypes;

            filterResultsCbx.SelectedIndex = 0;
        }

        #region "eventHandlers"

        private void zoekBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string zoekString = keywordTxt.Text;
                string themekey = GDIthemeCbx.Text; 
                string orgName = orgNameCbx.Text;
                string dataType = "";
                if( dataTypes.Select(c => c.Key).Contains(typeCbx.Text)) dataType = dataTypes[typeCbx.Text] ;
                string siteId = "";
                if( dataBronnen.Select(c => c.Key).Contains(bronCatCbx.Text)) siteId = dataBronnen[bronCatCbx.Text];
                string inspiretheme = INSPIREthemeCbx.Text; 
                string inspireannex = INSPIREannexCbx.Text; 
                string inspireServiceType = INSPIREserviceCbx.Text;

                metaList = clg.searchAll(zoekString, themekey, orgName, dataType, siteId, inspiretheme, inspireannex, inspireServiceType);
                
                statusMsgLbl.Text = "";
                descriptionHTML.DocumentText = "";

                if( metaList.to != 0 ) {
                    updateFilter();
                    statusMsgLbl.Text = String.Format("Aantal records gevonden: {0}", metaList.maxCount );
                }
                else
                {
                    MessageBox.Show( "Er werd niets gevonden dat voldoet aan deze criteria", "Geen resultaat" );
                }
                addWMSbtn.Enabled = false;
                OpenDownloadBtn.Enabled = false;
            }
            catch ( Exception ex )
            {
                MessageBox.Show( ex.Message +" : "+ ex.StackTrace, "Error" );
            }
        }

        private void helpLbl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                "http://www.geopunt.be/nl/voor-experts/geopunt-plug-ins/functionaliteiten/catalogus");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchResultsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metaList == null) return;

            addWMSbtn.Enabled = false;
            OpenDownloadBtn.Enabled = false;

            string selVal = searchResultsList.Text;
            List<datacontract.metadata> metaObjs = (from n in metaList.metadataRecords
                                                    where n.title == selVal
                                                    select n).ToList();
            if (metaObjs.Count > 0)
            {
                datacontract.metadata metaObj = metaObjs[0];
                string infoMsg = string.Format("<strong><small>{0}</small></strong><br/><div><small>{1}</small></div>", metaObj.title, metaObj.description);
                infoMsg += string.Format(
                    "<br/><a target='_blank' href='https://metadata.geopunt.be/zoekdienst/apps/tabsearch/index.html?uuid={0}'><small>Ga naar fiche</small></a>", 
                                            metaObj.sourceID);

                descriptionHTML.DocumentText = infoMsg;

                if (metaList.geturl(selVal, "DOWNLOAD")) OpenDownloadBtn.Enabled = true;
                if (metaList.geturl(selVal, "OGC:WMS")) addWMSbtn.Enabled = true;
            }
        }

        private void OpenDownloadBtn_Click(object sender, EventArgs e)
        {
            string selVal = searchResultsList.Text;
            string dlName; string dlUrl;

            bool hasDl = metaList.geturl(selVal, "DOWNLOAD", out dlUrl, out dlName);
            if (hasDl) System.Diagnostics.Process.Start(dlUrl);
        }

        private void addWMSbtn_Click(object sender, EventArgs e)
        {
            string selVal = searchResultsList.Text;
            string lyrName; string wmsUrl;

            bool hasWms = metaList.geturl(selVal, "OGC:WMS", out wmsUrl, out lyrName);
            if (hasWms)
            {
                wmsUrl = wmsUrl.Split('?')[0] + "?";

                if (geopuntHelper.websiteExists(wmsUrl, true) == false)
                {
                    MessageBox.Show( "Kan geen connectie maken met de Service.", "Connection timed out");
                    return;
                }

                ILayer lyr = geopuntHelper.getWMSLayerByName(wmsUrl, lyrName);
                if (lyr != null)
                {
                    ArcMap.Document.FocusMap.AddLayer(lyr);
                }
                else
                {
                    geopuntHelper.addWMS2map(ArcMap.Document.FocusMap, wmsUrl);
                }
            }
        }

        private void filterResultsCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFilter();
        }

        #endregion

        private void updateFilter()
        {
            string filterTxt = filterResultsCbx.Text;
            switch (filterTxt)
            {
                case "Alles weergeven":
                    searchResultsList.Items.Clear();
                    searchResultsList.Items.AddRange(geenFilter());
                    break;
                case "WMS":
                    searchResultsList.Items.Clear();
                    searchResultsList.Items.AddRange(filterWMS());
                    break;
                case "Download":
                    searchResultsList.Items.Clear();
                    searchResultsList.Items.AddRange(filterDL());
                    break;
                default:
                    break;
            }
        }
        private string[] filterDL()
        {
            if (metaList == null) return new string[0];
            return (from g in metaList.metadataRecords
                    where metaList.geturl(g.title, "DOWNLOAD")
                    select g.title).ToArray();
        }
        private string[] filterWMS()
        {
            if (metaList == null) return new string[0];
            return (from g in metaList.metadataRecords
                    where metaList.geturl(g.title, "OGC:WMS")
                    select g.title).ToArray();
        }
        private string[] geenFilter()
        {
            if (metaList == null) return new string[0];
            return (from g in metaList.metadataRecords
                    select g.title).ToArray();
        }
    }
}
