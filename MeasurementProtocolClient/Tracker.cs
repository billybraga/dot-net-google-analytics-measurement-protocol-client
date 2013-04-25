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

        private const string DEFAULT_PROTOCOL_VERSION = "1";
        private const Uri SSL_ENDPOINT_URI = new Uri("https://ssl.google-analytics.com/collect");
        private const Uri NON_SSL_ENDPOINT_URI = new Uri("http://www.google-analytics.com/collect");

        #endregion


        #region Enums

        public enum SessionControlValues
        {
            Start,
            End
        }

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

        /// <summary>
        /// When present, the IP address of the sender will be anonymized.
        /// </summary>
        [Parameter("aip")]
        public bool? AnonymizeIP { get; set; }

        [MaxByteCount(500)]
        [Parameter("cc")]
        public string CampaignContent { get; set; }

        [MaxByteCount(100)]
        [Parameter("ci")]
        public string CampaignId { get; set; }

        [MaxByteCount(500)]
        [Parameter("ck")]
        public string CampaignKeyword { get; set; }

        [MaxByteCount(100)]
        [Parameter("cn")]
        public string CampaignName { get; set; }

        [MaxByteCount(50)]
        [Parameter("cm")]
        public string CampaignMedium { get; set; }

        [MaxByteCount(100)]
        [Parameter("cs")]
        public string CampaignSource { get; set; }

        [Parameter("cid")]
        public string ClientId { get; set; }

        [MaxByteCount(2048)]
        [Parameter("dr")]
        public string DocumentReferrer { get; set; }

        [Parameter("gclid")]
        public string GoogleAdWordsId { get; set; }

        [Parameter("dclid")]
        public string GoogleDisplayAdsId { get; set; }

        [Parameter("v")]
        public string ProtocolVersion { get; set; }
        
        /// <summary>
        /// Used to collect offline / latent hits. 
        /// The value represents the time delta (in milliseconds) 
        /// between when the hit being reported occurred and the time the hit was sent. 
        /// The value must be greater than or equal to 0. 
        /// Values greater than four hours may lead to hits not being processed.
        /// </summary>
        [Parameter("qt")]
        public int? QueueTime { get; set; }

        [Parameter("sr")]
        public ScreenResolution ScreenResolution { get; set; }

        /// <summary>
        /// Used to control the session duration. A value of 'start' forces a new session to start with this hit and 'end' forces the current session to end with this hit. All other values are ignored.
        /// </summary>
        [Parameter("sc")]
        public SessionControlValues? SessionControl { get; set; }

        /// <summary>
        /// Property ID. Ex.: UA-XXXX-Y
        /// </summary>
        [Parameter("tid")]
        public string TrackingId { get; set; }
        
        public string UserAgent { get; set; }
        
        public bool UseSsl { get; set; }

        #endregion


        #region Contructors

        public Tracker()
        {
            ProtocolVersion = DEFAULT_PROTOCOL_VERSION
        }

        #endregion
    }
}
