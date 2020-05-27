namespace Telnyx.net.Services.Calls.CallControlApplications
{
    public class ListCallControlApplicationOptions : ListOptions
    {
        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public string FilterApplicationNameContains { get; set; }

        public string FilterOutboundOutboundVoiceProfileId { get; set; }

        public string Sort { get; set; }
    }
}