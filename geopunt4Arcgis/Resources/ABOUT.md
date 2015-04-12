Geopunt voor Arcgis
============

Functies
--------

  * <a href="http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/zoek-een-adres" > Zoek een Adres</a> 
  * <a href="http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/prik-een-adres-op-kaart" > Prik een Adres op kaart</a>
  * <a href="http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/csv-bestanden-geocoderen" > CSV-adresbestanden geocoderen</a>
  * <a href="http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/poi" > Zoek een Plaats - interesse punt</a>
  * <a href="http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/gipod" > GIPOD</a>
  * <a href="http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/hoogteprofiel" > Hoogteprofiel</a>
  * <a href="http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/zoek-een-perceel" > Zoek een perceel</a>
  * <a href="http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/catalogus" > Geopunt catalogus</a>
 
Systeem vereisten
-----------------

- Minimaal: Windows XP, ArcGIS Destkop versie 10.0 sp4 of hoger, .net-framework versie 3.5
- Aanbevolen: Windows7, ArcGIS Destkop versie 10.2 of hoger, .net-framework versie 4.0
- Een verbinding met het internet, restrictieve firewalls kunnen mogelijk de connectie blokkeren.

Doelstelling
-----------

Geopunt4arcgis - 'Geopunt voor ArcGIS' is een add-in voor ESRI ArcGIS desktop, die de webservices van het Vlaamse geoportaal Geopunt ontsluit naar desktop ArcGIS-gebruikers.

Het Vlaamse Geoportaal Geopunt biedt een aantal geografische diensten (web-services) aan die mogen gebruikt worden door derden zoals andere overheden en bedrijven.

De kaartdiensten zijn gebaseerd op de OGC open standaard WMS of WMTS en kunnen gemakkelijk worden toegevoegd aan desktop GIS. GIS-gebruikers kunnen deze diensten ontdekken via het [metadatacenter](https://metadata.geopunt.be). 
De achterliggende zoekservice voor deze diensten is niet direct bruikbaar in QGIS en wordt in deze plugin ingebouwd.

Sommige diensten aangeboden door geopunt zijn niet gebaseerd op een open standaard omdat het gaat om diensten die geen  courant gebruikte open standaard hebben. Deze publieke webdiensten bieden een REST-interface aan, die eenvoudiger in gebruik is voor programmeurs dan OGC-diensten, maar omdat ze niet gestandaardiseerd zijn, kunnen ze niet zomaar binnen getrokken worden in desktop software.

Het gaat onder andere over:

- **Geocoderen**, gebaseerd op de officiële [CRAB](https://www.agiv.be/producten/crab) adressen-databank.
- **Interessante locaties zoeken** (points of interest). Typisch locaties beschikbaar gesteld door Vlaamse instanties.
- **Innames van openbaar domein**, van het Generiek Informatieplatform Openbaar Domein. Het [GIPOD](http://gipod.api.agiv.be/#!index.md) is de officiële databank met manifestaties, wegenwerken en andere obstructies op het openbaar domein.
- **Hoogteprofiel**, een dienst waarmee de hoogte, in digitaal hoogte model Vlaanderen, langsheen een lijn kan worden opgevraagd en gepresenteerd. De brondata is [DHM-Vlaanderen](https://www.agiv.be/producten/digitaal-hoogtemodel-vlaanderen).
- **Percelen zoeken**, op getrapte wijze op de basis van gemeente naar departement, sectie dan naar perceelnummer in KADMAP.
- **Metadata zoekdienst**, dienst om datasets te zoeken via het [metadatacenter](https://metadata.geopunt.be) van Geopunt. Deze bevat ondermeer metadatasets van AGIV, het samenwerkingsverband MercatorNet en DOV. 

Om GIS gebruikers binnen en buiten de Vlaamse Overheid dezelfde functionaliteit ter beschikking te stellen als aangeboden in Geopunt, wenst AGIV deze gebruikers te voorzien van software plug-ins die deze functionaliteit geïntegreerd aanbieden binnen de meest gangbare GIS desktop  omgevingen. 
Op basis van voorafgaand overleg met de GDI-Vlaanderen gemeenschap werd volgende GIS software geselecteerd: Quantum GIS (QGIS) v2.0 Dufour en ESRI ArcMap v10. 

Wat is Geopunt ?
--------------

[Geopunt](http://www.geopunt.be/) is de centrale toegangspoort tot geografische overheidsinformatie, en het uithangbord van het samenwerkingsverband voor geografische informatie in Vlaanderen (GDI-Vlaanderen). Het portaal richt zich met een uitgebreid data-, diensten- en toepassingenaanbod naar een breed en divers publiek. Van burgers op zoek naar een geschikte bouwgrond tot de GIS-coördinator of het studiebureau die een milieu-studie wensen uit te voeren. Het geoportaal maakt laagdrempelig gebruik van geografische informatie door zowel overheidsinstanties, burgers, organisaties als bedrijven mogelijk. Maatschappelijk relevante geografische gegevens en diensten worden op een slimme en gebruiksvriendelijke wijze bijeengebracht. 

Alle componenten (metadata-cataloog, downloadapplicatie, e-commerce-applicatie, data en netwerkdiensten) worden rechtstreeks en geïntegreerd aangeboden. Het geoportaal vormt het Vlaams knooppunt in een Europese geografische data-infrastructuur en voldoet aan de vereisten van de [European INSPIRE richtlijn](http://inspire-geoportal.ec.europa.eu/).

Geopunt is de website van het samenwerkingsverband voor geografische informatie binnen de Vlaamse overheid, GDI-Vlaanderen (GDI = Geografische Data Infrastructuur). In de rol van geografische dienstenintegrator en als uitvoerend orgaan van het samenwerkingsverband GDI-Vlaanderen staat het Agentschap voor Geografische Informatie Vlaanderen (AGIV) in voor de realisatie en het onderhoud van Geopunt. 

Over de auteur
-------------

[Kay Warrie](http://kgis.be)

Ik ben geodata analyst en programmeur, werkzaam als freelance GIS consultant en bij de Studiedienst van stad Antwerpen. 

Professioneel werk ik op desktop GIS, voornamelijk Arcgis en QGIS en op webmapping met ESRI Arcgis-server of opensource webGIS en Maptiling Systemen. Ik beheer ook mee de centrale geodatabases van het stad en INSPIRE-compliant metadata in kader van GDI, Voor de rest doe ik vooral allerlei GIS analyses op data van het Stad. De meeste analyses zijn gerelateerd aan adressering-geocoding, ruimtelijke relaties, nabijheidsanalyses (routing, service area's ed.) voor onder andere MER studies, ruimtelijke ordening of bouwvergunningen.

[Contact mij](mailto:kaywarrie@gmail.com)

[Meer over mij](http://warrieka.github.io/#!aboutMe.md)

#### Online Bronnen:

- *[http://www.geopunt.be](http://www.geopunt.be/voor-experts/geopunt-plugins)* 
- *[https://www.agiv.be/](https://www.agiv.be/)*

