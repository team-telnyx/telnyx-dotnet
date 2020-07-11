namespace Telnyx.net.Entities.Wireless
{
    using Newtonsoft.Json;

    /// <summary>
    /// Phone number.
    /// </summary>
    public class SimCardRecord: TelnyxEntity, IHasId
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
