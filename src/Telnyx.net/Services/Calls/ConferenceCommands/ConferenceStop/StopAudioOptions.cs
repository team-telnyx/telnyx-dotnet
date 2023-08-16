namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferenceStop
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class StopAudioOptions : BaseOptions
    {
        /// <summary>
        /// List of call control ids identifying participants the audio file should stop be played to. If not given, the audio will be stoped to the entire conference.
        /// </summary>
        [JsonProperty("call_control_ids")]
        public IEnumerable<string> CallControlIds { get; set; }
    }
}
