namespace Telnyx.net.Services.NumberPortouts
{
    using Newtonsoft.Json;

    public class CreateCommentsForAPortoutRequestOptions : BaseOptions
    {
        /// <summary>
        /// Comment to post on this portout request.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
