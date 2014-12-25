using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Catalog;

namespace geopunt4Arcgis 
{
    public partial class capakeyForm : Form
    {
        ISpatialReferenceFactory3 spatialReferenceFactory;
        IActiveView view;
        IMap map;
        ISpatialReference wgs;
        
        dataHandler.capakey capakey;
        List<IElement> graphics;
        geopunt4arcgisExtension gpExtension;
        
        List<datacontract.municipality> municipalities;
        List<datacontract.department> departments;
        List<datacontract.parcel> parcels;
        datacontract.parcel perceel;

        public capakeyForm()
        {
            //set global objects
            view = ArcMap.Document.ActiveView;
            map = view.FocusMap;

            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            wgs = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();

            capakey = new dataHandler.capakey();

            InitializeComponent();

            initGui();
        }

        private void initGui()
        {
            municipalities = capakey.getMunicipalities().municipalities;
            perceel = null;
            graphics = new List<IElement>();
            gemeenteCbx.Items.Clear();
            gemeenteCbx.Items.AddRange((from n in municipalities select n.municipalityName).ToArray());
        }

        #region "Event handlers"

        private void gemeenteCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            if (niscode == ""|| niscode == null) return;

            try
            {
                departments = capakey.getDepartments(int.Parse(niscode)).departments;
                departementCbx.Items.Clear();
                sectieCbx.Items.Clear();
                parcelCbx.Items.Clear();
                departementCbx.Items.AddRange((from n in departments select n.departmentName).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void departementCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            string depName = departementCbx.Text;
            string depCode = department2code(depName);

            if (niscode == "" || depCode == "" || niscode == null || depCode == null) return;

            try
            {
                List<datacontract.section> secties = capakey.getSecties(int.Parse(niscode), int.Parse(depCode)).sections;
                sectieCbx.Items.Clear();
                parcelCbx.Items.Clear();
                sectieCbx.Items.AddRange((from n in secties select n.sectionCode).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void sectieCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            string depName = departementCbx.Text;
            string depCode = department2code(depName);

            string sectie = sectieCbx.Text;

            if (niscode == "" || depCode == "" || sectie == "" ||
                niscode == null || depCode == null || sectie == null ) return;

            try
            {
                parcelCbx.Items.Clear();
                parcels = capakey.getParcels(int.Parse(niscode), int.Parse(depCode), sectie).parcels;
                parcelCbx.Items.AddRange((from n in parcels select n.perceelnummer).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void parcelCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gemeente = gemeenteCbx.Text;
            string niscode = municipality2nis(gemeente);

            string depName = departementCbx.Text;
            string depCode = department2code(depName);

            string sectie = sectieCbx.Text;
            string parcelNr = parcelCbx.Text;

            if (niscode == "" || depCode == "" || sectie == "" || parcelNr == "" ||
                niscode == null || depCode == null || sectie == null || parcelNr == null) return;

            try
            {
                perceel = capakey.getParcel(int.Parse(niscode), int.Parse(depCode), sectie, parcelNr,
                                                    dataHandler.CRS.WGS84, dataHandler.capakeyGeometryType.full);
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

        private void helpLbl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.geopunt.be/voor-experts/geopunt-plug-ins/functionaliteiten/zoek-een-perceel");
        }
        #endregion

        #region "private functions"
        private string municipality2nis(string muniName)
        {
            if (muniName == null || muniName == "") return "";

            var niscodes = (
                from n in municipalities
                where n.municipalityName == muniName
                select n.municipalityCode);

            if (niscodes.Count() == 0) return "";

            return niscodes.First<string>();
        }

        private string department2code(string depName )
        {
            if (depName == null || depName == "") return "";

            var depcodes = (
                from n in departments
                where n.departmentName == depName
                select n.departmentCode);

            if (depcodes.Count() == 0) return "";

            return depcodes.First<string>();
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
