namespace Telnyx.net.Entities.PhoneNumbers.Coverage
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the details of phone number coverage.
    /// </summary>
    public class PhoneNumberCoverage : TelnyxEntity
    {
        /// <summary>
        /// List of phone number details to check phone numbers on.
        /// </summary>
        [JsonProperty("phone_numbers")]
        public List<PhoneNumberDetail> PhoneNumbers { get; set; }
    }


}
