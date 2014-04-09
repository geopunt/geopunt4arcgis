using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace geoPunt4Arcgis
{
    public class settingsCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
       
        public settingsCmd() { }

        protected override void OnClick()
        {
            try
            {
                settingsForm settingsFrm;
                settingsFrm = new settingsForm();
                settingsFrm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }
    }
}
