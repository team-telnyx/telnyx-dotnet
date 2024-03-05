using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PortingOrders.PortingOrderComments
{
    public class PortingOrderComment : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("porting_order_id")]
        public Guid PortingOrderId { get; set; }

        [JsonProperty("user_type")]
        public string UserType { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
