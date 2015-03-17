using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace geopunt4Arcgis
{
    public class geopuntSettingsCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        settingsForm settingsDlg;
        geopunt4arcgisExtension gpExtension;

        public geopuntSettingsCmd()
        {
            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
        }

        protected override void OnClick()
        {

            if (settingsDlg != null)
            {
                if (settingsDlg.IsDisposed)
                {
                    settingsDlg = null;
                }
                else
                {
                    if (!settingsDlg.Visible) settingsDlg.Show();
                    settingsDlg.WindowState = FormWindowState.Normal;
                    settingsDlg.Focus();
                    return;
                }
            }
            settingsDlg = new settingsForm();
            gpExtension.settingsDlg = settingsDlg;
            settingsDlg.Show();
            settingsDlg.WindowState = FormWindowState.Normal;
            settingsDlg.Focus();
        }

    }
}
