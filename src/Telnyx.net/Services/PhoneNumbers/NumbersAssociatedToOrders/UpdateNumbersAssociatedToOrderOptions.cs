namespace Telnyx.net.Services.PhoneNumbers.NumbersAssociatedToOrders
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.PhoneNumbers.NumbersAssociatedToOrders;

    public class UpdateNumbersAssociatedToOrderOptions : BaseOptions
    {
        [JsonProperty("regulatory_requirements")]
        public List<UpdateRegulatoryRequirement> RegulatoryRequirements { get; set; }
    }
}
