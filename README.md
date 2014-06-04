dot-net-google-analytics-measurement-protocol-client
====================================================

.NET Client Library for Google Analytics Measurement Protocol (Universal Analytics)

https://developers.google.com/analytics/devguides/collection/protocol/v1/devguide


<h3>Usage: </h3>

Install with <a href="https://www.nuget.org/packages/MeasurementProtocolClient/">NuGet</a>

```
  var tracker = new PageviewTracker("UA-XXXX-Y", CLIENT_ID); 
  tracker.Parameters.DocumentPath = "/testpage"; 
  tracker.Parameters.DocumentTitle = "Test page"; 
  tracker.Send(); 
```

<h3>TODOs:</h3>

<ul>
<li>Implement other tracker types (<a target="_blank" href="http://bit.ly/YUrjck">"hit types"</a>)</li>
<li>Make library usage less verbose</li>
<li>Finish adding <a target="_blank" href="https://developers.google.com/analytics/devguides/collection/protocol/v1/parameters">all parameters</a></li>
</ul>
