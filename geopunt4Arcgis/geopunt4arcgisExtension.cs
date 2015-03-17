using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;

namespace geopunt4Arcgis
{
    public class geopunt4arcgisExtension : ESRI.ArcGIS.Desktop.AddIns.Extension
    {
        private static geopunt4arcgisExtension gpExtension;
        private RegistryKey geopuntKey;
        //layers
        public IFeatureClass adresLayer = null;
        public IFeatureClass reverseLayer = null;
        public IFeatureClass poiLayer = null;
        public IFeatureClass poiMinLayer = null;
        public IFeatureClass parcelLayer = null;
        public IFeatureClass profileLineLayer = null;
        public IFeatureClass profilePointsLayer = null;
        
        //settings
        public int profileCounter = 0;
        public int csvMaxRows = 500;
        public int timeout = 5000;

        //forms
        public zoekAdresForm zoekAdresDlg = null;
        public reverseZoekForm reverseDlg = null;
        public poiSearchForm poiDlg = null;
        public gipodForm gipodDlg = null;
        public capakeyForm capakayDlg = null;
        public batchGeocodeForm batchGeocodeDlg = null;
        public elevationForm elevationDlg = null;
        public catalogForm catalogDLg = null;
        public settingsForm settingsDlg = null;
        public AboutGeopunt4arcgisForm aboutDlg = null;
        
        public geopunt4arcgisExtension()
        {
            gpExtension = this;
            //cannot access app.config from addin -> using registry instead
            geopuntKey = Registry.CurrentUser.CreateSubKey("Software\\geopunt");
            loadSettings();
        }

        public void loadSettings() 
        {
            try
            {
                csvMaxRows = (int)geopuntKey.GetValue("csvMaxRows", 500);
                timeout = (int)geopuntKey.GetValue("timeOut", 5000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace, "Kon settings niet openen");
            }
        }

        public void saveSettings()
        {
            try
            {
                geopuntKey.SetValue("csvMaxRows", csvMaxRows);
                geopuntKey.SetValue("timeOut", timeout);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace, "Kon settings niet opslaan");
            }
        }

        /// <summary>Get the extensions object</summary>
        internal static geopunt4arcgisExtension getGeopuntExtension()
        {
            if (gpExtension == null)
            {
                UID extID = new UIDClass();
                extID.Value = ThisAddIn.IDs.geopunt4arcgisExtension;
                ArcMap.Application.FindExtensionByCLSID(extID);
            }
            return gpExtension;
        }

        protected override void OnStartup()
        {
            try
            {
                versionChecker vrs = new versionChecker();
                vrs.checkVersion();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message +": "+ ex.StackTrace);
            }

            
            base.OnStartup();
        }

        protected override void OnShutdown()
        {
            //trash every form and its resources still open on shutdown.
            if (zoekAdresDlg != null)
                if (!zoekAdresDlg.IsDisposed) zoekAdresDlg.Dispose();

            if (reverseDlg != null)
                if (!reverseDlg.IsDisposed) reverseDlg.Dispose();

            if (poiDlg != null)
                if (!poiDlg.IsDisposed) poiDlg.Dispose();

            if (gipodDlg != null)
                if (!gipodDlg.IsDisposed) gipodDlg.Dispose();

            if (capakayDlg != null)
                if (!capakayDlg.IsDisposed) capakayDlg.Dispose();

            if (batchGeocodeDlg != null)
                if (!batchGeocodeDlg.IsDisposed) batchGeocodeDlg.Dispose();

            if (elevationDlg != null)
                if (!elevationDlg.IsDisposed) elevationDlg.Dispose();

            if (catalogDLg != null)
                if (!catalogDLg.IsDisposed) batchGeocodeDlg.Dispose();

            if (settingsDlg != null)
                if (!settingsDlg.IsDisposed) settingsDlg.Dispose();

            if (aboutDlg != null)
                if (!aboutDlg.IsDisposed) aboutDlg.Dispose();

            saveSettings();

            base.OnShutdown();
        }

    }
}
