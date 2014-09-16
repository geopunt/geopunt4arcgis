using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
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
    public partial class reverseZoekForm : Form
    {
        IActiveView view;
        ISpatialReference lam72;
        IFeatureClass reverseFC;

        geopunt4arcgisExtension gpExtension;

        public Double xClick; public Double yClick;
        public Double xAdres; public Double yAdres;
        public Double diff;
        string adres; string adresType;
        dataHandler.adresLocation adresLocation;

        public reverseZoekForm()
        {
            view = ArcMap.Document.ActiveView;
            adresLocation = new dataHandler.adresLocation(adresCallback);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
            reverseFC = gpExtension.reverseLayer;

            InitializeComponent();
        }

     #region "eventhandlers"
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add2MapBtn_Click(object sender, EventArgs e)
        {
            if ( lam72 == null || adres == null ) { return; }

            IPoint fromXY = new ESRI.ArcGIS.Geometry.PointClass(){X = xAdres, Y= yAdres, SpatialReference = lam72 } ;
            IPoint toXY = geopuntHelper.Transform(fromXY as IGeometry, view.FocusMap.SpatialReference) as IPoint;

            IRgbColor innerClr = new RgbColor() { Red = 255, Blue = 0, Green = 255 };
            IRgbColor outlineClr = new RgbColor() { Red = 0, Blue = 0, Green = 0 };

            geopuntHelper.AddGraphicToMap(view.FocusMap, toXY, innerClr, outlineClr, 12);
            geopuntHelper.AddTextElement(view.FocusMap, toXY, adres);
            
            view.Refresh();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            if (reverseFC == null)
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
            IPoint fromXY = new PointClass() { X = xAdres, Y = yAdres, SpatialReference = lam72 };
            IPoint toXY = geopuntHelper.Transform(fromXY as IGeometry, view.FocusMap.SpatialReference) as IPoint;
            //add the adres to to the adres feature class
            addAdres2FC(toXY.X, toXY.Y, view.FocusMap.SpatialReference, adres, adresType);
            view.Refresh();
        }
     #endregion

     #region "overrides"
        protected override void OnClosed(EventArgs e)
        {
            if (adresLocation.client.IsBusy)
            {
                adresLocation.client.CancelAsync();
            }
            base.OnClosed(e);
        }
     #endregion

     #region "callbacks"
        private void adresCallback(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                datacontract.crabLocation loc = JsonConvert.DeserializeObject<datacontract.crabLocation>(e.Result);

                List<datacontract.locationResult> addresses = loc.LocationResult;
                if (addresses.Count > 0)
                {
                    xAdres = addresses[0].Location.X_Lambert72;
                    yAdres = addresses[0].Location.Y_Lambert72;
                    adres =  addresses[0].FormattedAddress;
                    adresType = addresses[0].LocationType;
                    diff = Math.Sqrt(Math.Pow(xAdres - xClick, 2) + Math.Pow(yAdres - yClick, 2));
                    setText(adres, diff, adresType);
                    add2MapBtn.Enabled = true;
                    saveBtn.Enabled = true;
                    return;
                }
                else
                {
                    MessageBox.Show(string.Format("Er werd geen adres gevonden nabij: {0:0.#}, {1:0.#}", xClick, yClick));
                    this.Close();
                }
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
        private void createAdresFeatureClass(string fcPath, ISpatialReference srs)
        {
            List<IField> attr = new List<IField>();
            attr.Add(geopuntHelper.createField("adres", esriFieldType.esriFieldTypeString));
            attr.Add(geopuntHelper.createField("adresType", esriFieldType.esriFieldTypeString));

            FileInfo fcInfo = new FileInfo(fcPath);

            if (fcInfo.Extension == ".shp")
            {
                reverseFC = geopuntHelper.createShapeFile(fcInfo.FullName, attr, view.FocusMap.SpatialReference,
                                                esriGeometryType.esriGeometryPoint, true);
            }
            else if (fcInfo.DirectoryName.ToLowerInvariant().EndsWith(".gdb"))
            {
                reverseFC = geopuntHelper.createFeatureClass(fcInfo.DirectoryName, fcInfo.Name, attr, srs,
                                                                           esriGeometryType.esriGeometryPoint, true);
            }
            else
            {
                throw new Exception("Bestand is geen shapefile of FileGeodatabase Feature Class");
            }
            geopuntHelper.addFeatureClassToMap(view, reverseFC);
            gpExtension.reverseLayer = reverseFC;
        }

        private void addAdres2FC(double x, double y, ISpatialReference srs, string adres, string adresType)
        {
            if (reverseFC == null) { return; }

            IPoint pt = new PointClass() { X = x, Y = y, SpatialReference = srs };

            IFeature feature = reverseFC.CreateFeature();
            feature.Shape = (IGeometry)pt;

            int adresIdx = reverseFC.FindField("adres");
            int adresTypeIdx = reverseFC.FindField("adresType");

            feature.set_Value(adresIdx, adres);
            feature.set_Value(adresTypeIdx, adresType);

            feature.Store();
        }

     #endregion

     #region "shared functions"
        public void setText(string adrestext, double diffValue = 0, string statustext = "")
        {
            adresBox.Text = adrestext;
            diffBox.Text = string.Format("{0:0.##} meter", diffValue);
            infoLabel.Text = statustext;
        }

        public void reverseGeocode(IPoint xyLam72)
        {
            if (adresLocation.client.IsBusy) { return; }

            xClick = Math.Round(xyLam72.X, 2);
            yClick = Math.Round(xyLam72.Y, 2);

            lam72 = xyLam72.SpatialReference;

            adresLocation.getXYadresLocationAsync(xClick, yClick);

            adresBox.Text = "< De informatie wordt opgehaald, even geduld. >";
            diffBox.Text = "";
            infoLabel.Text = "";
            add2MapBtn.Enabled = false;
            saveBtn.Enabled = false;
        }

     #endregion

    }
}
