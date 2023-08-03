namespace Telnyx.net.Services.NumberPortouts
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Telnyx.net.Entities.Enum.NumberPortouts;

    public class ListPortoutRequestOptions : ListOptions
    {
        [JsonProperty("filter[carrier_name]")]
        public string CarrierName { get; set; }

        [JsonProperty("filter[spid]")]
        public string Spid { get; set; }

        [JsonProperty("filter[status]")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PortoutStatus Status { get; set; }
    }
}
