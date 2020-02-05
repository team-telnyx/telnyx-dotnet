namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlRecordStopCreateOptions
    /// </summary>
    public class CallControlRecordStopCreateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("command_id")]
        public Guid CommandId { get; set; }
    }
}