namespace Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DeleteABatchOfNumbersOptions : BaseOptions
    {

        /// <summary>
        /// The array of phone numbers in e164 format.
        /// </summary>
        [JsonProperty("phone_numbers")]
        public List<string> PhoneNumber { get; set; }
    }
}
