using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PortingOrders.PortingOrderRequirements
{
    public class PortingOrderRequirement : TelnyxEntity
    {
        [JsonProperty("field_type")]
        public string FieldType { get; set; }

        [JsonProperty("field_value")]
        public string FieldValue { get; set; }

        [JsonProperty("requirement_type")]
        public RequirementTypeModel RequirementType { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("requirement_status")]
        public string RequirementStatus { get; set; }
    }

    public class RequirementTypeModel
    {
        [JsonProperty("acceptance_criteria")]
        public string AcceptanceCriteria { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("example")]
        public string Example { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
