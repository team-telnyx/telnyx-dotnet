namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlForkStopCreateOptions
    /// </summary>
    public class CallControlForkStopOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
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