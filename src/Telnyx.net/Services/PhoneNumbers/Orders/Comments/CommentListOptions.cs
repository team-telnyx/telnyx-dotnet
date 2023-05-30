using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.PhoneNumbers.Orders.Comments
{
    public class CommentListOptions : ListOptions
    {
        [JsonProperty("filter[comment_record_type]")]
        public string CommentRecordType { get; set; }

        [JsonProperty("filter[comment_record_id]")]
        public string CommentRecordId { get; set; }
    }
}
