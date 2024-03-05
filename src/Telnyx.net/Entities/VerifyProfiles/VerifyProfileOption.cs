using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.VerifyProfiles
{
    public class VerifyProfileOption : ListOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
