using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;


namespace geoPunt4Arcgis
{
    static class geopuntHelper
    {
        #region "geometry operations"
        ///<summary>Reproject geometry to wanted crs, optimized for Lam72</summary>
        public static IGeometry Transform(IGeometry geom, ISpatialReference toSrs)
        {
            if (toSrs == null || geom.SpatialReference == null || toSrs.FactoryCode == geom.SpatialReference.FactoryCode)
            {
                return geom;
            }

            if (toSrs.FactoryCode == 31370)
            {
                Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
                System.Object obj = Activator.CreateInstance(factoryType);
                ISpatialReferenceFactory2 spatialReferenceFactory2 = obj as ISpatialReferenceFactory2;

                IGeoTransformation geoTransformation = spatialReferenceFactory2.CreateGeoTransformation((int)
                    esriSRGeoTransformation3Type.esriSRGeoTransformation_Belge_1972_To_WGS_1984_2) as IGeoTransformation;

                IGeometry2 geometry = geom as IGeometry2; //clone geom as IGeometry2
                geometry.ProjectEx(toSrs, esriTransformDirection.esriTransformReverse, geoTransformation, false, 0, 0);

                return geometry as IGeometry;
            }
            else
            {
                IGeometry geometry = geom; //clone geom
                geometry.Project(toSrs);
                return geometry;
            }
        }

        ///<summary>Reproject geometry to wanted WGS84, optimized for Lam72</summary>
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

        #region "Create FeatureClass"

        ///<summary>Simple helper to create a featureclass in a geodatabase.</summary>
        /// 
        ///<param name="workspace">An IWorkspace2 interface</param>
        ///<param name="featureDataset">An IFeatureDataset interface or Nothing</param>
        ///<param name="featureClassName">A System.String that contains the name of the feature class to open or create. Example: "states"</param>
        ///<param name="fields">An IFields interface</param>
        ///<param name="CLSID">A UID value or Nothing. Example "esriGeoDatabase.Feature" or Nothing</param>
        ///<param name="CLSEXT">A UID value or Nothing (this is the class extension if you want to reference a class extension when creating the feature class).</param>
        ///<param name="strConfigKeyword">An empty System.String or RDBMS table string for ArcSDE. Example: "myTable" or ""</param>
        ///  
        ///<returns>An IFeatureClass interface or a Nothing</returns>
        ///  
        ///<remarks>
        ///  (1) If a 'featureClassName' already exists in the workspace a reference to that feature class 
        ///      object will be returned.
        ///  (2) If an IFeatureDataset is passed in for the 'featureDataset' argument the feature class
        ///      will be created in the dataset. If a Nothing is passed in for the 'featureDataset'
        ///      argument the feature class will be created in the workspace.
        ///  (3) When creating a feature class in a dataset the spatial reference is inherited 
        ///      from the dataset object.
        ///  (4) If an IFields interface is supplied for the 'fields' collection it will be used to create the
        ///      table. If a Nothing value is supplied for the 'fields' collection, a table will be created using 
        ///      default values in the method.
        ///  (5) The 'strConfigurationKeyword' parameter allows the application to control the physical layout 
        ///      for this table in the underlying RDBMS—for example, in the case of an Oracle database, the 
        ///      configuration keyword controls the tablespace in which the table is created, the initial and 
        ///     next extents, and other properties. The 'strConfigurationKeywords' for an ArcSDE instance are 
        ///      set up by the ArcSDE data administrator, the list of available keywords supported by a workspace 
        ///      may be obtained using the IWorkspaceConfiguration interface. For more information on configuration 
        ///      keywords, refer to the ArcSDE documentation. When not using an ArcSDE table use an empty 
        ///      string (ex: "").
        ///</remarks>
        public static IFeatureClass CreateFeatureClass(IWorkspace2 workspace, //IFeatureDataset featureDataset, 
                                String featureClassName, IFields fields, UID CLSID, UID CLSEXT, String strConfigKeyword)
        {
    
          if (featureClassName == "") return null; // name was not passed in 

          IFeatureClass featureClass;
          IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace; // Explicit Cast

          if (workspace.get_NameExists(esriDatasetType.esriDTFeatureClass, featureClassName)) //feature class with that name already exists 
          {
                featureClass = featureWorkspace.OpenFeatureClass(featureClassName);
                return featureClass;
          }

          // assign the class id value if not assigned
          if (CLSID == null)
          {
                CLSID = new UIDClass();
                CLSID.Value = "esriGeoDatabase.Feature";
          }

          IObjectClassDescription objectClassDescription = new FeatureClassDescriptionClass();

          // if a fields collection is not passed in then supply our own
          if (fields == null)
          {
                // create the fields using the required fields method
                fields = objectClassDescription.RequiredFields;
                IFieldsEdit fieldsEdit = (IFieldsEdit)fields; // Explicit Cast
                IField field = new FieldClass();

                // create a user defined text field
                IFieldEdit fieldEdit = (IFieldEdit)field; // Explicit Cast
              
                // setup field properties
                fieldEdit.Name_2 = "SampleField";
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                fieldEdit.IsNullable_2 = true;
                fieldEdit.AliasName_2 = "Sample Field Column";
                fieldEdit.DefaultValue_2 = "test";
                fieldEdit.Editable_2 = true;
                fieldEdit.Length_2 = 100;

                // add field to field collection
                fieldsEdit.AddField(field);
                fields = (IFields)fieldsEdit; // Explicit Cast
          }

          String strShapeField = "";

          // locate the shape field
          for (int j = 0; j < fields.FieldCount; j++)
          {
            if (fields.get_Field(j).Type == esriFieldType.esriFieldTypeGeometry)
            {
                strShapeField = fields.get_Field(j).Name;
            }
          }

          // Use IFieldChecker to create a validated fields collection.
          IFieldChecker fieldChecker = new FieldCheckerClass();
          IEnumFieldError enumFieldError = null;
          IFields validatedFields = null;
          fieldChecker.ValidateWorkspace = (IWorkspace)workspace;
          fieldChecker.Validate(fields, out enumFieldError, out validatedFields);

          // The enumFieldError enumerator can be inspected at this point to determine 
          // which fields were modified during validation.


          // finally create and return the feature class
          featureClass = featureWorkspace.CreateFeatureClass(featureClassName, validatedFields, CLSID, CLSEXT, esriFeatureType.esriFTSimple, strShapeField, strConfigKeyword);
          return featureClass;
        }
        #endregion

        #region "create a field"
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

        #region "create ShapeFile"
        public static IFeatureClass createShapeFile(string shapeFilePath, List<IField> field2add , ISpatialReference srs, esriGeometryType geomType )
        {

            System.IO.FileInfo shapeInfo = new System.IO.FileInfo(shapeFilePath);

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
            IFeatureWorkspace featureWorkspace = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspace;     // Explict Cast
            IFeatureClass featureClass = featureWorkspace.CreateFeatureClass(shapeInfo.Name, fields, ocDescription.InstanceCLSID, 
                            ocDescription.ClassExtensionCLSID, esriFeatureType.esriFTSimple, fcDescription.ShapeFieldName, "");

            return featureClass;
        }
        #endregion

        #region "add featureclass to map"
        /// <summary>
        /// Add feature class to active View and then zoom to its extend
        /// </summary>
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

    }
}
