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
            this.cityCombo.Location = new System.Drawing.Point(141, 123);
            this.cityCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cityCombo.Name = "cityCombo";
            this.cityCombo.Size = new System.Drawing.Size(521, 24);
            this.cityCombo.TabIndex = 0;
            // 
            // provinceCombo
            // 
            this.provinceCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.provinceCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.provinceCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.provinceCombo.FormattingEnabled = true;
            this.provinceCombo.Location = new System.Drawing.Point(141, 90);
            this.provinceCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.provinceCombo.Name = "provinceCombo";
            this.provinceCombo.Size = new System.Drawing.Size(521, 24);
            this.provinceCombo.TabIndex = 1;
            this.provinceCombo.SelectedIndexChanged += new System.EventHandler(this.provinceCombo_SelectedIndexChanged);
            // 
            // citylbl
            // 
            this.citylbl.AutoSize = true;
            this.citylbl.Location = new System.Drawing.Point(91, 127);
            this.citylbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.citylbl.Name = "citylbl";
            this.citylbl.Size = new System.Drawing.Size(41, 17);
            this.citylbl.TabIndex = 2;
            this.citylbl.Text = "Stad:";
            // 
            // provinceLbl
            // 
            this.provinceLbl.AutoSize = true;
            this.provinceLbl.Location = new System.Drawing.Point(61, 94);
            this.provinceLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.provinceLbl.Name = "provinceLbl";
            this.provinceLbl.Size = new System.Drawing.Size(70, 17);
            this.provinceLbl.TabIndex = 3;
            this.provinceLbl.Text = "Provincie:";
            // 
            // startdatePicker
            // 
            this.startdatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.startdatePicker.Location = new System.Drawing.Point(141, 236);
            this.startdatePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startdatePicker.Name = "startdatePicker";
            this.startdatePicker.Size = new System.Drawing.Size(521, 22);
            this.startdatePicker.TabIndex = 4;
            // 
            // enddatePicker
            // 
            this.enddatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.enddatePicker.Location = new System.Drawing.Point(141, 268);
            this.enddatePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enddatePicker.Name = "enddatePicker";
            this.enddatePicker.Size = new System.Drawing.Size(521, 22);
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
            this.ownerCombo.Location = new System.Drawing.Point(141, 159);
            this.ownerCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ownerCombo.Name = "ownerCombo";
            this.ownerCombo.Size = new System.Drawing.Size(521, 24);
            this.ownerCombo.TabIndex = 6;
            // 
            // startdateLbl
            // 
            this.startdateLbl.AutoSize = true;
            this.startdateLbl.Location = new System.Drawing.Point(52, 236);
            this.startdateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startdateLbl.Name = "startdateLbl";
            this.startdateLbl.Size = new System.Drawing.Size(81, 17);
            this.startdateLbl.TabIndex = 7;
            this.startdateLbl.Text = "Startdatum:";
            // 
            // enddatelbl
            // 
            this.enddatelbl.AutoSize = true;
            this.enddatelbl.Location = new System.Drawing.Point(52, 268);
            this.enddatelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enddatelbl.Name = "enddatelbl";
            this.enddatelbl.Size = new System.Drawing.Size(79, 17);
            this.enddatelbl.TabIndex = 8;
            this.enddatelbl.Text = "Einddatum:";
            // 
            // ownerLbl
            // 
            this.ownerLbl.AutoSize = true;
            this.ownerLbl.Location = new System.Drawing.Point(64, 162);
            this.ownerLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ownerLbl.Name = "ownerLbl";
            this.ownerLbl.Size = new System.Drawing.Size(69, 17);
            this.ownerLbl.TabIndex = 9;
            this.ownerLbl.Text = "Eigenaar:";
            // 
            // eventtypeLbl
            // 
            this.eventtypeLbl.AutoSize = true;
            this.eventtypeLbl.Location = new System.Drawing.Point(9, 199);
            this.eventtypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.eventtypeLbl.Name = "eventtypeLbl";
            this.eventtypeLbl.Size = new System.Drawing.Size(124, 17);
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
            this.eventTypeCombo.Location = new System.Drawing.Point(141, 196);
            this.eventTypeCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.eventTypeCombo.Name = "eventTypeCombo";
            this.eventTypeCombo.Size = new System.Drawing.Size(521, 24);
            this.eventTypeCombo.TabIndex = 11;
            // 
            // gipodTypeGroup
            // 
            this.gipodTypeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gipodTypeGroup.Controls.Add(this.manifestationRadio);
            this.gipodTypeGroup.Controls.Add(this.workassignmentRadio);
            this.gipodTypeGroup.Location = new System.Drawing.Point(13, 16);
            this.gipodTypeGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gipodTypeGroup.Name = "gipodTypeGroup";
            this.gipodTypeGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gipodTypeGroup.Size = new System.Drawing.Size(651, 63);
            this.gipodTypeGroup.TabIndex = 12;
            this.gipodTypeGroup.TabStop = false;
            this.gipodTypeGroup.Text = "Type";
            // 
            // manifestationRadio
            // 
            this.manifestationRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.manifestationRadio.AutoSize = true;
            this.manifestationRadio.Location = new System.Drawing.Point(316, 23);
            this.manifestationRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.manifestationRadio.Name = "manifestationRadio";
            this.manifestationRadio.Size = new System.Drawing.Size(105, 21);
            this.manifestationRadio.TabIndex = 1;
            this.manifestationRadio.Text = "Manifestatie";
            this.manifestationRadio.UseVisualStyleBackColor = true;
            // 
            // workassignmentRadio
            // 
            this.workassignmentRadio.AutoSize = true;
            this.workassignmentRadio.Checked = true;
            this.workassignmentRadio.Location = new System.Drawing.Point(43, 23);
            this.workassignmentRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.workassignmentRadio.Name = "workassignmentRadio";
            this.workassignmentRadio.Size = new System.Drawing.Size(118, 21);
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
            this.closeBtn.Location = new System.Drawing.Point(564, 325);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(100, 28);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "Sluiten";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageLbl,
            this.HelpLbl});
            this.statusBar.Location = new System.Drawing.Point(0, 368);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(680, 23);
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
            this.messageLbl.Size = new System.Drawing.Size(593, 18);
            this.messageLbl.Spring = true;
            this.messageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HelpLbl
            // 
            this.HelpLbl.IsLink = true;
            this.HelpLbl.Name = "HelpLbl";
            this.HelpLbl.Size = new System.Drawing.Size(36, 18);
            this.HelpLbl.Text = "Help";
            this.HelpLbl.Click += new System.EventHandler(this.HelpLbl_Click);
            // 
            // useExtendChk
            // 
            this.useExtendChk.AutoSize = true;
            this.useExtendChk.Location = new System.Drawing.Point(56, 300);
            this.useExtendChk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.useExtendChk.Name = "useExtendChk";
            this.useExtendChk.Size = new System.Drawing.Size(288, 21);
            this.useExtendChk.TabIndex = 15;
            this.useExtendChk.Text = "Beperk zoekresultaten tot huidige extend";
            this.useExtendChk.UseVisualStyleBackColor = true;
            // 
            // saveAsShapeBtn
            // 
            this.saveAsShapeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAsShapeBtn.Location = new System.Drawing.Point(444, 325);
            this.saveAsShapeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveAsShapeBtn.Name = "saveAsShapeBtn";
            this.saveAsShapeBtn.Size = new System.Drawing.Size(112, 28);
            this.saveAsShapeBtn.TabIndex = 16;
            this.saveAsShapeBtn.Text = "Opslaan";
            this.saveAsShapeBtn.UseVisualStyleBackColor = true;
            this.saveAsShapeBtn.Click += new System.EventHandler(this.saveAsShapeBtn_Click);
            // 
            // gipodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(680, 391);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1597, 423);
            this.MinimumSize = new System.Drawing.Size(557, 423);
            this.Name = "gipodForm";
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
        private System.Windows.Forms.ToolStripStatusLabel HelpLbl;
    }
}