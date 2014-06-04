using MeasurementProtocolClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeasurementProtocolClient
{
    public class TrackerParameters
    {
        #region Constants

        private const string DEFAULT_PROTOCOL_VERSION = "1";

        #endregion


        #region Enums

        public enum HitTypes
        {
            pageview,
            appview,
            @event,
            transaction,
            item,
            social,
            exception,
            timing
        }

        public enum SessionControlValues
        {
            Start,
            End
        }
        
        #endregion


        #region Private fields

        private Tracker tracker;

        #endregion


        #region Public Properties

        /// <summary>
        /// When present, the IP address of the sender will be anonymized.
        /// </summary>
        [Parameter("aip")]
        public bool? AnonymizeIP { get; set; }

        [Parameter("an")]
        public string ApplicationName { get; set; }

        [Parameter("av")]
        public string ApplicationVersion { get; set; }

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

        [MaxByteCount(2048)]
        [Parameter("cd")]
        public string ContentDescription { get; set; }

        [Parameter("cid")]
        public string ClientId { get; set; }

        public Dictionary<int, string> CustomDimensions { get; private set; }

        public Dictionary<int, int> CustomMetrics { get; private set; }
        
        /// <summary>
        /// Default value from Analytics : UTF-8
        /// </summary>
        [MaxByteCount(20)]
        [Parameter("de")]
        public string DocumentEncoding { get; set; }

        [MaxByteCount(100)]
        [Parameter("dh")]
        public string DocumentHostName { get; set; }

        [MaxByteCount(2048)]
        [Parameter("dl")]
        public string DocumentLocationUrl { get; set; }

        /// <summary>
        /// The path portion of the page URL. Should begin with '/'.
        /// </summary>
        [MaxByteCount(2048)]
        [Parameter("dp")]
        public string DocumentPath { get; set; }

        [MaxByteCount(2048)]
        [Parameter("dr")]
        public string DocumentReferrer { get; set; }

        [MaxByteCount(1500)]
        [Parameter("dt")]
        public string DocumentTitle { get; set; }

        [MaxByteCount(500)]
        [Parameter("ea")]
        public string EventAction { get; set; }

        [MaxByteCount(150)]
        [Parameter("ec")]
        public string EventCategory { get; set; }

        [Parameter("ev")]
        public string EventValue { get; set; }

        [MaxByteCount(500)]
        [Parameter("el")]
        public string EventLabel { get; set; }

        [MaxByteCount(20)]
        [Parameter("fl")]
        public string FlashVersion { get; set; }

        [Parameter("gclid")]
        public string GoogleAdWordsId { get; set; }

        [Parameter("dclid")]
        public string GoogleDisplayAdsId { get; set; }

        [Parameter("t")]
        public HitTypes HitType
        {
            get
            {
                return tracker.HitType;
            }
        }

        [Parameter("v")]
        public string ProtocolVersion { get; set; }

        [Parameter("je")]
        public bool? JavaEnabled { get; set; }

        /// <summary>
        /// Used to collect offline / latent hits. 
        /// The value represents the time delta (in milliseconds) 
        /// between when the hit being reported occurred and the time the hit was sent. 
        /// The value must be greater than or equal to 0. 
        /// Values greater than four hours may lead to hits not being processed.
        /// </summary>
        [Parameter("qt")]
        public int? QueueTime { get; set; }

        /// <summary>
        /// Specifies that a hit be considered non-interactive.
        /// </summary>
        [Parameter("ni")]
        public bool? NonInteractionHit { get; set; }

        /// <summary>
        /// Example: 24-bits
        /// </summary>
        [Parameter("sd")]
        public string ScreenColors { get; set; }

        [Parameter("sr")]
        public Size ScreenResolution { get; set; }

        [Parameter("ul")]
        public string UserLanguage { get; set; }

        [Parameter("vp")]
        public Size ViewportSize { get; set; }

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

        #endregion


        #region Constructors

        public TrackerParameters(Tracker tracker, string trackingId, string clientId)
        {
            this.tracker = tracker;
            this.ClientId = clientId;
            this.TrackingId = trackingId;
            this.CustomDimensions = new Dictionary<int, string>();
            this.CustomMetrics = new Dictionary<int, int>();
            this.ProtocolVersion = DEFAULT_PROTOCOL_VERSION;
        }

        #endregion
    }
}
