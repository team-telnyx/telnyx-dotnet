using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.NumberOrderDocuments
{
    public class NumberOrderDocumentListOptions : ListOptions
    {
        [JsonProperty("filter[requirement_id]")]
        public string RequirementId { get; set; }

        [JsonProperty("filter[created_at][gt]")]
        public string CreatedAtGreaterThan { get; set; }

        [JsonProperty("filter[created_at][lt]")]
        public string CreatedAtLessThan { get; set; }
    }
}
