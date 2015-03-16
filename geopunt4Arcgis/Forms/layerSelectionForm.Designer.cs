namespace geopunt4Arcgis
{
    partial class layerSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(layerSelectionForm));
            this.layersListCbx = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addToMapBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // layersListCbx
            // 
            this.layersListCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layersListCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layersListCbx.FormattingEnabled = true;
            this.layersListCbx.Location = new System.Drawing.Point(12, 45);
            this.layersListCbx.Name = "layersListCbx";
            this.layersListCbx.Size = new System.Drawing.Size(364, 24);
            this.layersListCbx.TabIndex = 0;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(258, 118);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(118, 38);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Annuleer";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addToMapBtn
            // 
            this.addToMapBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addToMapBtn.Location = new System.Drawing.Point(130, 118);
            this.addToMapBtn.Name = "addToMapBtn";
            this.addToMapBtn.Size = new System.Drawing.Size(122, 38);
            this.addToMapBtn.TabIndex = 2;
            this.addToMapBtn.Text = "Voeg toe";
            this.addToMapBtn.UseVisualStyleBackColor = true;
            this.addToMapBtn.Click += new System.EventHandler(this.addToMapBtn_Click);
            // 
            // layerSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 168);
            this.Controls.Add(this.addToMapBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.layersListCbx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(10000, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "layerSelectionForm";
            this.Text = "Selecteer een laag";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox layersListCbx;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button addToMapBtn;

    }
}