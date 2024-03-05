using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.SimCards
{
    public class UpsertSIMCardNetworkPreference : BaseOptions
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
