namespace Telnyx.net.Entities.AccessIPAddresses
{
    using Newtonsoft.Json;

    public class AccessIPAddressCreateOptions : BaseOptions
    {
        /// <summary>
        /// The description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The IP address.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
    }
}
