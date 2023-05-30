using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.PhoneNumbers.Orders.Comments;

namespace Telnyx.net.Services.PhoneNumbers.Orders.Comments
{
    public class CommentCreateOptions : BaseOptions
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("comment_record_id")]
        public string CommentRecordId { get; set; }

        [JsonProperty("comment_record_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CommentRecordType CommentRecordType { get; set; }
    }
}
