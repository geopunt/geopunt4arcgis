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
    public partial class layerSelectionForm : Form
    {
        public string selectedLayerName = null;
        private BindingList<string> layerList;
        private List<ESRI.ArcGIS.GISClient.IWMSLayerDescription> layerDescripts;

        private string intlr ;

        public layerSelectionForm(List<ESRI.ArcGIS.GISClient.IWMSLayerDescription> layers, string initialLayer = null)
        {
            intlr = initialLayer;

            InitializeComponent();
            layerDescripts = layers;
            layerList = new BindingList<string>( layers.Select( c => c.Title ).ToList() );
            layersListCbx.DataSource = layerList;

            if (initialLayer != null && layerDescripts.Count > 0) 
            {
                List<string> lyrTitles = (from g in layerDescripts
                                 where g.Title == initialLayer || g.Name == initialLayer 
                                 select g.Title).ToList();

                if (lyrTitles.Count > 0) layersListCbx.Text = lyrTitles[0];
            }
        }

        private void addToMapBtn_Click(object sender, EventArgs e)
        {
            string lyr = layersListCbx.Text;
            string lyrKey = (from g in layerDescripts
                             where g.Title == lyr
                             select g.Name    ).First();

            selectedLayerName = lyrKey;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            selectedLayerName = null;
            this.Close();
        }
    }
}
