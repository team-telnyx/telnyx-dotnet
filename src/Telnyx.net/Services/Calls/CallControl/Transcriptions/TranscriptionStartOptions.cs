using Newtonsoft.Json;
using Telnyx.net.Entities.Enum.Transcriptions;

namespace Telnyx.net.Services.Calls.CallControl.Transcriptions
{
    public class TranscriptionStartOptions : TranscriptionOptions
    {
        /// <summary>
        /// Language to use for speech recognition.
        /// <para>Default: "en".</para>
        /// <para>Options <see cref="Languages"/></para>
        /// </summary>
        [JsonProperty("language")]
        public Languages Language { get; set; } = Languages.English;
    }
}
