using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.Orders.OrderDocuments
{
    public class NumberOrderDocument : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("requirements_id")]
        public string RequirementsId { get; set; }

        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        [JsonProperty("requirement_type")]
        public string RequirementType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
