using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.DynamicEmergencyAddresses;

namespace Telnyx.net.Services.DynamicEmergencyAddresses
{
    public class DynamicEmergencyAddressListOptions : ListOptions
    {
        /// <summary>
        /// Gets or sets the filter status.
        /// </summary>
        [JsonProperty("filter[status]")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusFilter FilterStatus { get; set; }

        /// <summary>
        /// Gets or sets the filter country code.
        /// </summary>
        [JsonProperty("filter[country_code]")]
        public string FilterCountryCode { get; set; }
    }
}
