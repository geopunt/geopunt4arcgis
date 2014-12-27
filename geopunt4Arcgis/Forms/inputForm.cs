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
    public partial class inputForm : Form
    {
        public string message;
        public bool accepted;

        public inputForm(string infomessage)
        {
            InitializeComponent();
            msgLbl.Text = infomessage;
            accepted = false;
        }

        public static string showInputDlg(string infomessage, IWin32Window owner)
        {
            inputForm dlg = new inputForm(infomessage);
            dlg.ShowDialog(owner);
            if (dlg.accepted) 
            {
                return dlg.message;
            }
            else
            {
                return null;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            accepted = true;
            this.Close();
        }

        private void text_TextChanged(object sender, EventArgs e)
        {
            message = msgTxt.Text;
        }


    }
}
