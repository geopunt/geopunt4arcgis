namespace geopunt4Arcgis
{
    partial class zoekAdresForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(zoekAdresForm));
            this.zoomBtn = new System.Windows.Forms.Button();
            this.zoekText = new System.Windows.Forms.TextBox();
            this.suggestionList = new System.Windows.Forms.ListBox();
            this.makeMarkerBtn = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.infoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.helpLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.gemeenteBox = new System.Windows.Forms.ComboBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.LARALink = new System.Windows.Forms.LinkLabel();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoomBtn
            // 
            this.zoomBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomBtn.Location = new System.Drawing.Point(304, 218);
            this.zoomBtn.Margin = new System.Windows.Forms.Padding(4);
            this.zoomBtn.Name = "zoomBtn";
            this.zoomBtn.Size = new System.Drawing.Size(113, 28);
            this.zoomBtn.TabIndex = 0;
            this.zoomBtn.Text = "Zoom naar";
            this.zoomBtn.UseVisualStyleBackColor = true;
            this.zoomBtn.Click += new System.EventHandler(this.zoomBtn_Click);
            // 
            // zoekText
            // 
            this.zoekText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zoekText.Location = new System.Drawing.Point(185, 37);
            this.zoekText.Margin = new System.Windows.Forms.Padding(4);
            this.zoekText.Name = "zoekText";
            this.zoekText.Size = new System.Drawing.Size(340, 22);
            this.zoekText.TabIndex = 1;
            this.zoekText.TextChanged += new System.EventHandler(this.zoekText_onZoekTextChange);
            // 
            // suggestionList
            // 
            this.suggestionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.suggestionList.FormattingEnabled = true;
            this.suggestionList.ItemHeight = 16;
            this.suggestionList.Location = new System.Drawing.Point(16, 69);
            this.suggestionList.Margin = new System.Windows.Forms.Padding(4);
            this.suggestionList.Name = "suggestionList";
            this.suggestionList.Size = new System.Drawing.Size(509, 132);
            this.suggestionList.TabIndex = 2;
            this.suggestionList.DoubleClick += new System.EventHandler(this.suggestionList_itemDoubleClicked);
            // 
            // makeMarkerBtn
            // 
            this.makeMarkerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.makeMarkerBtn.Location = new System.Drawing.Point(156, 218);
            this.makeMarkerBtn.Margin = new System.Windows.Forms.Padding(4);
            this.makeMarkerBtn.Name = "makeMarkerBtn";
            this.makeMarkerBtn.Size = new System.Drawing.Size(140, 28);
            this.makeMarkerBtn.TabIndex = 3;
            this.makeMarkerBtn.Text = "Markeer locatie";
            this.makeMarkerBtn.UseVisualStyleBackColor = true;
            this.makeMarkerBtn.Click += new System.EventHandler(this.makeMarkerBtn_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoLabel,
            this.helpLbl});
            this.statusBar.Location = new System.Drawing.Point(0, 275);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(542, 23);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "statusStrip1";
            // 
            // infoLabel
            // 
            this.infoLabel.ActiveLinkColor = System.Drawing.Color.Black;
            this.infoLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.infoLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(486, 18);
            this.infoLabel.Spring = true;
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // helpLbl
            // 
            this.helpLbl.IsLink = true;
            this.helpLbl.Name = "helpLbl";
            this.helpLbl.Size = new System.Drawing.Size(36, 18);
            this.helpLbl.Text = "Help";
            this.helpLbl.Click += new System.EventHandler(this.helpLbl_Click);
            // 
            // gemeenteBox
            // 
            this.gemeenteBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.gemeenteBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gemeenteBox.FormattingEnabled = true;
            this.gemeenteBox.Items.AddRange(new object[] {
            "Aalst",
            "Aalter",
            "Aarschot",
            "Aartselaar",
            "Affligem",
            "Alken",
            "Alveringem",
            "Antwerpen",
            "Anzegem",
            "Ardooie",
            "Arendonk",
            "As",
            "Asse",
            "Assenede",
            "Avelgem",
            "Baarle-Hertog",
            "Balen",
            "Beernem",
            "Beerse",
            "Beersel",
            "Begijnendijk",
            "Bekkevoort",
            "Beringen",
            "Berlaar",
            "Berlare",
            "Bertem",
            "Bever",
            "Beveren",
            "Bierbeek",
            "Bilzen",
            "Blankenberge",
            "Bocholt",
            "Boechout",
            "Bonheiden",
            "Boom",
            "Boortmeerbeek",
            "Borgloon",
            "Bornem",
            "Borsbeek",
            "Boutersem",
            "Brakel",
            "Brasschaat",
            "Brecht",
            "Bredene",
            "Bree",
            "Brugge",
            "Buggenhout",
            "Damme",
            "De Haan",
            "De Panne",
            "De Pinte",
            "Deerlijk",
            "Deinze",
            "Denderleeuw",
            "Dendermonde",
            "Dentergem",
            "Dessel",
            "Destelbergen",
            "Diepenbeek",
            "Diest",
            "Diksmuide",
            "Dilbeek",
            "Dilsen-Stokkem",
            "Drogenbos",
            "Duffel",
            "Edegem",
            "Eeklo",
            "Erpe-Mere",
            "Essen",
            "Evergem",
            "Galmaarden",
            "Gavere",
            "Geel",
            "Geetbets",
            "Genk",
            "Gent",
            "Geraardsbergen",
            "Gingelom",
            "Gistel",
            "Glabbeek",
            "Gooik",
            "Grimbergen",
            "Grobbendonk",
            "Haacht",
            "Haaltert",
            "Halen",
            "Halle",
            "Ham",
            "Hamme",
            "Hamont-Achel",
            "Harelbeke",
            "Hasselt",
            "Hechtel-Eksel",
            "Heers",
            "Heist-op-den-Berg",
            "Hemiksem",
            "Herent",
            "Herentals",
            "Herenthout",
            "Herk-de-Stad",
            "Herne",
            "Herselt",
            "Herstappe",
            "Herzele",
            "Heusden-Zolder",
            "Heuvelland",
            "Hoegaarden",
            "Hoeilaart",
            "Hoeselt",
            "Holsbeek",
            "Hooglede",
            "Hoogstraten",
            "Horebeke",
            "Houthalen-Helchteren",
            "Houthulst",
            "Hove",
            "Huldenberg",
            "Hulshout",
            "Ichtegem",
            "Ieper",
            "Ingelmunster",
            "Izegem",
            "Jabbeke",
            "Kalmthout",
            "Kampenhout",
            "Kapellen",
            "Kapelle-op-den-Bos",
            "Kaprijke",
            "Kasterlee",
            "Keerbergen",
            "Kinrooi",
            "Kluisbergen",
            "Knesselare",
            "Knokke-Heist",
            "Koekelare",
            "Koksijde",
            "Kontich",
            "Kortemark",
            "Kortenaken",
            "Kortenberg",
            "Kortessem",
            "Kortrijk",
            "Kraainem",
            "Kruibeke",
            "Kruishoutem",
            "Kuurne",
            "Laakdal",
            "Laarne",
            "Lanaken",
            "Landen",
            "Langemark-Poelkapelle",
            "Lebbeke",
            "Lede",
            "Ledegem",
            "Lendelede",
            "Lennik",
            "Leopoldsburg",
            "Leuven",
            "Lichtervelde",
            "Liedekerke",
            "Lier",
            "Lierde",
            "Lille",
            "Linkebeek",
            "Lint",
            "Linter",
            "Lochristi",
            "Lokeren",
            "Lommel",
            "Londerzeel",
            "Lo-Reninge",
            "Lovendegem",
            "Lubbeek",
            "Lummen",
            "Maarkedal",
            "Maaseik",
            "Maasmechelen",
            "Machelen",
            "Maldegem",
            "Malle",
            "Mechelen",
            "Meerhout",
            "Meeuwen-Gruitrode",
            "Meise",
            "Melle",
            "Menen",
            "Merchtem",
            "Merelbeke",
            "Merksplas",
            "Mesen",
            "Meulebeke",
            "Middelkerke",
            "Moerbeke",
            "Mol",
            "Moorslede",
            "Mortsel",
            "Nazareth",
            "Neerpelt",
            "Nevele",
            "Niel",
            "Nieuwerkerken",
            "Nieuwpoort",
            "Nijlen",
            "Ninove",
            "Olen",
            "Oostende",
            "Oosterzele",
            "Oostkamp",
            "Oostrozebeke",
            "Opglabbeek",
            "Opwijk",
            "Oudenaarde",
            "Oudenburg",
            "Oud-Heverlee",
            "Oud-Turnhout",
            "Overijse",
            "Overpelt",
            "Peer",
            "Pepingen",
            "Pittem",
            "Poperinge",
            "Putte",
            "Puurs",
            "Ranst",
            "Ravels",
            "Retie",
            "Riemst",
            "Rijkevorsel",
            "Roeselare",
            "Ronse",
            "Roosdaal",
            "Rotselaar",
            "Ruiselede",
            "Rumst",
            "Schelle",
            "Scherpenheuvel-Zichem",
            "Schilde",
            "Schoten",
            "Sint-Amands",
            "Sint-Genesius-Rode",
            "Sint-Gillis-Waas",
            "Sint-Katelijne-Waver",
            "Sint-Laureins",
            "Sint-Lievens-Houtem",
            "Sint-Martens-Latem",
            "Sint-Niklaas",
            "Sint-Pieters-Leeuw",
            "Sint-Truiden",
            "Spiere-Helkijn",
            "Stabroek",
            "Staden",
            "Steenokkerzeel",
            "Stekene",
            "Temse",
            "Ternat",
            "Tervuren",
            "Tessenderlo",
            "Tielt",
            "Tielt-Winge",
            "Tienen",
            "Tongeren",
            "Torhout",
            "Tremelo",
            "Turnhout",
            "Veurne",
            "Vilvoorde",
            "Vleteren",
            "Voeren",
            "Vorselaar",
            "Vosselaar",
            "Waarschoot",
            "Waasmunster",
            "Wachtebeke",
            "Waregem",
            "Wellen",
            "Wemmel",
            "Wervik",
            "Westerlo",
            "Wetteren",
            "Wevelgem",
            "Wezembeek-Oppem",
            "Wichelen",
            "Wielsbeke",
            "Wijnegem",
            "Willebroek",
            "Wingene",
            "Wommelgem",
            "Wortegem-Petegem",
            "Wuustwezel",
            "Zandhoven",
            "Zaventem",
            "Zedelgem",
            "Zele",
            "Zelzate",
            "Zemst",
            "Zingem",
            "Zoersel",
            "Zomergem",
            "Zonhoven",
            "Zonnebeke",
            "Zottegem",
            "Zoutleeuw",
            "Zuienkerke",
            "Zulte",
            "Zutendaal",
            "Zwalm",
            "Zwevegem",
            "Zwijndrecht",
            "Anderlecht",
            "Brussel",
            "Elsene",
            "Etterbeek",
            "Evere",
            "Ganshoren",
            "Jette",
            "Koekelberg",
            "Oudergem",
            "Schaarbeek",
            "Sint-Agatha-Berchem",
            "Sint-Gillis",
            "Sint-Jans-Molenbeek",
            "Sint-Joost-ten-Node",
            "Sint-Lambrechts-Woluwe",
            "Sint-Pieters-Woluwe",
            "Ukkel",
            "Vorst",
            "Watermaal-Bosvoorde\'",
            ">>> \'",
            "\'.join(nn)",
            "u\'",
            "Aalst",
            "Aalter",
            "Aarschot",
            "Aartselaar",
            "Affligem",
            "Alken",
            "Alveringem",
            "Antwerpen",
            "Anzegem",
            "Ardooie",
            "Arendonk",
            "As",
            "Asse",
            "Assenede",
            "Avelgem",
            "Baarle-Hertog",
            "Balen",
            "Beernem",
            "Beerse",
            "Beersel",
            "Begijnendijk",
            "Bekkevoort",
            "Beringen",
            "Berlaar",
            "Berlare",
            "Bertem",
            "Bever",
            "Beveren",
            "Bierbeek",
            "Bilzen",
            "Blankenberge",
            "Bocholt",
            "Boechout",
            "Bonheiden",
            "Boom",
            "Boortmeerbeek",
            "Borgloon",
            "Bornem",
            "Borsbeek",
            "Boutersem",
            "Brakel",
            "Brasschaat",
            "Brecht",
            "Bredene",
            "Bree",
            "Brugge",
            "Buggenhout",
            "Damme",
            "De Haan",
            "De Panne",
            "De Pinte",
            "Deerlijk",
            "Deinze",
            "Denderleeuw",
            "Dendermonde",
            "Dentergem",
            "Dessel",
            "Destelbergen",
            "Diepenbeek",
            "Diest",
            "Diksmuide",
            "Dilbeek",
            "Dilsen-Stokkem",
            "Drogenbos",
            "Duffel",
            "Edegem",
            "Eeklo",
            "Erpe-Mere",
            "Essen",
            "Evergem",
            "Galmaarden",
            "Gavere",
            "Geel",
            "Geetbets",
            "Genk",
            "Gent",
            "Geraardsbergen",
            "Gingelom",
            "Gistel",
            "Glabbeek",
            "Gooik",
            "Grimbergen",
            "Grobbendonk",
            "Haacht",
            "Haaltert",
            "Halen",
            "Halle",
            "Ham",
            "Hamme",
            "Hamont-Achel",
            "Harelbeke",
            "Hasselt",
            "Hechtel-Eksel",
            "Heers",
            "Heist-op-den-Berg",
            "Hemiksem",
            "Herent",
            "Herentals",
            "Herenthout",
            "Herk-de-Stad",
            "Herne",
            "Herselt",
            "Herstappe",
            "Herzele",
            "Heusden-Zolder",
            "Heuvelland",
            "Hoegaarden",
            "Hoeilaart",
            "Hoeselt",
            "Holsbeek",
            "Hooglede",
            "Hoogstraten",
            "Horebeke",
            "Houthalen-Helchteren",
            "Houthulst",
            "Hove",
            "Huldenberg",
            "Hulshout",
            "Ichtegem",
            "Ieper",
            "Ingelmunster",
            "Izegem",
            "Jabbeke",
            "Kalmthout",
            "Kampenhout",
            "Kapellen",
            "Kapelle-op-den-Bos",
            "Kaprijke",
            "Kasterlee",
            "Keerbergen",
            "Kinrooi",
            "Kluisbergen",
            "Knesselare",
            "Knokke-Heist",
            "Koekelare",
            "Koksijde",
            "Kontich",
            "Kortemark",
            "Kortenaken",
            "Kortenberg",
            "Kortessem",
            "Kortrijk",
            "Kraainem",
            "Kruibeke",
            "Kruishoutem",
            "Kuurne",
            "Laakdal",
            "Laarne",
            "Lanaken",
            "Landen",
            "Langemark-Poelkapelle",
            "Lebbeke",
            "Lede",
            "Ledegem",
            "Lendelede",
            "Lennik",
            "Leopoldsburg",
            "Leuven",
            "Lichtervelde",
            "Liedekerke",
            "Lier",
            "Lierde",
            "Lille",
            "Linkebeek",
            "Lint",
            "Linter",
            "Lochristi",
            "Lokeren",
            "Lommel",
            "Londerzeel",
            "Lo-Reninge",
            "Lovendegem",
            "Lubbeek",
            "Lummen",
            "Maarkedal",
            "Maaseik",
            "Maasmechelen",
            "Machelen",
            "Maldegem",
            "Malle",
            "Mechelen",
            "Meerhout",
            "Meeuwen-Gruitrode",
            "Meise",
            "Melle",
            "Menen",
            "Merchtem",
            "Merelbeke",
            "Merksplas",
            "Mesen",
            "Meulebeke",
            "Middelkerke",
            "Moerbeke",
            "Mol",
            "Moorslede",
            "Mortsel",
            "Nazareth",
            "Neerpelt",
            "Nevele",
            "Niel",
            "Nieuwerkerken",
            "Nieuwpoort",
            "Nijlen",
            "Ninove",
            "Olen",
            "Oostende",
            "Oosterzele",
            "Oostkamp",
            "Oostrozebeke",
            "Opglabbeek",
            "Opwijk",
            "Oudenaarde",
            "Oudenburg",
            "Oud-Heverlee",
            "Oud-Turnhout",
            "Overijse",
            "Overpelt",
            "Peer",
            "Pepingen",
            "Pittem",
            "Poperinge",
            "Putte",
            "Puurs",
            "Ranst",
            "Ravels",
            "Retie",
            "Riemst",
            "Rijkevorsel",
            "Roeselare",
            "Ronse",
            "Roosdaal",
            "Rotselaar",
            "Ruiselede",
            "Rumst",
            "Schelle",
            "Scherpenheuvel-Zichem",
            "Schilde",
            "Schoten",
            "Sint-Amands",
            "Sint-Genesius-Rode",
            "Sint-Gillis-Waas",
            "Sint-Katelijne-Waver",
            "Sint-Laureins",
            "Sint-Lievens-Houtem",
            "Sint-Martens-Latem",
            "Sint-Niklaas",
            "Sint-Pieters-Leeuw",
            "Sint-Truiden",
            "Spiere-Helkijn",
            "Stabroek",
            "Staden",
            "Steenokkerzeel",
            "Stekene",
            "Temse",
            "Ternat",
            "Tervuren",
            "Tessenderlo",
            "Tielt",
            "Tielt-Winge",
            "Tienen",
            "Tongeren",
            "Torhout",
            "Tremelo",
            "Turnhout",
            "Veurne",
            "Vilvoorde",
            "Vleteren",
            "Voeren",
            "Vorselaar",
            "Vosselaar",
            "Waarschoot",
            "Waasmunster",
            "Wachtebeke",
            "Waregem",
            "Wellen",
            "Wemmel",
            "Wervik",
            "Westerlo",
            "Wetteren",
            "Wevelgem",
            "Wezembeek-Oppem",
            "Wichelen",
            "Wielsbeke",
            "Wijnegem",
            "Willebroek",
            "Wingene",
            "Wommelgem",
            "Wortegem-Petegem",
            "Wuustwezel",
            "Zandhoven",
            "Zaventem",
            "Zedelgem",
            "Zele",
            "Zelzate",
            "Zemst",
            "Zingem",
            "Zoersel",
            "Zomergem",
            "Zonhoven",
            "Zonnebeke",
            "Zottegem",
            "Zoutleeuw",
            "Zuienkerke",
            "Zulte",
            "Zutendaal",
            "Zwalm",
            "Zwevegem",
            "Zwijndrecht",
            "Anderlecht",
            "Brussel",
            "Elsene",
            "Etterbeek",
            "Evere",
            "Ganshoren",
            "Jette",
            "Koekelberg",
            "Oudergem",
            "Schaarbeek",
            "Sint-Agatha-Berchem",
            "Sint-Gillis",
            "Sint-Jans-Molenbeek",
            "Sint-Joost-ten-Node",
            "Sint-Lambrechts-Woluwe",
            "Sint-Pieters-Woluwe",
            "Ukkel",
            "Vorst",
            "Watermaal-Bosvoorde"});
            this.gemeenteBox.Location = new System.Drawing.Point(16, 36);
            this.gemeenteBox.Margin = new System.Windows.Forms.Padding(4);
            this.gemeenteBox.Name = "gemeenteBox";
            this.gemeenteBox.Size = new System.Drawing.Size(160, 24);
            this.gemeenteBox.TabIndex = 5;
            this.gemeenteBox.SelectedIndexChanged += new System.EventHandler(this.gemeenteBox_SelectedIndexChanged);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(425, 218);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(100, 28);
            this.closeBtn.TabIndex = 6;
            this.closeBtn.Text = "Sluiten";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selecteer een gemeente. Geef een straat (+nr) op, dan selecteer een suggestie.";
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(48, 218);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 28);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Opslaan";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // LARALink
            // 
            this.LARALink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LARALink.AutoSize = true;
            this.LARALink.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LARALink.Location = new System.Drawing.Point(301, 250);
            this.LARALink.Name = "LARALink";
            this.LARALink.Size = new System.Drawing.Size(224, 15);
            this.LARALink.TabIndex = 9;
            this.LARALink.TabStop = true;
            this.LARALink.Text = "Foute adressen kunt u melden via LARA";
            this.LARALink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LARALink_LinkClicked);
            // 
            // zoekAdresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(542, 298);
            this.Controls.Add(this.LARALink);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.gemeenteBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.makeMarkerBtn);
            this.Controls.Add(this.suggestionList);
            this.Controls.Add(this.zoekText);
            this.Controls.Add(this.zoomBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(550, 300);
            this.Name = "zoekAdresForm";
            this.Text = "Zoek een adres";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zoomBtn;
        private System.Windows.Forms.TextBox zoekText;
        private System.Windows.Forms.ListBox suggestionList;
        private System.Windows.Forms.Button makeMarkerBtn;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel infoLabel;
        private System.Windows.Forms.ComboBox gemeenteBox;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ToolStripStatusLabel helpLbl;
        private System.Windows.Forms.LinkLabel LARALink;
    }
}