using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.ShortCode
{
    public class UpsertShortCode : BaseOptions
    {
        [JsonProperty("messaging_profile_id")]
        public string MessagingProfileId { get; set; }
    }
}
