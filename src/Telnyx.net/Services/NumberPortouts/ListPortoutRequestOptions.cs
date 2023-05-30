using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.NumberPortouts;
using Telnyx.net.Services.PhoneNumbers.Orders.Comments;

namespace Telnyx.net.Services.NumberPortouts
{
    public class ListPortoutRequestOptions : ListOptions
    {
        [JsonProperty("filter[carrier_name]")]
        public string CarrierName { get; set; }

        [JsonProperty("filter[spid]")]
        public string Spid { get; set; }

        [JsonProperty("filter[status]")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PortoutStatus Status { get; set; }
    }
}
