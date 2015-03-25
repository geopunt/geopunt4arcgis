import urllib2, json

u = r'http://a8da9008116d4b0b8ee34d6b6e1f21db.cloudapp.net/v1/core?maxModel=true'

req = urllib2.Request( u, headers = {"Content-Type":"application/json"} )

f= urllib2.urlopen(req)

print f.read()