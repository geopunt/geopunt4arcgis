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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(elevationForm));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.msgLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.helpLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.drawLineBtn = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msgLbl,
            this.helpLink});
            this.statusBar.Location = new System.Drawing.Point(0, 324);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(526, 23);
            this.statusBar.TabIndex = 0;
            // 
            // msgLbl
            // 
            this.msgLbl.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.msgLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(475, 18);
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
            // elevationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 347);
            this.Controls.Add(this.drawLineBtn);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "elevationForm";
            this.Text = "Hoogteprofiel";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Button drawLineBtn;
        private System.Windows.Forms.ToolStripStatusLabel msgLbl;
        private System.Windows.Forms.ToolStripStatusLabel helpLink;
    }
}