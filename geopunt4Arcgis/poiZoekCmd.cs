using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace geoPunt4Arcgis
{
    public class poiZoekCmd : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IActiveView view;

        public poiZoekCmd()
        {
            view = ArcMap.Document.ActiveView;
        }

        protected override void OnClick()
        {
            try
            {

                if (view.Extent.SpatialReference == null)
                {
                    System.Windows.Forms.MessageBox.Show("Je moet eerst een Coördinaatsysteem instellen");
                    return;
                }

                if (view.Extent.SpatialReference.FactoryCode == 4326 ||   //= wgs84
                    view.Extent.SpatialReference.FactoryCode == 31370 ||  //= lam72
                    view.Extent.SpatialReference.FactoryCode == 4258 ||   //=ETRS89
                    view.Extent.SpatialReference.FactoryCode == 32631 ||  //= WGS utm 31n
                    view.Extent.SpatialReference.FactoryCode == 3043 ||   //= ETRS89 utm 31n
                    view.Extent.SpatialReference.FactoryCode == 3857 ||   //= web mercator
                    view.Extent.SpatialReference.FactoryCode == 102100 || //= 3857
                    view.Extent.SpatialReference.FactoryCode == 900913    //= 3857
                    )
                {

                    poiZoekForm poiZoekFrm = new poiZoekForm();
                    poiZoekFrm.Show();
                }
                else System.Windows.Forms.MessageBox.Show("Dit CRS is niet ondersteund: " +
                        view.Extent.SpatialReference.FactoryCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }
    }
}
