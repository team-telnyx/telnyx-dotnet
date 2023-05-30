using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.DynamicEmergencyEndpoints
{
    public class DynamicEmergencyEndpointOptions : BaseOptions
    {
        /// <summary>
        /// The callback number.
        /// </summary>
        [JsonProperty("callback_number")]
        public string CallbackNumber { get; set; }

        /// <summary>
        /// The caller name.
        /// </summary>
        [JsonProperty("caller_name")]
        public string CallerName { get; set; }

        /// <summary>
        /// An id of a currently active dynamic emergency location.
        /// </summary>
        [JsonProperty("dynamic_emergency_address_id")]
        public string DynamicEmergencyAddressId { get; set; }
    }
}
