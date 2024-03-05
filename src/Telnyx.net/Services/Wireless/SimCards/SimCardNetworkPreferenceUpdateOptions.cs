namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Wireless.OTAUpdates;

    public class SimCardNetworkPreferenceUpdateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or Sets MobileOperatorNetworksPreferences.
        /// </summary>
        [JsonProperty("mobile_operator_networks_preferences")]
        public List<MobileOperatorNetworksPreferences> MobileOperatorNetworksPreferences { get; set; }
    }
}