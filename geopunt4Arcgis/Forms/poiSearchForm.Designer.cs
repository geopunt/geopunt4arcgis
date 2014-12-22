namespace geopunt4Arcgis 
{
    partial class poiSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(poiSearchForm));
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.zoekBtn = new System.Windows.Forms.Button();
            this.themeCbx = new System.Windows.Forms.ComboBox();
            this.categoryCbx = new System.Windows.Forms.ComboBox();
            this.typeCbx = new System.Windows.Forms.ComboBox();
            this.gemeenteCbx = new System.Windows.Forms.ComboBox();
            this.GemeenteLbl = new System.Windows.Forms.Label();
            this.categoryLbl = new System.Windows.Forms.Label();
            this.themeLbl = new System.Windows.Forms.Label();
            this.tyoeLbl = new System.Windows.Forms.Label();
            this.extentCkb = new System.Windows.Forms.CheckBox();
            this.keywordTxt = new System.Windows.Forms.TextBox();
            this.keywordLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addSelection2mapBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToAddRows = false;
            this.resultGrid.AllowUserToDeleteRows = false;
            this.resultGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.resultGrid.Location = new System.Drawing.Point(12, 198);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.ReadOnly = true;
            this.resultGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultGrid.Size = new System.Drawing.Size(493, 185);
            this.resultGrid.TabIndex = 0;
            this.resultGrid.SelectionChanged += new System.EventHandler(this.resultGrid_SelectionChanged);
            // 
            // zoekBtn
            // 
            this.zoekBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoekBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoekBtn.Location = new System.Drawing.Point(430, 169);
            this.zoekBtn.Name = "zoekBtn";
            this.zoekBtn.Size = new System.Drawing.Size(75, 23);
            this.zoekBtn.TabIndex = 1;
            this.zoekBtn.Text = "Zoek";
            this.zoekBtn.UseVisualStyleBackColor = true;
            this.zoekBtn.Click += new System.EventHandler(this.zoekBtn_Click);
            // 
            // themeCbx
            // 
            this.themeCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.themeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeCbx.FormattingEnabled = true;
            this.themeCbx.Location = new System.Drawing.Point(95, 59);
            this.themeCbx.Name = "themeCbx";
            this.themeCbx.Size = new System.Drawing.Size(410, 21);
            this.themeCbx.TabIndex = 2;
            this.themeCbx.SelectedIndexChanged += new System.EventHandler(this.themeCbx_SelectedIndexChanged);
            // 
            // categoryCbx
            // 
            this.categoryCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryCbx.FormattingEnabled = true;
            this.categoryCbx.Location = new System.Drawing.Point(95, 86);
            this.categoryCbx.Name = "categoryCbx";
            this.categoryCbx.Size = new System.Drawing.Size(410, 21);
            this.categoryCbx.TabIndex = 3;
            this.categoryCbx.SelectedIndexChanged += new System.EventHandler(this.categoryCbx_SelectedIndexChanged);
            // 
            // typeCbx
            // 
            this.typeCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCbx.FormattingEnabled = true;
            this.typeCbx.Location = new System.Drawing.Point(95, 113);
            this.typeCbx.Name = "typeCbx";
            this.typeCbx.Size = new System.Drawing.Size(410, 21);
            this.typeCbx.TabIndex = 4;
            // 
            // gemeenteCbx
            // 
            this.gemeenteCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gemeenteCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gemeenteCbx.FormattingEnabled = true;
            this.gemeenteCbx.Location = new System.Drawing.Point(95, 32);
            this.gemeenteCbx.Name = "gemeenteCbx";
            this.gemeenteCbx.Size = new System.Drawing.Size(410, 21);
            this.gemeenteCbx.TabIndex = 5;
            // 
            // GemeenteLbl
            // 
            this.GemeenteLbl.AutoSize = true;
            this.GemeenteLbl.Location = new System.Drawing.Point(30, 32);
            this.GemeenteLbl.Name = "GemeenteLbl";
            this.GemeenteLbl.Size = new System.Drawing.Size(59, 13);
            this.GemeenteLbl.TabIndex = 6;
            this.GemeenteLbl.Text = "Gemeente:";
            // 
            // categoryLbl
            // 
            this.categoryLbl.AutoSize = true;
            this.categoryLbl.Location = new System.Drawing.Point(34, 86);
            this.categoryLbl.Name = "categoryLbl";
            this.categoryLbl.Size = new System.Drawing.Size(55, 13);
            this.categoryLbl.TabIndex = 7;
            this.categoryLbl.Text = "Categorie:";
            // 
            // themeLbl
            // 
            this.themeLbl.AutoSize = true;
            this.themeLbl.Location = new System.Drawing.Point(46, 59);
            this.themeLbl.Name = "themeLbl";
            this.themeLbl.Size = new System.Drawing.Size(43, 13);
            this.themeLbl.TabIndex = 8;
            this.themeLbl.Text = "Thema:";
            // 
            // tyoeLbl
            // 
            this.tyoeLbl.AutoSize = true;
            this.tyoeLbl.Location = new System.Drawing.Point(55, 113);
            this.tyoeLbl.Name = "tyoeLbl";
            this.tyoeLbl.Size = new System.Drawing.Size(34, 13);
            this.tyoeLbl.TabIndex = 9;
            this.tyoeLbl.Text = "Type:";
            // 
            // extentCkb
            // 
            this.extentCkb.AutoSize = true;
            this.extentCkb.Location = new System.Drawing.Point(21, 9);
            this.extentCkb.Name = "extentCkb";
            this.extentCkb.Size = new System.Drawing.Size(244, 17);
            this.extentCkb.TabIndex = 10;
            this.extentCkb.Text = "Beperk zoekresultaten tot huidige zoomniveau";
            this.extentCkb.UseVisualStyleBackColor = true;
            this.extentCkb.CheckedChanged += new System.EventHandler(this.extentCkb_CheckedChanged);
            // 
            // keywordTxt
            // 
            this.keywordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keywordTxt.Location = new System.Drawing.Point(95, 141);
            this.keywordTxt.Name = "keywordTxt";
            this.keywordTxt.Size = new System.Drawing.Size(410, 20);
            this.keywordTxt.TabIndex = 11;
            // 
            // keywordLbl
            // 
            this.keywordLbl.AutoSize = true;
            this.keywordLbl.Location = new System.Drawing.Point(21, 141);
            this.keywordLbl.Name = "keywordLbl";
            this.keywordLbl.Size = new System.Drawing.Size(71, 13);
            this.keywordLbl.TabIndex = 12;
            this.keywordLbl.Text = "Sleutelwoord:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(430, 418);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Sluiten";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addSelection2mapBtn
            // 
            this.addSelection2mapBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addSelection2mapBtn.Location = new System.Drawing.Point(217, 389);
            this.addSelection2mapBtn.Name = "addSelection2mapBtn";
            this.addSelection2mapBtn.Size = new System.Drawing.Size(156, 23);
            this.addSelection2mapBtn.TabIndex = 14;
            this.addSelection2mapBtn.Text = "Voeg selectie aan kaart";
            this.addSelection2mapBtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(379, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Zoom naar selectie";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // poiSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 448);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addSelection2mapBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.keywordLbl);
            this.Controls.Add(this.keywordTxt);
            this.Controls.Add(this.extentCkb);
            this.Controls.Add(this.tyoeLbl);
            this.Controls.Add(this.themeLbl);
            this.Controls.Add(this.categoryLbl);
            this.Controls.Add(this.GemeenteLbl);
            this.Controls.Add(this.gemeenteCbx);
            this.Controls.Add(this.typeCbx);
            this.Controls.Add(this.categoryCbx);
            this.Controls.Add(this.themeCbx);
            this.Controls.Add(this.zoekBtn);
            this.Controls.Add(this.resultGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "poiSearchForm";
            this.Text = "Zoek naar interessante plaats";
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.Button zoekBtn;
        private System.Windows.Forms.ComboBox themeCbx;
        private System.Windows.Forms.ComboBox categoryCbx;
        private System.Windows.Forms.ComboBox typeCbx;
        private System.Windows.Forms.ComboBox gemeenteCbx;
        private System.Windows.Forms.Label GemeenteLbl;
        private System.Windows.Forms.Label categoryLbl;
        private System.Windows.Forms.Label themeLbl;
        private System.Windows.Forms.Label tyoeLbl;
        private System.Windows.Forms.CheckBox extentCkb;
        private System.Windows.Forms.TextBox keywordTxt;
        private System.Windows.Forms.Label keywordLbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button addSelection2mapBtn;
        private System.Windows.Forms.Button button1;
    }
}