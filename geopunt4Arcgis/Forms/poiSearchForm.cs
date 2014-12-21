using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace geopunt4Arcgis 
{
    public partial class poiSearchForm : Form
    {
        BindingList<poiDataRow> rows;
        dataHandler.poi poiDH;

        public poiSearchForm()
        {
            InitializeComponent();

            rows = new BindingList<poiDataRow>();
            resultGrid.DataSource = rows;

            poiDH = new dataHandler.poi();
        }

        private void zoekBtn_Click(object sender, EventArgs e)
        {
            datacontract.poiMaxResponse poiData = poiDH.getMaxmodel("school");
            List<datacontract.poiMaxModel> pois = poiData.pois;

            MessageBox.Show( Newtonsoft.Json.JsonConvert.SerializeObject(pois[0].categories));

            foreach ( datacontract.poiMaxModel poi in pois)
            {
                poiDataRow row = new poiDataRow();
                List<string> qry;
                datacontract.poiAddress adres;

                row.id = poi.id;

                qry = (
                    from datacontract.poiValueGroup n in poi.categories 
                    where n.type == "Type" select n.value ).ToList();
                if (qry.Count > 0) row.Type = qry[0];
                qry = (
                 from datacontract.poiValueGroup n in poi.labels select n.value).ToList();
                if (qry.Count > 0) row.Naam = qry[0];

                adres = poi.location.address;
                if (adres != null)
                {
                    row.Straat = adres.street;
                    row.Huisnummer = adres.streetnumber;
                    row.Postcode = adres.postalcode;
                    row.Gemeente = adres.municipality;
                }
                rows.Add(row);
            }
            resultGrid.Refresh();
        }

    }
}
