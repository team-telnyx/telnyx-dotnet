namespace Telnyx.net.Entities.NumberOrderDocuments
{
    using Newtonsoft.Json;

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
