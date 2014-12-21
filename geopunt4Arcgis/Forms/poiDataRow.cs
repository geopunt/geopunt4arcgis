using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geopunt4Arcgis
{
    class poiDataRow
    {
       public int id { get; set; }
       //public string Theme { get; set; }
       //public string Category { get; set; }
       public string Type { get; set; }
       public string Naam { get; set; }
       public string Straat { get; set; }
       public string Huisnummer { get; set; }
       public string Gemeente { get; set; }
       public string Postcode { get; set; } 
    }
}
