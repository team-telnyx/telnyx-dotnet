namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlTransferCreateOptions
    /// </summary>
    public class CallControlTransferCreateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("audio_url")]
        public string AudioUrl { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("timeout_secs")]
        public int TimeoutSecs { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("time_limit_secs")]
        public int TimeLimitSecs { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("answering_machine_detection")]
        public bool AnsweringMachineDetection { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("command_id")]
        public Guid CommandId { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("sip_auth_username")]
        public string SipAuthUsername { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("sip_auth_password")]
        public string SipAuthPassword { get; set; }
    }
}