namespace Telnyx.net.Services.OutboundVoiceProfiles
{
    public class ListOutboundVoiceProfileOptions : ListOptions
    {
        public string FilterNameContains { get; set; }

        public string Sort { get; set; }
    }
}