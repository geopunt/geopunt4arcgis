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

        public aboutCmd()
        {
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
            about.Show();
            about.WindowState = FormWindowState.Normal;
            about.Focus();
        }

    }
}
