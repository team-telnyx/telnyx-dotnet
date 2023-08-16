namespace Telnyx.net.Entities.Documents
{
    using Newtonsoft.Json;

    public class DocumentSize
    {
        /// <summary>
        /// The number of bytes.
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Identifies the unit.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
