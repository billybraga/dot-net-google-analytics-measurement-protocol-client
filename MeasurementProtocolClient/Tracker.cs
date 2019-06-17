using MeasurementProtocolClient.Attributes;
using System;
using System.Collections.Specialized;
using System.Net;

namespace MeasurementProtocolClient
{
    public abstract class Tracker
    {
        #region Constants

        private static readonly Uri SSL_ENDPOINT_URI = new Uri("https://ssl.google-analytics.com/collect");
        private static readonly Uri NON_SSL_ENDPOINT_URI = new Uri("http://www.google-analytics.com/collect");

        #endregion


        #region Private Properties

        private Uri EndpointUri
        {
            get
            {
                return UseSsl ? SSL_ENDPOINT_URI : NON_SSL_ENDPOINT_URI;
            }
        }

        #endregion


        #region Public Properties

        public abstract TrackerParameters.HitTypes HitType { get; }

        public TrackerParameters Parameters { get; private set; }

        public string UserAgent { get; set; }

        public bool UseSsl { get; set; }

        #endregion


        #region Contructors

        protected Tracker(string trackingId, string clientId)
        {
            Parameters = new TrackerParameters(this,trackingId, clientId);
        }

        #endregion


        #region Methods

        public NameValueCollection GetNameValueCollection()
        {
            var collection = ParameterAttribute.GetNameValueCollection(Parameters);

            foreach (var pair in Parameters.CustomDimensions)
            {
                collection.Add("cd" + pair.Key, pair.Value);
            }

            foreach (var pair in Parameters.CustomMetrics)
            {
                collection.Add("cm" + pair.Key, pair.Value.ToString());
            }

            return collection;
        }

        public void Send()
        {
            using (var wc = new WebClient())
            {
                wc.UploadValues(EndpointUri, GetNameValueCollection());
            }
        }

        #endregion
    }
}
