using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Geometry;
using System.Windows.Forms;


namespace geopunt4Arcgis
{
    public class testBtn : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IPoint xy;
        public testBtn()
        {
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            ISpatialReferenceFactory3 spatialReferenceFactory = obj as ISpatialReferenceFactory3;
            //new PointClass() {X= 15, Y=45, SpatialReference = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326)  };
        }

        protected override void OnClick()
        {
            try
            {
                string json = @"{coordinates: [ 3.7225998287631654, 51.091958256371555 ],
                                    type: 'Point',
                                    crs: {
                                    type: 'name',
                                    properties: {name: 'urn:ogc:def:crs:OGC:1.3:CRS84'}
                                    } }";
                datacontract.geojsonPoint js = Newtonsoft.Json.JsonConvert.DeserializeObject<datacontract.geojsonPoint>(json);

                xy = geopuntHelper.geojson2esriPoint(js);

                MessageBox.Show( xy.IsEmpty.ToString() );

                string msg = geopuntHelper.esri2geojsonPoint(xy);
                MessageBox.Show(msg);
                Clipboard.SetText(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }
    }
}
