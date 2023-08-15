namespace Telnyx.net.Entities.NumberOrderDocuments
{
    using Newtonsoft.Json;

    public class NumberOrderDocumentCreateOptions : BaseOptions
    {
        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("requirements_id")]
        public string RequirementsId { get; set; }
    }
}
