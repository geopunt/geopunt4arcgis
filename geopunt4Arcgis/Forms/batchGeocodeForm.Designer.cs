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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.gridTools = new System.Windows.Forms.ToolStrip();
            this.validateAllBtn = new System.Windows.Forms.ToolStripButton();
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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusBar.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.gridTools.SuspendLayout();
            this.adresSettingsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msgLbl,
            this.progressBar,
            this.helpLbl});
            this.statusBar.Location = new System.Drawing.Point(0, 480);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(532, 22);
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
            this.msgLbl.Size = new System.Drawing.Size(387, 17);
            this.msgLbl.Spring = true;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // helpLbl
            // 
            this.helpLbl.IsLink = true;
            this.helpLbl.Name = "helpLbl";
            this.helpLbl.Size = new System.Drawing.Size(28, 17);
            this.helpLbl.Text = "Help";
            this.helpLbl.Click += new System.EventHandler(this.helpLbl_Click);
            // 
            // openBtn
            // 
            this.openBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openBtn.Location = new System.Drawing.Point(445, 12);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 2;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(445, 454);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
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
            this.gridPanel.Controls.Add(this.dataGrid);
            this.gridPanel.Controls.Add(this.gridTools);
            this.gridPanel.Location = new System.Drawing.Point(12, 195);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(508, 253);
            this.gridPanel.TabIndex = 5;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 25);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(508, 228);
            this.dataGrid.TabIndex = 6;
            // 
            // gridTools
            // 
            this.gridTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validateAllBtn,
            this.toolStripButton1});
            this.gridTools.Location = new System.Drawing.Point(0, 0);
            this.gridTools.Name = "gridTools";
            this.gridTools.Size = new System.Drawing.Size(508, 25);
            this.gridTools.TabIndex = 5;
            this.gridTools.Text = "toolStrip1";
            // 
            // validateAllBtn
            // 
            this.validateAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("validateAllBtn.Image")));
            this.validateAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.validateAllBtn.Name = "validateAllBtn";
            this.validateAllBtn.Size = new System.Drawing.Size(89, 22);
            this.validateAllBtn.Text = "Valideer alles";
            this.validateAllBtn.ToolTipText = "Valideer alle records";
            // 
            // openCSVDlg
            // 
            this.openCSVDlg.DefaultExt = "csv";
            this.openCSVDlg.Filter = "\"CSV-file(*.csv)|*.csv|Text-file(*.txt)|*.txt|All Files(*.*)|*.*\"";
            this.openCSVDlg.RestoreDirectory = true;
            // 
            // csvPathTxt
            // 
            this.csvPathTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.csvPathTxt.Location = new System.Drawing.Point(12, 12);
            this.csvPathTxt.Name = "csvPathTxt";
            this.csvPathTxt.ReadOnly = true;
            this.csvPathTxt.Size = new System.Drawing.Size(427, 20);
            this.csvPathTxt.TabIndex = 6;
            this.csvPathTxt.Text = "< input CSV-file >";
            this.csvPathTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // adresColLbl
            // 
            this.adresColLbl.AutoSize = true;
            this.adresColLbl.Location = new System.Drawing.Point(6, 45);
            this.adresColLbl.Name = "adresColLbl";
            this.adresColLbl.Size = new System.Drawing.Size(72, 13);
            this.adresColLbl.TabIndex = 7;
            this.adresColLbl.Text = "Straat kolom: ";
            // 
            // adresColCbx
            // 
            this.adresColCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adresColCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adresColCbx.FormattingEnabled = true;
            this.adresColCbx.Location = new System.Drawing.Point(105, 42);
            this.adresColCbx.Name = "adresColCbx";
            this.adresColCbx.Size = new System.Drawing.Size(397, 21);
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
            this.adresSettingsBox.Location = new System.Drawing.Point(12, 66);
            this.adresSettingsBox.Name = "adresSettingsBox";
            this.adresSettingsBox.Size = new System.Drawing.Size(508, 123);
            this.adresSettingsBox.TabIndex = 9;
            this.adresSettingsBox.TabStop = false;
            this.adresSettingsBox.Text = "Adres Instellingen";
            // 
            // singleColAdresRadio
            // 
            this.singleColAdresRadio.AutoSize = true;
            this.singleColAdresRadio.Location = new System.Drawing.Point(168, 19);
            this.singleColAdresRadio.Name = "singleColAdresRadio";
            this.singleColAdresRadio.Size = new System.Drawing.Size(91, 17);
            this.singleColAdresRadio.TabIndex = 14;
            this.singleColAdresRadio.Text = "Adres op 1 lijn";
            this.singleColAdresRadio.UseVisualStyleBackColor = true;
            this.singleColAdresRadio.CheckedChanged += new System.EventHandler(this.adresRadio_CheckedChanged);
            // 
            // multiColAdresRadio
            // 
            this.multiColAdresRadio.AutoSize = true;
            this.multiColAdresRadio.Checked = true;
            this.multiColAdresRadio.Location = new System.Drawing.Point(9, 19);
            this.multiColAdresRadio.Name = "multiColAdresRadio";
            this.multiColAdresRadio.Size = new System.Drawing.Size(153, 17);
            this.multiColAdresRadio.TabIndex = 13;
            this.multiColAdresRadio.TabStop = true;
            this.multiColAdresRadio.Text = "Adres in meerdere kolomen";
            this.multiColAdresRadio.UseVisualStyleBackColor = true;
            this.multiColAdresRadio.CheckedChanged += new System.EventHandler(this.adresRadio_CheckedChanged);
            // 
            // HuisNrCbx
            // 
            this.HuisNrCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HuisNrCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HuisNrCbx.FormattingEnabled = true;
            this.HuisNrCbx.Location = new System.Drawing.Point(105, 69);
            this.HuisNrCbx.Name = "HuisNrCbx";
            this.HuisNrCbx.Size = new System.Drawing.Size(397, 21);
            this.HuisNrCbx.TabIndex = 12;
            // 
            // huisNrColLbl
            // 
            this.huisNrColLbl.AutoSize = true;
            this.huisNrColLbl.Location = new System.Drawing.Point(6, 72);
            this.huisNrColLbl.Name = "huisNrColLbl";
            this.huisNrColLbl.Size = new System.Drawing.Size(102, 13);
            this.huisNrColLbl.TabIndex = 11;
            this.huisNrColLbl.Text = "Huisnummer kolom: ";
            // 
            // gemeenteColCbx
            // 
            this.gemeenteColCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gemeenteColCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gemeenteColCbx.FormattingEnabled = true;
            this.gemeenteColCbx.Location = new System.Drawing.Point(105, 96);
            this.gemeenteColCbx.Name = "gemeenteColCbx";
            this.gemeenteColCbx.Size = new System.Drawing.Size(397, 21);
            this.gemeenteColCbx.TabIndex = 10;
            // 
            // GemeenteColLbl
            // 
            this.GemeenteColLbl.AutoSize = true;
            this.GemeenteColLbl.Location = new System.Drawing.Point(6, 99);
            this.GemeenteColLbl.Name = "GemeenteColLbl";
            this.GemeenteColLbl.Size = new System.Drawing.Size(93, 13);
            this.GemeenteColLbl.TabIndex = 9;
            this.GemeenteColLbl.Text = "Gemeente kolom: ";
            // 
            // sepLbl
            // 
            this.sepLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sepLbl.AutoSize = true;
            this.sepLbl.Location = new System.Drawing.Point(278, 45);
            this.sepLbl.Name = "sepLbl";
            this.sepLbl.Size = new System.Drawing.Size(59, 13);
            this.sepLbl.TabIndex = 10;
            this.sepLbl.Text = "Separator: ";
            // 
            // sepCbx
            // 
            this.sepCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sepCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sepCbx.FormattingEnabled = true;
            this.sepCbx.Items.AddRange(new object[] {
            "PUNTCOMMA",
            "COMMA",
            "SPATIE",
            "TAB",
            "ANDER TEKEN"});
            this.sepCbx.Location = new System.Drawing.Point(353, 42);
            this.sepCbx.Name = "sepCbx";
            this.sepCbx.Size = new System.Drawing.Size(121, 21);
            this.sepCbx.TabIndex = 11;
            this.sepCbx.SelectedIndexChanged += new System.EventHandler(this.sepCbx_SelectedIndexChanged);
            // 
            // otherSepBox
            // 
            this.otherSepBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.otherSepBox.Location = new System.Drawing.Point(480, 43);
            this.otherSepBox.Name = "otherSepBox";
            this.otherSepBox.ReadOnly = true;
            this.otherSepBox.Size = new System.Drawing.Size(34, 20);
            this.otherSepBox.TabIndex = 12;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(104, 22);
            this.toolStripButton1.Text = "Valideer selectie";
            this.toolStripButton1.ToolTipText = "Valideer alleen de geselecteerde records";
            // 
            // batchGeocodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(532, 502);
            this.Controls.Add(this.otherSepBox);
            this.Controls.Add(this.sepCbx);
            this.Controls.Add(this.sepLbl);
            this.Controls.Add(this.adresSettingsBox);
            this.Controls.Add(this.csvPathTxt);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "batchGeocodeForm";
            this.Text = "batchGeocodeForm";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.gridPanel.ResumeLayout(false);
            this.gridPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.gridTools.ResumeLayout(false);
            this.gridTools.PerformLayout();
            this.adresSettingsBox.ResumeLayout(false);
            this.adresSettingsBox.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGrid;
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
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}