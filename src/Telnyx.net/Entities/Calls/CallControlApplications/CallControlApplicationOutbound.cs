namespace Telnyx.net.Entities.Calls.CallControlApplications
{
    using Newtonsoft.Json;

    public partial class CallControlApplicationOutbound
    {
        /// <summary>
        /// When set, this will limit the total number of outbound calls to phone numbers associated with this connection.
        /// </summary>
        /// <value>When set, this will limit the total number of outbound calls to phone numbers associated with this connection.</value>
        [JsonProperty("channel_limit")]
        public int? ChannelLimit { get; set; }

        /// <summary>
        /// Gets or Sets OutboundVoiceProfileId.
        /// </summary>
        [JsonProperty("outbound_voice_profile_id")]
        public string OutboundVoiceProfileId { get; set; }
    }
}
