namespace Telnyx.net.Entities.PhoneNumbers.Coverage
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PhoneNumberCoverageOptions : BaseOptions
    {
        //List of phone numbers to check phone numbers
        [JsonProperty("phone_numbers")]
        public List<PhoneNumberEntry> PhoneNumbers { get; set; }
    }
}
