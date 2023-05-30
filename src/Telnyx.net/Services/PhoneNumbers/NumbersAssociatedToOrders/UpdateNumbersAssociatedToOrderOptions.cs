using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.NumbersAssociatedToOrders;

namespace Telnyx.net.Services.PhoneNumbers.NumbersAssociatedToOrders
{
    public class UpdateNumbersAssociatedToOrderOptions : BaseOptions
    {
        [JsonProperty("regulatory_requirements")]
        public List<UpdateRegulatoryRequirement> RegulatoryRequirements { get; set; }
    }
}
