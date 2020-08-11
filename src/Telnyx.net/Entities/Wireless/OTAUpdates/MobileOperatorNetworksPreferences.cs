namespace Telnyx.net.Entities.Wireless.OTAUpdates
{
    using System;
    using Newtonsoft.Json;

    public class MobileOperatorNetworksPreferences
    {
        /// <summary>
        /// The mobile operator network resource identification UUID.
        /// </summary>
        [JsonProperty("mobile_operator_network_id")]
        public Guid? MobileOperatorNetworkId { get; set; }

        /// <summary>
        /// The mobile operator network resource name.
        /// </summary>
        [JsonProperty("mobile_operator_network_name")]
        public string MobileOperatorNetworkName { get; set; }

        /// <summary>
        /// It determines what is the priority of a specific operator network that should be assumed by a SIM card when connecting to a network. The highest priority is 0, the second highest is 1 and so on.
        /// </summary>
        [JsonProperty("priority")]
        public int? Priority { get; set; }
    }
}