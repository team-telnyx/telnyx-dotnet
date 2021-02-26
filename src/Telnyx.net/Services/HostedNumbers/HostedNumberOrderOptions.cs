using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Services.HostedNumbers
{
    public class HostedNumberOrderOptions : BaseOptions
    {
        /// <summary>
        /// Automatically associate the number with this messaging profile ID when the order is complete.
        /// </summary>
        [JsonProperty("messaging_profile_id")]
        public string MessagingProfileId { get; set; }

        /// <summary>
        /// Phone numbers to be used for hosted messaging.
        /// </summary>
        [JsonProperty("phone_numbers")]
        public IEnumerable<string> PhoneNumbers { get; set; }
    }
}
