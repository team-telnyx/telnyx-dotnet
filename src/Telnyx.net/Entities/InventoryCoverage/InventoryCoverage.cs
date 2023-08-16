namespace Telnyx.net.Entities.InventoryCoverage
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.InventoryCoverage;

    public class InventoryCoverage : TelnyxEntity
    {
        /// <summary>
        /// The count.
        /// </summary>
        [JsonProperty("count")]
        public int? Count { get; set; }

        /// <summary>
        /// The coverage type.
        /// Enum: "number" "block".
        /// </summary>
        //[JsonProperty("coverage_type")]
        //public CoverageType? CoverageType { get; set; }

        /// <summary>
        /// The group.
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// The group type.
        /// </summary>
        [JsonProperty("group_type")]
        public string GroupType { get; set; }

        /// <summary>
        /// The number range.
        /// </summary>
        [JsonProperty("number_range")]
        public int? NumberRange { get; set; }

        /// <summary>
        /// The number type.
        /// Enum: "did" "toll-free".
        /// </summary>
        [JsonProperty("number_type")]
        public NumberType? NumberType { get; set; }

        /// <summary>
        /// The phone number type.
        /// Enum: "local" "toll_free" "national" "landline" "shared_cost" "mobile".
        /// </summary>
        [JsonProperty("phone_number_type")]
        public PhoneNumberType? PhoneNumberType { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
}
