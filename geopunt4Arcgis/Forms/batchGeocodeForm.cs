using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Catalog;

namespace geopunt4Arcgis
{
    public partial class batchGeocodeForm : Form
    {
        ISpatialReferenceFactory3 spatialReferenceFactory;
        IActiveView view;
        IMap map;
        ISpatialReference wgs;
        ISpatialReference lam72;

        geopunt4arcgisExtension gpExtension;
        dataHandler.adresLocation loc;
        dataHandler.adresSuggestion sug;
        string sepator;

        public batchGeocodeForm()
        {
            //set global objects
            view = ArcMap.Document.ActiveView;
            map = view.FocusMap;

            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            wgs = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);
            lam72 = spatialReferenceFactory.CreateProjectedCoordinateSystem(31370);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();

            loc = new dataHandler.adresLocation();
            sug = new dataHandler.adresSuggestion();

            InitializeComponent();

            sepCbx.SelectedIndex = 0;
            sepator = sepCbx.Text;
        }

        #region "event handlers"
        private void openBtn_Click(object sender, EventArgs e)
        {
            DialogResult openDlgResult = openCSVDlg.ShowDialog(this);
            if (openDlgResult == DialogResult.Cancel )
            {
                return;
            }
            else
            {
                csvPathTxt.Text = openCSVDlg.FileName;
                csvPathTxt.TextAlign = HorizontalAlignment.Left;
                loadCSV2table();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpLbl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.geopunt.be/voor-experts/geopunt-plug-ins/functionaliteiten/csv-bestanden-geocoderen");
        }

        private void sepCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sepCbx.Text == "ANDER TEKEN") 
            {
               string sep = inputForm.showInputDlg("Geef het gewenste scheidings teken op:", this);
               if ( sep != null )
               {
                   otherSepBox.Text = sep;
                   sepator = sep;
               }
               else
               {
                   return;
               }
            }
            else sepator = sepCbx.Text;
            loadCSV2table();
        }

        private void adresRadio_CheckedChanged(object sender, EventArgs e)
        {
            bool singleLine = singleColAdresRadio.Checked;
            if (!singleLine)
            {
                HuisNrCbx.Visible = true;
                huisNrColLbl.Visible = true;
                gemeenteColCbx.Visible = true;
                GemeenteColLbl.Visible = true;
                adresColLbl.Text = "Straat kolom: ";
            }
            else
            {
                HuisNrCbx.Visible = false;
                huisNrColLbl.Visible = false;
                gemeenteColCbx.Visible = false;
                GemeenteColLbl.Visible = false;
                adresColLbl.Text = "Adres kolom: ";
            }
        }
        #endregion

        #region "private functions"
        private void loadCSV2table()
        {
            string csvPath = csvPathTxt.Text;
            DataGridViewComboBoxColumn validatedRow;

            if ( !File.Exists(csvPath) || sepator == "" || sepator == null ) return;

            try
            {
                DataTable csvDataTbl = geopuntHelper.loadCSV2datatable(csvPath, sepator);
                //set validation column
                validatedRow = new DataGridViewComboBoxColumn();
                validatedRow.HeaderText = "Gevalideerd adres";
                validatedRow.Name = "validatedRow";
                //clear the table of all stuff
                dataGrid.Columns.Clear();
                adresColCbx.Items.Clear();
                adresColCbx.Items.Add("");
                HuisNrCbx.Items.Clear();
                HuisNrCbx.Items.Add("");
                gemeenteColCbx.Items.Clear();
                gemeenteColCbx.Items.Add("");

                foreach (DataColumn column in csvDataTbl.Columns)
                {
                    dataGrid.Columns.Add(column.ColumnName, column.ColumnName);
                    adresColCbx.Items.Add(column.ColumnName);
                    HuisNrCbx.Items.Add(column.ColumnName);
                    gemeenteColCbx.Items.Add(column.ColumnName);
                }
                dataGrid.Columns.Add(validatedRow);

                foreach (DataRow row in csvDataTbl.Rows)
                {
                    dataGrid.Rows.Add(row.ItemArray);
                }
            }
            catch (csvException csvEx)
            {
                msgLbl.Text = csvEx.Message;
                MessageBox.Show(this , csvEx.Message + " : " + csvEx.StackTrace, "CSV");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message +" : "+ ex.StackTrace );
                return;
            }

        }

        #endregion

    }
}
