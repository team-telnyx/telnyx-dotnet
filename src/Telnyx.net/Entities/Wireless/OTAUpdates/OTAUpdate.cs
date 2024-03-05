using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.OTAUpdates
{
    public class OTAUpdate : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("sim_card_id")]
        public Guid SimCardId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("settings")]
        public NetworkSettings Settings { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class NetworkSettings
    {
        [JsonProperty("mobile_network_operators_preferences")]
        public MobileNetworkOperatorPreference[] MobileNetworkOperatorsPreferences { get; set; }
    }

    public class MobileNetworkOperatorPreference
    {
        [JsonProperty("mobile_network_operator_id")]
        public Guid MobileNetworkOperatorId { get; set; }

        [JsonProperty("mobile_network_operator_name")]
        public string MobileNetworkOperatorName { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }
    }

}
