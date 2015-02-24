REM deps: http://www.imagemagick.org and https://inkscape.org

REM add to path
set PATH=%PATH%;C:\Program Files\Inkscape\;C:\Program Files\ImageMagick-6.9.0-Q16

REM EMF uncomment if you want this
REM inkscape -z -f geopuntAddress.svg -M  geopuntAddress.emf
REM inkscape -z -f geopuntCatalog.svg -M  geopuntCatalog.emf
REM inkscape -z -f geopuntPerceel.svg -M  geopuntPerceel.emf
REM inkscape -z -f geopuntBatch.svg -M    geopuntBatch.emf
REM inkscape -z -f geopuntElevation.svg -M geopuntElevation.emf
REM inkscape -z -f geopuntGipod.svg -M    geopuntGipod.emf
REM inkscape -z -f geopuntPoi.svg -M      geopuntPoi.emf
REM inkscape -z -f geopuntReverse.svg -M  geopuntReverse.emf
REM inkscape -z -f geopuntSetting.svg -M  geopuntSetting.emf

REM png's
inkscape -z -f geopuntAddress.svg -w 16 -h 16 -e geopuntAddress16x16.png
inkscape -z -f geopuntCatalog.svg -w 16 -h 16 -e geopuntCatalog16x16.png
inkscape -z -f geopuntPerceel.svg -w 16 -h 16 -e geopuntPerceel16x16.png
inkscape -z -f geopuntBatch.svg -w 16 -h 16 -e geopuntBatch16x16.png
inkscape -z -f geopuntElevation.svg -w 16 -h 16 -e geopuntElevation16x16.png
inkscape -z -f geopuntGipod.svg -w 16 -h 16 -e geopuntGipod16x16.png
inkscape -z -f geopuntPoi.svg -w 16 -h 16 -e geopuntPoi16x16.png
inkscape -z -f geopuntReverse.svg -w 16 -h 16 -e geopuntReverse16x16.png
inkscape -z -f geopuntSetting.svg -w 16 -h 16 -e geopuntSetting16x16.png

inkscape -z -f geopuntAddress.svg -w 24 -h 24 -e geopuntAddress24x24.png
inkscape -z -f geopuntCatalog.svg -w 24 -h 24 -e geopuntCatalog24x24.png
inkscape -z -f geopuntPerceel.svg -w 24 -h 24 -e geopuntPerceel24x24.png
inkscape -z -f geopuntBatch.svg -w 24 -h 24 -e geopuntBatch24x24.png
inkscape -z -f geopuntElevation.svg -w 24 -h 24 -e geopuntElevation24x24.png
inkscape -z -f geopuntGipod.svg -w 24 -h 24 -e geopuntGipod24x24.png
inkscape -z -f geopuntPoi.svg -w 24 -h 24 -e geopuntPoi24x24.png
inkscape -z -f geopuntReverse.svg -w 24 -h 24 -e geopuntReverse24x24.png
inkscape -z -f geopuntSetting.svg -w 24 -h 24 -e geopuntSetting24x24.png

inkscape -z -f geopuntAddress.svg -w 32 -h 32 -e geopuntAddress32x32.png
inkscape -z -f geopuntCatalog.svg -w 32 -h 32 -e geopuntCatalog32x32.png
inkscape -z -f geopuntPerceel.svg -w 32 -h 32 -e geopuntPerceel32x32.png
inkscape -z -f geopuntBatch.svg -w 32 -h 32 -e geopuntBatch32x32.png
inkscape -z -f geopuntElevation.svg -w 32 -h 32 -e geopuntElevation32x32.png
inkscape -z -f geopuntGipod.svg -w 32 -h 32 -e geopuntGipod32x32.png
inkscape -z -f geopuntPoi.svg -w 32 -h 32 -e geopuntPoi32x32.png
inkscape -z -f geopuntReverse.svg -w 32 -h 32 -e geopuntReverse32x32.png
inkscape -z -f geopuntSetting.svg -w 32 -h 32 -e geopuntSetting32x32.png

inkscape -z -f geopuntAddress.svg -w 48 -h 48 -e geopuntAddress48x48.png
inkscape -z -f geopuntCatalog.svg -w 48 -h 48 -e geopuntCatalog48x48.png
inkscape -z -f geopuntPerceel.svg -w 48 -h 48 -e geopuntPerceel48x48.png
inkscape -z -f geopuntBatch.svg -w 48 -h 48 -e geopuntBatch48x48.png
inkscape -z -f geopuntElevation.svg -w 48 -h 48 -e geopuntElevation48x48.png
inkscape -z -f geopuntGipod.svg -w 48 -h 48 -e geopuntGipod48x48.png
inkscape -z -f geopuntPoi.svg -w 48 -h 48 -e geopuntPoi48x48.png
inkscape -z -f geopuntReverse.svg -w 48 -h 48 -e geopuntReverse48x48.png
inkscape -z -f geopuntSetting.svg -w 48 -h 48 -e geopuntSetting48x48.png

inkscape -z -f geopuntAddress.svg -w 256 -h 256 -e geopuntAddress256x256.png
inkscape -z -f geopuntCatalog.svg -w 256 -h 256 -e geopuntCatalog256x256.png
inkscape -z -f geopuntPerceel.svg -w 256 -h 256 -e geopuntPerceel256x256.png
inkscape -z -f geopuntBatch.svg -w 256 -h 256 -e geopuntBatch256x256.png
inkscape -z -f geopuntElevation.svg -w 256 -h 256 -e geopuntElevation256x256.png
inkscape -z -f geopuntGipod.svg -w 256 -h 256 -e geopuntGipod256x256.png
inkscape -z -f geopuntPoi.svg -w 256 -h 256 -e geopuntPoi256x256.png
inkscape -z -f geopuntReverse.svg -w 256 -h 256 -e geopuntReverse256x256.png
inkscape -z -f geopuntSetting.svg -w 256 -h 256 -e geopuntSetting256x256.png

REM icon's for forms
REM convert -background none geopuntAddress16x16.png geopuntAddress24x24.png geopuntAddress32x32.png geopuntAddress48x48.png geopuntAddress256x256.png geopuntAddress.ico
REM convert -background none geopuntCatalog16x16.png geopuntCatalog24x24.png geopuntCatalog32x32.png geopuntCatalog48x48.png geopuntCatalog256x256.png geopuntCatalog.ico
REM convert -background none geopuntPerceel16x16.png geopuntPerceel24x24.png geopuntPerceel32x32.png geopuntPerceel48x48.png geopuntPerceel256x256.png geopuntPerceel.ico
REM convert -background none geopuntBatch16x16.png geopuntBatch24x24.png geopuntBatch32x32.png geopuntBatch48x48.png geopuntBatch256x256.png geopuntBatch.ico
REM convert -background none geopuntElevation16x16.png geopuntElevation24x24.png geopuntElevation32x32.png geopuntElevation48x48.png geopuntElevation256x256.png geopuntElevation.ico
REM convert -background none geopuntGipod16x16.png geopuntGipod24x24.png geopuntGipod32x32.png geopuntGipod48x48.png geopuntGipod256x256.png geopuntGipod.ico
REM convert -background none geopuntPoi16x16.png geopuntPoi24x24.png geopuntPoi32x32.png geopuntPoi48x48.png geopuntPoi256x256.png geopuntPoi.ico
REM convert -background none geopuntReverse16x16.png geopuntReverse24x24.png geopuntReverse32x32.png geopuntReverse48x48.png geopuntReverse256x256.png geopuntReverse.ico
REM convert -background none geopuntSetting16x16.png geopuntSetting24x24.png geopuntSetting32x32.png geopuntSetting48x48.png geopuntSetting256x256.png geopuntSetting.ico

convert -background none geopuntAddress32x32.png geopuntAddress48x48.png geopuntAddress256x256.png geopuntAddress.ico
convert -background none geopuntCatalog32x32.png geopuntCatalog48x48.png geopuntCatalog256x256.png geopuntCatalog.ico
convert -background none geopuntPerceel32x32.png geopuntPerceel48x48.png geopuntPerceel256x256.png geopuntPerceel.ico
convert -background none geopuntBatch32x32.png geopuntBatch48x48.png geopuntBatch256x256.png geopuntBatch.ico
convert -background none geopuntElevation32x32.png geopuntElevation48x48.png geopuntElevation256x256.png geopuntElevation.ico
convert -background none geopuntGipod32x32.png geopuntGipod48x48.png geopuntGipod256x256.png geopuntGipod.ico
convert -background none geopuntPoi32x32.png geopuntPoi48x48.png geopuntPoi256x256.png geopuntPoi.ico
convert -background none geopuntReverse32x32.png geopuntReverse48x48.png geopuntReverse256x256.png geopuntReverse.ico
convert -background none geopuntSetting32x32.png geopuntSetting48x48.png geopuntSetting256x256.png geopuntSetting.ico


REM copy to addincontent
copy /Y geopuntAddress32x32.png ..\geopunt4arcgis\Images\geopuntAddressCmd.png
copy /Y geopuntCatalog32x32.png ..\geopunt4arcgis\Images\geopuntDataCatalogusCmd.png
copy /Y geopuntPerceel32x32.png ..\geopunt4arcgis\Images\geopuntPerceelCmd.png
copy /Y geopuntBatch32x32.png ..\geopunt4arcgis\Images\geopuntBatchGeocodingCmd.png
copy /Y geopuntElevation32x32.png ..\geopunt4arcgis\Images\geopuntElevationCmd.png
copy /Y geopuntGipod32x32.png ..\geopunt4arcgis\Images\geopuntGipodCmd.png
copy /Y geopuntPoi32x32.png ..\geopunt4arcgis\Images\geopuntPoiCmd.png
copy /Y geopuntReverse32x32.png ..\geopunt4arcgis\Images\geopuntReverseCmd.png

