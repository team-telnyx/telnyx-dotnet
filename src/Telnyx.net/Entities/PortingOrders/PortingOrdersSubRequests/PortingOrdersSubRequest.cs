using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PortingOrders.PortingOrdersSubRequests
{
    public class PortingOrdersSubRequest : TelnyxEntity
    {
        [JsonProperty("sub_request_id")]
        public string SubRequestId { get; set; }

        [JsonProperty("port_request_id")]
        public string PortRequestId { get; set; }
    }
}
