using Newtonsoft.Json;

namespace Telnyx.net.Services.Calls.CallControl.RecordActions
{
    public class RecordStartOptions : RecordActionOptions
    {
        /// <summary>
        /// When `dual`, final audio file will be stereo recorded with the first leg on channel A, and the rest on channel B.
        /// <para>Example: "dual"</para>
        /// <para>Options: ["single", "dual"]</para>
        /// </summary>
        [JsonProperty("channels")]
        public string Channels { get; set; }

        /// <summary>
        /// The audio file format used when storing the call recording. Can be either `mp3` or `wav`.
        /// <para>Example: "mp3"</para>
        /// <para>Options: ["mp3", "wav"]</para>
        /// </summary>
        [JsonProperty("format")]
        public string Formap { get; set; }

        /// <summary>
        /// If enabled, a beep sound will be played at the start of a recording.
        /// </summary>
        [JsonProperty("play_beep")]
        public bool PlayBeep { get; set; }

    }
}
