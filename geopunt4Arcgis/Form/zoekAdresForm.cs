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
using System.Net;
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
    public partial class zoekAdresForm : Form
    {
        ISpatialReferenceFactory2 spatialReferenceFactory;
        IActiveView view;
        ISpatialReference wgs;
        IFeatureClass adresFC;

        geopunt4arcgisExtension gpExtension;

        dataHandler.adresSuggestion adresSuggestion;
        dataHandler.adresLocation adresLocation;

        List<string> suggestions;

        public zoekAdresForm( IActiveView activeView )
        {

            //set global objects
            view = ArcMap.Document.ActiveView;

            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory2;

            //spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            wgs = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
            adresFC = gpExtension.adresLayer;

            //dataHandlers
            adresSuggestion = new dataHandler.adresSuggestion(sugCallback);
            adresLocation = new dataHandler.adresLocation();

            //init UI
            InitializeComponent();
        }

     #region "Event handlers"
        private void zoomBtn_Click(object sender, EventArgs e)
        {
            if (suggestionList.Items.Count == 0) { return; }
            string searchString;

            if (suggestionList.SelectedIndex == -1)
            {
                searchString = zoekText.Text + ", " + gemeenteBox.Text;
            }
            else 
            {
                searchString = suggestionList.SelectedItem.ToString();
            }
            zoomToQuery(searchString, 1, 0.5);
        }

        private void suggestionList_itemDoubleClicked(object sender, EventArgs e)
        {
            if (suggestionList.SelectedIndex != -1)
            {
                string adresSelected = suggestionList.SelectedItem.ToString();
                zoekText.Text = adresSelected.Split(',')[0];
            }
        }

        private void gemeenteBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSuggestions();
        }

        private void zoekText_onZoekTextChange(object sender, EventArgs e)
        {
            updateSuggestions();
        }

        private void makeMarkerBtn_Click(object sender, EventArgs e)
        {
            if (suggestionList.Items.Count == 0) { return; }
            string searchString;

            if (suggestionList.SelectedIndex == -1)
            {
                searchString = zoekText.Text + ", " + gemeenteBox.Text;
            }
            else
            {
                searchString = suggestionList.SelectedItem.ToString();
            }

            addMarkerAtAdres(searchString);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (suggestionList.Items.Count == 0) { return; }
            saveAdres();
        }

     #endregion

     #region "overrides"
        protected override void OnClosed(EventArgs e)
        {
            if (adresSuggestion.client.IsBusy)
            {
                adresSuggestion.client.CancelAsync();
            }
            base.OnClosed(e);
        }
     #endregion

     #region "callbacks"
        private void sugCallback(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                datacontract.crabSuggestion sug = JsonConvert.DeserializeObject<datacontract.crabSuggestion>(e.Result);
                suggestions = sug.SuggestionResult;
                suggestionList.DataSource = suggestions;
            }
            else
            {
                if (e.Error != null) 
                {
                    MessageBox.Show(e.Error.Message);
                }
            }
        }

     #endregion

     #region "private functions"

        private void updateSuggestions()
        {
            if (adresSuggestion.client.IsBusy) { return; }

            string searchString = zoekText.Text +", "+ gemeenteBox.Text;
            adresSuggestion.getAdresSuggestionAsync(searchString, 25);
        }

        private bool zoomToQuery(string query, int count, Double zoom)
        {
            List<datacontract.locationResult> loc =  adresLocation.getAdresLocation(query, count);

            if (loc.Count > 0)
            {
                IPoint XY = new ESRI.ArcGIS.Geometry.Point()
                {
                    X = loc[0].Location.Lon_WGS84,
                    Y = loc[0].Location.Lat_WGS84,
                    SpatialReference = wgs
                };
                IPoint toXY = geopuntHelper.Transform(XY as IGeometry, view.FocusMap.SpatialReference) as IPoint;
                geopuntHelper.FlashGeometry(toXY, new RgbColorClass() { Red = 255, Blue = 0, Green = 0 }, view.ScreenDisplay, 800);
                geopuntHelper.ZoomByRatioAndRecenter(view, zoom, toXY.X, toXY.Y);
                view.Refresh();
                return true;
            }
            else return false;
        }

        private datacontract.locationResult getAdres(string adres) 
        {
            List<datacontract.locationResult> locs = adresLocation.getAdresLocation(adres, 1);
            if (locs.Count > 0)
            {
                return locs[0];
            }
            else
            {
                return null;
            }
        }

        private bool addMarkerAtAdres(string Adres)
        {
            datacontract.locationResult loc = getAdres(Adres);
            IPoint fromXY; IPoint toXY;
            IRgbColor innerClr; IRgbColor outlineClr;

            if (loc != null )
            {
                fromXY = new ESRI.ArcGIS.Geometry.Point()
                {
                    X = loc.Location.Lon_WGS84,
                    Y = loc.Location.Lat_WGS84,
                    SpatialReference = wgs
                };
                toXY = geopuntHelper.Transform(fromXY as IGeometry, view.FocusMap.SpatialReference) as IPoint;

                innerClr = new RgbColor() { Red = 255, Blue = 0, Green = 255 };
                outlineClr = new RgbColor() { Red = 0, Blue = 0, Green = 0 };
                geopuntHelper.AddGraphicToMap(view.FocusMap, toXY, innerClr, outlineClr, 12);
                geopuntHelper.AddTextElement(view.FocusMap, toXY, loc.FormattedAddress);
                view.Refresh();
                return true;
            }
            return false;
        }

        private void createAdresFeatureClass(string fcPath, ISpatialReference srs)
        {
            List<IField> attr = new List<IField>();
            attr.Add(geopuntHelper.createField("adres", esriFieldType.esriFieldTypeString));
            attr.Add(geopuntHelper.createField("adresType", esriFieldType.esriFieldTypeString));

            FileInfo fcInfo = new FileInfo(fcPath);

            if (fcInfo.Extension == ".shp")
            {
                adresFC = geopuntHelper.createShapeFile(fcInfo.FullName, attr, view.FocusMap.SpatialReference, 
                                                esriGeometryType.esriGeometryPoint, true);
            }
            else if (fcInfo.DirectoryName.ToLowerInvariant().EndsWith(".gdb"))
            {
               adresFC = geopuntHelper.createFeatureClass(fcInfo.DirectoryName, fcInfo.Name, attr, srs, 
                                                                          esriGeometryType.esriGeometryPoint, true);
            }
            else
            {
                throw new Exception("Bestand is geen shapefile of FileGeodatabase Feature Class");
            }
            geopuntHelper.addFeatureClassToMap(view, adresFC);
            gpExtension.adresLayer = adresFC;
        }

        private void addAdres2FC( double x, double y, ISpatialReference srs , string adres, string adresType )
        {
            if (adresFC == null) { return; }

            IPoint pt = new PointClass() { X=x , Y=y, SpatialReference= srs };

            IFeature feature = adresFC.CreateFeature();
            feature.Shape = (IGeometry) pt;

            int adresIdx = adresFC.FindField("adres");
            int adresTypeIdx = adresFC.FindField("adresType");

            feature.set_Value(adresIdx, adres);
            feature.set_Value(adresTypeIdx, adresType);

            feature.Store();
        }

        private void saveAdres()
        {
            string searchString;
            IPoint fromXY; IPoint toXY;
            //get adres string
            if (suggestionList.SelectedIndex == -1)
            {
                searchString = zoekText.Text + ", " + gemeenteBox.Text;
            }
            else
            {
                searchString = suggestionList.SelectedItem.ToString();
            }
            //get the adres XY, return if no result
            datacontract.locationResult loc = getAdres(searchString);
            if (loc == null) { return; }
            //if no adres feature class yet, create it.
            if (adresFC == null)
            {
                IGxObjectFilter shpFilter = new GxFilterShapefilesClass();
                IGxObjectFilter gdbFilter = new GxFilterFGDBFeatureClassesClass();
                List<IGxObjectFilter> gxFilterList = new List<IGxObjectFilter>(new IGxObjectFilter[] { gdbFilter, shpFilter });

                this.Visible = false;
                string fcPath = geopuntHelper.ShowSaveDataDialog(gxFilterList, "Save as ..");
                this.Visible = true;
                if (fcPath == null) { return; }
                createAdresFeatureClass(fcPath, view.FocusMap.SpatialReference);
            }
            //reproject the point
            fromXY = new PointClass() {X= loc.Location.Lon_WGS84, Y= loc.Location.Lat_WGS84, SpatialReference = wgs };
            toXY = geopuntHelper.Transform(fromXY as IGeometry, view.FocusMap.SpatialReference) as IPoint;
            //add the adres to to the adres feature class
            addAdres2FC(toXY.X , toXY.Y, view.FocusMap.SpatialReference, loc.FormattedAddress, loc.LocationType);
            infoLabel.Text = loc.FormattedAddress + " opgeslagen naar " + adresFC.AliasName;
            view.Refresh();
        }

    #endregion

    }
}
