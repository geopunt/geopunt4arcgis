import urllib2, json

u = r'http://poi.api.geopunt.be/core?keyword=fiets&maxmodel=true&maxcount=1'

req = urllib2.Request( u, headers = {"Content-Type":"application/json"} )

f= urllib2.urlopen(req)

r = f.read()

print r