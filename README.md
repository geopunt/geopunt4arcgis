Geopunt4Arcgis
==============

####English:
Geopunt4Arcgis is an extension for arcgis, aimed at local goverments in Flanders.
It essentialy a port of geopunt4Qgis, to C-charp and Arcgis.
Right now only geocoding and reverse geocoding are implemented.

See also:
https://github.com/warrieka/geopunt4Qgis 


####Nederlands:
Het Vlaamse Geoportaal Geopunt bied een aantal geografische diensten (web-services) aan die mogen gebruikt worden door derden zoals andere overheden en bedrijven. Deze tool implementeert de geolocatie publieke dienst als een arcgis deskop addin. Het is een port van mijn QGIS-plugin [geopunt4qgis](https://github.com/warrieka/geopunt4Qgis) naar Arcgis en C#.

Er zijn op dit moment 3 functies:

**Zoeken op  adres:** 
Op basis van een input string wordt gezocht naar een adres in CRAB. Je kiest de gemeente uit een selectielijst en geeft een adres op als input tekst. De input tekst bevat verplicht een straatnaam en optioneel een huisnummer. Als output krijg je een lijst van strings in de vorm (straatnaam huisnummer, gemeente) die voldoen aan de selectie criteria. Het maximaal aantal elementen in de lijst is 12. Het maximaal aantal elementen in de lijst is 25. Je kan het gewenste adres selecteren door erop te klikken, de locatie van het adres licht dan even op. Je kan een geselecteerd adres ook  toevoegen  als graphic of zoomen naar het adres. 

**Een adres Identificeren:** 
Met deze tool kan je op een locatie in Vlaanderen op de kaart klikken om het correcte adres in CRAB te weten te komen. Het gevonden adres verschijnt in een popup. Je kan de locatie van dit adres toevoegen als graphic.

**Zoeken naar interessepunten **
Met deze tool kan je de POI-service doorzoeken en de resultaten opslaan als een shapefile of graphic.