
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

using System.IO;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace geopunt4Arcgis
{
    static class geopuntHelper
    {
        #region "geometry operations"
        /// <summary>
        /// Reproject geometry to wanted crs, optimized for Lam72
        /// </summary>
        /// <param name="geom">input geometry, with a set crs</param>
        /// <param name="toSrs">srs to project too</param>
        /// <returns></returns>
        public static IGeometry Transform(IGeometry geom, ISpatialReference toSrs)
        {
            if (toSrs == null || geom.SpatialReference == null || toSrs.FactoryCode == geom.SpatialReference.FactoryCode)
            {
                return geom;
            }
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            ISpatialReferenceFactory2 spatialReferenceFactory2 = obj as ISpatialReferenceFactory2;

            if (toSrs.FactoryCode == 31370)
            {
                IGeoTransformation geoTransformation = spatialReferenceFactory2.CreateGeoTransformation((int)
                    esriSRGeoTransformation3Type.esriSRGeoTransformation_Belge_1972_To_WGS_1984_2) as IGeoTransformation;

                IGeometry2 geometry = geom as IGeometry2; //clone geom as IGeometry2
                geometry.ProjectEx(toSrs, esriTransformDirection.esriTransformReverse, geoTransformation, false, 0, 0);

                return geometry as IGeometry;
            }
            if (geom.SpatialReference.FactoryCode == 31370)
            {
                IGeoTransformation geoTransformation = spatialReferenceFactory2.CreateGeoTransformation((int)
                    esriSRGeoTransformation3Type.esriSRGeoTransformation_Belge_1972_To_WGS_1984_2) as IGeoTransformation;

                IGeometry2 geometry = geom as IGeometry2; //clone geom as IGeometry2
                geometry.ProjectEx(toSrs, esriTransformDirection.esriTransformForward, geoTransformation, false, 0, 0);

                return geometry as IGeometry;
            }
            else
            {
                IGeometry geometry = geom; //clone geom
                geometry.Project(toSrs);
                return geometry;
            }
        }

        /// <summary>
        /// Reproject geometry to wanted WGS84, optimized for Lam72
        /// </summary>
        /// <param name="geom">the geometry to project</param>
        /// <returns>the projected geometry</returns>
        public static IGeometry Transform2WGS(IGeometry geom)
        {
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            ISpatialReferenceFactory2 spatialReferenceFactory2 = obj as ISpatialReferenceFactory2;
            ISpatialReference wgs = spatialReferenceFactory2.CreateGeographicCoordinateSystem(4326);

            if (geom.SpatialReference.FactoryCode == 4326)
            {
                return geom;
            }

            if (geom.SpatialReference.FactoryCode == 31370)
            {

                IGeoTransformation geoTransformation = spatialReferenceFactory2.CreateGeoTransformation((int)
                    esriSRGeoTransformation3Type.esriSRGeoTransformation_Belge_1972_To_WGS_1984_2) as IGeoTransformation;

                IGeometry2 geometry = geom as IGeometry2; //clone geom as IGeometry2
                geometry.ProjectEx(wgs, esriTransformDirection.esriTransformForward, geoTransformation, false, 0, 0);

                return geometry as IGeometry;
            }
            else
            {
                IGeometry geometry = geom; //clone geom
                geometry.Project(wgs);
                return geometry;
            }
        }

        /// <summary>
        /// Reproject geometry to wanted Lam72
        /// </summary>
        /// <param name="geom">the geometry to project</param>
        /// <returns>the projected geometry</returns>
        public static IGeometry Transform2Lam72(IGeometry geom)
        {
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            ISpatialReferenceFactory2 spatialReferenceFactory2 = obj as ISpatialReferenceFactory2;
            ISpatialReference lam72 = spatialReferenceFactory2.CreateSpatialReference(31370);

            if (geom.SpatialReference.FactoryCode == 31370)
            {
                return geom;
            }

            if (geom.SpatialReference.FactoryCode == 4326 ||   //= wgs84
                    geom.SpatialReference.FactoryCode == 4258 ||   //=ETRS89
                    geom.SpatialReference.FactoryCode == 32631 ||  //= WGS utm 31n
                    geom.SpatialReference.FactoryCode == 3043 ||   //= ETRS89 utm 31n
                    geom.SpatialReference.FactoryCode == 3857 ||   //= web mercator
                    geom.SpatialReference.FactoryCode == 102100 || //= 3857
                    geom.SpatialReference.FactoryCode == 900913)  //= 3857
            {

                IGeoTransformation geoTransformation = spatialReferenceFactory2.CreateGeoTransformation((int)
                    esriSRGeoTransformation3Type.esriSRGeoTransformation_Belge_1972_To_WGS_1984_2) as IGeoTransformation;

                IGeometry2 geometry = geom as IGeometry2; //clone geom as IGeometry2
                geometry.ProjectEx(lam72, esriTransformDirection.esriTransformReverse, geoTransformation, false, 0, 0);

                return geometry as IGeometry;
            }
            else
            {
                IGeometry geometry = geom; //clone geom
                geometry.Project(lam72);
                return geometry;
            }
        }


        /// <summary>
        /// make arcgis IEnvelope from Xmin|Ymin|Xmax|Ymax
        /// </summary>
        /// <param name="xmin">lowest x-coordinate in given srs</param>
        /// <param name="ymin">lowest y-coordinate in given srs<</param>
        /// <param name="xmax">highest x-coordinate in given srs<</param>
        /// <param name="ymax">highest x-coordinate in given srs<</param>
        /// <param name="srs">the srs of the bbox</param>
        /// <returns></returns>
        public static IEnvelope makeExtend(Double xmin, Double ymin, Double xmax, Double ymax, ISpatialReference srs)
        {
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords(xmin, ymin, xmax, ymax);
            envelope.SpatialReference = srs;
            return envelope;
        }
        #endregion

        #region "Flash Geometry"

        ///<summary>Flash geometry on the display. The geometry type could be polygon, polyline, point, or multipoint.</summary>
        ///
        ///<param name="geometry"> An IGeometry interface</param>
        ///<param name="color">An IRgbColor interface</param>
        ///<param name="display">An IDisplay interface</param>
        ///<param name="delay">A System.Int32 that is the time im milliseconds to wait.</param>
        /// 
        ///<remarks></remarks>
        public static void FlashGeometry(IGeometry geometry, IRgbColor color, IDisplay display, System.Int32 delay)
        {
            if (geometry == null || color == null || display == null)
            {
                return;
            }

            display.StartDrawing(display.hDC, (System.Int16)esriScreenCache.esriNoScreenCache); // Explicit Cast

            switch (geometry.GeometryType)
            {
                case esriGeometryType.esriGeometryPolygon:
                    {
                        //Set the flash geometry's symbol.
                        ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
                        simpleFillSymbol.Color = color;
                        ISymbol symbol = simpleFillSymbol as ISymbol; // Dynamic Cast
                        symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

                        //Flash the input polygon geometry.
                        display.SetSymbol(symbol);
                        display.DrawPolygon(geometry);
                        System.Threading.Thread.Sleep(delay);
                        display.DrawPolygon(geometry);
                        break;
                    }

                case esriGeometryType.esriGeometryPolyline:
                    {
                        //Set the flash geometry's symbol.
                        ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
                        simpleLineSymbol.Width = 4;
                        simpleLineSymbol.Color = color;
                        ISymbol symbol = simpleLineSymbol as ISymbol; // Dynamic Cast
                        symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

                        //Flash the input polyline geometry.
                        display.SetSymbol(symbol);
                        display.DrawPolyline(geometry);
                        System.Threading.Thread.Sleep(delay);
                        display.DrawPolyline(geometry);
                        break;
                    }

                case esriGeometryType.esriGeometryPoint:
                    {
                        //Set the flash geometry's symbol.
                        ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                        simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                        simpleMarkerSymbol.Size = 12;
                        simpleMarkerSymbol.Color = color;
                        ISymbol symbol = simpleMarkerSymbol as ISymbol; // Dynamic Cast
                        symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

                        //Flash the input point geometry.
                        display.SetSymbol(symbol);
                        display.DrawPoint(geometry);
                        System.Threading.Thread.Sleep(delay);
                        display.DrawPoint(geometry);
                        break;
                    }

                case esriGeometryType.esriGeometryMultipoint:
                    {
                        //Set the flash geometry's symbol.
                        ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                        simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                        simpleMarkerSymbol.Size = 12;
                        simpleMarkerSymbol.Color = color;
                        ISymbol symbol = simpleMarkerSymbol as ISymbol; // Dynamic Cast
                        symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

                        //Flash the input multipoint geometry.
                        display.SetSymbol(symbol);
                        display.DrawMultipoint(geometry);
                        System.Threading.Thread.Sleep(delay);
                        display.DrawMultipoint(geometry);
                        break;
                    }
            }
            display.FinishDrawing();
        }
        #endregion

        #region "Zoom by Ratio and Recenter"

        ///<summary>Zoom in ActiveView using a ratio of the current extent and re-center based upon supplied x,y map coordinates.</summary>
        ///
        ///<param name="activeView">An IActiveView interface.</param>
        ///<param name="zoomRatio">A System.Double that is the ratio to zoom in. Less that 1 zooms in</param>
        ///<param name="xMap">A System.Double that is the x portion of a point in map units to re-center on.</param>
        ///<param name="yMap">A System.Double that is the y portion of a point in map units to re-center on.</param>
        /// 
        ///<remarks>Both the width and height ratio of the zoomed area is preserved.</remarks>
        public static void ZoomByRatioAndRecenter(IActiveView activeView, System.Double zoomRatio, System.Double xMap, System.Double yMap)
        {
            if (activeView == null || zoomRatio < 0)
            {
                return;
            }
            IEnvelope envelope = activeView.Extent;
            IPoint point = new PointClass();
            point.X = xMap;
            point.Y = yMap;
            envelope.CenterAt(point);
            envelope.Expand(zoomRatio, zoomRatio, true);
            activeView.Extent = envelope;
        }
        #endregion

        #region "Add Graphic markter to Map"
        ///<summary>Draw a specified graphic on the map using the supplied colors.</summary>
        ///      
        ///<param name="map">An IMap interface.</param>
        ///<param name="geometry">An IPoint interface. It can be of the geometry type esriGeometryPoint</param>
        ///<param name="rgbColor">An IRgbColor interface. The color to draw the geometry.</param>
        ///<param name="outlineRgbColor">An IRgbColor interface. For those geometry's with an outline it will be this color.</param>
        ///<param name="size">size in pixel as integer</param>
        public static IElement AddGraphicToMap(IMap map, IPoint geometry, IRgbColor rgbColor, IRgbColor outlineRgbColor, int size)
        {
            IGraphicsContainer graphicsContainer = (IGraphicsContainer)map; // Explicit Cast
            IElement element = null;
            if ((geometry.GeometryType) == esriGeometryType.esriGeometryPoint)
            {
                // Marker symbols
                ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                simpleMarkerSymbol.Color = rgbColor;
                simpleMarkerSymbol.Outline = true;
                simpleMarkerSymbol.OutlineColor = outlineRgbColor;
                simpleMarkerSymbol.Size = size;
                simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSDiamond;

                IMarkerElement markerElement = new MarkerElementClass();
                markerElement.Symbol = simpleMarkerSymbol;
                element = (IElement)markerElement; // Explicit Cast
            }

            if (!(element == null))
            {
                element.Geometry = geometry;
                graphicsContainer.AddElement(element, 0);
            }
            return element;
        }
        #endregion

        #region "Add text to map"
        public static IElement AddTextElement(IMap map, IPoint point, string text)
        {
            IGraphicsContainer graphicsContainer = map as IGraphicsContainer;
            IElement element = new TextElementClass();
            ITextElement textElement = element as ITextElement;

            element.Geometry = point;
            textElement.Text = text;
            graphicsContainer.AddElement(element, 0);
            return element;
        }
        #endregion    

        #region "create a field"
        /// <summary>
        /// create a single fieldClass 
        /// </summary>
        /// <param name="name">the name of field</param>
        /// <param name="fieldType">the type of the record: string, int, double or date</param>
        /// <param name="len">the of a string field, ignored for other types</param>
        /// <returns>the fieldClass</returns>
        public static IField createField( string name, esriFieldType fieldType = esriFieldType.esriFieldTypeString , int len = 64 ) 
        {
            IField field = new FieldClass();
            IFieldEdit fieldEdit = (IFieldEdit)field;
            fieldEdit.Name_2 = name;
            fieldEdit.Type_2 =  fieldType;
            fieldEdit.Length_2 = len;
            return field;
        }

        #endregion

        #region "create ShapeFile / featureclass"
        /// <summary>Create a ESRI shapefile </summary>
        /// <param name="shapeFilePath">the path to the shapefile</param>
        /// <param name="field2add">List of Ifields</param>
        /// <param name="srs">the srs of the shapefile</param>
        /// <param name="geomType">the type geometry: point, polyline, polygon, ...</param>
        /// <param name="deleteIfExists">Overwrite existing FeatureClass</param>
        /// <returns>the shapefile loaded in a IFeatureClass</returns>
        public static IFeatureClass createShapeFile(string shapeFilePath, List<IField> field2add , 
                                                    ISpatialReference srs, esriGeometryType geomType, bool deleteIfExists = true )
        {
            FileInfo shapeInfo = new FileInfo(shapeFilePath);

            // Instantiate a feature class description to get the required fields.
            IFeatureClassDescription fcDescription = new FeatureClassDescriptionClass();
            IObjectClassDescription ocDescription = fcDescription as IObjectClassDescription;

            IFields fields = ocDescription.RequiredFields;
            IFieldsEdit fieldsEdit = fields as IFieldsEdit;

            // Find the shape field in the required fields and modify its GeometryDef to
            // use wanted geometry and to set the spatial reference.
            int shapeFieldIndex = fields.FindField(fcDescription.ShapeFieldName);
            IField geofield = fields.get_Field(shapeFieldIndex);
            IGeometryDef geometryDef = geofield.GeometryDef;
            IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
            geometryDefEdit.GeometryType_2 = geomType;
            geometryDefEdit.SpatialReference_2 = srs;

            foreach (IField field in field2add)
            {
                fieldsEdit.AddField(field);
            }

            IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
            IWorkspace workspace = workspaceFactory.OpenFromFile( shapeInfo.DirectoryName , 0);
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace) workspace; // Explict Cast

            IWorkspace2 ws = (IWorkspace2)featureWorkspace;
            if ( shapeInfo.Exists )
            {
                if (deleteIfExists)
                {
                    if (!deleteFeatureClass(shapeInfo.FullName)) 
                    {
                        throw new Exception(shapeInfo.Name + " exists and cannot be deleted");
                    }
                }
                else
                {
                    throw new Exception(shapeInfo.Name + " exists");
                }
            }

            IFeatureClass featureClass = featureWorkspace.CreateFeatureClass(shapeInfo.Name, fields, 
                                               ocDescription.InstanceCLSID,  ocDescription.ClassExtensionCLSID, 
                                               esriFeatureType.esriFTSimple, fcDescription.ShapeFieldName, "");

            return featureClass;
        }
        /// <summary>Create a feature class in a existing FGDB </summary>
        /// <param name="FGDBPath">Path to the existing FGDB</param>
        /// <param name="FCname">Name of the new FeatureClass</param>
        /// <param name="field2add">List of Ifields</param>
        /// <param name="srs">the srs of the shapefile</param>
        /// <param name="geomType">the type geometry: point, polyline, polygon, ...</param>
        /// <param name="deleteIfExists">Overwrite existing FeatureClass</param>
        /// <returns>the Feuture Class loaded in a IFeatureClass</returns>
        public static IFeatureClass createFeatureClass(string FGDBPath, string FCname, List<IField> field2add,
                                                    ISpatialReference srs, esriGeometryType geomType, bool deleteIfExists = true)
        {
            DirectoryInfo fgbInfo = new DirectoryInfo(FGDBPath);

            // Instantiate a feature class description to get the required fields.
            IFeatureClassDescription fcDescription = new FeatureClassDescriptionClass();
            IObjectClassDescription ocDescription = fcDescription as IObjectClassDescription;

            IFields fields = ocDescription.RequiredFields;
            IFieldsEdit fieldsEdit = fields as IFieldsEdit;

            // Find the shape field in the required fields and modify its GeometryDef to
            // use wanted geometry and to set the spatial reference.
            int shapeFieldIndex = fields.FindField(fcDescription.ShapeFieldName);
            IField geofield = fields.get_Field(shapeFieldIndex);
            IGeometryDef geometryDef = geofield.GeometryDef;
            IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
            geometryDefEdit.GeometryType_2 = geomType;
            geometryDefEdit.SpatialReference_2 = srs;

            foreach (IField field in field2add)
            {
                fieldsEdit.AddField(field);
            }

            IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactoryClass();
            IWorkspace2 workspace = (IWorkspace2)workspaceFactory.OpenFromFile(FGDBPath, 0);
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace;     // Explict Cast

            if (workspace.get_NameExists(esriDatasetType.esriDTFeatureClass, FCname))
            {
                if (deleteIfExists)
                {
                    if (!deleteFeatureClass(fgbInfo.FullName +"\\"+ FCname ))
                    {
                        throw new Exception(FCname + " exists and cannot be deleted");
                    }
                }
                else
                {
                    throw new Exception(FCname + " exists");
                }
            }
            IFeatureClass featureClass = featureWorkspace.CreateFeatureClass( FCname , fields,
                                               ocDescription.InstanceCLSID, ocDescription.ClassExtensionCLSID,
                                               esriFeatureType.esriFTSimple, fcDescription.ShapeFieldName, "");

            return featureClass;
        }
        #endregion

        #region "add featureclass to map"
        /// <summary> Add feature class to active View and then zoom to its extend </summary>
        /// <param name="view">the current active view</param>
        /// <param name="inFeatureClass">the feature class to add</param>
        /// <param name="zoomTo">zoom to loaded feature class</param>
        /// <returns>the created layer</returns>
        public static IFeatureLayer addFeatureClassToMap(IActiveView view, IFeatureClass inFeatureClass, bool zoomTo = false)
        {
            IFeatureLayer featureLayer = new FeatureLayerClass();
            featureLayer.FeatureClass = inFeatureClass;
            featureLayer.Name = inFeatureClass.AliasName;
            featureLayer.Visible = true;
            view.FocusMap.AddLayer(featureLayer);

            if(zoomTo) view.Extent = featureLayer.AreaOfInterest;
                
            view.Refresh();
            return featureLayer;
        }

        #endregion

        #region "internet available?"
        /// <summary>check if internet available </summary>
        public static bool IsConnectedToInternet
        {
            get
            {
                try 
                {
                    HttpWebRequest hwebRequest = (HttpWebRequest)WebRequest.Create("http://kgis.be/"); 
                    hwebRequest.Timeout = 5000; //5 seconds timeout to process the request.
                    HttpWebResponse hWebResponse = (HttpWebResponse)hwebRequest.GetResponse(); //Process the request.
                    if (hWebResponse.StatusCode == HttpStatusCode.OK) //Get the response.
                    {
                        return true; //If true, the user is connected to the internet.
                    }
                    else return false; //Else it is not.
                }
                catch (Exception ex) {
                    MessageBox.Show("Geen internet connectie, misschien moet je een proxy instellen?", ex.Message);
                    return false;
                }
            }
        }
        #endregion

        #region "Delete shapefile or FGDB Feature Class"
        /// <summary>Delete a existing shapefile</summary>
        /// <param name="path">the full path to the shapefile (*.shp)</param>
        /// <returns>return if succesfull otherwise false</returns> 
        public static bool deleteFeatureClass( string path ){
            try
            {
                FileInfo featureClassPath = new FileInfo(path);

                if (featureClassPath.Exists && featureClassPath.Extension == ".shp")
                {
                    //create factory
                    IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
                    IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(
                                             featureClassPath.DirectoryName, 0);
                    //create featureclass 
                    IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(
                                             featureClassPath.Name.Replace(featureClassPath.Extension, ""));
                    //cast tot dataset and delete
                    IDataset ds = featureClass as IDataset;
                    if (ds.CanDelete())
                    {
                        ds.Delete();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ( featureClassPath.DirectoryName.ToLowerInvariant().EndsWith(".gdb") )
                {
                     IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactoryClass();
                     IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile( 
                                                                                      featureClassPath.DirectoryName, 0);
                     IWorkspace2 ws = (IWorkspace2)featureWorkspace;
                     if (!ws.get_NameExists(esriDatasetType.esriDTFeatureClass, featureClassPath.Name))
                     {
                         return false;
                     }
                     IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(featureClassPath.Name);
                     IDataset ds = featureClass as IDataset;
                     if (ds.CanDelete())
                     {
                         ds.Delete();
                         return true;
                     }
                     else
                     {
                         return false;
                     }
                }
                else
                {
                    throw new Exception("File is not a shapefile or Filegeodatabase Feature Class");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace +" : "+ ex.Message);
                return false;
            }
        }
        #endregion

        #region "open / save dialogs"
        /// <summary> Shows dialog for opening map layers / data.</summary>
        /// <param name="filters"> for example:
        ///       IGxObjectFilter ipFilter1 = new GxFilterFGDBFeatureClassesClass() ;
        ///       List<IGxObjectFilter> gxFilterList = new List<IGxObjectFilter>(new IGxObjectFilter[] { ipFilter1 });</param>
        /// <param name="dialogTitle"> The title of the dialog </param>
        /// <returns> IGxObject: object that contains the map layer. Must be cast to the correct layer type. </returns>
        public static IGxObject ShowAddDataDialog(List<IGxObjectFilter> filters, string dialogTitle)
        {

            IGxDialog pGxDialog = new GxDialogClass();
            pGxDialog.Title = dialogTitle;
            pGxDialog.AllowMultiSelect = false;

            // Create a filter collection for the dialog.
            IGxObjectFilterCollection pFilterCol = (IGxObjectFilterCollection)pGxDialog;

            foreach (IGxObjectFilter filt in filters)
            {
                pFilterCol.AddFilter(filt, false);
            }

            // Open the dialog
            IEnumGxObject pEnumGx = null;
            if (!pGxDialog.DoModalOpen(0, out pEnumGx))
            {
                return null;
            }

            // Retrieve the layer, via an IGXObject
            // pGxObject it the first and only element of the selection returned by the dialog.
            pEnumGx.Reset();
            IGxObject pGxObject = pEnumGx.Next();

            return pGxObject;
        }


        /// <summary> Shows dialog for saving data.</summary>
        /// <param name="filters"> for example:
        ///       IGxObjectFilter ipFilter1 = new GxFilterFGDBFeatureClassesClass() ;
        ///       List<IGxObjectFilter> gxFilterList = new List<IGxObjectFilter>(new IGxObjectFilter[] { ipFilter1 });</param>
        /// <param name="dialogTitle">The title of the dialog</param>
        /// <returns> the path to the file to save </returns>
        public static string ShowSaveDataDialog(List<IGxObjectFilter> filters, string dialogTitle)
        {

            IGxDialog pGxDialog = new GxDialogClass();
            pGxDialog.Title = dialogTitle;
            pGxDialog.AllowMultiSelect = false;

            // Create a filter collection for the dialog.
            IGxObjectFilterCollection pFilterCol = (IGxObjectFilterCollection)pGxDialog;

            foreach (IGxObjectFilter filt in filters)
            {
                pFilterCol.AddFilter(filt, false);
            }

            // Open the dialog
            if (!pGxDialog.DoModalSave(0))
            {
                return null;
            }
            string path = pGxDialog.FinalLocation.FullName + "\\" + pGxDialog.Name;
            return path;
        }

        #endregion
    }
}
