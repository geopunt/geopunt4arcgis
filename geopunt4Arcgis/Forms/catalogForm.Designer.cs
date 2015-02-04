namespace geopunt4Arcgis
{
    partial class catalogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(catalogForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusMsgLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.helpLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.keywordTxt = new System.Windows.Forms.TextBox();
            this.zoekBtn = new System.Windows.Forms.Button();
            this.GDIthemaLbl = new System.Windows.Forms.Label();
            this.orgName = new System.Windows.Forms.Label();
            this.BronLbl = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.INSPIREannexLbl = new System.Windows.Forms.Label();
            this.filterPane = new System.Windows.Forms.TableLayoutPanel();
            this.typeCbx = new System.Windows.Forms.ComboBox();
            this.INSPIREserviceCbx = new System.Windows.Forms.ComboBox();
            this.bronCatCbx = new System.Windows.Forms.ComboBox();
            this.INSPIREthemeCbx = new System.Windows.Forms.ComboBox();
            this.orgNameCbx = new System.Windows.Forms.ComboBox();
            this.INSPIREannexCbx = new System.Windows.Forms.ComboBox();
            this.GDIthemeCbx = new System.Windows.Forms.ComboBox();
            this.INSPIREthemeLbl = new System.Windows.Forms.Label();
            this.INSPIREserviceLbl = new System.Windows.Forms.Label();
            this.contentSplitContainer = new System.Windows.Forms.SplitContainer();
            this.searchResultsList = new System.Windows.Forms.ListBox();
            this.descriptionHTML = new System.Windows.Forms.WebBrowser();
            this.OpenDownloadBtn = new System.Windows.Forms.Button();
            this.addWMSbtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.filterPane.SuspendLayout();
            this.contentSplitContainer.Panel1.SuspendLayout();
            this.contentSplitContainer.Panel2.SuspendLayout();
            this.contentSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMsgLbl,
            this.helpLbl});
            this.statusStrip.Location = new System.Drawing.Point(0, 471);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(732, 23);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusMsgLbl
            // 
            this.statusMsgLbl.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusMsgLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusMsgLbl.Name = "statusMsgLbl";
            this.statusMsgLbl.Size = new System.Drawing.Size(676, 18);
            this.statusMsgLbl.Spring = true;
            // 
            // helpLbl
            // 
            this.helpLbl.IsLink = true;
            this.helpLbl.Name = "helpLbl";
            this.helpLbl.Size = new System.Drawing.Size(36, 18);
            this.helpLbl.Text = "Help";
            this.helpLbl.Click += new System.EventHandler(this.helpLbl_Click);
            // 
            // keywordTxt
            // 
            this.keywordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.keywordTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.keywordTxt.Location = new System.Drawing.Point(13, 18);
            this.keywordTxt.Margin = new System.Windows.Forms.Padding(4);
            this.keywordTxt.Name = "keywordTxt";
            this.keywordTxt.Size = new System.Drawing.Size(613, 22);
            this.keywordTxt.TabIndex = 1;
            // 
            // zoekBtn
            // 
            this.zoekBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoekBtn.Location = new System.Drawing.Point(634, 15);
            this.zoekBtn.Margin = new System.Windows.Forms.Padding(4);
            this.zoekBtn.Name = "zoekBtn";
            this.zoekBtn.Size = new System.Drawing.Size(85, 28);
            this.zoekBtn.TabIndex = 3;
            this.zoekBtn.Text = "Zoek";
            this.zoekBtn.UseVisualStyleBackColor = true;
            this.zoekBtn.Click += new System.EventHandler(this.zoekBtn_Click);
            // 
            // GDIthemaLbl
            // 
            this.GDIthemaLbl.AutoSize = true;
            this.GDIthemaLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GDIthemaLbl.Location = new System.Drawing.Point(3, 0);
            this.GDIthemaLbl.Name = "GDIthemaLbl";
            this.GDIthemaLbl.Size = new System.Drawing.Size(135, 36);
            this.GDIthemaLbl.TabIndex = 4;
            this.GDIthemaLbl.Text = "GDI-thema:";
            // 
            // orgName
            // 
            this.orgName.AutoSize = true;
            this.orgName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgName.Location = new System.Drawing.Point(3, 36);
            this.orgName.Name = "orgName";
            this.orgName.Size = new System.Drawing.Size(135, 36);
            this.orgName.TabIndex = 5;
            this.orgName.Text = "Organisatie naam:";
            // 
            // BronLbl
            // 
            this.BronLbl.AutoSize = true;
            this.BronLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BronLbl.Location = new System.Drawing.Point(3, 72);
            this.BronLbl.Name = "BronLbl";
            this.BronLbl.Size = new System.Drawing.Size(135, 36);
            this.BronLbl.TabIndex = 6;
            this.BronLbl.Text = "Bron catalogus";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeLbl.Location = new System.Drawing.Point(3, 108);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(135, 37);
            this.typeLbl.TabIndex = 7;
            this.typeLbl.Text = "Type: ";
            // 
            // INSPIREannexLbl
            // 
            this.INSPIREannexLbl.AutoSize = true;
            this.INSPIREannexLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREannexLbl.Location = new System.Drawing.Point(355, 0);
            this.INSPIREannexLbl.Name = "INSPIREannexLbl";
            this.INSPIREannexLbl.Size = new System.Drawing.Size(135, 36);
            this.INSPIREannexLbl.TabIndex = 8;
            this.INSPIREannexLbl.Text = "INSPIRE-annex:";
            // 
            // filterPane
            // 
            this.filterPane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPane.ColumnCount = 4;
            this.filterPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.filterPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.filterPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.filterPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.filterPane.Controls.Add(this.typeCbx, 1, 3);
            this.filterPane.Controls.Add(this.INSPIREserviceCbx, 3, 2);
            this.filterPane.Controls.Add(this.bronCatCbx, 1, 2);
            this.filterPane.Controls.Add(this.INSPIREthemeCbx, 3, 1);
            this.filterPane.Controls.Add(this.orgNameCbx, 1, 1);
            this.filterPane.Controls.Add(this.INSPIREannexCbx, 3, 0);
            this.filterPane.Controls.Add(this.GDIthemeCbx, 1, 0);
            this.filterPane.Controls.Add(this.GDIthemaLbl, 0, 0);
            this.filterPane.Controls.Add(this.orgName, 0, 1);
            this.filterPane.Controls.Add(this.typeLbl, 0, 3);
            this.filterPane.Controls.Add(this.BronLbl, 0, 2);
            this.filterPane.Controls.Add(this.INSPIREannexLbl, 2, 0);
            this.filterPane.Controls.Add(this.INSPIREthemeLbl, 2, 1);
            this.filterPane.Controls.Add(this.INSPIREserviceLbl, 2, 2);
            this.filterPane.Location = new System.Drawing.Point(14, 60);
            this.filterPane.Name = "filterPane";
            this.filterPane.RowCount = 4;
            this.filterPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterPane.Size = new System.Drawing.Size(706, 145);
            this.filterPane.TabIndex = 9;
            // 
            // typeCbx
            // 
            this.typeCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeCbx.FormattingEnabled = true;
            this.typeCbx.Location = new System.Drawing.Point(144, 111);
            this.typeCbx.Name = "typeCbx";
            this.typeCbx.Size = new System.Drawing.Size(205, 24);
            this.typeCbx.TabIndex = 16;
            // 
            // INSPIREserviceCbx
            // 
            this.INSPIREserviceCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREserviceCbx.FormattingEnabled = true;
            this.INSPIREserviceCbx.Location = new System.Drawing.Point(496, 75);
            this.INSPIREserviceCbx.Name = "INSPIREserviceCbx";
            this.INSPIREserviceCbx.Size = new System.Drawing.Size(207, 24);
            this.INSPIREserviceCbx.TabIndex = 15;
            // 
            // bronCatCbx
            // 
            this.bronCatCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bronCatCbx.FormattingEnabled = true;
            this.bronCatCbx.Location = new System.Drawing.Point(144, 75);
            this.bronCatCbx.Name = "bronCatCbx";
            this.bronCatCbx.Size = new System.Drawing.Size(205, 24);
            this.bronCatCbx.TabIndex = 14;
            // 
            // INSPIREthemeCbx
            // 
            this.INSPIREthemeCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREthemeCbx.FormattingEnabled = true;
            this.INSPIREthemeCbx.Location = new System.Drawing.Point(496, 39);
            this.INSPIREthemeCbx.Name = "INSPIREthemeCbx";
            this.INSPIREthemeCbx.Size = new System.Drawing.Size(207, 24);
            this.INSPIREthemeCbx.TabIndex = 13;
            // 
            // orgNameCbx
            // 
            this.orgNameCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgNameCbx.FormattingEnabled = true;
            this.orgNameCbx.Location = new System.Drawing.Point(144, 39);
            this.orgNameCbx.Name = "orgNameCbx";
            this.orgNameCbx.Size = new System.Drawing.Size(205, 24);
            this.orgNameCbx.TabIndex = 12;
            // 
            // INSPIREannexCbx
            // 
            this.INSPIREannexCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREannexCbx.FormattingEnabled = true;
            this.INSPIREannexCbx.Location = new System.Drawing.Point(496, 3);
            this.INSPIREannexCbx.Name = "INSPIREannexCbx";
            this.INSPIREannexCbx.Size = new System.Drawing.Size(207, 24);
            this.INSPIREannexCbx.TabIndex = 11;
            // 
            // GDIthemeCbx
            // 
            this.GDIthemeCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GDIthemeCbx.FormattingEnabled = true;
            this.GDIthemeCbx.Location = new System.Drawing.Point(144, 3);
            this.GDIthemeCbx.Name = "GDIthemeCbx";
            this.GDIthemeCbx.Size = new System.Drawing.Size(205, 24);
            this.GDIthemeCbx.TabIndex = 10;
            // 
            // INSPIREthemeLbl
            // 
            this.INSPIREthemeLbl.AutoSize = true;
            this.INSPIREthemeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREthemeLbl.Location = new System.Drawing.Point(355, 36);
            this.INSPIREthemeLbl.Name = "INSPIREthemeLbl";
            this.INSPIREthemeLbl.Size = new System.Drawing.Size(135, 36);
            this.INSPIREthemeLbl.TabIndex = 9;
            this.INSPIREthemeLbl.Text = "INSPIRE-thema:";
            // 
            // INSPIREserviceLbl
            // 
            this.INSPIREserviceLbl.AutoSize = true;
            this.INSPIREserviceLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREserviceLbl.Location = new System.Drawing.Point(355, 72);
            this.INSPIREserviceLbl.Name = "INSPIREserviceLbl";
            this.INSPIREserviceLbl.Size = new System.Drawing.Size(135, 36);
            this.INSPIREserviceLbl.TabIndex = 10;
            this.INSPIREserviceLbl.Text = "INSPIRE- servicetype:";
            // 
            // contentSplitContainer
            // 
            this.contentSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contentSplitContainer.Location = new System.Drawing.Point(14, 211);
            this.contentSplitContainer.Name = "contentSplitContainer";
            // 
            // contentSplitContainer.Panel1
            // 
            this.contentSplitContainer.Panel1.Controls.Add(this.searchResultsList);
            // 
            // contentSplitContainer.Panel2
            // 
            this.contentSplitContainer.Panel2.Controls.Add(this.descriptionHTML);
            this.contentSplitContainer.Size = new System.Drawing.Size(701, 197);
            this.contentSplitContainer.SplitterDistance = 232;
            this.contentSplitContainer.TabIndex = 10;
            // 
            // searchResultsList
            // 
            this.searchResultsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchResultsList.FormattingEnabled = true;
            this.searchResultsList.ItemHeight = 16;
            this.searchResultsList.Location = new System.Drawing.Point(0, 0);
            this.searchResultsList.Name = "searchResultsList";
            this.searchResultsList.Size = new System.Drawing.Size(232, 197);
            this.searchResultsList.TabIndex = 0;
            this.searchResultsList.SelectedIndexChanged += new System.EventHandler(this.searchResultsList_SelectedIndexChanged);
            // 
            // descriptionHTML
            // 
            this.descriptionHTML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionHTML.Location = new System.Drawing.Point(0, 0);
            this.descriptionHTML.MinimumSize = new System.Drawing.Size(20, 20);
            this.descriptionHTML.Name = "descriptionHTML";
            this.descriptionHTML.Size = new System.Drawing.Size(465, 197);
            this.descriptionHTML.TabIndex = 0;
            // 
            // OpenDownloadBtn
            // 
            this.OpenDownloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenDownloadBtn.Location = new System.Drawing.Point(469, 423);
            this.OpenDownloadBtn.Name = "OpenDownloadBtn";
            this.OpenDownloadBtn.Size = new System.Drawing.Size(110, 34);
            this.OpenDownloadBtn.TabIndex = 11;
            this.OpenDownloadBtn.Text = "Downloaden";
            this.OpenDownloadBtn.UseVisualStyleBackColor = true;
            this.OpenDownloadBtn.Click += new System.EventHandler(this.OpenDownloadBtn_Click);
            // 
            // addWMSbtn
            // 
            this.addWMSbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addWMSbtn.Location = new System.Drawing.Point(319, 423);
            this.addWMSbtn.Name = "addWMSbtn";
            this.addWMSbtn.Size = new System.Drawing.Size(144, 34);
            this.addWMSbtn.TabIndex = 12;
            this.addWMSbtn.Text = "WMS-toevoegen";
            this.addWMSbtn.UseVisualStyleBackColor = true;
            this.addWMSbtn.Click += new System.EventHandler(this.addWMSbtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Location = new System.Drawing.Point(605, 423);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(110, 34);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "Sluiten";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // catalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 494);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.addWMSbtn);
            this.Controls.Add(this.OpenDownloadBtn);
            this.Controls.Add(this.contentSplitContainer);
            this.Controls.Add(this.filterPane);
            this.Controls.Add(this.zoekBtn);
            this.Controls.Add(this.keywordTxt);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "catalogForm";
            this.Text = "Geopunt Catalogus";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.filterPane.ResumeLayout(false);
            this.filterPane.PerformLayout();
            this.contentSplitContainer.Panel1.ResumeLayout(false);
            this.contentSplitContainer.Panel2.ResumeLayout(false);
            this.contentSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusMsgLbl;
        private System.Windows.Forms.ToolStripStatusLabel helpLbl;
        private System.Windows.Forms.TextBox keywordTxt;
        private System.Windows.Forms.Button zoekBtn;
        private System.Windows.Forms.Label GDIthemaLbl;
        private System.Windows.Forms.Label orgName;
        private System.Windows.Forms.Label BronLbl;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label INSPIREannexLbl;
        private System.Windows.Forms.TableLayoutPanel filterPane;
        private System.Windows.Forms.Label INSPIREthemeLbl;
        private System.Windows.Forms.Label INSPIREserviceLbl;
        private System.Windows.Forms.ComboBox GDIthemeCbx;
        private System.Windows.Forms.ComboBox typeCbx;
        private System.Windows.Forms.ComboBox INSPIREserviceCbx;
        private System.Windows.Forms.ComboBox bronCatCbx;
        private System.Windows.Forms.ComboBox INSPIREthemeCbx;
        private System.Windows.Forms.ComboBox orgNameCbx;
        private System.Windows.Forms.ComboBox INSPIREannexCbx;
        private System.Windows.Forms.SplitContainer contentSplitContainer;
        private System.Windows.Forms.ListBox searchResultsList;
        private System.Windows.Forms.WebBrowser descriptionHTML;
        private System.Windows.Forms.Button OpenDownloadBtn;
        private System.Windows.Forms.Button addWMSbtn;
        private System.Windows.Forms.Button closeBtn;
    }
}