namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlSendDTMFCreateOptions
    /// </summary>
    public class CallControlSendDTMFOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets specifies for how many milliseconds each digit will be played in the audio stream.Ranges from 100 to 500ms
        /// </summary>
        [JsonProperty("duration_millis")]
        public int DurationMillis { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("command_id")]
        public Guid CommandId { get; set; }

        /// <summary>
        /// Gets or sets dTMF digits to send. Valid digits are 0-9, A-D, *, and #. Pauses can be added using w (0.5s) and W (1s).
        /// </summary>
        [JsonProperty("digits")]
        public string Digits { get; set; }
    }
}