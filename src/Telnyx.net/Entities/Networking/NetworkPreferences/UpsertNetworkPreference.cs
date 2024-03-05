using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Networking.NetworkPreferences
{
    public class UpsertNetworkPreference : BaseOptions
    {
        [JsonProperty("sim_card_ids")]
        public Guid[] SimCardIds { get; set; }

        [JsonProperty("mobile_network_operators_preferences")]
        public MobileNetworkOperatorsPreferences MobileNetworkOperatorsPreferences { get; set; }
    }
    public class MobileNetworkOperatorsPreferences
    {
        [JsonProperty("mobile_network_operator_id")]
        public Guid MobileNetworkOperatorId { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }
    }
}
