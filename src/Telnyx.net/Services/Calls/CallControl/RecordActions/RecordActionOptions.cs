namespace Telnyx.net.Services.Calls.CallControl.RecordActions
{
    using System;
    using Newtonsoft.Json;

    public class RecordActionOptions : BaseOptions
    {
        /// <summary>
        /// Use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// Example: "aGF2ZSBhIG5pY2UgZGF5ID1d".
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Use this field to avoid duplicate commands. Telnyx will ignore commands with the same `command_id`.
        /// Example: "891510ac-f3e4-11e8-af5b-de00688a4901".
        /// </summary>
        [JsonProperty("command_id")]
        public Guid? CommandId { get; set; }
    }
}
