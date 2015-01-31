using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;

namespace geopunt4Arcgis
{
    public class geopuntMetaCatalogCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IActiveView view;
        geopunt4arcgisExtension gpExtension;
        catalogForm catalogDlg;

        public geopuntMetaCatalogCmd()
        {
            view = ArcMap.Document.ActiveView;
            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();
        }

        protected override void OnClick()
        {
            //try
            //{
            //    dataHandler.catalog clg = new dataHandler.catalog();
            //    string[] keys = clg.getSources().Select( c => c.Key ).ToArray<string>();
            //    MessageBox.Show(String.Join(",", keys));

            //    MessageBox.Show(String.Join(",", clg.inspireKeywords().ToArray() ));

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show( ex.Message +" : "+ ex.StackTrace );
            //}

            try
            {
                if (view.FocusMap.SpatialReference == null)
                {
                    MessageBox.Show("Je moet eerst een Coördinaatsysteem instellen");
                    return;
                }
                if (catalogDlg != null)
                {
                    if (catalogDlg.IsDisposed)
                    {
                        catalogDlg = null;
                    }
                    else
                    {
                        if (!catalogDlg.Visible) catalogDlg.Show();
                        catalogDlg.WindowState = FormWindowState.Normal;
                        catalogDlg.Focus();
                        return;
                    }
                }
                catalogDlg = new catalogForm();
                gpExtension.catalogDLg = catalogDlg;
                catalogDlg.Show();
                catalogDlg.WindowState = FormWindowState.Normal;
                catalogDlg.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }

        }
    }
}
