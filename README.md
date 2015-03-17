Geopunt4Arcgis
==============

####English:
Geopunt4Arcgis is an extension for arcgis, aimed at local goverments in Flanders.
It essentialy a port of geopunt4Qgis, to C-charp and Arcgis.

See also:
https://github.com/warrieka/geopunt4Qgis 


####Nederlands:

##Doelstelling:

Geopunt4arcgis - 'Geopunt voor ArcGIS' is een add-in voor ESRI ArcGIS desktop, die de webservices van het Vlaamse geoportaal Geopunt ontsluit naar desktop ArcGIS-gebruikers.

Het Vlaamse Geoportaal Geopunt bied een aantal geografische diensten (web-services) aan die mogen gebruikt worden door derden zoals andere overheden en bedrijven. Deze tool implementeert de achterliggende diensten in een arcgis deskop addin. Het is een port van de QGIS-plugin [geopunt4qgis](https://github.com/warrieka/geopunt4Qgis) naar Arcgis.

De webservices, die zijn gebaseerd op de OGC standaard WMS en kunnen gemakkelijk worden toegevoegd aan ArcGIS desktop. GIS-gebruikers kunnen deze diensten ontdekken via het metadatacenter. De achterliggende zoekservice voor deze diensten is niet direct bruikbaar in ArcGIS en wordt in deze plug-in ingebouwd.
Sommige diensten aangeboden door Geopunt zijn niet gebaseerd op een open standaard omdat het gaat om diensten die geen open standaard hebben. Deze publieke webservices zijn opgesteld volgens een REST-volle API, die eenvoudiger in gebruik is voor programmeurs dan OGC-diensten, maar omdat ze niet gestandaardiseerd zijn kunnen ze niet zomaar binnen getrokken worden in desktop software.

Het gaat onder andere over:

- Geocoderen, gebaseerd op de officiële CRAB adressen-databank.
- Locaties zoeken, door koppeling van adressen aan de CRAB-databank, bijvoorbeeld de scholendatabank van de Vlaamse overheid. (documentatie nog niet beschikbaar).
- Innames van openbaar domein, van het Generiek Informatieplatform Openbaar Domein (GIPOD) GIPOD, de officiële databank met manifestaties, wegenwerken en andere obstructies op het openbaar domein.
- Hoogteprofiel, een dienst waarmee de hoogte, in digitaal hoogtemodel Vlaanderen, langsheen een lijn kan worden opgevraagd.
- Metadata zoekdienst, deze diensten worden gebruik in het metadatacenter van Geopunt en bevat ondermeer metadatafiches van AGIV, het samenwerkingsverband MercatorNet en DOV.

Om GIS-gebruikers binnen en buiten de Vlaamse Overheid dezelfde functionaliteit ter beschikking te stellen als aangeboden in Geopunt, wenst AGIV deze gebruikers te voorzien van software plug-ins die deze functionaliteit geïntegreerd aanbieden binnen de meest gangbare GIS-desktop omgevingen. 

##Systeemvereisten
- Minimaal: Windows XP, ArcGIS Destkop versie 10.0 sp4 of hoger, .net-framework versie 3.5
- Aanbevolen: Windows7, ArcGIS Destkop versie 10.2 of hoger, .net-framework versie 4.0
- Een verbinding met het Internet.

##Functionaliteit

**Zoeken op  adres (Geocoding)** 
Op basis van een input string wordt gezocht naar een adres in CRAB. Je kiest de gemeente uit een selectielijst en geeft een adres op als input tekst. De input tekst bevat verplicht een straatnaam en optioneel een huisnummer. 
Als output krijg je een lijst van strings in de vorm (straatnaam huisnummer, gemeente) die voldoen aan de selectie criteria. Het maximaal aantal elementen in de lijst is 12. Het maximaal aantal elementen in de lijst is 25. Je kan het gewenste adres selecteren door erop te klikken, de locatie van het adres licht dan even op. Je kan een geselecteerd adres ook  toevoegen  als graphic of Feature Class of zoomen naar het adres. 

**Een adres Identificeren op een lokatie op de kaart (Reverse geocoding)** 
Met deze tool kan je op een locatie in Vlaanderen op de kaart klikken om het correcte adres in CRAB te weten te komen. Het gevonden adres verschijnt in een popup. Je kan de locatie van dit adres toevoegen als graphic of Feature Class.

**Zoeken naar interessepunten**
Met deze tool kan je de Geopunt POI-service doorzoeken en de resultaten opslaan als een Feature Class of graphic.

**CSV-bestanden geocoderen**
Met deze tool kan je een CSV-bestand geocoderen, omzetten naar een kaartlaag. Een CSV-bestand (Comma Seperated Values) is een tekstbestand waarin de waarden door een teken (de separator) meestal een komma of puntkomma gescheiden zijn. Als je CSV-bestand adresgegevens bevat, kan je die met deze tool op de kaart weergeven en opslaan als Feature CLass met hun correct CRAB-adres.

**GIPOD**
Met deze kan zoeken op innames van openbaar domein, van het Generiek Informatieplatform Openbaar Domein (GIPOD) GIPOD, de officiële databank met manifestaties, wegenwerken en andere obstructies op het openbaar domein.
Je kunt deze gegevens opslaan als Feature Class.

**Hoogte profiel**
De hoogteprofielservice van Geopunt laat toe om hoogte-informatie van het digitaal hoogtemodel Vlaanderen op te halen langs een lijn. De brondata is [DHM-Vlaanderen](https://www.agiv.be/producten/digitaal-hoogtemodel-vlaanderen).

**Zoeken naar percelen**
Zoek een kadastraal perceel op via gemeente, departement, sectie en perceelnummer.

**Metadata Catalogus**
Zoek in de Geopunt-catalogus naar datasets en voeg ze toe aan je project. Het is gebaseerd op de webdiensten van het [metadatacenter](https://metadata.geopunt.be) van geopunt en bevat ondermeer metadatafiches van AGIV, het samenwerkingsverband MercatorNet en DOV. 

##Gerelateerde links

- [Add-ins voor Arcgis installeren](http://resources.arcgis.com/en/help/main/10.1/index.html#//014p0000001m000000)
- [Over Geopunt](http://www.geopunt.be/over-geopunt/)
- [Over de auteur](http://kgis.be/pages/over-mij.html)
- [Broncode](https://github.com/warrieka/geopunt4arcgis/)