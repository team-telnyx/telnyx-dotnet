namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferenceRecording
{
    using Newtonsoft.Json;

    public class RecordStartOptions : BaseOptions
    {
        /// <summary>
        /// When `dual`, final audio file will be stereo recorded with the first leg on channel A, and the rest on channel B.
        /// <para>Example: "single". </para>
        /// <para> Options: [
        ///  "single",
        ///  "dual"
        /// ]. </para>
        /// </summary>
        [JsonProperty("channels")]
        public string Channels { get; set; }

        /// <summary>
        /// The audio file format used when storing the call recording. Can be either `mp3` or `wav`.
        /// Example: "mp3".
        ///<para> Options: [
        ///          "wav",
        ///          "mp3"]. </para>
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// If enabled, a beep sound will be played at the start of a recording.
        /// <para>Example: true.</para>
        /// </summary>
        [JsonProperty("play_beep")]
        public bool PlayBeep { get; set; }

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
