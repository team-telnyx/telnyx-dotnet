namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlRecordStopCreateOptions.
    /// </summary>
    public class CallControlRecordStopOptions : BaseOptions
    {
        /// <summary>
        /// Use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Use this field to avoid duplicate commands. Telnyx will ignore commands with the same `command_id`.
        /// </summary>
        [JsonProperty("command_id")]
        public Guid CommandId { get; set; }
    }
}
