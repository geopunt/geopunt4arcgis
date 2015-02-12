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
            this.profileToolBar = new System.Windows.Forms.ToolStrip();
            this.savePrfAsImageBtn = new System.Windows.Forms.ToolStripButton();
            this.setTitleBtn = new System.Windows.Forms.ToolStripButton();
            this.closeBtn = new System.Windows.Forms.Button();
            this.unZoomBtn = new System.Windows.Forms.ToolStripButton();
            this.PanActivateBtn = new System.Windows.Forms.ToolStripButton();
            this.zoomRectActivateBtn = new System.Windows.Forms.ToolStripButton();
            this.fillBtn = new System.Windows.Forms.ToolStripButton();
            this.prevZoomBtn = new System.Windows.Forms.ToolStripButton();
            this.statusBar.SuspendLayout();
            this.GraphPanel.SuspendLayout();
            this.profileToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msgLbl,
            this.helpLink});
            this.statusBar.Location = new System.Drawing.Point(0, 380);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(607, 23);
            this.statusBar.TabIndex = 0;
            // 
            // msgLbl
            // 
            this.msgLbl.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.msgLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(556, 18);
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
            this.drawLineBtn.Size = new System.Drawing.Size(116, 30);
            this.drawLineBtn.TabIndex = 1;
            this.drawLineBtn.Text = "Teken Lijn";
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
            this.profileGrp.Size = new System.Drawing.Size(583, 255);
            this.profileGrp.TabIndex = 2;
            this.profileGrp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.profileGrp_MouseMove);
            // 
            // GraphPanel
            // 
            this.GraphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphPanel.Controls.Add(this.profileToolBar);
            this.GraphPanel.Controls.Add(this.profileGrp);
            this.GraphPanel.Location = new System.Drawing.Point(12, 48);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(583, 284);
            this.GraphPanel.TabIndex = 3;
            // 
            // profileToolBar
            // 
            this.profileToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.profileToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unZoomBtn,
            this.prevZoomBtn,
            this.PanActivateBtn,
            this.zoomRectActivateBtn,
            this.savePrfAsImageBtn,
            this.setTitleBtn,
            this.fillBtn});
            this.profileToolBar.Location = new System.Drawing.Point(0, 259);
            this.profileToolBar.Name = "profileToolBar";
            this.profileToolBar.Size = new System.Drawing.Size(583, 25);
            this.profileToolBar.TabIndex = 3;
            this.profileToolBar.Text = "profileToolbar";
            // 
            // savePrfAsImageBtn
            // 
            this.savePrfAsImageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.savePrfAsImageBtn.Image = ((System.Drawing.Image)(resources.GetObject("savePrfAsImageBtn.Image")));
            this.savePrfAsImageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.savePrfAsImageBtn.Name = "savePrfAsImageBtn";
            this.savePrfAsImageBtn.Size = new System.Drawing.Size(23, 22);
            this.savePrfAsImageBtn.Text = "Opslaan";
            this.savePrfAsImageBtn.Click += new System.EventHandler(this.savePrfAsImageBtn_Click);
            // 
            // setTitleBtn
            // 
            this.setTitleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setTitleBtn.Image = ((System.Drawing.Image)(resources.GetObject("setTitleBtn.Image")));
            this.setTitleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setTitleBtn.Name = "setTitleBtn";
            this.setTitleBtn.Size = new System.Drawing.Size(23, 22);
            this.setTitleBtn.Text = "Titel";
            this.setTitleBtn.Click += new System.EventHandler(this.setTitleBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(486, 338);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(109, 31);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "Sluiten";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // unZoomBtn
            // 
            this.unZoomBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.unZoomBtn.Image = ((System.Drawing.Image)(resources.GetObject("unZoomBtn.Image")));
            this.unZoomBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.unZoomBtn.Name = "unZoomBtn";
            this.unZoomBtn.Size = new System.Drawing.Size(23, 22);
            this.unZoomBtn.Text = "Keer terug";
            this.unZoomBtn.Click += new System.EventHandler(this.unZoomBtn_Click);
            // 
            // PanActivateBtn
            // 
            this.PanActivateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PanActivateBtn.Image = ((System.Drawing.Image)(resources.GetObject("PanActivateBtn.Image")));
            this.PanActivateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PanActivateBtn.Name = "PanActivateBtn";
            this.PanActivateBtn.Size = new System.Drawing.Size(23, 22);
            this.PanActivateBtn.Text = "Pan";
            this.PanActivateBtn.Click += new System.EventHandler(this.PanActivateBtn_Click);
            // 
            // zoomRectActivateBtn
            // 
            this.zoomRectActivateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomRectActivateBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoomRectActivateBtn.Image")));
            this.zoomRectActivateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomRectActivateBtn.Name = "zoomRectActivateBtn";
            this.zoomRectActivateBtn.Size = new System.Drawing.Size(23, 22);
            this.zoomRectActivateBtn.Text = "Zoom naar";
            this.zoomRectActivateBtn.Click += new System.EventHandler(this.zoomRectActivateBtn_Click);
            // 
            // fillBtn
            // 
            this.fillBtn.BackColor = System.Drawing.SystemColors.Control;
            this.fillBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fillBtn.Image = ((System.Drawing.Image)(resources.GetObject("fillBtn.Image")));
            this.fillBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillBtn.Name = "fillBtn";
            this.fillBtn.Size = new System.Drawing.Size(23, 22);
            this.fillBtn.Text = "toolStripButton1";
            // 
            // prevZoomBtn
            // 
            this.prevZoomBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevZoomBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevZoomBtn.Image")));
            this.prevZoomBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevZoomBtn.Name = "prevZoomBtn";
            this.prevZoomBtn.Size = new System.Drawing.Size(23, 22);
            this.prevZoomBtn.Text = "vorige zoom niveua";
            this.prevZoomBtn.Click += new System.EventHandler(this.prevZoomBtn_Click);
            // 
            // elevationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(607, 403);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.GraphPanel);
            this.Controls.Add(this.drawLineBtn);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "elevationForm";
            this.Text = "Hoogteprofiel";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.GraphPanel.ResumeLayout(false);
            this.GraphPanel.PerformLayout();
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
    }
}