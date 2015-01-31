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
        datacontract.metadataResponse metaList = null;

        AutoCompleteStringCollection keyWords ;

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
            List<string> gdiThemes = clg.getGDIthemes();
            gdiThemes.Insert(0, "");
            GDIthemeCbx.DataSource = gdiThemes;

            List<string> orgNames = clg.getOrganisations();
            orgNames.Insert(0, "");
            orgNameCbx.DataSource = orgNames;

            List<string> bronnen = clg.getSources().Select(c => c.Value).ToList();
            bronnen.Insert(0, "");
            bronCatCbx.DataSource = bronnen;

            List<string> stypes = clg.dataTypes.Select(c => c.Key).ToList() ;
            stypes.Insert(0, "");
            typeCbx.DataSource = stypes;

            List<string> inspKeyw = clg.inspireKeywords();
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
                metaList = clg.search(zoekString);
                string[] sresult = metaList.metadataRecords.Select(c => c.title).ToArray();

                searchResultsList.Items.Clear();
                searchResultsList.Items.AddRange(sresult);
            }
            catch ( Exception ex )
            {
                MessageBox.Show( ex.Message +" : "+ ex.StackTrace );
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
        #endregion

        private void searchResultsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(metaList == null) return;

            string selVal = searchResultsList.Text;

            List<datacontract.metadata> metaObjs = ( from n in metaList.metadataRecords
                                                     where n.title == selVal
                                                     select n).ToList();
            if (metaObjs.Count > 0)
            {
                datacontract.metadata metaObj = metaObjs[0];

                string infoMsg = string.Format("<h3>{0}</h3><div>{1}</div>", metaObj.title, metaObj.description);
                infoMsg += string.Format(
                   "<a target='_blank' href='https://metadata.geopunt.be/zoekdienst/apps/tabsearch/index.html?uuid={0}'>Ga naar fiche</a>", metaObj.sourceID);

                descriptionHTML.DocumentText = infoMsg;
            }
        }
    }
}
