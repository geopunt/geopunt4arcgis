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
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using RestSharp;
using System.Diagnostics;


namespace geoPunt4Arcgis
{
    public partial class zoekAdresForm : Form
    {
        ISpatialReferenceFactory spatialReferenceFactory;
        IActiveView view;
        crabRest crab;
        ISpatialReference wgs;

        public zoekAdresForm( IActiveView activeView )
        {
            //settings
            RegistryKey geopuntKey = Registry.CurrentUser.OpenSubKey("Software\\geopunt");
            int geopuntTimeOut = (int)geopuntKey.GetValue("geopuntTimeOut", 5000);
            string geopuntProxyUrl = (string)geopuntKey.GetValue("geopuntProxyUrl", "");
            int geopuntProxyPort = (int)geopuntKey.GetValue("geopuntProxyPort", 8080);

            //set global objects
            crab = new crabRest(geopuntTimeOut, geopuntProxyUrl, geopuntProxyPort);
            view = ArcMap.Document.ActiveView;
            spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            wgs = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);
            
            //init UI
            InitializeComponent();
        }

      #region "Event handlers"
        private void zoekBtn_Click(object sender, EventArgs e)
        {
            if (suggestionList.SelectedIndex != -1)
            {
                string qry = suggestionList.SelectedItem.ToString();
                zoomToQuery(qry, 1, 0.5);
            }
        }

        private void suggestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string adresSelected;
            crabResponse locations;

            if (suggestionList.SelectedIndex != -1)
            {
                adresSelected = suggestionList.SelectedItem.ToString();
            }
            else return;

            try
            {
                locations = crab.geolocate(adresSelected, 1);

                if (locations.LocationResult.Count > 0)
                {
                    IPoint XY = new ESRI.ArcGIS.Geometry.Point()
                    {
                        X = locations.LocationResult[0].Location.Lon_WGS84,
                        Y = locations.LocationResult[0].Location.Lat_WGS84,
                        SpatialReference = wgs
                    };
                    IPoint toXY = geopuntHelper.Transform(XY as IGeometry, view.Extent.SpatialReference) as IPoint;
                    IRgbColor rgb = new RgbColor() { Red = 255, Blue = 0, Green = 0 };
                    geopuntHelper.FlashGeometry(toXY, rgb, view.ScreenDisplay, 800);
                }
            }
            catch (Exception ex)
            {
                infoLabel.Text =  ex.Message + ": " + ex.StackTrace;
                return;
            }

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
            string adresSelected;
            crabResponse locations;
            IPoint fromXY; IPoint toXY;
            IRgbColor innerClr; IRgbColor outlineClr;

            if (suggestionList.SelectedIndex != -1)
            {
                adresSelected = suggestionList.SelectedItem.ToString();
            }
            else return;

            try
            {
                locations = crab.geolocate(adresSelected, 1);

                if (locations.LocationResult.Count > 0)
                {
                    fromXY = new ESRI.ArcGIS.Geometry.Point()
                    {
                        X = locations.LocationResult[0].Location.Lon_WGS84,
                        Y = locations.LocationResult[0].Location.Lat_WGS84,
                        SpatialReference = wgs
                    };
                    toXY = geopuntHelper.Transform(fromXY as IGeometry, view.Extent.SpatialReference) as IPoint;

                    innerClr = new RgbColor() { Red = 255, Blue = 0, Green = 255 };
                    outlineClr = new RgbColor() { Red = 0, Blue = 0, Green = 0 };
                    geopuntHelper.AddGraphicToMap(view.FocusMap, toXY, innerClr, outlineClr, 12);
                    geopuntHelper.AddTextElement(view.FocusMap, toXY, locations.LocationResult[0].FormattedAddress);
                    view.Refresh();
                }
            }
            catch (Exception ex)
            {
                infoLabel.Text = ex.Message + ": " + ex.StackTrace;
                return;
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     #endregion

        private bool zoomToQuery(string query, int count, Double zoom)
        {
            crabResponse locations;

            try
            {
                locations = crab.geolocate(query, count);

                if (locations.LocationResult.Count > 0)
                {
                    IPoint XY = new ESRI.ArcGIS.Geometry.Point()
                    {
                        X = locations.LocationResult[0].Location.Lon_WGS84,
                        Y = locations.LocationResult[0].Location.Lat_WGS84,
                        SpatialReference = wgs
                    };
                    IPoint toXY = geopuntHelper.Transform(XY as IGeometry, view.Extent.SpatialReference) as IPoint;
                    geopuntHelper.ZoomByRatioAndRecenter(view, zoom, toXY.X, toXY.Y);
                    view.Refresh();
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                infoLabel.Text = ex.Message + ": " + ex.StackTrace;
                return false;
            }
        }

        private void updateSuggestions()
        {
            string query = zoekText.Text + "," + gemeenteBox.Text;
            crabSuggestion suggestion;
            object[] suggestions;

            try
            { 
                suggestion = crab.suggestion(query, 10);
                suggestions = suggestion.SuggestionResult.ToArray() as object[];

                suggestionList.Items.Clear();
                suggestionList.Items.AddRange(suggestions);
            }
            catch (Exception ex)
            {
                infoLabel.Text = ex.Message + ": " + ex.StackTrace;
            }
        }

    }
}
