namespace MeasurementProtocolClient
{
    public class EventTracker : Tracker
    {
        public EventTracker(string trackingId, string clientId)
            : base(trackingId, clientId)
        { }

        public override TrackerParameters.HitTypes HitType
        {
            get { return TrackerParameters.HitTypes.@event; }
        }
    }
}
