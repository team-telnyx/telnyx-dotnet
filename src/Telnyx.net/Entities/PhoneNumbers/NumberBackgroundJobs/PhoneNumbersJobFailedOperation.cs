using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.PhoneNumbers.NumberBackgroundJobs
{
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
