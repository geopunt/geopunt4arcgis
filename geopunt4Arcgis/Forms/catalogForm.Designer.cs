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
            this.filterResultsCbx = new System.Windows.Forms.ComboBox();
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
            this.statusStrip.Location = new System.Drawing.Point(0, 379);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(549, 22);
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
            this.statusMsgLbl.Size = new System.Drawing.Size(506, 17);
            this.statusMsgLbl.Spring = true;
            // 
            // helpLbl
            // 
            this.helpLbl.IsLink = true;
            this.helpLbl.Name = "helpLbl";
            this.helpLbl.Size = new System.Drawing.Size(28, 17);
            this.helpLbl.Text = "Help";
            this.helpLbl.Click += new System.EventHandler(this.helpLbl_Click);
            // 
            // keywordTxt
            // 
            this.keywordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.keywordTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.keywordTxt.Location = new System.Drawing.Point(10, 15);
            this.keywordTxt.Name = "keywordTxt";
            this.keywordTxt.Size = new System.Drawing.Size(461, 20);
            this.keywordTxt.TabIndex = 1;
            // 
            // zoekBtn
            // 
            this.zoekBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoekBtn.Location = new System.Drawing.Point(476, 12);
            this.zoekBtn.Name = "zoekBtn";
            this.zoekBtn.Size = new System.Drawing.Size(64, 23);
            this.zoekBtn.TabIndex = 3;
            this.zoekBtn.Text = "Zoek";
            this.zoekBtn.UseVisualStyleBackColor = true;
            this.zoekBtn.Click += new System.EventHandler(this.zoekBtn_Click);
            // 
            // GDIthemaLbl
            // 
            this.GDIthemaLbl.AutoSize = true;
            this.GDIthemaLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GDIthemaLbl.Location = new System.Drawing.Point(2, 0);
            this.GDIthemaLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GDIthemaLbl.Name = "GDIthemaLbl";
            this.GDIthemaLbl.Size = new System.Drawing.Size(102, 29);
            this.GDIthemaLbl.TabIndex = 4;
            this.GDIthemaLbl.Text = "GDI-thema:";
            // 
            // orgName
            // 
            this.orgName.AutoSize = true;
            this.orgName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgName.Location = new System.Drawing.Point(2, 29);
            this.orgName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.orgName.Name = "orgName";
            this.orgName.Size = new System.Drawing.Size(102, 29);
            this.orgName.TabIndex = 5;
            this.orgName.Text = "Organisatie naam:";
            // 
            // BronLbl
            // 
            this.BronLbl.AutoSize = true;
            this.BronLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BronLbl.Location = new System.Drawing.Point(2, 58);
            this.BronLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BronLbl.Name = "BronLbl";
            this.BronLbl.Size = new System.Drawing.Size(102, 29);
            this.BronLbl.TabIndex = 6;
            this.BronLbl.Text = "Bron catalogus";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeLbl.Location = new System.Drawing.Point(2, 87);
            this.typeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(102, 31);
            this.typeLbl.TabIndex = 7;
            this.typeLbl.Text = "Type: ";
            // 
            // INSPIREannexLbl
            // 
            this.INSPIREannexLbl.AutoSize = true;
            this.INSPIREannexLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREannexLbl.Location = new System.Drawing.Point(267, 0);
            this.INSPIREannexLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.INSPIREannexLbl.Name = "INSPIREannexLbl";
            this.INSPIREannexLbl.Size = new System.Drawing.Size(102, 29);
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
            this.filterPane.Location = new System.Drawing.Point(10, 49);
            this.filterPane.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filterPane.Name = "filterPane";
            this.filterPane.RowCount = 4;
            this.filterPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.filterPane.Size = new System.Drawing.Size(530, 118);
            this.filterPane.TabIndex = 9;
            // 
            // typeCbx
            // 
            this.typeCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeCbx.FormattingEnabled = true;
            this.typeCbx.Location = new System.Drawing.Point(108, 89);
            this.typeCbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.typeCbx.Name = "typeCbx";
            this.typeCbx.Size = new System.Drawing.Size(155, 21);
            this.typeCbx.TabIndex = 16;
            // 
            // INSPIREserviceCbx
            // 
            this.INSPIREserviceCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREserviceCbx.FormattingEnabled = true;
            this.INSPIREserviceCbx.Location = new System.Drawing.Point(373, 60);
            this.INSPIREserviceCbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.INSPIREserviceCbx.Name = "INSPIREserviceCbx";
            this.INSPIREserviceCbx.Size = new System.Drawing.Size(155, 21);
            this.INSPIREserviceCbx.TabIndex = 15;
            // 
            // bronCatCbx
            // 
            this.bronCatCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bronCatCbx.FormattingEnabled = true;
            this.bronCatCbx.Location = new System.Drawing.Point(108, 60);
            this.bronCatCbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bronCatCbx.Name = "bronCatCbx";
            this.bronCatCbx.Size = new System.Drawing.Size(155, 21);
            this.bronCatCbx.TabIndex = 14;
            // 
            // INSPIREthemeCbx
            // 
            this.INSPIREthemeCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREthemeCbx.FormattingEnabled = true;
            this.INSPIREthemeCbx.Location = new System.Drawing.Point(373, 31);
            this.INSPIREthemeCbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.INSPIREthemeCbx.Name = "INSPIREthemeCbx";
            this.INSPIREthemeCbx.Size = new System.Drawing.Size(155, 21);
            this.INSPIREthemeCbx.TabIndex = 13;
            // 
            // orgNameCbx
            // 
            this.orgNameCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgNameCbx.FormattingEnabled = true;
            this.orgNameCbx.Location = new System.Drawing.Point(108, 31);
            this.orgNameCbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.orgNameCbx.Name = "orgNameCbx";
            this.orgNameCbx.Size = new System.Drawing.Size(155, 21);
            this.orgNameCbx.TabIndex = 12;
            // 
            // INSPIREannexCbx
            // 
            this.INSPIREannexCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREannexCbx.FormattingEnabled = true;
            this.INSPIREannexCbx.Location = new System.Drawing.Point(373, 2);
            this.INSPIREannexCbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.INSPIREannexCbx.Name = "INSPIREannexCbx";
            this.INSPIREannexCbx.Size = new System.Drawing.Size(155, 21);
            this.INSPIREannexCbx.TabIndex = 11;
            // 
            // GDIthemeCbx
            // 
            this.GDIthemeCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GDIthemeCbx.FormattingEnabled = true;
            this.GDIthemeCbx.Location = new System.Drawing.Point(108, 2);
            this.GDIthemeCbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GDIthemeCbx.Name = "GDIthemeCbx";
            this.GDIthemeCbx.Size = new System.Drawing.Size(155, 21);
            this.GDIthemeCbx.TabIndex = 10;
            // 
            // INSPIREthemeLbl
            // 
            this.INSPIREthemeLbl.AutoSize = true;
            this.INSPIREthemeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREthemeLbl.Location = new System.Drawing.Point(267, 29);
            this.INSPIREthemeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.INSPIREthemeLbl.Name = "INSPIREthemeLbl";
            this.INSPIREthemeLbl.Size = new System.Drawing.Size(102, 29);
            this.INSPIREthemeLbl.TabIndex = 9;
            this.INSPIREthemeLbl.Text = "INSPIRE-thema:";
            // 
            // INSPIREserviceLbl
            // 
            this.INSPIREserviceLbl.AutoSize = true;
            this.INSPIREserviceLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.INSPIREserviceLbl.Location = new System.Drawing.Point(267, 58);
            this.INSPIREserviceLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.INSPIREserviceLbl.Name = "INSPIREserviceLbl";
            this.INSPIREserviceLbl.Size = new System.Drawing.Size(102, 29);
            this.INSPIREserviceLbl.TabIndex = 10;
            this.INSPIREserviceLbl.Text = "INSPIRE- servicetype:";
            // 
            // contentSplitContainer
            // 
            this.contentSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contentSplitContainer.Location = new System.Drawing.Point(10, 171);
            this.contentSplitContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.contentSplitContainer.Name = "contentSplitContainer";
            // 
            // contentSplitContainer.Panel1
            // 
            this.contentSplitContainer.Panel1.Controls.Add(this.searchResultsList);
            // 
            // contentSplitContainer.Panel2
            // 
            this.contentSplitContainer.Panel2.Controls.Add(this.descriptionHTML);
            this.contentSplitContainer.Size = new System.Drawing.Size(526, 160);
            this.contentSplitContainer.SplitterDistance = 173;
            this.contentSplitContainer.SplitterWidth = 3;
            this.contentSplitContainer.TabIndex = 10;
            // 
            // searchResultsList
            // 
            this.searchResultsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchResultsList.FormattingEnabled = true;
            this.searchResultsList.Location = new System.Drawing.Point(0, 0);
            this.searchResultsList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchResultsList.Name = "searchResultsList";
            this.searchResultsList.Size = new System.Drawing.Size(173, 160);
            this.searchResultsList.TabIndex = 0;
            this.searchResultsList.SelectedIndexChanged += new System.EventHandler(this.searchResultsList_SelectedIndexChanged);
            // 
            // descriptionHTML
            // 
            this.descriptionHTML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionHTML.Location = new System.Drawing.Point(0, 0);
            this.descriptionHTML.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.descriptionHTML.MinimumSize = new System.Drawing.Size(15, 16);
            this.descriptionHTML.Name = "descriptionHTML";
            this.descriptionHTML.Size = new System.Drawing.Size(350, 160);
            this.descriptionHTML.TabIndex = 0;
            // 
            // OpenDownloadBtn
            // 
            this.OpenDownloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenDownloadBtn.Enabled = false;
            this.OpenDownloadBtn.Location = new System.Drawing.Point(352, 344);
            this.OpenDownloadBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenDownloadBtn.Name = "OpenDownloadBtn";
            this.OpenDownloadBtn.Size = new System.Drawing.Size(82, 28);
            this.OpenDownloadBtn.TabIndex = 11;
            this.OpenDownloadBtn.Text = "Downloaden";
            this.OpenDownloadBtn.UseVisualStyleBackColor = true;
            this.OpenDownloadBtn.Click += new System.EventHandler(this.OpenDownloadBtn_Click);
            // 
            // addWMSbtn
            // 
            this.addWMSbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addWMSbtn.Enabled = false;
            this.addWMSbtn.Location = new System.Drawing.Point(239, 344);
            this.addWMSbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addWMSbtn.Name = "addWMSbtn";
            this.addWMSbtn.Size = new System.Drawing.Size(108, 28);
            this.addWMSbtn.TabIndex = 12;
            this.addWMSbtn.Text = "WMS-toevoegen";
            this.addWMSbtn.UseVisualStyleBackColor = true;
            this.addWMSbtn.Click += new System.EventHandler(this.addWMSbtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Location = new System.Drawing.Point(454, 344);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(82, 28);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "Sluiten";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // filterResultsCbx
            // 
            this.filterResultsCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterResultsCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterResultsCbx.FormattingEnabled = true;
            this.filterResultsCbx.Items.AddRange(new object[] {
            "Alles weergeven",
            "WMS",
            "Download"});
            this.filterResultsCbx.Location = new System.Drawing.Point(14, 335);
            this.filterResultsCbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filterResultsCbx.Name = "filterResultsCbx";
            this.filterResultsCbx.Size = new System.Drawing.Size(100, 21);
            this.filterResultsCbx.TabIndex = 14;
            this.filterResultsCbx.SelectedIndexChanged += new System.EventHandler(this.filterResultsCbx_SelectedIndexChanged);
            // 
            // catalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 401);
            this.Controls.Add(this.filterResultsCbx);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.addWMSbtn);
            this.Controls.Add(this.OpenDownloadBtn);
            this.Controls.Add(this.contentSplitContainer);
            this.Controls.Add(this.filterPane);
            this.Controls.Add(this.zoekBtn);
            this.Controls.Add(this.keywordTxt);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(452, 410);
            this.Name = "catalogForm";
            this.Text = "Geopunt-catalogus";
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
        private System.Windows.Forms.ComboBox filterResultsCbx;
    }
}