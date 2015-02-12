namespace geopunt4Arcgis
{
    partial class elevationForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(elevationForm));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.msgLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.helpLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.drawLineBtn = new System.Windows.Forms.Button();
            this.profileGrp = new ZedGraph.ZedGraphControl();
            this.GraphPanel = new System.Windows.Forms.Panel();
            this.aantalSamplesNum = new System.Windows.Forms.Label();
            this.samplesNum = new System.Windows.Forms.NumericUpDown();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.profileToolBar = new System.Windows.Forms.ToolStrip();
            this.unZoomBtn = new System.Windows.Forms.ToolStripButton();
            this.prevZoomBtn = new System.Windows.Forms.ToolStripButton();
            this.PanActivateBtn = new System.Windows.Forms.ToolStripButton();
            this.zoomRectActivateBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.savePrfAsImageBtn = new System.Windows.Forms.ToolStripButton();
            this.setTitleBtn = new System.Windows.Forms.ToolStripButton();
            this.fillBtn = new System.Windows.Forms.ToolStripButton();
            this.symbolBtn = new System.Windows.Forms.ToolStripComboBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.addDhmBtn = new System.Windows.Forms.Button();
            this.savePointsBtn = new System.Windows.Forms.Button();
            this.saveLineBtn = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            this.GraphPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplesNum)).BeginInit();
            this.profileToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msgLbl,
            this.helpLink});
            this.statusBar.Location = new System.Drawing.Point(0, 475);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(715, 23);
            this.statusBar.TabIndex = 0;
            // 
            // msgLbl
            // 
            this.msgLbl.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.msgLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(664, 18);
            this.msgLbl.Spring = true;
            // 
            // helpLink
            // 
            this.helpLink.IsLink = true;
            this.helpLink.Name = "helpLink";
            this.helpLink.Size = new System.Drawing.Size(36, 18);
            this.helpLink.Text = "Help";
            this.helpLink.Click += new System.EventHandler(this.helpLink_Click);
            // 
            // drawLineBtn
            // 
            this.drawLineBtn.Location = new System.Drawing.Point(12, 12);
            this.drawLineBtn.Name = "drawLineBtn";
            this.drawLineBtn.Size = new System.Drawing.Size(183, 30);
            this.drawLineBtn.TabIndex = 1;
            this.drawLineBtn.Text = "Teken de profiellijn";
            this.drawLineBtn.UseVisualStyleBackColor = true;
            this.drawLineBtn.Click += new System.EventHandler(this.drawbtn_Click);
            // 
            // profileGrp
            // 
            this.profileGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.profileGrp.Location = new System.Drawing.Point(0, 0);
            this.profileGrp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.profileGrp.Name = "profileGrp";
            this.profileGrp.ScrollGrace = 0D;
            this.profileGrp.ScrollMaxX = 0D;
            this.profileGrp.ScrollMaxY = 0D;
            this.profileGrp.ScrollMaxY2 = 0D;
            this.profileGrp.ScrollMinX = 0D;
            this.profileGrp.ScrollMinY = 0D;
            this.profileGrp.ScrollMinY2 = 0D;
            this.profileGrp.Size = new System.Drawing.Size(691, 337);
            this.profileGrp.TabIndex = 2;
            this.profileGrp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.profileGrp_MouseMove);
            // 
            // GraphPanel
            // 
            this.GraphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphPanel.Controls.Add(this.aantalSamplesNum);
            this.GraphPanel.Controls.Add(this.samplesNum);
            this.GraphPanel.Controls.Add(this.refreshBtn);
            this.GraphPanel.Controls.Add(this.profileToolBar);
            this.GraphPanel.Controls.Add(this.profileGrp);
            this.GraphPanel.Location = new System.Drawing.Point(12, 48);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(691, 367);
            this.GraphPanel.TabIndex = 3;
            // 
            // aantalSamplesNum
            // 
            this.aantalSamplesNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aantalSamplesNum.AutoSize = true;
            this.aantalSamplesNum.Location = new System.Drawing.Point(424, 341);
            this.aantalSamplesNum.Name = "aantalSamplesNum";
            this.aantalSamplesNum.Size = new System.Drawing.Size(139, 17);
            this.aantalSamplesNum.TabIndex = 6;
            this.aantalSamplesNum.Text = "Aantal profielpunten:";
            // 
            // samplesNum
            // 
            this.samplesNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.samplesNum.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.samplesNum.Location = new System.Drawing.Point(569, 339);
            this.samplesNum.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.samplesNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.samplesNum.Name = "samplesNum";
            this.samplesNum.Size = new System.Drawing.Size(68, 22);
            this.samplesNum.TabIndex = 5;
            this.samplesNum.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshBtn.BackgroundImage")));
            this.refreshBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refreshBtn.Location = new System.Drawing.Point(643, 339);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(45, 24);
            this.refreshBtn.TabIndex = 4;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // profileToolBar
            // 
            this.profileToolBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.profileToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.profileToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.profileToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unZoomBtn,
            this.prevZoomBtn,
            this.PanActivateBtn,
            this.zoomRectActivateBtn,
            this.toolStripSeparator1,
            this.savePrfAsImageBtn,
            this.setTitleBtn,
            this.fillBtn,
            this.symbolBtn});
            this.profileToolBar.Location = new System.Drawing.Point(0, 337);
            this.profileToolBar.Name = "profileToolBar";
            this.profileToolBar.Padding = new System.Windows.Forms.Padding(2);
            this.profileToolBar.Size = new System.Drawing.Size(296, 30);
            this.profileToolBar.TabIndex = 3;
            this.profileToolBar.Text = "Toolbalk";
            // 
            // unZoomBtn
            // 
            this.unZoomBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.unZoomBtn.Image = ((System.Drawing.Image)(resources.GetObject("unZoomBtn.Image")));
            this.unZoomBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.unZoomBtn.Name = "unZoomBtn";
            this.unZoomBtn.Size = new System.Drawing.Size(23, 23);
            this.unZoomBtn.Text = "Keer terug naar overzicht";
            this.unZoomBtn.Click += new System.EventHandler(this.unZoomBtn_Click);
            // 
            // prevZoomBtn
            // 
            this.prevZoomBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevZoomBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevZoomBtn.Image")));
            this.prevZoomBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevZoomBtn.Name = "prevZoomBtn";
            this.prevZoomBtn.Size = new System.Drawing.Size(23, 23);
            this.prevZoomBtn.Text = "Vorig zoom niveau";
            this.prevZoomBtn.Click += new System.EventHandler(this.prevZoomBtn_Click);
            // 
            // PanActivateBtn
            // 
            this.PanActivateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PanActivateBtn.Image = ((System.Drawing.Image)(resources.GetObject("PanActivateBtn.Image")));
            this.PanActivateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PanActivateBtn.Name = "PanActivateBtn";
            this.PanActivateBtn.Size = new System.Drawing.Size(23, 23);
            this.PanActivateBtn.Text = "Pan";
            this.PanActivateBtn.Click += new System.EventHandler(this.PanActivateBtn_Click);
            // 
            // zoomRectActivateBtn
            // 
            this.zoomRectActivateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomRectActivateBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoomRectActivateBtn.Image")));
            this.zoomRectActivateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomRectActivateBtn.Name = "zoomRectActivateBtn";
            this.zoomRectActivateBtn.Size = new System.Drawing.Size(23, 23);
            this.zoomRectActivateBtn.Text = "Zoom naar rechthoek";
            this.zoomRectActivateBtn.Click += new System.EventHandler(this.zoomRectActivateBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // savePrfAsImageBtn
            // 
            this.savePrfAsImageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.savePrfAsImageBtn.Image = ((System.Drawing.Image)(resources.GetObject("savePrfAsImageBtn.Image")));
            this.savePrfAsImageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.savePrfAsImageBtn.Name = "savePrfAsImageBtn";
            this.savePrfAsImageBtn.Size = new System.Drawing.Size(23, 23);
            this.savePrfAsImageBtn.Text = "Opslaan als afbeelding";
            this.savePrfAsImageBtn.Click += new System.EventHandler(this.savePrfAsImageBtn_Click);
            // 
            // setTitleBtn
            // 
            this.setTitleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setTitleBtn.Image = ((System.Drawing.Image)(resources.GetObject("setTitleBtn.Image")));
            this.setTitleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setTitleBtn.Name = "setTitleBtn";
            this.setTitleBtn.Size = new System.Drawing.Size(23, 23);
            this.setTitleBtn.Text = "Titel instellen";
            this.setTitleBtn.Click += new System.EventHandler(this.setTitleBtn_Click);
            // 
            // fillBtn
            // 
            this.fillBtn.BackColor = System.Drawing.SystemColors.Control;
            this.fillBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fillBtn.Image = ((System.Drawing.Image)(resources.GetObject("fillBtn.Image")));
            this.fillBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillBtn.Name = "fillBtn";
            this.fillBtn.Size = new System.Drawing.Size(23, 23);
            this.fillBtn.Text = "Vulkleur";
            this.fillBtn.Click += new System.EventHandler(this.fillBtn_Click);
            // 
            // symbolBtn
            // 
            this.symbolBtn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.symbolBtn.Items.AddRange(new object[] {
            "Kruisje",
            "Diamant",
            "Cirkel",
            "Driehoek",
            "Geen symbool"});
            this.symbolBtn.Name = "symbolBtn";
            this.symbolBtn.Size = new System.Drawing.Size(121, 26);
            this.symbolBtn.ToolTipText = "Symbool";
            this.symbolBtn.SelectedIndexChanged += new System.EventHandler(this.symbolBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(594, 422);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(109, 31);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "Sluiten";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // addDhmBtn
            // 
            this.addDhmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addDhmBtn.Location = new System.Drawing.Point(455, 11);
            this.addDhmBtn.Name = "addDhmBtn";
            this.addDhmBtn.Size = new System.Drawing.Size(248, 30);
            this.addDhmBtn.TabIndex = 5;
            this.addDhmBtn.Text = "Voeg hoogtemodel toe als laag";
            this.addDhmBtn.UseVisualStyleBackColor = true;
            this.addDhmBtn.Click += new System.EventHandler(this.addDhmBtn_Click);
            // 
            // savePointsBtn
            // 
            this.savePointsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.savePointsBtn.Location = new System.Drawing.Point(12, 421);
            this.savePointsBtn.Name = "savePointsBtn";
            this.savePointsBtn.Size = new System.Drawing.Size(153, 32);
            this.savePointsBtn.TabIndex = 6;
            this.savePointsBtn.Text = "Profiellijn opslaan";
            this.savePointsBtn.UseVisualStyleBackColor = true;
            // 
            // saveLineBtn
            // 
            this.saveLineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveLineBtn.Location = new System.Drawing.Point(171, 421);
            this.saveLineBtn.Name = "saveLineBtn";
            this.saveLineBtn.Size = new System.Drawing.Size(178, 32);
            this.saveLineBtn.TabIndex = 7;
            this.saveLineBtn.Text = "Profielpunten opslaan";
            this.saveLineBtn.UseVisualStyleBackColor = true;
            // 
            // elevationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(715, 498);
            this.Controls.Add(this.saveLineBtn);
            this.Controls.Add(this.savePointsBtn);
            this.Controls.Add(this.addDhmBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.GraphPanel);
            this.Controls.Add(this.drawLineBtn);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "elevationForm";
            this.Text = "Hoogteprofiel";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.GraphPanel.ResumeLayout(false);
            this.GraphPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplesNum)).EndInit();
            this.profileToolBar.ResumeLayout(false);
            this.profileToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Button drawLineBtn;
        private System.Windows.Forms.ToolStripStatusLabel msgLbl;
        private System.Windows.Forms.ToolStripStatusLabel helpLink;
        private ZedGraph.ZedGraphControl profileGrp;
        private System.Windows.Forms.Panel GraphPanel;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ToolStrip profileToolBar;
        private System.Windows.Forms.ToolStripButton savePrfAsImageBtn;
        private System.Windows.Forms.ToolStripButton setTitleBtn;
        private System.Windows.Forms.ToolStripButton unZoomBtn;
        private System.Windows.Forms.ToolStripButton PanActivateBtn;
        private System.Windows.Forms.ToolStripButton zoomRectActivateBtn;
        private System.Windows.Forms.ToolStripButton fillBtn;
        private System.Windows.Forms.ToolStripButton prevZoomBtn;
        private System.Windows.Forms.Button addDhmBtn;
        private System.Windows.Forms.Button savePointsBtn;
        private System.Windows.Forms.Button saveLineBtn;
        private System.Windows.Forms.ToolStripComboBox symbolBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.NumericUpDown samplesNum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label aantalSamplesNum;
    }
}