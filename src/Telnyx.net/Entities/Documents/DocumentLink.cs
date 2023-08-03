namespace Telnyx.net.Entities.Documents
{
    using System;
    using Newtonsoft.Json;

    public class DocumentLink : TelnyxEntity
    {
        /// <summary>
        /// Identifies the associated document to filter on.
        /// Example: filter[document_id]=6a09cdc3-8948-47f0-aa62-74ac943d6c58.
        /// </summary>
        [JsonProperty("filter[document_id]")]
        public Guid? DocumentId { get; set; }

        /// <summary>
        /// The linked_record_type of the document to filter on.
        /// Example: filter[linked_record_type]=porting_order.
        /// </summary>
        [JsonProperty("filter[linked_record_type]")]
        public string LinkedRecordType { get; set; }

        /// <summary>
        /// The linked_resource_id of the document to filter on.
        /// Example: filter[linked_resource_id]=6a09cdc3-8948-47f0-aa62-74ac943d6c58.
        /// </summary>
        [JsonProperty("filter[linked_resource_id]")]
        public Guid? LinkedResourceId { get; set; }
    }
}