namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    using Newtonsoft.Json;

    public class EmergencyOptions : BaseOptions
    {
        [JsonProperty("emergency_address_id")]
        public string EmergencyAddressId { get; set; }

        [JsonProperty("emergency_enabled")]
        public bool EmergencyEnabled { get; set; }
    }
}
