using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geometry;

namespace geoPunt4Arcgis
{
    /// <summary>
    /// Class to handle a boundingbox, that make sure it is within Flanderers and return string string in the wanted format
    /// </summary>
    class boundingBox
    {
        double Xmax;
        double Ymax;
        double Xmin;
        double Ymin;
        ISpatialReference inSRS;

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

        public boundingBox(IEnvelope arcgisBbox)
        {
            //handle SRS
            inSRS = arcgisBbox.SpatialReference;

            //Set maxbounds
            ISpatialReferenceFactory3 SpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            ISpatialReference lam72 = SpatialReferenceFactory.CreateSpatialReference(31370);
            IEnvelope maxBounds = geopuntHelper.makeExtend(17750, 23720, 297240, 245340, lam72); //not outside flanders
            IEnvelope prjBounds = geopuntHelper.Transform(maxBounds as IGeometry, inSRS) as IEnvelope;

            if (arcgisBbox.XMin > prjBounds.XMin) Xmin = arcgisBbox.XMin;
            else Xmin = prjBounds.XMin;
            if (arcgisBbox.YMin > prjBounds.YMin) Ymin = arcgisBbox.YMin;
            else Ymin = prjBounds.YMin;
            if (arcgisBbox.XMax < prjBounds.XMax) Xmax = arcgisBbox.XMax;
            else Xmax = prjBounds.XMax;
            if (arcgisBbox.YMax < prjBounds.YMax) Ymax = arcgisBbox.YMax;
            else Ymax = prjBounds.YMax;
        }


        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}", Xmin, Ymin, Xmax, Ymax);
        }

        public IEnvelope toArcGISEnvelope()
        {
            return geopuntHelper.makeExtend(Xmin, Ymin, Xmax, Ymax, inSRS);
        }
    }
}
