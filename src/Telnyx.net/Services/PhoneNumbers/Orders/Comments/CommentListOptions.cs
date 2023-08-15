namespace Telnyx.net.Services.PhoneNumbers.Orders.Comments
{
    using Newtonsoft.Json;

    public class CommentListOptions : ListOptions
    {
        [JsonProperty("filter[comment_record_type]")]
        public string CommentRecordType { get; set; }

        [JsonProperty("filter[comment_record_id]")]
        public string CommentRecordId { get; set; }
    }
}
