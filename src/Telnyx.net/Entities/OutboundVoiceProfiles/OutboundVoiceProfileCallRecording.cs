namespace Telnyx.net.Entities.OutboundVoiceProfiles
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class OutboundVoiceProfileCallRecording
    {
        /// <summary>
        /// Specifies which calls are recorded.
        /// </summary>
        [JsonProperty("call_recording_type")]
        public string CallRecordingType { get; set; }

        /// <summary>
        /// When call_recording_type is &#x27;by_caller_phone_number&#x27;, only outbound calls using one of these numbers will be recorded. Numbers must be specified in E164 format.
        /// </summary>
        [JsonProperty("call_recording_caller_phone_numbers")]
        public List<string> CallRecordingCallerPhoneNumbers { get; set; }

        /// <summary>
        /// When using &#x27;dual&#x27; channels, the final audio file will be a stereo recording with the first leg on channel A, and the rest on channel B.
        /// </summary>
        [JsonProperty("call_recording_channels")]
        public string CallRecordingChannels { get; set; }

        /// <summary>
        /// The audio file format for calls being recorded.
        /// </summary>
        [JsonProperty("call_recording_format")]
        public string CallRecordingFormat { get; set; }
    }
}
