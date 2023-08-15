namespace Telnyx.net.Entities.PhoneNumbers.NumberBackgroundJobs
{
    using Newtonsoft.Json;

    public class PhoneNumbersJobSuccessfulOperation
    {
        /// <summary>
        /// The phone number's ID.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The phone number in e164 format.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
