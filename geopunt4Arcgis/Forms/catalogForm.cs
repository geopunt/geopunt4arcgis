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
            clg = new dataHandler.catalog();
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
                
                searchResultsList.Items.Clear();
                statusMsgLbl.Text = "";
                descriptionHTML.DocumentText = "";

                if( metaList.to != 0 ) {
                    string[] sresult = metaList.metadataRecords.Select(c => c.title).ToArray();
                    searchResultsList.Items.AddRange(sresult);
                    statusMsgLbl.Text = String.Format("Aantal records gevonden: {0}", metaList.maxCount );
                }
                else
                {
                    MessageBox.Show( "Er werd niets gevonden dat voldoet aan deze criteria", "Geen resultaat" );
                }
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
            }
        }

        private void OpenDownloadBtn_Click(object sender, EventArgs e)
        {
            if (metaList == null) return;

            string selVal = searchResultsList.Text;
            List<datacontract.metadata> metaObjs = (from n in metaList.metadataRecords
                                                    where n.title == selVal
                                                    select n).ToList();
            try
            {
                if (metaObjs.Count > 0 && metaObjs[0].links.Count > 0)
                {
                    datacontract.metadata metaObj = metaObjs[0];
                    List<List<string>> linkList = metaObj.links.Select(c => c.Split('|').ToList()).ToList();
                    foreach (List<string> link in linkList)
                    {
                        for (int i = 1; i < link.Count; i++)
                        {
                            if (link[i].ToUpper().Contains("DOWNLOAD") && link[i-1].ToLower().Contains("http"))
                            {
                                System.Diagnostics.Process.Start(link[i - 1]);
                                return;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message +" : "+ ex.StackTrace, "Error" );
            }
        }

        #endregion

        private void addWMSbtn_Click(object sender, EventArgs e)
        {
            if (metaList == null) return;

            string selVal = searchResultsList.Text;
            List<datacontract.metadata> metaObjs = (from n in metaList.metadataRecords
                                                    where n.title == selVal
                                                    select n).ToList();
            try
            {
                if (metaObjs.Count > 0 && metaObjs[0].links.Count > 0)
                {
                    datacontract.metadata metaObj = metaObjs[0];
                    List<List<string>> linkList = metaObj.links.Select(c => c.Split('|').ToList()).ToList();
                    foreach (List<string> link in linkList)
                    {
                        for (int i = 1; i < link.Count; i++)
                        {
                            if (link[i].ToUpper().Contains("OGC:WMS") && link[i - 1].ToLower().Contains("http"))
                            {
                                System.Diagnostics.Process.Start(link[i-1]);
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace, "Error");
            }
        }
    }
}
