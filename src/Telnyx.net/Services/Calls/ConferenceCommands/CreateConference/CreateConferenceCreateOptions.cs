namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CreateConferenceCreateOptions
    /// </summary>
    public class CreateConferenceCreateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets unique identifier and token for controlling the call
        /// </summary>
        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id"
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("command_id")]
        public Guid? CommandId { get; set; }

        /// <summary>
        /// Gets or sets specifies behavior after the bridge ends (i.e. the opposite leg either hangs up or is transferred). If supplied with the value 'self', the current leg will be parked after unbridge. If not set, the default behavior is to hang up the leg.
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}