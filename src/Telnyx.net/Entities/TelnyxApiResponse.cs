using Newtonsoft.Json;

namespace Telnyx.net.Entities
{
    public class TelnyxApiResponse : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets destination number or SIP URI of the call.
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}
