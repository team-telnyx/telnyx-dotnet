using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Telnyx.net.Entities.Enum.AccessIPAddresses;

namespace Telnyx.net.Entities.AccessIPAddresses
{
    public class AccessIPAddressCreateOptions : BaseOptions
    {    
        /// <summary>
         /// The description.
         /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The IP address.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
    }
}
