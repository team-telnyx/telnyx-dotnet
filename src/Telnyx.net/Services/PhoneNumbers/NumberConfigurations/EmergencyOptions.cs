using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    public class EmergencyOptions : BaseOptions
    {
        [JsonProperty("emergency_address_id")]
        public string EmergencyAddressId { get; set; }

        [JsonProperty("emergency_enabled")]
        public bool EmergencyEnabled { get; set; }
    }
}
