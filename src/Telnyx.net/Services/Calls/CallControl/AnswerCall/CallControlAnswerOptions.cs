namespace Telnyx
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    /// <summary>
    /// CallControlAnswerCreateOptions.
    /// </summary>
    public class CallControlAnswerOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901".</value>
        [JsonProperty("command_id")]
        public Guid? CommandId { get; set; }

        /// <summary>Use this field to override the URL for which Telnyx will send subsequent webhooks to for this call.</summary>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>HTTP request type used for `webhook_url`.</summary>
        [JsonProperty("webhook_url_method")]
        public WebhookUrlMethods WebhookUrlMethod { get; set; } = WebhookUrlMethods.POST;
    }
}