using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Services.BulkCredentials
{
    public class BulkCredentialsOptions : ListOptions
    {
        [JsonProperty("filter[tag]")]
        public string Filter { get; set; }
    }
}
