namespace Telnyx.net.Services.Documents.DocumentLinks
{
    using System;
    using Newtonsoft.Json;

    public class DocumentLinkOptions : ListOptions
    {
        /// <summary>
        /// Identifies the associated document to filter on.
        /// filter[document_id]=6a09cdc3-8948-47f0-aa62-74ac943d6c58.
        /// </summary>
        [JsonProperty("filter[document_id]")]
        public Guid DocumentId { get; set; }

        /// <summary>
        /// The linked_record_type of the document to filter on.
        /// Example: filter[linked_record_type]=porting_order.
        /// </summary>
        [JsonProperty("filter[linked_record_type]")]
        public string LinkedRecordType { get; set; }

        /// <summary>
        /// Filter documents by a list of customer references.
        /// Example: filter[customer_reference][in][]=MY REF 001.
        /// </summary>
        [JsonProperty("filter[linked_resource_id]")]
        public Guid LinkedResourceId { get; set; }
    }
}
