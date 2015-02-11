namespace geopunt4Arcgis 
{
    partial class capakeyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(capakeyForm));
            this.gemeenteLbl = new System.Windows.Forms.Label();
            this.gemeenteCbx = new System.Windows.Forms.ComboBox();
            this.departementCbx = new System.Windows.Forms.ComboBox();
            this.departementLbl = new System.Windows.Forms.Label();
            this.sectieCbx = new System.Windows.Forms.ComboBox();
            this.sectieLbl = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.msgLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.helpLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.parcelCbx = new System.Windows.Forms.ComboBox();
            this.parcelLbl = new System.Windows.Forms.Label();
            this.gemeenteZoomBtn = new System.Windows.Forms.Button();
            this.departementZoomBtn = new System.Windows.Forms.Button();
            this.sectieZoomBtn = new System.Windows.Forms.Button();
            this.parcelZoomBtn = new System.Windows.Forms.Button();
            this.add2mapBtn = new System.Windows.Forms.Button();
            this.addMarkerBtn = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gemeenteLbl
            // 
            this.gemeenteLbl.AutoSize = true;
            this.gemeenteLbl.Location = new System.Drawing.Point(45, 36);
            this.gemeenteLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gemeenteLbl.Name = "gemeenteLbl";
            this.gemeenteLbl.Size = new System.Drawing.Size(78, 17);
            this.gemeenteLbl.TabIndex = 0;
            this.gemeenteLbl.Text = "Gemeente:";
            // 
            // gemeenteCbx
            // 
            this.gemeenteCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gemeenteCbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.gemeenteCbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gemeenteCbx.FormattingEnabled = true;
            this.gemeenteCbx.Location = new System.Drawing.Point(132, 36);
            this.gemeenteCbx.Margin = new System.Windows.Forms.Padding(4);
            this.gemeenteCbx.Name = "gemeenteCbx";
            this.gemeenteCbx.Size = new System.Drawing.Size(417, 24);
            this.gemeenteCbx.TabIndex = 1;
            this.gemeenteCbx.SelectedIndexChanged += new System.EventHandler(this.gemeenteCbx_SelectedIndexChanged);
            // 
            // departementCbx
            // 
            this.departementCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.departementCbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.departementCbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.departementCbx.FormattingEnabled = true;
            this.departementCbx.Location = new System.Drawing.Point(132, 81);
            this.departementCbx.Margin = new System.Windows.Forms.Padding(4);
            this.departementCbx.Name = "departementCbx";
            this.departementCbx.Size = new System.Drawing.Size(417, 24);
            this.departementCbx.TabIndex = 3;
            this.departementCbx.SelectedIndexChanged += new System.EventHandler(this.departementCbx_SelectedIndexChanged);
            // 
            // departementLbl
            // 
            this.departementLbl.AutoSize = true;
            this.departementLbl.Location = new System.Drawing.Point(29, 81);
            this.departementLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.departementLbl.Name = "departementLbl";
            this.departementLbl.Size = new System.Drawing.Size(94, 17);
            this.departementLbl.TabIndex = 2;
            this.departementLbl.Text = "Departement:";
            // 
            // sectieCbx
            // 
            this.sectieCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sectieCbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sectieCbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sectieCbx.FormattingEnabled = true;
            this.sectieCbx.Location = new System.Drawing.Point(132, 127);
            this.sectieCbx.Margin = new System.Windows.Forms.Padding(4);
            this.sectieCbx.Name = "sectieCbx";
            this.sectieCbx.Size = new System.Drawing.Size(417, 24);
            this.sectieCbx.TabIndex = 5;
            this.sectieCbx.SelectedIndexChanged += new System.EventHandler(this.sectieCbx_SelectedIndexChanged);
            // 
            // sectieLbl
            // 
            this.sectieLbl.AutoSize = true;
            this.sectieLbl.Location = new System.Drawing.Point(71, 127);
            this.sectieLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sectieLbl.Name = "sectieLbl";
            this.sectieLbl.Size = new System.Drawing.Size(51, 17);
            this.sectieLbl.TabIndex = 4;
            this.sectieLbl.Text = "Sectie:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msgLbl,
            this.helpLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 258);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(636, 23);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // msgLbl
            // 
            this.msgLbl.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.msgLbl.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(580, 18);
            this.msgLbl.Spring = true;
            // 
            // helpLbl
            // 
            this.helpLbl.IsLink = true;
            this.helpLbl.Name = "helpLbl";
            this.helpLbl.Size = new System.Drawing.Size(36, 18);
            this.helpLbl.Text = "Help";
            this.helpLbl.Click += new System.EventHandler(this.helpLbl_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(515, 215);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(105, 28);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Sluiten";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // parcelCbx
            // 
            this.parcelCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.parcelCbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.parcelCbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.parcelCbx.FormattingEnabled = true;
            this.parcelCbx.Location = new System.Drawing.Point(132, 171);
            this.parcelCbx.Margin = new System.Windows.Forms.Padding(4);
            this.parcelCbx.Name = "parcelCbx";
            this.parcelCbx.Size = new System.Drawing.Size(417, 24);
            this.parcelCbx.TabIndex = 9;
            this.parcelCbx.SelectedIndexChanged += new System.EventHandler(this.parcelCbx_SelectedIndexChanged);
            // 
            // parcelLbl
            // 
            this.parcelLbl.AutoSize = true;
            this.parcelLbl.Location = new System.Drawing.Point(13, 171);
            this.parcelLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.parcelLbl.Name = "parcelLbl";
            this.parcelLbl.Size = new System.Drawing.Size(111, 17);
            this.parcelLbl.TabIndex = 8;
            this.parcelLbl.Text = "Perceelnummer:";
            // 
            // gemeenteZoomBtn
            // 
            this.gemeenteZoomBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gemeenteZoomBtn.Image = ((System.Drawing.Image)(resources.GetObject("gemeenteZoomBtn.Image")));
            this.gemeenteZoomBtn.Location = new System.Drawing.Point(561, 36);
            this.gemeenteZoomBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gemeenteZoomBtn.Name = "gemeenteZoomBtn";
            this.gemeenteZoomBtn.Size = new System.Drawing.Size(59, 26);
            this.gemeenteZoomBtn.TabIndex = 10;
            this.gemeenteZoomBtn.UseVisualStyleBackColor = true;
            this.gemeenteZoomBtn.Click += new System.EventHandler(this.gemeenteZoomBtn_Click);
            // 
            // departementZoomBtn
            // 
            this.departementZoomBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.departementZoomBtn.Image = ((System.Drawing.Image)(resources.GetObject("departementZoomBtn.Image")));
            this.departementZoomBtn.Location = new System.Drawing.Point(561, 81);
            this.departementZoomBtn.Margin = new System.Windows.Forms.Padding(4);
            this.departementZoomBtn.Name = "departementZoomBtn";
            this.departementZoomBtn.Size = new System.Drawing.Size(59, 26);
            this.departementZoomBtn.TabIndex = 11;
            this.departementZoomBtn.UseVisualStyleBackColor = true;
            this.departementZoomBtn.Click += new System.EventHandler(this.departementZoomBtn_Click);
            // 
            // sectieZoomBtn
            // 
            this.sectieZoomBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sectieZoomBtn.Image = ((System.Drawing.Image)(resources.GetObject("sectieZoomBtn.Image")));
            this.sectieZoomBtn.Location = new System.Drawing.Point(561, 126);
            this.sectieZoomBtn.Margin = new System.Windows.Forms.Padding(4);
            this.sectieZoomBtn.Name = "sectieZoomBtn";
            this.sectieZoomBtn.Size = new System.Drawing.Size(59, 26);
            this.sectieZoomBtn.TabIndex = 12;
            this.sectieZoomBtn.UseVisualStyleBackColor = true;
            this.sectieZoomBtn.Click += new System.EventHandler(this.sectieZoomBtn_Click);
            // 
            // parcelZoomBtn
            // 
            this.parcelZoomBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.parcelZoomBtn.Image = ((System.Drawing.Image)(resources.GetObject("parcelZoomBtn.Image")));
            this.parcelZoomBtn.Location = new System.Drawing.Point(561, 170);
            this.parcelZoomBtn.Margin = new System.Windows.Forms.Padding(4);
            this.parcelZoomBtn.Name = "parcelZoomBtn";
            this.parcelZoomBtn.Size = new System.Drawing.Size(59, 26);
            this.parcelZoomBtn.TabIndex = 13;
            this.parcelZoomBtn.UseVisualStyleBackColor = true;
            this.parcelZoomBtn.Click += new System.EventHandler(this.parcelZoomBtn_Click);
            // 
            // add2mapBtn
            // 
            this.add2mapBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.add2mapBtn.Location = new System.Drawing.Point(267, 215);
            this.add2mapBtn.Margin = new System.Windows.Forms.Padding(4);
            this.add2mapBtn.Name = "add2mapBtn";
            this.add2mapBtn.Size = new System.Drawing.Size(100, 28);
            this.add2mapBtn.TabIndex = 14;
            this.add2mapBtn.Text = "Opslaan";
            this.add2mapBtn.UseVisualStyleBackColor = true;
            this.add2mapBtn.Click += new System.EventHandler(this.add2mapBtn_Click);
            // 
            // addMarkerBtn
            // 
            this.addMarkerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addMarkerBtn.Location = new System.Drawing.Point(375, 215);
            this.addMarkerBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addMarkerBtn.Name = "addMarkerBtn";
            this.addMarkerBtn.Size = new System.Drawing.Size(132, 28);
            this.addMarkerBtn.TabIndex = 15;
            this.addMarkerBtn.Text = "Markeer Locatie";
            this.addMarkerBtn.UseVisualStyleBackColor = true;
            this.addMarkerBtn.Click += new System.EventHandler(this.addMarkerBtn_Click);
            // 
            // capakeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 281);
            this.Controls.Add(this.addMarkerBtn);
            this.Controls.Add(this.add2mapBtn);
            this.Controls.Add(this.parcelZoomBtn);
            this.Controls.Add(this.sectieZoomBtn);
            this.Controls.Add(this.departementZoomBtn);
            this.Controls.Add(this.gemeenteZoomBtn);
            this.Controls.Add(this.parcelCbx);
            this.Controls.Add(this.parcelLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.sectieCbx);
            this.Controls.Add(this.sectieLbl);
            this.Controls.Add(this.departementCbx);
            this.Controls.Add(this.departementLbl);
            this.Controls.Add(this.gemeenteCbx);
            this.Controls.Add(this.gemeenteLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(797, 313);
            this.MinimumSize = new System.Drawing.Size(397, 313);
            this.Name = "capakeyForm";
            this.Text = "Zoek een perceel";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gemeenteLbl;
        private System.Windows.Forms.ComboBox gemeenteCbx;
        private System.Windows.Forms.ComboBox departementCbx;
        private System.Windows.Forms.Label departementLbl;
        private System.Windows.Forms.ComboBox sectieCbx;
        private System.Windows.Forms.Label sectieLbl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel msgLbl;
        private System.Windows.Forms.ToolStripStatusLabel helpLbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox parcelCbx;
        private System.Windows.Forms.Label parcelLbl;
        private System.Windows.Forms.Button gemeenteZoomBtn;
        private System.Windows.Forms.Button departementZoomBtn;
        private System.Windows.Forms.Button sectieZoomBtn;
        private System.Windows.Forms.Button parcelZoomBtn;
        private System.Windows.Forms.Button add2mapBtn;
        private System.Windows.Forms.Button addMarkerBtn;
    }
}