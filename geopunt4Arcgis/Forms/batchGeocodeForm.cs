using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Catalog;
using System.Globalization;

namespace geopunt4Arcgis
{
    public partial class batchGeocodeForm : Form
    {
        ESRI.ArcGIS.Framework.ICommandItem oldCmd = null;
        ESRI.ArcGIS.Framework.ICommandItem mouseCmd = null;

        ISpatialReferenceFactory3 spatialReferenceFactory;
        IActiveView view;
        IMap map;
        ISpatialReference lam72;

        geopunt4arcgisExtension gpExtension;
        dataHandler.adresLocation loc;
        dataHandler.adresSuggestion sug;
        string sepator;
        int straatCol;
        int huisnrCol;
        int gemeenteCol;

        DataGridViewRow[] rows2validate;
        List<IElement> graphics;

        public batchGeocodeForm( )
        {
            //set global objects
            view = ArcMap.Document.ActiveView;
            map = view.FocusMap;

            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            lam72 = spatialReferenceFactory.CreateProjectedCoordinateSystem(31370);

            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();

            loc = new dataHandler.adresLocation( timeout: gpExtension.timeout);
            sug = new dataHandler.adresSuggestion( timeout: gpExtension.timeout);

            graphics = new List<IElement>();

            InitializeComponent();

            initGui();
        }

        private void initGui()
        {
            sepCbx.SelectedIndex = 0;
            sepator = sepCbx.Text;
            encodingCbx.SelectedIndex = 0;

            ESRI.ArcGIS.Framework.ICommandBars commandBars = ArcMap.Application.Document.CommandBars;
            UID toolID = new UIDClass();
            toolID.Value = ThisAddIn.IDs.geopuntBatchGeocodingTool;
            mouseCmd = commandBars.Find(toolID, false, false);
        }

        #region "overrides"
        protected override void  OnClosing(CancelEventArgs e)
        {
            if (validationWorker.IsBusy)
            {
                validationWorker.CancelAsync();
            }
            clearGraphics();
            if (oldCmd != null)
            {
                ArcMap.Application.CurrentTool = oldCmd;
                oldCmd = null;
            }
            gpExtension.batchGeocodeDlg = null;
            base.OnClosing(e);
        }

        #endregion

        #region "event handlers"
        private void openBtn_Click(object sender, EventArgs e)
        {
            openCSVDlg.Filter = "CSV-file(*.csv)|*.csv|Text-file(*.txt)|*.txt|All Files(*.*)|*.*";
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
            System.Diagnostics.Process.Start(
                "http://www.geopunt.be/voor-experts/geopunt-plug-ins/qgis%20plugin/functionaliteiten/csv-bestanden-geocoderen");
        }

        private void sepCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sepCbx.Text == "Ander teken") 
            {
               string sep = inputForm.showInputDlg("Geef het gewenste scheidingsteken op:", this);
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

        private void validateAllBtn_Click(object sender, EventArgs e)
        {
            if (csvDataGrid.RowCount == 0) return;

            if (adresColCbx.Text == "")
            {
                MessageBox.Show(this, "Stel eerst de adres kolommen in.", "Waarschuwing" );
                return;
            }
            if (validationWorker.IsBusy != true)
            {
                toggleInteraction(false);

                rows2validate = new DataGridViewRow[csvDataGrid.Rows.Count];
                csvDataGrid.Rows.CopyTo(rows2validate,0);
                progressBar.Maximum = csvDataGrid.Rows.Count;

                validationWorker.RunWorkerAsync( rows2validate );
            }
        }
        
        private void validateSelBtn_Click(object sender, EventArgs e)
        {
            if (csvDataGrid.SelectedRows.Count == 0) return;

            if (adresColCbx.Text == "")
            {
                MessageBox.Show(this, "Stel eerst de adres kolommen in.", "Waarschuwing");
                return;
            }

            if (validationWorker.IsBusy != true)
            {
                setCols();
                toggleInteraction(false);

                rows2validate = new DataGridViewRow[csvDataGrid.SelectedRows.Count];
                csvDataGrid.SelectedRows.CopyTo(rows2validate, 0);
                progressBar.Maximum = csvDataGrid.SelectedRows.Count;

                validationWorker.RunWorkerAsync(rows2validate);
            }
        }

        private void validationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataGridViewRow[] rows = (DataGridViewRow[])e.Argument;
            int counter = 0;

            List<string> suggestions;
            string street; string huisnr; string gemeente;

            foreach ( DataGridViewRow  row in rows)
            {
                if (validationWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                street = (string) row.Cells[straatCol].Value;
                if (huisnrCol >= 0) huisnr = (string) row.Cells[huisnrCol].Value;
                else huisnr = "";
                if (gemeenteCol >= 0) gemeente = (string) row.Cells[gemeenteCol].Value;
                else gemeente = "";

                suggestions= validateRow(street, huisnr, gemeente);

                if ( suggestions.Count > 1) 
                    if( suggestions[0].ToLowerInvariant() ==
                        string.Format("{0} {1}, {2}", street, huisnr, gemeente).ToLowerInvariant())
                    {
                        suggestions.Clear();
                        suggestions.Add(string.Format("{0} {1}, {2}", street, huisnr, gemeente));
                    }
                validationWorker.ReportProgress(counter, suggestions);
                counter++;
            }
        }
        private void validationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                List<string> suggestions = (List<string>)e.UserState;
                int count = e.ProgressPercentage;

                DataGridViewComboBoxCell validCell = (DataGridViewComboBoxCell)rows2validate[count].Cells["validAdres"];

                Color clr;
                if (suggestions.Count == 0)
                {
                    clr = ColorTranslator.FromHtml("#F8E0E0");
                }
                else if (suggestions.Count == 1)
                {
                    validCell.Items.Clear();
                    validCell.Items.AddRange(suggestions.ToArray());
                    clr = ColorTranslator.FromHtml("#D0F5A9");
                    validCell.Value = validCell.Items[0];
                }
                else
                {
                    validCell.Items.Clear();

                    string huisnr = "";
                    string street = (string)rows2validate[count].Cells[straatCol].Value;
                    if (huisnrCol >= 0) huisnr = (string)rows2validate[count].Cells[huisnrCol].Value;

                    string streetNrValid = suggestions[0].Split(',').First();

                    if (streetNrValid.ToLowerInvariant() == street.ToLowerInvariant() + " " + huisnr.ToLowerInvariant())
                    {
                        validCell.Items.AddRange(suggestions[0]);
                        clr = ColorTranslator.FromHtml("#F5F6CE");
                    }
                    else
                    {
                        validCell.Items.AddRange(suggestions.ToArray());
                        clr = ColorTranslator.FromHtml("#F5F6CE");
                    }
                    validCell.Value = validCell.Items[0];
                }
                foreach (DataGridViewCell cel in rows2validate[count].Cells)
                {
                    cel.Style.BackColor = clr;
                }
                progressBar.Value = count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }
        private void validationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toggleInteraction(true);
            progressBar.Value = 0;
        }

        private void add2mapBtn_Click(object sender, EventArgs e)
        {
            if (csvDataGrid.RowCount == 0) return;

            try
            {
                String shpPath = geopuntHelper.ShowSaveDataDialog("Opslaan als");
                if (shpPath == null) return;
                FileInfo featureClassPath = new FileInfo(shpPath);
                List<IField> fields = createFields();
                IFeatureClass csvFC;

                if (shpPath.ToLowerInvariant().EndsWith(".shp"))
                {
                    csvFC = geopuntHelper.createShapeFile(shpPath, fields, view.FocusMap.SpatialReference,
                                                                                    esriGeometryType.esriGeometryPoint, true);
                }
                else if (featureClassPath.DirectoryName.ToLowerInvariant().EndsWith(".gdb"))
                {
                    csvFC = geopuntHelper.createFeatureClass(featureClassPath.DirectoryName, featureClassPath.Name,
                                             fields, view.FocusMap.SpatialReference, esriGeometryType.esriGeometryPoint, true);
                }
                else
                {
                    throw new Exception("Is geen feature class of shapefile.");
                }
                populateFields(csvFC);
                geopuntHelper.addFeatureClassToMap(view, csvFC, false);
            }
            catch (WebException wex)
            {
                if (wex.Status == WebExceptionStatus.Timeout)
                    MessageBox.Show("De connectie werd afgebroken." +
                        " Het duurde te lang voor de server een resultaat terug gaf.\n" +
                        "U kunt via de instellingen de 'timout'-tijd optrekken.", wex.Message);
                else if (wex.Response != null)
                {
                    string resp = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
                    MessageBox.Show(resp, wex.Message);
                }
                else
                    MessageBox.Show(wex.Message, "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message +" : "+ ex.StackTrace );
            }
        }

        private void manualLocBtn_Click(object sender, EventArgs e)
        {
            if (mouseCmd == null || csvDataGrid.SelectedRows.Count == 0)
                return;

            oldCmd = ArcMap.Application.CurrentTool;
            ArcMap.Application.CurrentTool = mouseCmd;
        }

        private void zoom2selBtn_Click(object sender, EventArgs e)
        {
            if (mouseCmd == null || csvDataGrid.SelectedRows.Count == 0) return;

            int maxCount = 30;
            int i = 0;

            try
            {
                clearGraphics();

                IPointCollection points = new MultipointClass();

                foreach (DataGridViewRow row in csvDataGrid.SelectedRows)
                {
                    if (row.Cells["validAdres"].Value == null || row.Cells["validAdres"].Value.ToString() == "") 
                        continue;

                    if( i > maxCount ) break;
                    i++;

                    string adres = row.Cells["validAdres"].Value.ToString();

                    string[] xy = adres.Split(new string[] {"|"}, StringSplitOptions.RemoveEmptyEntries);

                    double x; double y;
                    string adresType = "Manueel";
                    if (xy.Count() == 2)
                    {
                        bool xBool = Double.TryParse(xy[0], out x);
                        bool yBool = Double.TryParse(xy[1], out y);

                        if (!xBool || !yBool)
                        {
                            List<datacontract.locationResult> locs = loc.getAdresLocation(adres, 1);
                            if (locs.Count == 0) continue;
                            x = locs[0].Location.X_Lambert72;
                            y = locs[0].Location.Y_Lambert72;
                            adresType = locs[0].LocationType;
                        }
                    }
                    else
                    {
                        List<datacontract.locationResult> locs = loc.getAdresLocation(adres, 1);
                        if (locs.Count == 0) continue;
                        x = locs[0].Location.X_Lambert72;
                        y = locs[0].Location.Y_Lambert72;
                        adresType = locs[0].LocationType;
                    }

                    IPoint pt = new PointClass() { X = x, Y = y, SpatialReference = lam72 };
                    IPoint prjPt = geopuntHelper.Transform(pt, map.SpatialReference) as IPoint;
                    points.AddPoint(prjPt);

                    IRgbColor rgb = new RgbColorClass() { Red = 0, Blue = 255, Green = 255 };
                    IRgbColor black = new RgbColorClass() { Red = 0, Green = 0, Blue = 0 };
                    IElement grp = geopuntHelper.AddGraphicToMap(map, (IGeometry)prjPt, rgb, black, 5, true);
                    graphics.Add(grp);
                }

                if (points.PointCount == 0)
                {
                    return;
                }
                else if (points.PointCount == 1)
                {
                    IPoint xy = points.get_Point(0);
                    geopuntHelper.ZoomByRatioAndRecenter(view, 1, xy.X, xy.Y);
                    map.MapScale = 1000;
                    view.Refresh();
                }
                else
                {
                    IEnvelope extent = ((IGeometry)points).Envelope;
                    view.Extent = extent;
                    view.Refresh();
                }
            }
            catch (WebException wex)
            {
                if (wex.Status == WebExceptionStatus.Timeout)
                    MessageBox.Show("De connectie werd afgebroken." +
                        " Het duurde te lang voor de server een resultaat terug gaf.\n" +
                        "U kunt via de instellingen de 'timout'-tijd optrekken.", wex.Message);
                else if (wex.Response != null)
                {
                    string resp = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
                    MessageBox.Show(resp, wex.Message);
                }
                else
                    MessageBox.Show(wex.Message, "Error");
            }
            catch (Exception ex)
            {
                 MessageBox.Show( ex.Message +" : "+ ex.StackTrace );
            }
        }

        private void cancelValidationBtn_Click(object sender, EventArgs e)
        {
            validationWorker.CancelAsync();
        }
        #endregion

        #region "private functions"
        private void loadCSV2table()
        {
            System.Text.Encoding codex = System.Text.Encoding.Default;
            if (encodingCbx.Text == "UTF-8") codex = System.Text.Encoding.UTF8;

            string csvPath = csvPathTxt.Text;
            DataGridViewComboBoxColumn validatedRow;

            if ( !File.Exists(csvPath) || sepator == "" || sepator == null ) return;

            DataTable csvDataTbl;
            csvErrorLbl.Text = "";
            //clear all the stuff
            csvDataGrid.Columns.Clear();
            adresColCbx.Items.Clear();
            adresColCbx.Items.Add("");
            HuisNrCbx.Items.Clear();
            HuisNrCbx.Items.Add("");
            gemeenteColCbx.Items.Clear();
            gemeenteColCbx.Items.Add("");
            
            try
            {
                int maxRowCount = gpExtension.csvMaxRows;
                csvDataTbl = geopuntHelper.loadCSV2datatable(csvPath, sepator, maxRowCount, codex);

                if (csvDataTbl.Rows.Count == maxRowCount)
                {
                    string msg =  String.Format(
                      "Maximaal aantal van {0} rijen overschreden, enkel de eerste {0} rijen worden getoont.", maxRowCount);
                    MessageBox.Show(msg, "Maximaal aantal rijen overschreden." );
                    csvErrorLbl.Text = msg;
                }
            }
            catch (Exception csvEx)
            { 
                MessageBox.Show(csvEx.Message, "Error" );
                csvErrorLbl.Text = csvEx.Message;
                return;
            }
               
            //set validation column
            validatedRow = new DataGridViewComboBoxColumn();
            validatedRow.HeaderText = "Gevalideerd adres";
            validatedRow.Name = "validAdres";
            validatedRow.Width = 120;

            foreach (DataColumn column in csvDataTbl.Columns)
            {
                csvDataGrid.Columns.Add(column.ColumnName, column.ColumnName);
                csvDataGrid.Columns[column.ColumnName].SortMode = DataGridViewColumnSortMode.Automatic;

                adresColCbx.Items.Add(column.ColumnName);
                HuisNrCbx.Items.Add(column.ColumnName);
                gemeenteColCbx.Items.Add(column.ColumnName);
            }
            csvDataGrid.Columns.Add(validatedRow);

            foreach (DataRow row in csvDataTbl.Rows)
            {
                csvDataGrid.Rows.Add(row.ItemArray);
            }
        }

        private List<string> validateRow(string street, string houseNr, string municapality)
        {
            string adres;
            List<string> formatedAddresses = new List<string>();

            if (street == null || street == "") return formatedAddresses;

            if ( (houseNr == null || houseNr == "") && (municapality == null || municapality == "") )
                adres = street;
            else if (municapality == null || municapality == "")
                adres = street + " " + houseNr;
            else if (houseNr == null || houseNr == "")
                adres = street + ", " + municapality;
            else
            {
                adres = string.Format("{0} {1}, {2}", street, houseNr, municapality);
            }
            formatedAddresses.AddRange( sug.getAdresSuggestion(adres, 5));
            return formatedAddresses;
        }

        private void setCols() 
        {
            straatCol = adresColCbx.SelectedIndex -1;
            if (multiColAdresRadio.Checked) 
            {
                huisnrCol = HuisNrCbx.SelectedIndex - 1;
                gemeenteCol = gemeenteColCbx.SelectedIndex - 1;
            }
            else
            {
                huisnrCol = -1;
                gemeenteCol = -1;
            }
        }

        private  List<IField> createFields() 
        {
            List<IField> attr = new List<IField>();
            
            if (csvDataGrid.Rows.Count == 0) return attr;

            for (int i = 0; i < csvDataGrid.ColumnCount ; i++)
            {
                DataGridViewColumn column = csvDataGrid.Columns[i];
                string colName = column.Name;

                esriFieldType dataType = esriFieldType.esriFieldTypeString;

                bool isInteger = true;
                bool isDouble = true;

                foreach (DataGridViewRow row in csvDataGrid.Rows)
                {
                    if (row.Cells[colName].Value == null )
                        continue;
                    string item = row.Cells[colName].Value.ToString();
                    int n; double d;
                    if (isInteger) isInteger = int.TryParse(item, out n);
                    if (isDouble) isDouble = double.TryParse(item, out d);

                    if (isInteger == false && isDouble == false) break;
                }
                if (isInteger) dataType = esriFieldType.esriFieldTypeInteger;
                if (isDouble && !isInteger) dataType = esriFieldType.esriFieldTypeDouble;

                attr.Add(geopuntHelper.createField( colName, dataType, 254));
            }
            attr.Add(geopuntHelper.createField("adresType", esriFieldType.esriFieldTypeString, 80));
            return attr;
        }

        private void populateFields(IFeatureClass FC)
        {
            using (ComReleaser comReleaser = new ComReleaser())
            {
                //Spatialreference 
                ISpatialReference srs = map.SpatialReference;
                // Create a feature buffer.
                IFeatureBuffer featureBuffer = FC.CreateFeatureBuffer();
                comReleaser.ManageLifetime(featureBuffer);

                // Create an insert cursor.
                IFeatureCursor insertCursor = FC.Insert(true);
                comReleaser.ManageLifetime(insertCursor);

                foreach ( DataGridViewRow row in csvDataGrid.Rows )
                {
                    DataGridViewCell validcell = row.Cells["validAdres"];
                    if (validcell.Value == null || validcell.Value.ToString() == "") continue;

                    string validAdres = validcell.Value.ToString();
                    string[] xy = validAdres.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries );

                    double x; double y;
                    string adresType = "Manueel";
                    if ( xy.Count() == 2)
                    {
                        bool xBool = Double.TryParse(xy[0], out x);
                        bool yBool = Double.TryParse(xy[1], out y);

                        if (!xBool || !yBool)
                        {
                            List<datacontract.locationResult> locs = loc.getAdresLocation(validAdres, 1);
                            if (locs.Count == 0) continue;
                            x = locs[0].Location.X_Lambert72;
                            y = locs[0].Location.Y_Lambert72;
                            adresType = locs[0].LocationType;
                        }
                    }
                    else 
                    {
                        List<datacontract.locationResult> locs = loc.getAdresLocation(validAdres, 1);
                        if (locs.Count == 0) continue;
                        x = locs[0].Location.X_Lambert72;
                        y = locs[0].Location.Y_Lambert72;
                        adresType = locs[0].LocationType;
                    }

                    IPoint pt = new PointClass() { X = x, Y = y, SpatialReference = lam72 };
                    IPoint prjPt = geopuntHelper.Transform(pt, srs) as IPoint;

                    featureBuffer.Shape = prjPt;
                    
                    int adresTypeIdx = FC.FindField("adresType");
                    featureBuffer.set_Value(adresTypeIdx, adresType);

                    int idxCounter = 2;
                    foreach (DataGridViewCell cel in row.Cells)
                    {
                        object val = cel.Value;
                        if (val is string && val.ToString().Length > 254)
                            val = cel.Value.ToString().Substring(0, 254);

                        featureBuffer.set_Value(idxCounter, val );
                        idxCounter++;
                    }
                    insertCursor.InsertFeature(featureBuffer);
                }
                insertCursor.Flush();
            }
        }

        private void clearGraphics()
        {
            IGraphicsContainer graphicsContainer = (IGraphicsContainer)map;

            foreach (IElement grp in graphics)
            {
                if (grp == null) break;
                //grp.Locked = false;
                try
                {
                    graphicsContainer.DeleteElement(grp);
                }
                catch (Exception)
                {
                    Console.Write("Element was already deleted");
                }
            }
            graphics.Clear();
        }

        private void toggleInteraction( bool active )
        {
            setCols();
            csvBox.Enabled = active;
            adresSettingsBox.Enabled = active;
            gridPanel.UseWaitCursor = !active;

            csvDataGrid.Enabled = active;

            manualLocBtn.Enabled = active;
            validateSelBtn.Enabled = active;
            validateAllBtn.Enabled = active;

            add2mapBtn.Enabled = active;
        }
        #endregion

        #region "public functions"
        public void getXYasValidAdres(Double X, Double Y)
        {
            if (csvDataGrid.RowCount == 0) return;

            foreach (DataGridViewRow row in csvDataGrid.SelectedRows)
            {
                DataGridViewComboBoxCell validCel = (DataGridViewComboBoxCell) row.Cells["validAdres"];
                validCel.Items.Clear();
                validCel.Items.Add(string.Format(CultureInfo.InvariantCulture, "{0:F0}|{1:F0}", X, Y));
                validCel.Value = validCel.Items[0];

                Color clr = ColorTranslator.FromHtml("#F1F8E0");
                foreach (DataGridViewCell cel in row.Cells)
                {
                    cel.Style.BackColor = clr;
                }
            }

            if (oldCmd != null)
            {
                ArcMap.Application.CurrentTool = oldCmd;
                oldCmd = null;
            }
            this.WindowState = FormWindowState.Normal;
            this.Focus();
        }
        #endregion

    }
}
