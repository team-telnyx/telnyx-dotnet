using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.PhoneNumbers.NumberBackgroundJobs;

namespace Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs
{
    public class NumberBackgroundJobListOptions : ListOptions
    {
        /// <summary>
        /// Filter the phone number jobs by type.
        /// </summary>
        [JsonProperty("type")]
        public PhoneNumberJobType Type { get; set; }

        /// <summary>
        /// Specifies the sort order for results. If not given, results are sorted by created_at in descending order.
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }
    }
}
