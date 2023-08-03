namespace Telnyx.net.Entities.Faxes.Webhooks
{
    using Newtonsoft.Json;

    public class FaxWebhook : FaxBase
    {
        /// <summary>
        /// The URL to the PDF used for the fax's media.
        /// </summary>
        [JsonProperty("original_media_url")]
        public string OriginalMediaUrl { get; set; }
    }
}
