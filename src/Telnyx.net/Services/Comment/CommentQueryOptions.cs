using Newtonsoft.Json;

namespace Telnyx
{
    /// <summary>
    /// Options for querying comments based on record type and record ID.
    /// </summary>
    public class CommentQueryOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets the record type that the comment relates to.
        /// </summary>
        [JsonProperty("filter[comment_record_type]")]
        public string CommentRecordType { get; set; }

        /// <summary>
        /// Gets or sets the ID of the record the comments relate to.
        /// </summary>
        [JsonProperty("filter[comment_record_id]")]
        public string CommentRecordId { get; set; }
    }
}
