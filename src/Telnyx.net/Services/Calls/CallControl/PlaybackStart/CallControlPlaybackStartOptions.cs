namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlPlaybackStartCreateOptions.
    /// </summary>
    public class CallControlPlaybackStartOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets when enabled, audio will be mixed on top of any other audio that is actively being played back. Note that overlay: true will only work if there is another audio file already being played on the.
        /// </summary>
        [JsonProperty("audio_url")]
        public string AudioUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether when enabled, audio will be mixed on top of any other audio that is actively being played back. Note that overlay: true will only work if there is another audio file already being played on the.
        /// </summary>
        [JsonProperty("overlay")]
        public bool Overlay { get; set; }

        /// <summary>
        /// Gets or sets the number of times the audio file should be played. If supplied, the value must be an integer between 1 and 100, or the special string infinity for an endless loop.
        /// </summary>
        [JsonProperty("loop")]
        public string Loop { get; set; }

        /// <summary>
        /// Gets or sets when specified, it stops the current audio being played.Specify current to stop the current audio being played, and to play the next file in the queue. Specify all to stop the current audio file being played and to also clear all audio files from the queue.
        /// </summary>
        [JsonProperty("stop")]
        public string Stop { get; set; }

        /// <summary>
        /// Gets or sets specifies the leg or legs on which audio will be played. If supplied, the value must be either self, opposite or both.
        /// </summary>
        [JsonProperty("target_legs")]
        public string TargetLegs { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901".</value>
        [JsonProperty("command_id")]
        public Guid CommandId { get; set; }
    }
}