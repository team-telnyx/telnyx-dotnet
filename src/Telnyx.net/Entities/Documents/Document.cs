namespace Telnyx.net.Entities.Documents
{
    using System;
    using Newtonsoft.Json;

    public class Document : TelnyxEntity
    {
        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Identifies the resourceDocumentLink.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// The document's content_type.
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        /// <summary>
        /// Optional reference string for customer tracking.
        /// </summary>
        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// The filename of the document.
        /// </summary>
        [JsonProperty("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// The document's SHA256 hash provided for optional verification purposes.
        /// </summary>
        [JsonProperty("sha256")]
        public string Sha256 { get; set; }

        /// <summary>
        /// Indicates the document's filesize.
        /// </summary>
        [JsonProperty("size")]
        public DocumentSize Size { get; set; }

        /// <summary>
        /// Indicates the current document reviewing status.
        /// Enum: "pending" "verified" "denied".
        /// </summary>
        [JsonProperty("status")]
        public DocumentStatus Status { get; set; }

        public object url { get; internal set; }
    }
}
