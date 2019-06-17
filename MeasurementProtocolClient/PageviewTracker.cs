namespace MeasurementProtocolClient
{
    public class PageviewTracker : Tracker
    {
        public PageviewTracker(string trackingId, string clientId)
            : base(trackingId, clientId)
        { }

        public override TrackerParameters.HitTypes HitType
        {
            get { return TrackerParameters.HitTypes.pageview; }
        }
    }
}
