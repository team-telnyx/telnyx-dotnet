namespace Telnyx.net.Entities.NumberLookup
{
    using Newtonsoft.Json;

    public class NumberLookupRecord : TelnyxEntity, IHasId
    { /// <summary>
      /// Identifies the type of record.
      /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Region code that matches the specific country calling code.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Hyphen-separated national number, preceded by the national destination code (NDC), with a 0 prefix, if an NDC is found.
        /// </summary>
        [JsonProperty("national_format")]
        public string NationalFormat { get; set; }

        /// <summary>
        /// E164-formatted phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Unused.
        /// </summary>
        [JsonProperty("fraud")]
        public string Fraud { get; set; }

        /// <summary>
        /// Gets or Sets Carrier.
        /// </summary>
        [JsonProperty("carrier")]
        public Carrier Carrier { get; set; }

        /// <summary>
        /// Gets or Sets CallerName.
        /// </summary>
        [JsonProperty("caller_name")]
        public CallerName CallerName { get; set; }

        /// <summary>
        /// Gets or Sets Portability.
        /// </summary>
        [JsonProperty("portability")]
        public Portability Portability { get; set; }

        /// <summary>
        /// Gets id.
        /// </summary>
        [JsonProperty("phone_number")]
        public string Id { get; set; }
    }
}
