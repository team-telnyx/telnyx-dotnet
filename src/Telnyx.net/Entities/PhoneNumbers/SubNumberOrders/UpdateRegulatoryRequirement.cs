using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.PhoneNumbers.SubNumberOrders
{
    public class UpdateRegulatoryRequirement
    {
        [JsonProperty("field_value")]
        public string FieldValue { get; set; }

        [JsonProperty("requirement_id")]
        public string RequirementId { get; set; }
    }
}
