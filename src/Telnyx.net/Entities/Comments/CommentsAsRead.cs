using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.CommentAsRead
{
    public class CommentsAsRead : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("commenter")]
        public string Commenter { get; set; }

        [JsonProperty("commenter_type")]
        public string CommenterType { get; set; }

        [JsonProperty("comment_record_type")]
        public string CommentRecordType { get; set; }

        [JsonProperty("comment_record_id")]
        public Guid CommentRecordId { get; set; }

        [JsonProperty("read_at")]
        public DateTime? ReadAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
