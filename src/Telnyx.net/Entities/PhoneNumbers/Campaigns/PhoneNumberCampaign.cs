using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.PhoneNumbers.Campaigns
{
    public class PhoneNumberCampaign : TelnyxEntity
    {
        /// <summary>
        /// Array of objects (Records).
        /// </summary>
        [JsonProperty("records")]
        public List<Records> Records { get; set; }
    }
}
