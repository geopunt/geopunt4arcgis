namespace geoPunt4Arcgis
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.labelClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeOutLbl = new System.Windows.Forms.Label();
            this.timeoutNum = new System.Windows.Forms.NumericUpDown();
            this.proxyGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.proxyPortNum = new System.Windows.Forms.NumericUpDown();
            this.proxyUrlTxt = new System.Windows.Forms.TextBox();
            this.proxyPortLbl = new System.Windows.Forms.Label();
            this.proxyUrlLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.labelClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutNum)).BeginInit();
            this.proxyGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proxyPortNum)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(214, 166);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(94, 23);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Opslaan";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(314, 166);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Annuleren";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // labelClassBindingSource
            // 
            this.labelClassBindingSource.DataSource = typeof(geoPunt4Arcgis.labelClass);
            // 
            // timeOutLbl
            // 
            this.timeOutLbl.AutoSize = true;
            this.timeOutLbl.Location = new System.Drawing.Point(13, 13);
            this.timeOutLbl.Name = "timeOutLbl";
            this.timeOutLbl.Size = new System.Drawing.Size(131, 13);
            this.timeOutLbl.TabIndex = 2;
            this.timeOutLbl.Text = "Timeout (in milliseconden):";
            // 
            // timeoutNum
            // 
            this.timeoutNum.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.timeoutNum.Location = new System.Drawing.Point(150, 13);
            this.timeoutNum.Maximum = new decimal(new int[] {
            120000,
            0,
            0,
            0});
            this.timeoutNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeoutNum.Name = "timeoutNum";
            this.timeoutNum.Size = new System.Drawing.Size(102, 20);
            this.timeoutNum.TabIndex = 3;
            this.timeoutNum.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // proxyGroup
            // 
            this.proxyGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.proxyGroup.Controls.Add(this.label1);
            this.proxyGroup.Controls.Add(this.proxyPortNum);
            this.proxyGroup.Controls.Add(this.proxyUrlTxt);
            this.proxyGroup.Controls.Add(this.proxyPortLbl);
            this.proxyGroup.Controls.Add(this.proxyUrlLbl);
            this.proxyGroup.Location = new System.Drawing.Point(12, 50);
            this.proxyGroup.Name = "proxyGroup";
            this.proxyGroup.Size = new System.Drawing.Size(396, 107);
            this.proxyGroup.TabIndex = 4;
            this.proxyGroup.TabStop = false;
            this.proxyGroup.Text = "Proxy Instellingen";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "(bv: http://proxy.vlaanderen.be)";
            // 
            // proxyPortNum
            // 
            this.proxyPortNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.proxyPortNum.Location = new System.Drawing.Point(75, 68);
            this.proxyPortNum.Maximum = new decimal(new int[] {
            1874919424,
            2328306,
            0,
            0});
            this.proxyPortNum.Name = "proxyPortNum";
            this.proxyPortNum.Size = new System.Drawing.Size(96, 20);
            this.proxyPortNum.TabIndex = 4;
            this.proxyPortNum.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // proxyUrlTxt
            // 
            this.proxyUrlTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.proxyUrlTxt.Location = new System.Drawing.Point(75, 26);
            this.proxyUrlTxt.Name = "proxyUrlTxt";
            this.proxyUrlTxt.Size = new System.Drawing.Size(308, 20);
            this.proxyUrlTxt.TabIndex = 2;
            // 
            // proxyPortLbl
            // 
            this.proxyPortLbl.AutoSize = true;
            this.proxyPortLbl.Location = new System.Drawing.Point(6, 68);
            this.proxyPortLbl.Name = "proxyPortLbl";
            this.proxyPortLbl.Size = new System.Drawing.Size(67, 13);
            this.proxyPortLbl.TabIndex = 1;
            this.proxyPortLbl.Text = "Proxy Poort: ";
            // 
            // proxyUrlLbl
            // 
            this.proxyUrlLbl.AutoSize = true;
            this.proxyUrlLbl.Location = new System.Drawing.Point(6, 33);
            this.proxyUrlLbl.Name = "proxyUrlLbl";
            this.proxyUrlLbl.Size = new System.Drawing.Size(55, 13);
            this.proxyUrlLbl.TabIndex = 0;
            this.proxyUrlLbl.Text = "Proxy Url: ";
            // 
            // settingsForm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(420, 201);
            this.Controls.Add(this.proxyGroup);
            this.Controls.Add(this.timeoutNum);
            this.Controls.Add(this.timeOutLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 228);
            this.Name = "settingsForm";
            this.ShowInTaskbar = false;
            this.Text = "Instellingen";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.labelClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutNum)).EndInit();
            this.proxyGroup.ResumeLayout(false);
            this.proxyGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proxyPortNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.BindingSource labelClassBindingSource;
        private System.Windows.Forms.Label timeOutLbl;
        private System.Windows.Forms.NumericUpDown timeoutNum;
        private System.Windows.Forms.GroupBox proxyGroup;
        private System.Windows.Forms.NumericUpDown proxyPortNum;
        private System.Windows.Forms.TextBox proxyUrlTxt;
        private System.Windows.Forms.Label proxyPortLbl;
        private System.Windows.Forms.Label proxyUrlLbl;
        private System.Windows.Forms.Label label1;
    }
}