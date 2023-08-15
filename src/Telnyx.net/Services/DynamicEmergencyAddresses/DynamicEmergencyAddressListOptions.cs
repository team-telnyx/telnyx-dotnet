namespace Telnyx.net.Services.DynamicEmergencyAddresses
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Telnyx.net.Entities.Enum.DynamicEmergencyAddresses;

    public class DynamicEmergencyAddressListOptions : ListOptions
    {
        /// <summary>
        /// Gets or sets the filter status.
        /// </summary>
        [JsonProperty("filter[status]")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusFilter FilterStatus { get; set; }

        /// <summary>
        /// Gets or sets the filter country code.
        /// </summary>
        [JsonProperty("filter[country_code]")]
        public string FilterCountryCode { get; set; }
    }
}
