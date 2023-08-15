namespace Telnyx.net.Services.Documents
{
    using Newtonsoft.Json;

    public class DocumentCreateOptions : BaseOptions
    {
        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }
    }
}
