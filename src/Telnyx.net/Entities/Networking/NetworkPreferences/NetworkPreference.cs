using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Networking.NetworkPreferences
{
    public class NetworkPreference : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("sim_card_id")]
        public Guid SimCardId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("settings")]
        public OtaUpdateSettings Settings { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
    public class OtaUpdateSettings
    {
        [JsonProperty("mobile_network_operators_preferences")]
        public MobileNetworkOperatorsPreference[] MobileNetworkOperatorsPreferences { get; set; }
    }
    public class MobileNetworkOperatorsPreference
    {
        [JsonProperty("mobile_network_operator_id")]
        public Guid MobileNetworkOperatorId { get; set; }

        [JsonProperty("mobile_network_operator_name")]
        public string MobileNetworkOperatorName { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }
    }
    public class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("source")]
        public ErrorSource Source { get; set; }

        [JsonProperty("meta")]
        public object Meta { get; set; }
    }

    public class ErrorSource
    {
        [JsonProperty("pointer")]
        public string Pointer { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }
    }
}
