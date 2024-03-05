namespace Telnyx.net.Entities.PhoneNumbers.Coverage
{

    using Newtonsoft.Json;
    /// <summary>
    /// Holds the details for a single phone number.
    /// </summary>
    public class PhoneNumberDetail
    {
        /// <summary>
        /// The phone number as it was submitted.
        /// </summary>
        [JsonProperty("raw_number")]
        public string RawNumber { get; set; }

        /// <summary>
        /// The phone number parsed into E164 format.
        /// </summary>
        [JsonProperty("e164_number")]
        public string E164Number { get; set; }

        /// <summary>
        /// Indicates if the number is portable.
        /// </summary>
        [JsonProperty("portable")]
        public bool Portable { get; set; }

        /// <summary>
        /// Specifies whether the portability status is pending, confirmed, or provisional.
        /// </summary>
        [JsonProperty("portability_status")]
        public string PortabilityStatus { get; set; }

        /// <summary>
        /// The name of the underlying carrier associated with the phone number.
        /// </summary>
        [JsonProperty("carrier_name")]
        public string CarrierName { get; set; }

        /// <summary>
        /// The category of phone number coverage such as NANP generic, toll-free, etc.
        /// </summary>
        [JsonProperty("coverage_category")]
        public string CoverageCategory { get; set; }

        /// <summary>
        /// Reason the phone number is not portable, if applicable.
        /// </summary>
        [JsonProperty("non_portable_reason")]
        public string NonPortableReason { get; set; }
    }
}
