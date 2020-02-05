namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlSpeakCreateOptions
    /// </summary>
    public class CallControlSpeakCreateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets the text or SSML to be converted into speech. There is a 5,000 character limit.
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets when specified, it stops the current audio being played. Specify current to stop the current audio being played, and to play the next file in the queue. Specify all to stop the current audio file being played and to also clear all audio files from the queue.
        /// </summary>
        [JsonProperty("stop")]
        public string Stop { get; set; }

        /// <summary>
        /// Gets or sets the type of the provided payload. The payload can either be plain text, or Speech Synthesis Markup Language (SSML).
        /// </summary>
        [JsonProperty("payload_type")]
        public string PayloadType { get; set; }

        /// <summary>
        /// Gets or sets this parameter impacts speech quality, language options and payload types. When using basic, only the en-US language and payload type text are allowed.
        /// </summary>
        [JsonProperty("service_level")]
        public string ServiceLevel { get; set; }

        /// <summary>
        /// Gets or sets the gender of the voice used to speak back the text.
        /// </summary>
        [JsonProperty("voice")]
        public string Voice { get; set; }

        /// <summary>
        /// Gets or sets the language you want spoken.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("command_id")]
        public Guid CommandId { get; set; }
    }
}