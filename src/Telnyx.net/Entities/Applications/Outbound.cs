namespace Telnyx.net.Entities.Applications
{
    using Newtonsoft.Json;

    public class Outbound
    {
        /// <summary>
        /// When set, this will limit the number of concurrent outbound calls to phone numbers associated with this connection.
        /// </summary>
        [JsonProperty("channel_limit")]
        public int? ChannelLimit { get; set; } = null;

        /// <summary>
        /// Identifies the associated outbound voice profile.
        /// </summary>
        [JsonProperty("outbound_voice_profile_id")]
        public string OutboundVoiceProfileId { get; set; }
    }
}
