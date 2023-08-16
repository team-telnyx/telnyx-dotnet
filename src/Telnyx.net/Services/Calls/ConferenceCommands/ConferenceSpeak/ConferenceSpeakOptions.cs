namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferenceSpeak
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ConferenceSpeakOptions : BaseOptions
    {
        /// <summary>
        /// The language used to speak the text.
        /// <para>Example: "en-US".</para>
        /// <para>
        /// Options: [
        ///  "arb",
        ///  "cmn-CN",
        ///  "cy-GB",
        ///  "da-DK",
        ///  "de-DE",
        ///  "en-AU",
        ///  "en-GB",
        ///  "en-GB-WLS",
        ///  "en-IN",
        ///  "en-US",
        ///  "es-ES",
        ///  "es-MX",
        ///  "es-US",
        ///  "fr-CA",
        ///  "fr-FR",
        ///  "hi-IN",
        ///  "is-IS",
        ///  "it-IT",
        ///  "ja-JP",
        ///  "ko-KR",
        ///  "nb-NO",
        ///  "nl-NL",
        ///  "pl-PL",
        ///  "pt-BR",
        ///  "pt-PT",
        ///  "ro-RO",
        ///  "ru-RU",
        ///  "sv-SE",
        ///  "tr-TR"
        /// ]. </para>
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// The text or SSML to be converted into speech. There is a 5,000 character limit.
        /// <para>Example: "Say this to participants".</para>
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }

        /// <summary>
        /// The gender of the voice used to speak the text.
        /// <para>Options: [
        ///  "male",
        ///  "female"
        ///]. </para>
        /// </summary>
        [JsonProperty("voice")]
        public string Voice { get; set; }

        /// <summary>
        /// Call Control IDs of participants who will hear the spoken text. When empty all participants will hear the spoken text.
        /// </summary>
        [JsonProperty("call_control_ids")]
        public IEnumerable<string> CallControlIds { get; set; }

        /// <summary>
        /// Use this field to avoid execution of duplicate commands. Telnyx will ignore subsequent commands with the same `command_id` as one that has already been executed.
        /// </summary>
        [JsonProperty("command_id")]
        public string CommandId { get; set; }

        /// <summary>
        /// The type of the provided payload. The payload can either be plain text, or Speech Synthesis Markup Language (SSML).
        /// <para>[
        ///   "text",
        ///   "ssml"
        /// ]. </para>
        /// </summary>
        [JsonProperty("payload_type")]
        public string PayloadType { get; set; }
    }
}
