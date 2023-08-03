namespace Telnyx.net.Entities.NumberLookup
{
    using Newtonsoft.Json;

    public class CallerName
    {
        /// <summary>
        /// The name of the requested phone number&#x27;s owner as per the CNAM database.
        /// </summary>
        [JsonProperty("caller_name")]
        public string _CallerName { get; set; }

        /// <summary>
        /// A caller-name lookup specific error code, expressed as a stringified 5-digit integer.
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
    }
}
