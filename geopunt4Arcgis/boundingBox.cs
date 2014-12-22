using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geometry;

namespace geopunt4Arcgis
{

    /// <summary>
    /// Class to handle a boundingbox, that make sure it is within Flanderers and return string string in the wanted format
    /// </summary>
   public class boundingBox
    {
        double Xmax;
        double Ymax;
        double Xmin;
        double Ymin;
        ISpatialReference inSRS;

        /// <summary> constructor: creates a Class to handle a boundingbox, 
        /// that make sure it is within Flanderers and return string string in the wanted format. </summary>
        /// <param name="xmin">lowest x-coordinate in given srs</param>
        /// <param name="ymin">lowest y-coordinate in given srs<</param>
        /// <param name="xmax">highest x-coordinate in given srs<</param>
        /// <param name="ymax">highest x-coordinate in given srs<</param>
        /// <param name="srs">the spatial reference of input and output</param>
        public boundingBox(double xmin, double ymin, double xmax, double ymax, int srs)
        {
            //handle SRS
            ISpatialReferenceFactory3 SpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            inSRS = SpatialReferenceFactory.CreateSpatialReference(srs);

            //Set maxbounds
            ISpatialReference lam72 = SpatialReferenceFactory.CreateSpatialReference(31370);
            IEnvelope maxBounds = geopuntHelper.makeExtend(17750, 23720, 297240, 245340, lam72); //not outside flanders
            IEnvelope prjBounds = geopuntHelper.Transform(maxBounds as IGeometry, inSRS) as IEnvelope;

            if (xmin > prjBounds.XMin) Xmin = xmin;
            else Xmin = prjBounds.XMin;
            if (ymin > prjBounds.YMin) Ymin = ymin;
            else Ymin = prjBounds.YMin;
            if (xmax < prjBounds.XMax) Xmax = xmax;
            else Xmax = prjBounds.XMax;
            if (xmax < prjBounds.YMax) Ymax = ymax;
            else Ymax = prjBounds.YMax;
        }
        /// <summary> returns the bounds of vlaanderen </summary>
        /// <param name="srs">the spatial reference of input and output, default lam72</param>
        public boundingBox(int srs = 31370)
        {
            //handle SRS
            ISpatialReferenceFactory3 SpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            inSRS = SpatialReferenceFactory.CreateSpatialReference(srs);

            //Set maxbounds
            ISpatialReference lam72 = SpatialReferenceFactory.CreateSpatialReference(31370);
            IEnvelope maxBounds = geopuntHelper.makeExtend(17750, 23720, 297240, 245340, lam72); //not outside flanders
            IEnvelope prjBounds = geopuntHelper.Transform(maxBounds as IGeometry, inSRS) as IEnvelope;
            Xmin = prjBounds.XMin;
            Ymin = prjBounds.YMin;
            Xmax = prjBounds.XMax;
            Ymax = prjBounds.YMax;
        }

        /// <summary> Class to handle a boundingbox, that make sure it is within Flanderers 
        /// and return string string in the wanted format from arcgis IEnvelope </summary>
        /// <param name="arcgisBbox">arcgis IEnvelope </param>
        public boundingBox(IEnvelope arcgisBbox)
        {
            //handle SRS
            inSRS = arcgisBbox.SpatialReference;

            //Set maxbounds
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            ISpatialReferenceFactory3 spatialReferenceFactory = obj as ISpatialReferenceFactory3;

            ISpatialReference lam72 = spatialReferenceFactory.CreateSpatialReference(31370);
            IEnvelope maxBounds = geopuntHelper.makeExtend(17750, 23720, 297240, 245340, lam72); //not outside flanders
            if (inSRS.FactoryCode != lam72.FactoryCode)
            {
                maxBounds = geopuntHelper.Transform(maxBounds as IGeometry, inSRS) as IEnvelope;
            }
            if (arcgisBbox.XMin > maxBounds.XMin) Xmin = arcgisBbox.XMin;
            else Xmin = maxBounds.XMin;
            if (arcgisBbox.YMin > maxBounds.YMin) Ymin = arcgisBbox.YMin;
            else Ymin = maxBounds.YMin;
            if (arcgisBbox.XMax < maxBounds.XMax) Xmax = arcgisBbox.XMax;
            else Xmax = maxBounds.XMax;
            if (arcgisBbox.YMax < maxBounds.YMax) Ymax = arcgisBbox.YMax;
            else Ymax = maxBounds.YMax;
        }

        /// <summary> return a strin in the "Xmin,Ymin|Xmax,Ymax" form, with sep=| and xySplit = ","</summary>
        /// <param name="xySplit">separator of x and y pairs </param>
        /// <param name="sep">sepator between xy-pairs </param>
        public string ToBboxString( string xySplit = "|" , string sep="|")
        {
            string toString, formatString;
            formatString = "{0:F4}" + xySplit + "{1:F4}" + sep + "{2:F4}" + xySplit + "{3:F4}";
            toString = string.Format( formatString , Xmin, Ymin, Xmax, Ymax);
            return toString;
        }

        /// <summary> Return bbox as arcgis IEnvelope </summary>
        /// <returns>the bbox as arcgis IEnvelope</returns>
        public IEnvelope toArcGISEnvelope()
        {
            return geopuntHelper.makeExtend(Xmin, Ymin, Xmax, Ymax, inSRS);
        }
    }
}
