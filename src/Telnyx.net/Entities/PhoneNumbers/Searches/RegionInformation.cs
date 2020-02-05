namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// Region Information
    /// </summary>
    public class RegionInformation
    {
        /// <summary>
        /// Gets or sets RegionType
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum RegionTypeEnum
        {
            /// <summary>
            /// Enum CountryCodeEnum for country_code
            /// </summary>
            [JsonProperty("country_code")]
            CountryCodeEnum = 0,

            /// <summary>
            /// Enum RateCenterEnum for rate_center
            /// </summary>
            [JsonProperty("rate_center")]
            RateCenterEnum = 1,

            /// <summary>
            /// Enum StateEnum for state
            /// </summary>
            [JsonProperty("state")]
            StateEnum = 2,

            /// <summary>
            /// Enum LocationEnum for location
            /// </summary>
            [JsonProperty("location")]
            LocationEnum = 3
        }

        /// <summary>
        /// Gets or sets RegionType
        /// </summary>
        [JsonProperty("region_type")]
        public string RegionType { get; set; }

        /// <summary>
        /// Gets or sets RegionName
        /// </summary>
        [JsonProperty("region_name")]
        public string RegionName { get; set; }
    }
}
