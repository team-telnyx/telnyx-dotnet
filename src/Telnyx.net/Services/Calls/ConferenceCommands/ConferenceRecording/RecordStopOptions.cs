namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferenceRecording
{
    using Newtonsoft.Json;

    public class RecordStopOptions : BaseOptions
    {
        /// <summary>
        /// Use this field to avoid duplicate commands. Telnyx will ignore commands with the same `command_id`.
        /// </summary>
        [JsonProperty("command_id")]
        public string CommandId { get; set; }

        /// <summary>
        /// Use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }
    }
}
