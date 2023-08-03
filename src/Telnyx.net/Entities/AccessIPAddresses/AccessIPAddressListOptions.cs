namespace Telnyx.net.Entities.AccessIPAddresses
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.AccessIPAddresses;

    public class AccessIPAddressListOptions : ListOptions
    {
        /// <summary>
        /// Filter by the IP source.
        /// </summary>
        [JsonProperty("filter[ip_source]")]
        public string IpSource { get; set; }

        /// <summary>
        /// Filter by the IP address.
        /// </summary>
        [JsonProperty("filter[ip_address]")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Filter by the status of the Cloudflare sync.
        /// </summary>
        [JsonProperty("filter[status]")]
        public CloudflareSyncStatus Status { get; set; }

        /// <summary>
        /// Filter by the created date after the specified datetime.
        /// </summary>
        [JsonProperty("filter[created_at][gt]")]
        public string CreatedAtGreaterThan { get; set; }

        /// <summary>
        /// Filter by the created date before the specified datetime.
        /// </summary>
        [JsonProperty("filter[created_at][lt]")]
        public string CreatedAtLessThan { get; set; }
    }
}
