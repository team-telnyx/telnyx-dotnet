namespace Telnyx.net.Services.PhoneNumbers.SubNumberOrders
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.PhoneNumbers.SubNumberOrders;

    public class UpdateSubNumberOrderOptions : BaseOptions
    {
        [JsonProperty("regulatory_requirements")]
        public List<UpdateRegulatoryRequirement> RegulatoryRequirements { get; set; }
    }
}
