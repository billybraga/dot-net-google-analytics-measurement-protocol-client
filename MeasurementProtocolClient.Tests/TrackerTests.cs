using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeasurementProtocolClient.Tests
{
    [TestClass]
    public class TrackerTests
    {
        const string TRACKER_ID = "UA-29544240-4";
        static readonly string CLIENT_ID = Environment.UserName;

        [TestMethod]
        public void BasicNameValueCollectionGenerationTest()
        {
            var tracker = new PageviewTracker(TRACKER_ID, CLIENT_ID);
            var collection = tracker.GetNameValueCollection();

            Assert.AreEqual(CLIENT_ID, collection["cid"]);
        }

        [TestMethod]
        public void SendTest()
        {
            var tracker = new PageviewTracker(TRACKER_ID, CLIENT_ID);
            tracker.Parameters.DocumentPath = "/testpage";
            tracker.Parameters.DocumentTitle = "Test page";
            tracker.Send();

            tracker.Parameters.ClientId = CLIENT_ID + "2";
            tracker.Parameters.DocumentPath = "/testpage2";
            tracker.Parameters.DocumentTitle = "Test page2";
            tracker.Send();
        }

    }
}
