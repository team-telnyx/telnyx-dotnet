namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Wireless.OTAUpdates;

    public class SimCardBulkNetworkPreferenceUpdateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or Sets MobileOperatorNetworksPreferences.
        /// </summary>
        [JsonProperty("mobile_operator_networks_preferences")]
        public List<MobileOperatorNetworksPreferences> MobileOperatorNetworksPreferences { get; set; }

        /// <summary>
        /// Gets or Sets Sim Card Ids.
        /// </summary>
        [JsonProperty("sim_card_ids")]
        public string[] SimCardIds { get; set; }
    }
}
