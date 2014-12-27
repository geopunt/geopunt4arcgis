using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geopunt4Arcgis.datacontract
{
    public class municipalityList
    {
        public List<municipality> municipalities { get; set; }
    }
    public class municipality
    {
       public string municipalityCode { get; set; }
       public string municipalityName { get; set; }
       public capakeyGeometry geometry { get; set; }
    }

    public class departmentList {
        public List<department> departments { get; set; }
    }
    public class department 
    {
        public string departmentCode { get; set; }
        public string departmentName { get; set; }
        public capakeyGeometry geometry { get; set; }
    }

    public class capakeyGeometry
    {
        public string boundingBox { get; set; }
        public string center { get; set; }
        public string shape { get; set; }
    }

    public class sectionList
    {
        public List<section> sections { get; set; }
    }
    public class section
    {
        public string sectionCode { get; set; }
        public capakeyGeometry geometry { get; set; }
    }

    public class parcelList
    {
        public List<parcel> parcels { get; set; }
    }
    public class parcel 
    {
        public string perceelnummer { get; set; }
        public string capakey { get; set; }
        public string grondnummer { get; set; }
        public string exponent { get; set; }
        public int macht { get; set; }
        public int bisnummer { get; set; }
        public string type { get; set; }
        public List<string> adres { get; set; }
        public capakeyGeometry geometry { get; set; }
    }

}
