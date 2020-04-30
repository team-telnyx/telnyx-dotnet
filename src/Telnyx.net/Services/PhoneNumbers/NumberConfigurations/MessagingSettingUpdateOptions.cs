using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    public class MessagingSettingUpdateOptions : BaseOptions
    {
        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; set; }

        [JsonProperty("messaging_profile_id")]
        public Guid MessagingProfileId { get; set; }
    }
}
