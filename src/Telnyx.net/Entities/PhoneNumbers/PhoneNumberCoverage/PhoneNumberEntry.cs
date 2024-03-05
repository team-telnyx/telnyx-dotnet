namespace Telnyx.net.Entities.PhoneNumbers.Coverage
{
    using Newtonsoft.Json;

    public class PhoneNumberEntry
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
