namespace Telnyx.net.Services.Calls.CallControlApplications
{
    public class ListCallControlApplicationOptions : ListOptions
    {
        public string FilterApplicationNameContains { get; set; }

        public string FilterOutboundOutboundVoiceProfileId { get; set; }

        public string Sort { get; set; }
    }
}