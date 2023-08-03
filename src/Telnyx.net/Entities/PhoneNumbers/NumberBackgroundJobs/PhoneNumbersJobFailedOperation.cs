namespace Telnyx.net.Entities.PhoneNumbers.NumberBackgroundJobs
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PhoneNumbersJobFailedOperation
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

        /// <summary>
        /// An array of error objects.
        /// </summary>
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }
}
