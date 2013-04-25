dot-net-google-analytics-measurement-protocol-client
====================================================

.NET Client for Google Analytics Measurement Protocol (Universal Analytics)

https://developers.google.com/analytics/devguides/collection/protocol/v1/devguide


Usage : 

```
  var tracker = new PageviewTracker("UA-XXXX-Y", CLIENT_ID); 
  tracker.Parameters.DocumentPath = "/testpage"; 
  tracker.Parameters.DocumentTitle = "Test page"; 
  tracker.Send(); 
```
