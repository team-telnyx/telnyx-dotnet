namespace Telnyx.net.Entities
{
    using Newtonsoft.Json;

    public class TelnyxApiResponse : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets destination number or SIP URI of the call.
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}
