using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.PhoneNumbers.SubNumberOrders
{
    public class RetrieveSubNumberOrderOption : BaseOptions
    {
        [JsonProperty("filter[include_phone_numbers]")]
        public bool IncludePhoneNumbers { get; set; } = false;
    }
}
