import json, os, sys
import xml.etree.ElementTree as tree

def main( outPath ):
    version = {}
    version["AddInID"] = "{9473f72a-33ce-402e-85c7-170c29b08419}"
    version["Name"] = "geopunt4Arcgis"
    version["Version"] = "1.7.1"
    version["Date"] = "23/03/2015"

    outPath = open( outPath , 'w' )
    outPath.write( json.dumps( version ) )
    outPath.close()

if __name__ == '__main__':
    p= "C:\Users\SA64489\Documents\Visual Studio 2010\Projects\geopunt4arcgis\geopunt4arcgis.json"
    if len( sys.argv ) > 1:
       p= sys.argv[1]

    main( p )
