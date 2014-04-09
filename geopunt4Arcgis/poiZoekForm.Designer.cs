namespace geoPunt4Arcgis
{
    partial class poiZoekForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(poiZoekForm));
            this.zoekBtn = new System.Windows.Forms.Button();
            this.zoekTxt = new System.Windows.Forms.TextBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.idCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resultListView = new System.Windows.Forms.ListView();
            this.adresCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.add2MapBtn = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.messageLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.bboxChk = new System.Windows.Forms.CheckBox();
            this.addAsGrapicBtn = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoekBtn
            // 
            this.zoekBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoekBtn.Location = new System.Drawing.Point(553, 12);
            this.zoekBtn.Name = "zoekBtn";
            this.zoekBtn.Size = new System.Drawing.Size(75, 23);
            this.zoekBtn.TabIndex = 1;
            this.zoekBtn.Text = "Zoek";
            this.zoekBtn.UseVisualStyleBackColor = true;
            this.zoekBtn.Click += new System.EventHandler(this.zoekBtn_Click);
            // 
            // zoekTxt
            // 
            this.zoekTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zoekTxt.Location = new System.Drawing.Point(12, 12);
            this.zoekTxt.Name = "zoekTxt";
            this.zoekTxt.Size = new System.Drawing.Size(535, 20);
            this.zoekTxt.TabIndex = 2;
            this.zoekTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zoektxt_enterPressed);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(537, 437);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(91, 21);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Sluiten";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // idCol
            // 
            this.idCol.Text = "id";
            this.idCol.Width = 0;
            // 
            // categoryCol
            // 
            this.categoryCol.Text = "Categorie";
            this.categoryCol.Width = 82;
            // 
            // nameCol
            // 
            this.nameCol.Text = "Naam";
            this.nameCol.Width = 164;
            // 
            // resultListView
            // 
            this.resultListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.resultListView.AllowColumnReorder = true;
            this.resultListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultListView.CheckBoxes = true;
            this.resultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.idCol,
            this.categoryCol,
            this.adresCol});
            this.resultListView.HideSelection = false;
            this.resultListView.LabelWrap = false;
            this.resultListView.Location = new System.Drawing.Point(13, 67);
            this.resultListView.MultiSelect = false;
            this.resultListView.Name = "resultListView";
            this.resultListView.ShowGroups = false;
            this.resultListView.Size = new System.Drawing.Size(615, 364);
            this.resultListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.resultListView.TabIndex = 4;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            this.resultListView.View = System.Windows.Forms.View.Details;
            // 
            // adresCol
            // 
            this.adresCol.Text = "adres";
            this.adresCol.Width = 318;
            // 
            // add2MapBtn
            // 
            this.add2MapBtn.AccessibleDescription = "Voeg aangevinte records toe aan kaart";
            this.add2MapBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.add2MapBtn.Location = new System.Drawing.Point(394, 436);
            this.add2MapBtn.Name = "add2MapBtn";
            this.add2MapBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.add2MapBtn.Size = new System.Drawing.Size(137, 23);
            this.add2MapBtn.TabIndex = 5;
            this.add2MapBtn.Text = "Voeg toe als Shapefile";
            this.add2MapBtn.UseVisualStyleBackColor = true;
            this.add2MapBtn.Click += new System.EventHandler(this.add2MapBtn_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageLbl});
            this.statusBar.Location = new System.Drawing.Point(0, 461);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(640, 22);
            this.statusBar.TabIndex = 6;
            this.statusBar.Text = "status";
            // 
            // messageLbl
            // 
            this.messageLbl.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.messageLbl.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(625, 17);
            this.messageLbl.Spring = true;
            this.messageLbl.Text = " ";
            this.messageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bboxChk
            // 
            this.bboxChk.AutoSize = true;
            this.bboxChk.Location = new System.Drawing.Point(13, 39);
            this.bboxChk.Name = "bboxChk";
            this.bboxChk.Size = new System.Drawing.Size(122, 17);
            this.bboxChk.TabIndex = 7;
            this.bboxChk.Text = "Binnen huidig extent";
            this.bboxChk.UseVisualStyleBackColor = true;
            // 
            // addAsGrapicBtn
            // 
            this.addAsGrapicBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addAsGrapicBtn.Location = new System.Drawing.Point(249, 435);
            this.addAsGrapicBtn.Name = "addAsGrapicBtn";
            this.addAsGrapicBtn.Size = new System.Drawing.Size(139, 23);
            this.addAsGrapicBtn.TabIndex = 8;
            this.addAsGrapicBtn.Text = "Voeg toe als Figuur";
            this.addAsGrapicBtn.UseVisualStyleBackColor = true;
            this.addAsGrapicBtn.Click += new System.EventHandler(this.addAsGrapicBtn_Click);
            // 
            // poiZoekForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(640, 483);
            this.Controls.Add(this.addAsGrapicBtn);
            this.Controls.Add(this.bboxChk);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.add2MapBtn);
            this.Controls.Add(this.resultListView);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.zoekTxt);
            this.Controls.Add(this.zoekBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(280, 240);
            this.Name = "poiZoekForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoeken naar interessepunten";
            this.TopMost = true;
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zoekBtn;
        private System.Windows.Forms.TextBox zoekTxt;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ColumnHeader idCol;
        private System.Windows.Forms.ColumnHeader categoryCol;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.ColumnHeader adresCol;
        private System.Windows.Forms.Button add2MapBtn;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel messageLbl;
        private System.Windows.Forms.CheckBox bboxChk;
        private System.Windows.Forms.Button addAsGrapicBtn;
    }
}