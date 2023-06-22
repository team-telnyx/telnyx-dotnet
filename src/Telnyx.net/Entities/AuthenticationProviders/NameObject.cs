using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Telnyx.net.Entities.Enum.AuthenticationProviders;
using Telnyx.net.Services.PhoneNumbers.Orders.Comments;

namespace Telnyx.net.Entities.AuthenticationProviders
{
    public class NameObject
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("formatted_name")]
        public string FormattedName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }
    }
}
