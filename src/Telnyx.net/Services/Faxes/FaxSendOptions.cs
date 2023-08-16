namespace Telnyx.net.Services.Faxes
{
    using Newtonsoft.Json;

    public class FaxSendOptions : BaseOptions
    {
        /// <summary>
        /// The connection ID to send the fax with.
        /// <para>Example: "2234423".</para>
        /// </summary>
        [JsonRequired]
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// The phone number, in E.164 format, the fax will be sent from.
        /// <para>"+13125790015".</para>
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// The phone number, in E.164 format, the fax will be sent to or SIP URI.
        /// <para>"+13127367276".</para>
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// The URL to the PDF used for the fax's media.
        /// <para>Example: "http://www.example.com/fax.pdf".</para>
        /// </summary>
        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }

        /// <summary>
        /// The quality of the fax.
        /// <para>Options: normal, high, very_high.</para>
        /// </summary>
        [JsonProperty("quality")]
        public string Quality { get; set; } = "high";
    }
}
