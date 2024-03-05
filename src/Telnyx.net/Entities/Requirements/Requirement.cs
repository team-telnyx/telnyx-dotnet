using System;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Requirements
{
    public class Requirement : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("phone_number_type")]
        public string PhoneNumberType { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("requirements_types")]
        public RequirementType[] RequirementsTypes { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
