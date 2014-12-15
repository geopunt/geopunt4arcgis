using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace geopunt4Arcgis
{
    public class testBtn : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        IPolygon xy;
        ISpatialReferenceFactory3 spatialReferenceFactory;
        IActiveView activeView ;
        public testBtn()
        {
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            activeView = ArcMap.Document.ActiveView;
        }

        protected override void OnClick()
        {
            try
            {
                string wms = Interaction.InputBox("geef wms op", "WMS toevoegen");
                //bv http://geo.agiv.be/ogc/wms/product/VMM?request=GetCapabilities&version=1.3.0&service=wms 

                if (wms != "")
                {
                    IMap map = activeView.FocusMap;
                    geopuntHelper.addWMS2map(map, wms);
                } 

                //dataHandler.capakey capa = new dataHandler.capakey();
                //datacontract.municipality muni = capa.getMunicipalitiy(
                //    11002, dataHandler.CRS.WGS84, dataHandler.capakeyGeometryType.full);

                //string json = muni.geometry.shape;

                //datacontract.geojsonPolygon js = Newtonsoft.Json.JsonConvert.DeserializeObject<datacontract.geojsonPolygon>(json);
                //xy = geopuntHelper.geojson2esriPolygon(js, (int) dataHandler.CRS.WGS84 );

                //string msg = geopuntHelper.esri2geojsonPolygon(xy).Substring(0,100);
                //MessageBox.Show(msg);
                //Clipboard.SetText(msg);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message + " : " + ex.StackTrace);
            }
        }
    }
}
