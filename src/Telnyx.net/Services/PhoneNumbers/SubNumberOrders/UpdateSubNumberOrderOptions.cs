using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.SubNumberOrders;

namespace Telnyx.net.Services.PhoneNumbers.SubNumberOrders
{
    public class UpdateSubNumberOrderOptions : BaseOptions
    {
        [JsonProperty("regulatory_requirements")]
        public List<UpdateRegulatoryRequirement> RegulatoryRequirements { get; set; }
    }
}
