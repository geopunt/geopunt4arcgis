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
        ISpatialReferenceFactory3 spatialReferenceFactory;
        IActiveView view;
        IMap map;
        ISpatialReference wgs;
        IFeatureClass adresFC;
        IElement graphic;
        geopunt4arcgisExtension gpExtension;

        dataHandler.adresSuggestion adresSuggestion;
        dataHandler.adresLocation adresLocation;

        List<string> suggestions;

        public zoekAdresForm()
        {
            //set global objects
            view = ArcMap.Document.ActiveView;
            map = view.FocusMap;

            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            wgs = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
            adresFC = gpExtension.adresLayer;

            //dataHandlers
            adresSuggestion = new dataHandler.adresSuggestion(sugCallback, timeout: gpExtension.timeout);
            adresLocation = new dataHandler.adresLocation(timeout: gpExtension.timeout);

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

        private void helpLbl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.geopunt.be/voor-experts/geopunt-plug-ins/functionaliteiten/zoek-een-adres");
        }

        private void LARALink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://crab.agiv.be/Lara/");
        }
     #endregion

     #region "overrides"
        protected override void OnClosed(EventArgs e)
        {
            if (adresSuggestion.client.IsBusy)
            {
                adresSuggestion.client.CancelAsync();
            }
            if (graphic != null)
            {
                IGraphicsContainer grpCont = (IGraphicsContainer)map;
                grpCont.DeleteElement(graphic);
                view.Refresh();
            }

            gpExtension.zoekAdresDlg = null;
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
                IPoint leftXY = new ESRI.ArcGIS.Geometry.Point()
                {
                    X = loc[0].BoundingBox.LowerLeft.Lon_WGS84,
                    Y = loc[0].BoundingBox.LowerLeft.Lat_WGS84,
                    SpatialReference = wgs
                };
                IPoint toleftXY = geopuntHelper.Transform(leftXY as IGeometry, map.SpatialReference) as IPoint;
                IPoint rightXY = new ESRI.ArcGIS.Geometry.Point()
                {
                    X = loc[0].BoundingBox.UpperRight.Lon_WGS84,
                    Y = loc[0].BoundingBox.UpperRight.Lat_WGS84,
                    SpatialReference = wgs
                };
                IPoint torightXY = geopuntHelper.Transform(rightXY as IGeometry, map.SpatialReference) as IPoint;
                IEnvelope bbox = geopuntHelper.makeExtend(toleftXY.X, toleftXY.Y, torightXY.X, torightXY.Y, 
                                                                                map.SpatialReference);

                IPoint XY = new ESRI.ArcGIS.Geometry.Point()
                {
                    X = loc[0].Location.Lon_WGS84,
                    Y = loc[0].Location.Lat_WGS84,
                    SpatialReference = wgs
                };
                IPoint toXY = geopuntHelper.Transform(XY as IGeometry, map.SpatialReference) as IPoint;

                //create a graphic
                IRgbColor rgb = new RgbColorClass() { Red = 255, Blue = 255, Green = 0 };
                if (graphic != null)
                {
                    IGraphicsContainer grpCont = (IGraphicsContainer)map;
                    grpCont.DeleteElement(graphic);
                    graphic = null;
                }
                graphic = geopuntHelper.AddGraphicToMap(map, toXY, rgb, 
                                new RgbColorClass() { Red = 0, Blue = 0, Green = 0 }, 8, true);

                map.MapScale = 1000;
                view.Extent = bbox;
                geopuntHelper.ZoomByRatioAndRecenter(view, 1, toXY.X, toXY.Y);

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
                toXY = geopuntHelper.Transform(fromXY as IGeometry, map.SpatialReference) as IPoint;

                innerClr = new RgbColor() { Red = 255, Blue = 0, Green = 255 };
                outlineClr = new RgbColor() { Red = 0, Blue = 0, Green = 0 };
                geopuntHelper.AddGraphicToMap(map, toXY, innerClr, outlineClr, 12, false);
                geopuntHelper.AddTextElement(map , toXY, loc.FormattedAddress);
                view.Refresh();
                return true;
            }
            return false;
        }

        private void createAdresFeatureClass(string fcPath, ISpatialReference srs)
        {
            List<IField> attr = new List<IField>();
            attr.Add(geopuntHelper.createField("adres", esriFieldType.esriFieldTypeString, 254));
            attr.Add(geopuntHelper.createField("adresType", esriFieldType.esriFieldTypeString, 80));

            FileInfo fcInfo = new FileInfo(fcPath);

            if (fcInfo.Extension == ".shp")
            {
                adresFC = geopuntHelper.createShapeFile(fcInfo.FullName, attr, map.SpatialReference, 
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
            if (adresFC == null) return;

            IPoint pt = new PointClass() { X=x , Y=y, SpatialReference= srs };

            IFeature feature = adresFC.CreateFeature();
            feature.Shape = (IGeometry) pt;

            if (adres.Length > 254) adres = adres.Substring(0, 254);

            int adresIdx = adresFC.FindField("adres");
            feature.set_Value(adresIdx, adres);
            int adresTypeIdx = adresFC.FindField("adresType");
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
            if (loc == null) return; 
            //if no adres feature class yet, create it.
            if (adresFC == null)
            {
                this.Visible = false;
                string fcPath = geopuntHelper.ShowSaveDataDialog("Save as ..");
                this.Visible = true;
                if (fcPath == null) return;
                createAdresFeatureClass(fcPath, map.SpatialReference);
            }
            //reproject the point
            fromXY = new PointClass() {X= loc.Location.Lon_WGS84, Y= loc.Location.Lat_WGS84, SpatialReference = wgs };
            toXY = geopuntHelper.Transform(fromXY as IGeometry, map.SpatialReference) as IPoint;
            //add the adres to to the adres feature class
            addAdres2FC(toXY.X , toXY.Y, map.SpatialReference, loc.FormattedAddress, loc.LocationType);
            infoLabel.Text = loc.FormattedAddress + " opgeslagen naar " + adresFC.AliasName;
            view.Refresh();
        }

    #endregion

    }
}
