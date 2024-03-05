using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.CommentAsRead
{
    public class UpsertCommentAsRead : BaseOptions
    {
        [JsonProperty("id")]
        public string Id { get; set; }

    }
}
