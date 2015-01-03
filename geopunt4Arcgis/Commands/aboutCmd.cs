using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace geopunt4Arcgis
{
    public class aboutCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        AboutGeopunt4arcgisForm about;
        geopunt4arcgisExtension gpExtension;

        public aboutCmd()
        {
            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
        }

        protected override void OnClick()
        {
            if (about != null) 
            {
                if (about.IsDisposed)
                {
                    about = null;
                }
                else
                {
                    if (!about.Visible) about.Show();
                    about.WindowState = FormWindowState.Normal;
                    about.Focus();
                    return;
                }
            }
            about = new AboutGeopunt4arcgisForm();
            gpExtension.aboutDlg = about;
            about.Show();
            about.WindowState = FormWindowState.Normal;
            about.Focus();
        }

    }
}
