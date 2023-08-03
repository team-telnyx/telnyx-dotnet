namespace Telnyx.net.Entities.NumberPortouts
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Telnyx.net.Entities.Enum.NumberPortouts;

    public class SupportingDocument
    {
        /// <summary>
        /// Identifies the associated document.
        /// </summary>
        [JsonProperty("document_id")]
        public string DocumentId { get; set; }

        /// <summary>
        /// Identifies the type of the document.
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType Type { get; set; }
    }
}
