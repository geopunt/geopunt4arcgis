namespace geopunt4Arcgis
{
    partial class batchGeocodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(batchGeocodeForm));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.msgLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.helpLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.openBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.csvDataGrid = new System.Windows.Forms.DataGridView();
            this.gridTools = new System.Windows.Forms.ToolStrip();
            this.validateAllBtn = new System.Windows.Forms.ToolStripButton();
            this.validateSelBtn = new System.Windows.Forms.ToolStripButton();
            this.cancelValidationBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.manualLocBtn = new System.Windows.Forms.ToolStripButton();
            this.zoom2selBtn = new System.Windows.Forms.ToolStripButton();
            this.openCSVDlg = new System.Windows.Forms.OpenFileDialog();
            this.csvPathTxt = new System.Windows.Forms.TextBox();
            this.adresColLbl = new System.Windows.Forms.Label();
            this.adresColCbx = new System.Windows.Forms.ComboBox();
            this.adresSettingsBox = new System.Windows.Forms.GroupBox();
            this.singleColAdresRadio = new System.Windows.Forms.RadioButton();
            this.multiColAdresRadio = new System.Windows.Forms.RadioButton();
            this.HuisNrCbx = new System.Windows.Forms.ComboBox();
            this.huisNrColLbl = new System.Windows.Forms.Label();
            this.gemeenteColCbx = new System.Windows.Forms.ComboBox();
            this.GemeenteColLbl = new System.Windows.Forms.Label();
            this.sepLbl = new System.Windows.Forms.Label();
            this.sepCbx = new System.Windows.Forms.ComboBox();
            this.otherSepBox = new System.Windows.Forms.TextBox();
            this.validationWorker = new System.ComponentModel.BackgroundWorker();
            this.csvBox = new System.Windows.Forms.GroupBox();
            this.encodingCbx = new System.Windows.Forms.ComboBox();
            this.csvErrorLbl = new System.Windows.Forms.Label();
            this.add2mapBtn = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csvDataGrid)).BeginInit();
            this.gridTools.SuspendLayout();
            this.adresSettingsBox.SuspendLayout();
            this.csvBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msgLbl,
            this.progressBar,
            this.helpLbl});
            this.statusBar.Location = new System.Drawing.Point(0, 596);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(907, 26);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // msgLbl
            // 
            this.msgLbl.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.msgLbl.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(716, 21);
            this.msgLbl.Spring = true;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(133, 20);
            // 
            // helpLbl
            // 
            this.helpLbl.IsLink = true;
            this.helpLbl.Name = "helpLbl";
            this.helpLbl.Size = new System.Drawing.Size(36, 21);
            this.helpLbl.Text = "Help";
            this.helpLbl.Click += new System.EventHandler(this.helpLbl_Click);
            // 
            // openBtn
            // 
            this.openBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openBtn.Location = new System.Drawing.Point(674, 16);
            this.openBtn.Margin = new System.Windows.Forms.Padding(4);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(83, 28);
            this.openBtn.TabIndex = 2;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(795, 550);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(96, 28);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Sluiten";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // gridPanel
            // 
            this.gridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPanel.Controls.Add(this.csvDataGrid);
            this.gridPanel.Controls.Add(this.gridTools);
            this.gridPanel.Location = new System.Drawing.Point(16, 261);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(4);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(875, 281);
            this.gridPanel.TabIndex = 5;
            // 
            // csvDataGrid
            // 
            this.csvDataGrid.AllowUserToAddRows = false;
            this.csvDataGrid.AllowUserToDeleteRows = false;
            this.csvDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csvDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csvDataGrid.Location = new System.Drawing.Point(0, 25);
            this.csvDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.csvDataGrid.Name = "csvDataGrid";
            this.csvDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.csvDataGrid.Size = new System.Drawing.Size(875, 256);
            this.csvDataGrid.TabIndex = 6;
            // 
            // gridTools
            // 
            this.gridTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validateAllBtn,
            this.validateSelBtn,
            this.cancelValidationBtn,
            this.toolStripSeparator1,
            this.manualLocBtn,
            this.zoom2selBtn});
            this.gridTools.Location = new System.Drawing.Point(0, 0);
            this.gridTools.Name = "gridTools";
            this.gridTools.Size = new System.Drawing.Size(875, 25);
            this.gridTools.TabIndex = 5;
            this.gridTools.Text = "Tabel tools";
            // 
            // validateAllBtn
            // 
            this.validateAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("validateAllBtn.Image")));
            this.validateAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.validateAllBtn.Name = "validateAllBtn";
            this.validateAllBtn.Size = new System.Drawing.Size(110, 22);
            this.validateAllBtn.Text = "Valideer alles";
            this.validateAllBtn.ToolTipText = "Valideer alle records";
            this.validateAllBtn.Click += new System.EventHandler(this.validateAllBtn_Click);
            // 
            // validateSelBtn
            // 
            this.validateSelBtn.Image = ((System.Drawing.Image)(resources.GetObject("validateSelBtn.Image")));
            this.validateSelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.validateSelBtn.Name = "validateSelBtn";
            this.validateSelBtn.Size = new System.Drawing.Size(130, 22);
            this.validateSelBtn.Text = "Valideer selectie";
            this.validateSelBtn.ToolTipText = "Valideer alleen de geselecteerde records";
            this.validateSelBtn.Click += new System.EventHandler(this.validateSelBtn_Click);
            // 
            // cancelValidationBtn
            // 
            this.cancelValidationBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelValidationBtn.Image")));
            this.cancelValidationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelValidationBtn.Name = "cancelValidationBtn";
            this.cancelValidationBtn.Size = new System.Drawing.Size(84, 22);
            this.cancelValidationBtn.Text = "Annuleer";
            this.cancelValidationBtn.ToolTipText = "Annuleer validatie, onderbreek uitvoering";
            this.cancelValidationBtn.Click += new System.EventHandler(this.cancelValidationBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // manualLocBtn
            // 
            this.manualLocBtn.Image = ((System.Drawing.Image)(resources.GetObject("manualLocBtn.Image")));
            this.manualLocBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.manualLocBtn.Name = "manualLocBtn";
            this.manualLocBtn.Size = new System.Drawing.Size(175, 22);
            this.manualLocBtn.Text = "Prik de locatie op kaart";
            this.manualLocBtn.ToolTipText = "Duid de locatie van de geselecteerde records op de kaart aan";
            this.manualLocBtn.Click += new System.EventHandler(this.manualLocBtn_Click);
            // 
            // zoom2selBtn
            // 
            this.zoom2selBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoom2selBtn.Image")));
            this.zoom2selBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoom2selBtn.Name = "zoom2selBtn";
            this.zoom2selBtn.Size = new System.Drawing.Size(152, 22);
            this.zoom2selBtn.Text = "Zoom naar Selectie";
            this.zoom2selBtn.ToolTipText = "Zoom naar Selectie (Maximaal 30 rijen)";
            this.zoom2selBtn.Click += new System.EventHandler(this.zoom2selBtn_Click);
            // 
            // openCSVDlg
            // 
            this.openCSVDlg.DefaultExt = "csv";
            this.openCSVDlg.RestoreDirectory = true;
            // 
            // csvPathTxt
            // 
            this.csvPathTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.csvPathTxt.Location = new System.Drawing.Point(12, 20);
            this.csvPathTxt.Margin = new System.Windows.Forms.Padding(4);
            this.csvPathTxt.Name = "csvPathTxt";
            this.csvPathTxt.ReadOnly = true;
            this.csvPathTxt.Size = new System.Drawing.Size(654, 22);
            this.csvPathTxt.TabIndex = 6;
            this.csvPathTxt.Text = "< input CSV-file >";
            this.csvPathTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // adresColLbl
            // 
            this.adresColLbl.AutoSize = true;
            this.adresColLbl.Location = new System.Drawing.Point(113, 55);
            this.adresColLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.adresColLbl.Name = "adresColLbl";
            this.adresColLbl.Size = new System.Drawing.Size(130, 17);
            this.adresColLbl.TabIndex = 7;
            this.adresColLbl.Text = "Straatnaam kolom: ";
            // 
            // adresColCbx
            // 
            this.adresColCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.adresColCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adresColCbx.FormattingEnabled = true;
            this.adresColCbx.Location = new System.Drawing.Point(258, 52);
            this.adresColCbx.Margin = new System.Windows.Forms.Padding(4);
            this.adresColCbx.Name = "adresColCbx";
            this.adresColCbx.Size = new System.Drawing.Size(493, 24);
            this.adresColCbx.TabIndex = 8;
            // 
            // adresSettingsBox
            // 
            this.adresSettingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.adresSettingsBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.adresSettingsBox.Controls.Add(this.singleColAdresRadio);
            this.adresSettingsBox.Controls.Add(this.multiColAdresRadio);
            this.adresSettingsBox.Controls.Add(this.HuisNrCbx);
            this.adresSettingsBox.Controls.Add(this.huisNrColLbl);
            this.adresSettingsBox.Controls.Add(this.gemeenteColCbx);
            this.adresSettingsBox.Controls.Add(this.GemeenteColLbl);
            this.adresSettingsBox.Controls.Add(this.adresColCbx);
            this.adresSettingsBox.Controls.Add(this.adresColLbl);
            this.adresSettingsBox.Location = new System.Drawing.Point(16, 105);
            this.adresSettingsBox.Margin = new System.Windows.Forms.Padding(4);
            this.adresSettingsBox.MaximumSize = new System.Drawing.Size(760, 151);
            this.adresSettingsBox.MinimumSize = new System.Drawing.Size(400, 151);
            this.adresSettingsBox.Name = "adresSettingsBox";
            this.adresSettingsBox.Padding = new System.Windows.Forms.Padding(4);
            this.adresSettingsBox.Size = new System.Drawing.Size(760, 151);
            this.adresSettingsBox.TabIndex = 9;
            this.adresSettingsBox.TabStop = false;
            this.adresSettingsBox.Text = "Adres Instellingen";
            // 
            // singleColAdresRadio
            // 
            this.singleColAdresRadio.AutoSize = true;
            this.singleColAdresRadio.Location = new System.Drawing.Point(258, 23);
            this.singleColAdresRadio.Margin = new System.Windows.Forms.Padding(4);
            this.singleColAdresRadio.Name = "singleColAdresRadio";
            this.singleColAdresRadio.Size = new System.Drawing.Size(187, 21);
            this.singleColAdresRadio.TabIndex = 14;
            this.singleColAdresRadio.Text = "Volledig adres in 1 kolom";
            this.singleColAdresRadio.UseVisualStyleBackColor = true;
            this.singleColAdresRadio.CheckedChanged += new System.EventHandler(this.adresRadio_CheckedChanged);
            // 
            // multiColAdresRadio
            // 
            this.multiColAdresRadio.AutoSize = true;
            this.multiColAdresRadio.Checked = true;
            this.multiColAdresRadio.Location = new System.Drawing.Point(29, 23);
            this.multiColAdresRadio.Margin = new System.Windows.Forms.Padding(4);
            this.multiColAdresRadio.Name = "multiColAdresRadio";
            this.multiColAdresRadio.Size = new System.Drawing.Size(214, 21);
            this.multiColAdresRadio.TabIndex = 13;
            this.multiColAdresRadio.TabStop = true;
            this.multiColAdresRadio.Text = "Adres in meerdere kolommen";
            this.multiColAdresRadio.UseVisualStyleBackColor = true;
            this.multiColAdresRadio.CheckedChanged += new System.EventHandler(this.adresRadio_CheckedChanged);
            // 
            // HuisNrCbx
            // 
            this.HuisNrCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HuisNrCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HuisNrCbx.FormattingEnabled = true;
            this.HuisNrCbx.Location = new System.Drawing.Point(258, 85);
            this.HuisNrCbx.Margin = new System.Windows.Forms.Padding(4);
            this.HuisNrCbx.Name = "HuisNrCbx";
            this.HuisNrCbx.Size = new System.Drawing.Size(493, 24);
            this.HuisNrCbx.TabIndex = 12;
            // 
            // huisNrColLbl
            // 
            this.huisNrColLbl.AutoSize = true;
            this.huisNrColLbl.Location = new System.Drawing.Point(35, 88);
            this.huisNrColLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.huisNrColLbl.Name = "huisNrColLbl";
            this.huisNrColLbl.Size = new System.Drawing.Size(208, 17);
            this.huisNrColLbl.TabIndex = 11;
            this.huisNrColLbl.Text = "Huisnummer kolom (optioneel): ";
            // 
            // gemeenteColCbx
            // 
            this.gemeenteColCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gemeenteColCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gemeenteColCbx.FormattingEnabled = true;
            this.gemeenteColCbx.Location = new System.Drawing.Point(258, 118);
            this.gemeenteColCbx.Margin = new System.Windows.Forms.Padding(4);
            this.gemeenteColCbx.Name = "gemeenteColCbx";
            this.gemeenteColCbx.Size = new System.Drawing.Size(493, 24);
            this.gemeenteColCbx.TabIndex = 10;
            // 
            // GemeenteColLbl
            // 
            this.GemeenteColLbl.AutoSize = true;
            this.GemeenteColLbl.Location = new System.Drawing.Point(42, 121);
            this.GemeenteColLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GemeenteColLbl.Name = "GemeenteColLbl";
            this.GemeenteColLbl.Size = new System.Drawing.Size(201, 17);
            this.GemeenteColLbl.TabIndex = 9;
            this.GemeenteColLbl.Text = "Gemeente of postcode kolom: \r\n";
            // 
            // sepLbl
            // 
            this.sepLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sepLbl.AutoSize = true;
            this.sepLbl.Location = new System.Drawing.Point(587, 59);
            this.sepLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sepLbl.Name = "sepLbl";
            this.sepLbl.Size = new System.Drawing.Size(79, 17);
            this.sepLbl.TabIndex = 10;
            this.sepLbl.Text = "Separator: ";
            // 
            // sepCbx
            // 
            this.sepCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sepCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sepCbx.FormattingEnabled = true;
            this.sepCbx.Items.AddRange(new object[] {
            "Puntcomma",
            "Comma",
            "Spatie",
            "Tab",
            "Ander teken"});
            this.sepCbx.Location = new System.Drawing.Point(674, 54);
            this.sepCbx.Margin = new System.Windows.Forms.Padding(4);
            this.sepCbx.Name = "sepCbx";
            this.sepCbx.Size = new System.Drawing.Size(143, 24);
            this.sepCbx.TabIndex = 11;
            this.sepCbx.SelectedIndexChanged += new System.EventHandler(this.sepCbx_SelectedIndexChanged);
            // 
            // otherSepBox
            // 
            this.otherSepBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.otherSepBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otherSepBox.Location = new System.Drawing.Point(834, 55);
            this.otherSepBox.Margin = new System.Windows.Forms.Padding(4);
            this.otherSepBox.Name = "otherSepBox";
            this.otherSepBox.ReadOnly = true;
            this.otherSepBox.Size = new System.Drawing.Size(27, 26);
            this.otherSepBox.TabIndex = 12;
            // 
            // validationWorker
            // 
            this.validationWorker.WorkerReportsProgress = true;
            this.validationWorker.WorkerSupportsCancellation = true;
            this.validationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.validationWorker_DoWork);
            this.validationWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.validationWorker_ProgressChanged);
            this.validationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.validationWorker_RunWorkerCompleted);
            // 
            // csvBox
            // 
            this.csvBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.csvBox.Controls.Add(this.encodingCbx);
            this.csvBox.Controls.Add(this.csvErrorLbl);
            this.csvBox.Controls.Add(this.otherSepBox);
            this.csvBox.Controls.Add(this.csvPathTxt);
            this.csvBox.Controls.Add(this.sepCbx);
            this.csvBox.Controls.Add(this.openBtn);
            this.csvBox.Controls.Add(this.sepLbl);
            this.csvBox.Location = new System.Drawing.Point(16, 5);
            this.csvBox.Margin = new System.Windows.Forms.Padding(4);
            this.csvBox.MinimumSize = new System.Drawing.Size(400, 92);
            this.csvBox.Name = "csvBox";
            this.csvBox.Padding = new System.Windows.Forms.Padding(4);
            this.csvBox.Size = new System.Drawing.Size(875, 92);
            this.csvBox.TabIndex = 0;
            this.csvBox.TabStop = false;
            this.csvBox.Text = "CSV instellingen";
            // 
            // encodingCbx
            // 
            this.encodingCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.encodingCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encodingCbx.FormattingEnabled = true;
            this.encodingCbx.Items.AddRange(new object[] {
            "ANSI",
            "UTF-8"});
            this.encodingCbx.Location = new System.Drawing.Point(764, 20);
            this.encodingCbx.Name = "encodingCbx";
            this.encodingCbx.Size = new System.Drawing.Size(102, 24);
            this.encodingCbx.TabIndex = 14;
            // 
            // csvErrorLbl
            // 
            this.csvErrorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.csvErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.csvErrorLbl.Location = new System.Drawing.Point(8, 52);
            this.csvErrorLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.csvErrorLbl.Name = "csvErrorLbl";
            this.csvErrorLbl.Size = new System.Drawing.Size(571, 37);
            this.csvErrorLbl.TabIndex = 13;
            // 
            // add2mapBtn
            // 
            this.add2mapBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.add2mapBtn.Location = new System.Drawing.Point(495, 550);
            this.add2mapBtn.Margin = new System.Windows.Forms.Padding(4);
            this.add2mapBtn.Name = "add2mapBtn";
            this.add2mapBtn.Size = new System.Drawing.Size(278, 28);
            this.add2mapBtn.TabIndex = 10;
            this.add2mapBtn.Text = "Voeg alle gevalideerde adressen toe";
            this.add2mapBtn.UseVisualStyleBackColor = true;
            this.add2mapBtn.Click += new System.EventHandler(this.add2mapBtn_Click);
            // 
            // batchGeocodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(907, 622);
            this.Controls.Add(this.add2mapBtn);
            this.Controls.Add(this.csvBox);
            this.Controls.Add(this.adresSettingsBox);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(450, 485);
            this.Name = "batchGeocodeForm";
            this.Text = "CSV-adresbestanden geocoderen";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.gridPanel.ResumeLayout(false);
            this.gridPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csvDataGrid)).EndInit();
            this.gridTools.ResumeLayout(false);
            this.gridTools.PerformLayout();
            this.adresSettingsBox.ResumeLayout(false);
            this.adresSettingsBox.PerformLayout();
            this.csvBox.ResumeLayout(false);
            this.csvBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel msgLbl;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel helpLbl;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGridView csvDataGrid;
        private System.Windows.Forms.ToolStrip gridTools;
        private System.Windows.Forms.OpenFileDialog openCSVDlg;
        private System.Windows.Forms.TextBox csvPathTxt;
        private System.Windows.Forms.ToolStripButton validateAllBtn;
        private System.Windows.Forms.Label adresColLbl;
        private System.Windows.Forms.ComboBox adresColCbx;
        private System.Windows.Forms.GroupBox adresSettingsBox;
        private System.Windows.Forms.ComboBox HuisNrCbx;
        private System.Windows.Forms.Label huisNrColLbl;
        private System.Windows.Forms.ComboBox gemeenteColCbx;
        private System.Windows.Forms.Label GemeenteColLbl;
        private System.Windows.Forms.Label sepLbl;
        private System.Windows.Forms.ComboBox sepCbx;
        private System.Windows.Forms.RadioButton multiColAdresRadio;
        private System.Windows.Forms.RadioButton singleColAdresRadio;
        private System.Windows.Forms.TextBox otherSepBox;
        private System.Windows.Forms.ToolStripButton validateSelBtn;
        private System.ComponentModel.BackgroundWorker validationWorker;
        private System.Windows.Forms.GroupBox csvBox;
        private System.Windows.Forms.Label csvErrorLbl;
        private System.Windows.Forms.Button add2mapBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton manualLocBtn;
        private System.Windows.Forms.ToolStripButton zoom2selBtn;
        private System.Windows.Forms.ToolStripButton cancelValidationBtn;
        private System.Windows.Forms.ComboBox encodingCbx;
    }
}