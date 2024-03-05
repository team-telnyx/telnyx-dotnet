using Newtonsoft.Json;
using System;

namespace Telnyx
{
    /// <summary>
    /// Represents a Comment entity.
    /// </summary>
    public class Comment : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the comment.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the body of the comment.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the commenter's name or identifier.
        /// </summary>
        [JsonProperty("commenter")]
        public string Commenter { get; set; }

        /// <summary>
        /// Gets or sets the type of the commenter.
        /// </summary>
        [JsonProperty("commenter_type")]
        public string CommenterType { get; set; }

        /// <summary>
        /// Gets or sets the record type that the comment is associated with.
        /// </summary>
        [JsonProperty("comment_record_type")]
        public string CommentRecordType { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the record the comment is associated with.
        /// </summary>
        [JsonProperty("comment_record_id")]
        public Guid CommentRecordId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the comment was read.
        /// </summary>
        [JsonProperty("read_at")]
        public DateTime? ReadAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the comment was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the comment was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
