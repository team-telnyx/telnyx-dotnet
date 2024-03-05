namespace Telnyx.net.Entities.Faxes.Webhooks
{
    using Newtonsoft.Json;

    public class FaxFailedWebhook : FaxWebhook
    {
        /// <summary>
        /// Reason fax failed to send.
        /// </summary>
        [JsonProperty("failure_reason")]
        public string FailureReason { get; set; }
    }
}
