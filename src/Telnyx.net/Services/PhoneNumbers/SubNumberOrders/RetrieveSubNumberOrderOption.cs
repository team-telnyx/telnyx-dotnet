namespace Telnyx.net.Services.PhoneNumbers.SubNumberOrders
{
    using Newtonsoft.Json;

    public class RetrieveSubNumberOrderOption : BaseOptions
    {
        [JsonProperty("filter[include_phone_numbers]")]
        public bool IncludePhoneNumbers { get; set; } = false;
    }
}
