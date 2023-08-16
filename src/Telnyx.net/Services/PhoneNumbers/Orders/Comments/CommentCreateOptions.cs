namespace Telnyx.net.Services.PhoneNumbers.Orders.Comments
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Telnyx.net.Entities.Enum.PhoneNumbers.Orders.Comments;

    public class CommentCreateOptions : BaseOptions
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("comment_record_id")]
        public string CommentRecordId { get; set; }

        [JsonProperty("comment_record_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommentRecordType CommentRecordType { get; set; }
    }
}
