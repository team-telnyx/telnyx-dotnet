namespace Telnyx.net.Services.Documents.DownloadDocumet
{
    using System;
    using Newtonsoft.Json;

    public class DocumentListOptions : TelnyxEntity
    {
        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Identifies the resource.
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
        /// Identifies the associated document.
        /// </summary>
        [JsonProperty("document_id")]
        public Guid DocumentId { get; set; }

        /// <summary>
        /// The linked resource's record type.
        /// </summary>
        [JsonProperty("linked_record_type")]
        public string LinkedRecordType { get; set; }

        /// <summary>
        /// Identifies the linked resource.
        /// </summary>
        [JsonProperty("linked_resource_id")]
        public Guid LinkedResourceId { get; set; }
    }
}
