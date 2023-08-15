namespace Telnyx.net.Entities.MediaStorages
{
    using Newtonsoft.Json;

    public class MediaStorage : TelnyxEntity
    {
        /// <summary>
        /// Content type of the file.
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        /// <summary>
        /// ISO 8601 formatted date of when the media resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ISO 8601 formatted date of when the media resource will expire and be deleted.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }

        /// <summary>
        /// Uniquely identifies a media resource.
        /// </summary>
        [JsonProperty("media_name")]
        public string MediaName { get; set; }

        /// <summary>
        /// ISO 8601 formatted date of when the media resource was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
