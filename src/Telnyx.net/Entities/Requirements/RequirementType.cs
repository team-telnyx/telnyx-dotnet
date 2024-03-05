using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Requirements
{
    public class RequirementType : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("acceptance_criteria")]
        public AcceptanceCriteria AcceptanceCriteria { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("example")]
        public string Example { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
    public class AcceptanceCriteria
    {
        [JsonProperty("time_limit")]
        public string TimeLimit { get; set; }

        [JsonProperty("locality_limit")]
        public string LocalityLimit { get; set; }

        [JsonProperty("acceptable_values")]
        public string[] AcceptableValues { get; set; }
    }
}
