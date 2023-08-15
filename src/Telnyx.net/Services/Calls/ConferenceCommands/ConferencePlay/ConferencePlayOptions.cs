namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferencePlay
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ConferencePlayOptions : BaseOptions
    {
        /// <summary>
        /// The URL of the file to be played back in the conference. The URL can point to either a WAV or MP3 file.
        /// <para>Example: "http://www.example.com/sounds/greeting.wav".</para>
        /// </summary>
        [JsonProperty("audio_url")]
        public string AudioURL { get; set; }

        /// <summary>
        /// List of call control ids identifying participants the audio file should be played to. If not given, the audio file will be played to the entire conference.
        /// </summary>
        [JsonProperty("call_control_ids")]
        public IEnumerable<string> CallControlIds { get; set; }

        /// <summary>
        /// The number of times the audio file should be played. If supplied, the value must be an integer between 1 and 100, or the special string `infinity` for an endless loop.
        /// <para>Default: 1. </para>
        /// <para>Example: "infinity".</para>
        /// </summary>
        [JsonProperty("loop")]
        public object Loop { get; set; } = 1;
    }
}
