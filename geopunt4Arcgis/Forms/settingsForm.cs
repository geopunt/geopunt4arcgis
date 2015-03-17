using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace geopunt4Arcgis
{
    public partial class settingsForm : Form
    {
        geopunt4arcgisExtension gpExtension;

        public settingsForm()
        {
            InitializeComponent();
            initGui();
        }

        private void initGui()
        {
            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
            try
            {
                maxRowCsvNum.Value = (decimal)gpExtension.csvMaxRows;
                timeOutnum.Value = (decimal)(gpExtension.timeout / 1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            gpExtension.csvMaxRows= (int)( maxRowCsvNum.Value );
            gpExtension.timeout = (int)(timeOutnum.Value * 1000);
            this.Close();
        }
    }
}
