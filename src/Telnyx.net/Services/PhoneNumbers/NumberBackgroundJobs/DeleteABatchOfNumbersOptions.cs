using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs
{
    public class DeleteABatchOfNumbersOptions : BaseOptions
    {

        /// <summary>
        /// The array of phone numbers in e164 format.
        /// </summary>
        [JsonProperty("phone_number")]
        public List<string> PhoneNumber { get; set; }
    }
}
