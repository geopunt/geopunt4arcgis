namespace geopunt4Arcgis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.timeoutLbl = new System.Windows.Forms.Label();
            this.timeOutnum = new System.Windows.Forms.NumericUpDown();
            this.maxRowsLbl = new System.Windows.Forms.Label();
            this.maxRowCsvNum = new System.Windows.Forms.NumericUpDown();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRowCsvNum)).BeginInit();
            this.SuspendLayout();
            // 
            // timeoutLbl
            // 
            this.timeoutLbl.AutoSize = true;
            this.timeoutLbl.Location = new System.Drawing.Point(12, 9);
            this.timeoutLbl.Name = "timeoutLbl";
            this.timeoutLbl.Size = new System.Drawing.Size(291, 17);
            this.timeoutLbl.TabIndex = 0;
            this.timeoutLbl.Text = "Timeout voor internetconnecties (seconden):";
            // 
            // timeOutnum
            // 
            this.timeOutnum.Location = new System.Drawing.Point(171, 33);
            this.timeOutnum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.timeOutnum.Name = "timeOutnum";
            this.timeOutnum.Size = new System.Drawing.Size(129, 22);
            this.timeOutnum.TabIndex = 1;
            this.timeOutnum.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // maxRowsLbl
            // 
            this.maxRowsLbl.AutoSize = true;
            this.maxRowsLbl.Location = new System.Drawing.Point(12, 75);
            this.maxRowsLbl.Name = "maxRowsLbl";
            this.maxRowsLbl.Size = new System.Drawing.Size(284, 17);
            this.maxRowsLbl.TabIndex = 2;
            this.maxRowsLbl.Text = "Maximaal aantal rijen voor csv geocodering:";
            // 
            // maxRowCsvNum
            // 
            this.maxRowCsvNum.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maxRowCsvNum.Location = new System.Drawing.Point(171, 105);
            this.maxRowCsvNum.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.maxRowCsvNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxRowCsvNum.Name = "maxRowCsvNum";
            this.maxRowCsvNum.Size = new System.Drawing.Size(129, 22);
            this.maxRowCsvNum.TabIndex = 3;
            this.maxRowCsvNum.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(202, 161);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(98, 35);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Opslaan";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(79, 161);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(103, 35);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Annuleer";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // settingsForm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(312, 208);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.maxRowCsvNum);
            this.Controls.Add(this.maxRowsLbl);
            this.Controls.Add(this.timeOutnum);
            this.Controls.Add(this.timeoutLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 240);
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "settingsForm";
            this.Text = "Instellingen";
            ((System.ComponentModel.ISupportInitialize)(this.timeOutnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRowCsvNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeoutLbl;
        private System.Windows.Forms.NumericUpDown timeOutnum;
        private System.Windows.Forms.Label maxRowsLbl;
        private System.Windows.Forms.NumericUpDown maxRowCsvNum;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}