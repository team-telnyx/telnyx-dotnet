namespace Telnyx.net.Services.Documents
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.Documents;

    public class DocumentListOptions : ListOptions
    {
        /// <summary>
        /// Filter by string matching part of filename.
        /// Example: filter[filename][contains]=invoice.
        /// </summary>
        [JsonProperty("filter[filename][contains]")]
        public string FilenameContains { get; set; }

        /// <summary>
        /// Filter documents by a customer reference.
        /// Example: filter[customer_reference][eq]=MY REF 001.
        /// </summary>
        [JsonProperty("filter[customer_reference][eq]")]
        public string CustomerReferenceEquals { get; set; }

        /// <summary>
        /// Filter documents by a list of customer references.
        /// Example: filter[customer_reference][in][]=MY REF 001.
        /// </summary>
        [JsonProperty("filter[customer_reference][in][]")]
        public List<string> CustomerReferencesIn { get; set; }

        /// <summary>
        /// Filter by created at greater than provided value.
        /// Example: filter[created_at][gt]=2021-04-09T22:25:27.521Z.
        /// </summary>
        [JsonProperty("filter[created_at][gt]")]
        public string CreatedAtGreaterThan { get; set; }

        /// <summary>
        /// Filter by created at less than provided value.
        /// Example: filter[created_at][lt]=2021-04-09T22:25:27.521Z.
        /// </summary>
        [JsonProperty("filter[created_at][lt]")]
        public string CreatedAtLessThan { get; set; }

        /// <summary>
        /// Specifies the sort order for results. If you want to sort by a field in ascending order, include it as a sort parameter. If you want to sort in descending order, prepend a - in front of the field name.
        /// Enum: "filename" "created_at" "updated_at"
        /// Example: sort[]=filename.
        /// </summary>
        [JsonProperty("sort[]")]
        public DocumentSort? Sort { get; set; }
    }
}
