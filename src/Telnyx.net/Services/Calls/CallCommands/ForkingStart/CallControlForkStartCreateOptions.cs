namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlForkStartCreateOptions
    /// </summary>
    public class CallControlForkStartCreateOptions : BaseOptions
    {
        /// <summary>
        /// The network target, , where the call's RTP media packets should be forwarded. Both incoming and outgoing media packets will be delivered to the specified target, and information about the stream will be included in the encapsulation protocol header, including the direction (0 = inbound; 1 = outbound), leg (0 = A-leg; 1 = B-leg), and call_leg_id.
        /// Example: "udp:192.0.2.1:9000"
        /// </summary>
        [JsonProperty("target")]
        public string Target { get; set; }

        /// <summary>
        /// The network target, , where the call's incoming RTP media packets should be forwarded.
        /// Example: "192.0.2.1:9000"
        /// </summary>
        [JsonProperty("rx")]
        public string Rx { get; set; }

        /// <summary>
        /// The network target, , where the call's outgoing RTP media packets should be forwarded.
        /// Example: "192.0.2.1:9001"
        /// </summary>
        [JsonProperty("tx")]
        public string Tx { get; set; }

        /// <summary>
        /// Use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// Example: "aGF2ZSBhIG5pY2UgZGF5ID1d"
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Use this field to avoid duplicate commands. Telnyx will ignore commands with the same `command_id`.
        /// Example: "891510ac-f3e4-11e8-af5b-de00688a4901"
        /// </summary>
        [JsonProperty("command_id")]
        public Guid CommandId { get; set; }
    }
}