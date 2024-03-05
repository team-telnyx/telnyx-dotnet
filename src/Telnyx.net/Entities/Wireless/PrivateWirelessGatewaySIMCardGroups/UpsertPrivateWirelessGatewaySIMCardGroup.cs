using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.PrivateWirelessGatewaySIMCardGroups
{
    public class UpsertPrivateWirelessGatewaySIMCardGroup : BaseOptions
    {
        [JsonProperty("private_wireless_gateway_id")]
        public Guid PrivateWirelessGatewayId { get; set; }
    }
}
