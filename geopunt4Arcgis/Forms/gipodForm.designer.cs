namespace geopunt4Arcgis
{
    partial class gipodForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gipodForm));
            this.cityCombo = new System.Windows.Forms.ComboBox();
            this.provinceCombo = new System.Windows.Forms.ComboBox();
            this.citylbl = new System.Windows.Forms.Label();
            this.provinceLbl = new System.Windows.Forms.Label();
            this.startdatePicker = new System.Windows.Forms.DateTimePicker();
            this.enddatePicker = new System.Windows.Forms.DateTimePicker();
            this.ownerCombo = new System.Windows.Forms.ComboBox();
            this.startdateLbl = new System.Windows.Forms.Label();
            this.enddatelbl = new System.Windows.Forms.Label();
            this.ownerLbl = new System.Windows.Forms.Label();
            this.eventtypeLbl = new System.Windows.Forms.Label();
            this.eventTypeCombo = new System.Windows.Forms.ComboBox();
            this.gipodTypeGroup = new System.Windows.Forms.GroupBox();
            this.manifestationRadio = new System.Windows.Forms.RadioButton();
            this.workassignmentRadio = new System.Windows.Forms.RadioButton();
            this.closeBtn = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.messageLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.HelpLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.useExtendChk = new System.Windows.Forms.CheckBox();
            this.saveAsShapeBtn = new System.Windows.Forms.Button();
            this.gipodTypeGroup.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // cityCombo
            // 
            this.cityCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cityCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cityCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cityCombo.FormattingEnabled = true;
            this.cityCombo.Location = new System.Drawing.Point(106, 100);
            this.cityCombo.Name = "cityCombo";
            this.cityCombo.Size = new System.Drawing.Size(392, 21);
            this.cityCombo.TabIndex = 0;
            // 
            // provinceCombo
            // 
            this.provinceCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.provinceCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.provinceCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.provinceCombo.FormattingEnabled = true;
            this.provinceCombo.Location = new System.Drawing.Point(106, 73);
            this.provinceCombo.Name = "provinceCombo";
            this.provinceCombo.Size = new System.Drawing.Size(392, 21);
            this.provinceCombo.TabIndex = 1;
            this.provinceCombo.SelectedIndexChanged += new System.EventHandler(this.provinceCombo_SelectedIndexChanged);
            // 
            // citylbl
            // 
            this.citylbl.AutoSize = true;
            this.citylbl.Location = new System.Drawing.Point(68, 103);
            this.citylbl.Name = "citylbl";
            this.citylbl.Size = new System.Drawing.Size(32, 13);
            this.citylbl.TabIndex = 2;
            this.citylbl.Text = "Stad:";
            // 
            // provinceLbl
            // 
            this.provinceLbl.AutoSize = true;
            this.provinceLbl.Location = new System.Drawing.Point(46, 76);
            this.provinceLbl.Name = "provinceLbl";
            this.provinceLbl.Size = new System.Drawing.Size(54, 13);
            this.provinceLbl.TabIndex = 3;
            this.provinceLbl.Text = "Provincie:";
            // 
            // startdatePicker
            // 
            this.startdatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startdatePicker.Location = new System.Drawing.Point(106, 192);
            this.startdatePicker.Name = "startdatePicker";
            this.startdatePicker.Size = new System.Drawing.Size(392, 20);
            this.startdatePicker.TabIndex = 4;
            // 
            // enddatePicker
            // 
            this.enddatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enddatePicker.Location = new System.Drawing.Point(106, 218);
            this.enddatePicker.Name = "enddatePicker";
            this.enddatePicker.Size = new System.Drawing.Size(392, 20);
            this.enddatePicker.TabIndex = 5;
            this.enddatePicker.ValueChanged += new System.EventHandler(this.enddatePicker_ValueChanged);
            // 
            // ownerCombo
            // 
            this.ownerCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ownerCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ownerCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ownerCombo.FormattingEnabled = true;
            this.ownerCombo.Location = new System.Drawing.Point(106, 129);
            this.ownerCombo.Name = "ownerCombo";
            this.ownerCombo.Size = new System.Drawing.Size(392, 21);
            this.ownerCombo.TabIndex = 6;
            // 
            // startdateLbl
            // 
            this.startdateLbl.AutoSize = true;
            this.startdateLbl.Location = new System.Drawing.Point(39, 192);
            this.startdateLbl.Name = "startdateLbl";
            this.startdateLbl.Size = new System.Drawing.Size(61, 13);
            this.startdateLbl.TabIndex = 7;
            this.startdateLbl.Text = "Startdatum:";
            // 
            // enddatelbl
            // 
            this.enddatelbl.AutoSize = true;
            this.enddatelbl.Location = new System.Drawing.Point(39, 218);
            this.enddatelbl.Name = "enddatelbl";
            this.enddatelbl.Size = new System.Drawing.Size(60, 13);
            this.enddatelbl.TabIndex = 8;
            this.enddatelbl.Text = "Einddatum:";
            // 
            // ownerLbl
            // 
            this.ownerLbl.AutoSize = true;
            this.ownerLbl.Location = new System.Drawing.Point(48, 132);
            this.ownerLbl.Name = "ownerLbl";
            this.ownerLbl.Size = new System.Drawing.Size(52, 13);
            this.ownerLbl.TabIndex = 9;
            this.ownerLbl.Text = "Eigenaar:";
            // 
            // eventtypeLbl
            // 
            this.eventtypeLbl.AutoSize = true;
            this.eventtypeLbl.Location = new System.Drawing.Point(7, 162);
            this.eventtypeLbl.Name = "eventtypeLbl";
            this.eventtypeLbl.Size = new System.Drawing.Size(93, 13);
            this.eventtypeLbl.TabIndex = 10;
            this.eventtypeLbl.Text = "Type manifestatie:";
            // 
            // eventTypeCombo
            // 
            this.eventTypeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventTypeCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.eventTypeCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.eventTypeCombo.Enabled = false;
            this.eventTypeCombo.FormattingEnabled = true;
            this.eventTypeCombo.Location = new System.Drawing.Point(106, 159);
            this.eventTypeCombo.Name = "eventTypeCombo";
            this.eventTypeCombo.Size = new System.Drawing.Size(392, 21);
            this.eventTypeCombo.TabIndex = 11;
            // 
            // gipodTypeGroup
            // 
            this.gipodTypeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gipodTypeGroup.Controls.Add(this.manifestationRadio);
            this.gipodTypeGroup.Controls.Add(this.workassignmentRadio);
            this.gipodTypeGroup.Location = new System.Drawing.Point(10, 13);
            this.gipodTypeGroup.Name = "gipodTypeGroup";
            this.gipodTypeGroup.Size = new System.Drawing.Size(488, 51);
            this.gipodTypeGroup.TabIndex = 12;
            this.gipodTypeGroup.TabStop = false;
            this.gipodTypeGroup.Text = "Type";
            // 
            // manifestationRadio
            // 
            this.manifestationRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.manifestationRadio.AutoSize = true;
            this.manifestationRadio.Location = new System.Drawing.Point(234, 19);
            this.manifestationRadio.Name = "manifestationRadio";
            this.manifestationRadio.Size = new System.Drawing.Size(82, 17);
            this.manifestationRadio.TabIndex = 1;
            this.manifestationRadio.Text = "Manifestatie";
            this.manifestationRadio.UseVisualStyleBackColor = true;
            // 
            // workassignmentRadio
            // 
            this.workassignmentRadio.AutoSize = true;
            this.workassignmentRadio.Checked = true;
            this.workassignmentRadio.Location = new System.Drawing.Point(32, 19);
            this.workassignmentRadio.Name = "workassignmentRadio";
            this.workassignmentRadio.Size = new System.Drawing.Size(93, 17);
            this.workassignmentRadio.TabIndex = 0;
            this.workassignmentRadio.TabStop = true;
            this.workassignmentRadio.Text = "Werkopdracht";
            this.workassignmentRadio.UseVisualStyleBackColor = true;
            this.workassignmentRadio.CheckedChanged += new System.EventHandler(this.workassignmentRadio_CheckedChanged);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(423, 264);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "Sluiten";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageLbl,
            this.progress,
            this.HelpLbl});
            this.statusBar.Location = new System.Drawing.Point(0, 301);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(510, 22);
            this.statusBar.TabIndex = 14;
            this.statusBar.Text = "statusStrip1";
            // 
            // messageLbl
            // 
            this.messageLbl.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.messageLbl.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(334, 17);
            this.messageLbl.Spring = true;
            this.messageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progress
            // 
            this.progress.MarqueeAnimationSpeed = 0;
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(100, 16);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // HelpLbl
            // 
            this.HelpLbl.IsLink = true;
            this.HelpLbl.Name = "HelpLbl";
            this.HelpLbl.Size = new System.Drawing.Size(28, 17);
            this.HelpLbl.Text = "Help";
            this.HelpLbl.Click += new System.EventHandler(this.HelpLbl_Click);
            // 
            // useExtendChk
            // 
            this.useExtendChk.AutoSize = true;
            this.useExtendChk.Location = new System.Drawing.Point(42, 244);
            this.useExtendChk.Name = "useExtendChk";
            this.useExtendChk.Size = new System.Drawing.Size(219, 17);
            this.useExtendChk.TabIndex = 15;
            this.useExtendChk.Text = "Beperk zoekresultaten tot huidige extend";
            this.useExtendChk.UseVisualStyleBackColor = true;
            // 
            // saveAsShapeBtn
            // 
            this.saveAsShapeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAsShapeBtn.Location = new System.Drawing.Point(333, 264);
            this.saveAsShapeBtn.Name = "saveAsShapeBtn";
            this.saveAsShapeBtn.Size = new System.Drawing.Size(84, 23);
            this.saveAsShapeBtn.TabIndex = 16;
            this.saveAsShapeBtn.Text = "Opslaan";
            this.saveAsShapeBtn.UseVisualStyleBackColor = true;
            this.saveAsShapeBtn.Click += new System.EventHandler(this.saveAsShapeBtn_Click);
            // 
            // gipodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(510, 323);
            this.Controls.Add(this.saveAsShapeBtn);
            this.Controls.Add(this.useExtendChk);
            this.Controls.Add(this.cityCombo);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.gipodTypeGroup);
            this.Controls.Add(this.eventTypeCombo);
            this.Controls.Add(this.eventtypeLbl);
            this.Controls.Add(this.ownerLbl);
            this.Controls.Add(this.enddatelbl);
            this.Controls.Add(this.startdateLbl);
            this.Controls.Add(this.ownerCombo);
            this.Controls.Add(this.enddatePicker);
            this.Controls.Add(this.startdatePicker);
            this.Controls.Add(this.provinceCombo);
            this.Controls.Add(this.provinceLbl);
            this.Controls.Add(this.citylbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1200, 350);
            this.MinimumSize = new System.Drawing.Size(420, 350);
            this.Name = "gipodForm";
            this.ShowInTaskbar = false;
            this.Text = "GIPOD";
            this.gipodTypeGroup.ResumeLayout(false);
            this.gipodTypeGroup.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cityCombo;
        private System.Windows.Forms.ComboBox provinceCombo;
        private System.Windows.Forms.Label citylbl;
        private System.Windows.Forms.Label provinceLbl;
        private System.Windows.Forms.DateTimePicker startdatePicker;
        private System.Windows.Forms.DateTimePicker enddatePicker;
        private System.Windows.Forms.ComboBox ownerCombo;
        private System.Windows.Forms.Label startdateLbl;
        private System.Windows.Forms.Label enddatelbl;
        private System.Windows.Forms.Label ownerLbl;
        private System.Windows.Forms.Label eventtypeLbl;
        private System.Windows.Forms.ComboBox eventTypeCombo;
        private System.Windows.Forms.GroupBox gipodTypeGroup;
        private System.Windows.Forms.RadioButton workassignmentRadio;
        private System.Windows.Forms.RadioButton manifestationRadio;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel messageLbl;
        private System.Windows.Forms.CheckBox useExtendChk;
        private System.Windows.Forms.Button saveAsShapeBtn;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.Windows.Forms.ToolStripStatusLabel HelpLbl;
    }
}