namespace Telnyx.net.Entities.PhoneNumbers.InboundChannels
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class InboundChannel : TelnyxEntity, IHasId
    {
        /// <summary>
        /// The current number of concurrent channels set for the account.
        /// </summary>
        [JsonProperty("channels")]
        public int Channels { get; set; }

        /// <summary>
        /// Identifies the type of the response.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        string IHasId.Id { get => this.Channels.ToString(); set => int.Parse(value); }
    }
}
