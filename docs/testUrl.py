import urllib2, json

u = r'http://poi.beta.geopunt.be/v1/core/categories'

req = urllib2.Request( u, headers = {"Content-Type":"application/json"} )

f= urllib2.urlopen(req)

print f.read()
