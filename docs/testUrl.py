import urllib2, json

u = r'http://poi.beta.geopunt.be/v1/core?keyword=school&srsIn=4326&srsOut=4326&region=23002&theme=&category=&POItype=&maxcount=32&maxmodel=true'

req = urllib2.Request( u, headers = {"Content-Type":"application/json"} )

f= urllib2.urlopen(req)

print f.read()