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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusMsgLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.helpLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.keywordTxt = new System.Windows.Forms.TextBox();
            this.keywordLbl = new System.Windows.Forms.Label();
            this.zoekBtn = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMsgLbl,
            this.helpLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 288);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(432, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusMsgLbl
            // 
            this.statusMsgLbl.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusMsgLbl.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.statusMsgLbl.Name = "statusMsgLbl";
            this.statusMsgLbl.Size = new System.Drawing.Size(385, 17);
            this.statusMsgLbl.Spring = true;
            // 
            // helpLbl
            // 
            this.helpLbl.IsLink = true;
            this.helpLbl.Name = "helpLbl";
            this.helpLbl.Size = new System.Drawing.Size(32, 17);
            this.helpLbl.Text = "Help";
            this.helpLbl.Click += new System.EventHandler(this.helpLbl_Click);
            // 
            // keywordTxt
            // 
            this.keywordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.keywordTxt.Location = new System.Drawing.Point(60, 12);
            this.keywordTxt.Name = "keywordTxt";
            this.keywordTxt.Size = new System.Drawing.Size(309, 20);
            this.keywordTxt.TabIndex = 1;
            // 
            // keywordLbl
            // 
            this.keywordLbl.AutoSize = true;
            this.keywordLbl.Location = new System.Drawing.Point(12, 15);
            this.keywordLbl.Name = "keywordLbl";
            this.keywordLbl.Size = new System.Drawing.Size(35, 13);
            this.keywordLbl.TabIndex = 2;
            this.keywordLbl.Text = "Zoek:";
            // 
            // zoekBtn
            // 
            this.zoekBtn.Location = new System.Drawing.Point(345, 38);
            this.zoekBtn.Name = "zoekBtn";
            this.zoekBtn.Size = new System.Drawing.Size(75, 23);
            this.zoekBtn.TabIndex = 3;
            this.zoekBtn.Text = "Zoek";
            this.zoekBtn.UseVisualStyleBackColor = true;
            this.zoekBtn.Click += new System.EventHandler(this.zoekBtn_Click);
            // 
            // catalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 310);
            this.Controls.Add(this.zoekBtn);
            this.Controls.Add(this.keywordLbl);
            this.Controls.Add(this.keywordTxt);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "catalogForm";
            this.Text = "Geopunt Catalogus";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusMsgLbl;
        private System.Windows.Forms.ToolStripStatusLabel helpLbl;
        private System.Windows.Forms.TextBox keywordTxt;
        private System.Windows.Forms.Label keywordLbl;
        private System.Windows.Forms.Button zoekBtn;
    }
}