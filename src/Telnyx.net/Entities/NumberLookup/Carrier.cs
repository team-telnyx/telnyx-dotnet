namespace Telnyx.net.Entities.NumberLookup
{
    using Newtonsoft.Json;

    public class Carrier
    {
        /// <summary>
        /// Region code that matches the specific country calling code if the requested phone number type is mobile.
        /// </summary>
        [JsonProperty("mobile_country_code")]
        public string MobileCountryCode { get; set; }

        /// <summary>
        /// National destination code (NDC), with a 0 prefix, if an NDC is found and the requested phone number type is mobile.
        /// </summary>
        [JsonProperty("mobile_network_code")]
        public string MobileNetworkCode { get; set; }

        /// <summary>
        /// SPID (Service Provider ID) name, if the requested phone number has been ported; otherwise, the name of carrier who owns the phone number block.
        /// </summary>
        /// [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A phone number type that identifies the type of service associated with the requested phone number.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Unused.
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
    }
}
