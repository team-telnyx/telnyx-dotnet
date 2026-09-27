namespace Telnyx.net.Entities.Wireless.OTAUpdates
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CompleteOTAUpdateSettings
    {
        /// <summary>
        /// Gets or Sets MobileOperatorNetworksPreferences.
        /// </summary>
        [JsonProperty("mobile_network_operators_preferences")]
        public List<MobileOperatorNetworksPreferences> MobileOperatorNetworksPreferences { get; set; }
    }
}