using System;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace geoPunt4Arcgis
{
    public partial class settingsForm : Form
    {
        RegistryKey geopuntKey;

        public settingsForm()
        {
            //cannot access app.config from addin -> =crap, using registry instead
            geopuntKey = Registry.CurrentUser.CreateSubKey("Software\\geopunt");

            int geopuntTimeOut = (int) geopuntKey.GetValue("geopuntTimeOut", 5000);
            string geopuntProxyUrl = (string) geopuntKey.GetValue("geopuntProxyUrl", "");
            int geopuntProxyPort = (int) geopuntKey.GetValue("geopuntProxyPort", 8080);

            //init UI
            InitializeComponent();
            timeoutNum.Value =  geopuntTimeOut ;
            proxyUrlTxt.Text = geopuntProxyUrl;
            proxyPortNum.Value = geopuntProxyPort;
            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //cannot access app.config from addin -> =crap, using registry instead
            int geopuntTimeOut = (int) ( timeoutNum.Value );
            string geopuntProxyUrl = proxyUrlTxt.Text;
            int geopuntProxyPort = (int) proxyPortNum.Value;

            geopuntKey.SetValue("geopuntTimeOut", geopuntTimeOut);
            geopuntKey.SetValue("geopuntProxyUrl", geopuntProxyUrl);
            geopuntKey.SetValue("geopuntProxyPort" , geopuntProxyPort);

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
