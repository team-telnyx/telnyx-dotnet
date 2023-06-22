using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Telnyx.net.Entities.Enum.AuthenticationProviders;
using Telnyx.net.Services.PhoneNumbers.Orders.Comments;

namespace Telnyx.net.Entities.AuthenticationProviders
{
    public class AuthenticationProviderListOption : ListOptions
    {
        [JsonProperty("sort")]
        public Sort Sort { get; set; } = Sort.Name;
    }
}
