using MeasurementProtocolClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeasurementProtocolClient
{
    public class Tracker
    {
        #region Constants

        private const Uri SSL_ENDPOINT_URI = new Uri("https://ssl.google-analytics.com/collect");
        private const Uri NON_SSL_ENDPOINT_URI = new Uri("http://www.google-analytics.com/collect");

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

        public TrackerParameters Parameters { get; private set; }

        public string UserAgent { get; set; }
        
        public bool UseSsl { get; set; }

        #endregion


        #region Contructors

        public Tracker()
        {
            Parameters = new TrackerParameters();
        }

        #endregion
    }
}
