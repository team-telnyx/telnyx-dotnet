namespace Telnyx.net.Services.MediaStorages
{
    using Newtonsoft.Json;

    public class MediaStorageListOptions : ListOptions
    {
        /// <summary>
        /// Filters files by given content types.
        /// </summary>
        [JsonProperty("filter[content_type][]")]
        public string ContentType { get; set; }
    }
}
