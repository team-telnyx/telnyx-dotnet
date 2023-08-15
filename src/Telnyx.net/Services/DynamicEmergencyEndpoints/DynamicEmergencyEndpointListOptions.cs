namespace Telnyx.net.Services.DynamicEmergencyEndpoints
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.DynamicEmergencyEndpoints;

    public class DynamicEmergencyEndpointListOptions : ListOptions
    {
        /// <summary>
        /// Filter by status.
        /// Enum: "pending" "activated" "rejected".
        /// </summary>
        [JsonProperty("filter[status]")]
        public DynamicEmergencyAddressStatus? Status { get; set; }

        /// <summary>
        /// Filter by country code.
        /// </summary>
        [JsonProperty("filter[country_code]")]
        public string CountryCode { get; set; }
    }
}
