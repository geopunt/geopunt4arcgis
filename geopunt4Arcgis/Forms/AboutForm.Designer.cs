namespace geopunt4Arcgis
{
    public partial class AboutGeopunt4arcgisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutGeopunt4arcgisForm));
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.okButton = new System.Windows.Forms.Button();
            this.labelProductName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.descriptionWebBox = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(16, 15);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(311, 103);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.Click += new System.EventHandler(this.logoPictureBox_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(683, 562);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(117, 27);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "Sluiten";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(8, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(453, 21);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.labelProductName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCompanyName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelAuthor, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelVersion, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(335, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(465, 103);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCompanyName.Location = new System.Drawing.Point(8, 25);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(453, 21);
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAuthor
            // 
            this.labelAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAuthor.Location = new System.Drawing.Point(8, 75);
            this.labelAuthor.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelAuthor.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(453, 21);
            this.labelAuthor.TabIndex = 21;
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point(8, 50);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(453, 21);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionWebBox
            // 
            this.descriptionWebBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
<<<<<<< HEAD
            this.descriptionWebBox.Location = new System.Drawing.Point(12, 113);
            this.descriptionWebBox.MinimumSize = new System.Drawing.Size(20, 20);
=======
            this.descriptionWebBox.Location = new System.Drawing.Point(16, 139);
            this.descriptionWebBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.descriptionWebBox.MinimumSize = new System.Drawing.Size(27, 25);
>>>>>>> 3e779762c701ff2f1f36e7643fe6939135544ab5
            this.descriptionWebBox.Name = "descriptionWebBox";
            this.descriptionWebBox.Size = new System.Drawing.Size(780, 416);
            this.descriptionWebBox.TabIndex = 28;
            // 
            // AboutGeopunt4arcgisForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 604);
            this.Controls.Add(this.descriptionWebBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.logoPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutGeopunt4arcgisForm";
<<<<<<< HEAD
            this.Padding = new System.Windows.Forms.Padding(9);
=======
            this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.ShowInTaskbar = false;
>>>>>>> 3e779762c701ff2f1f36e7643fe6939135544ab5
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.WebBrowser descriptionWebBox;

    }
}
