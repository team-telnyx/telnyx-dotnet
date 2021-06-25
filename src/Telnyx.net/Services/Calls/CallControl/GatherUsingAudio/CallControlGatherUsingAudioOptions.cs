namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlGatherUsingAudioCreateOptions.
    /// </summary>
    public class CallControlGatherUsingAudioOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets the URL of a file to be played back at the beginning of each prompt. The URL can point to either a WAV or MP3 file.
        /// </summary>
        [JsonProperty("audio_url")]
        public string AudioUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL of a file to play when digits don't match the valid_digits parameter or the number of digits is not between min and max. The URL can point to either a WAV or MP3 file.
        /// </summary>
        [JsonProperty("invalid_audio_url")]
        public string InvalidAudioUrl { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of times the file should be played if there is no input from the user on the call.
        /// </summary>
        [JsonProperty("maximum_tries")]
        public int MaximumTries { get; set; }

        /// <summary>
        /// Gets or sets the number of milliseconds to wait for a DTMF response after file playback ends before a replaying the sound file.
        /// </summary>
        [JsonProperty("timeout_millis")]
        public int TimeoutMillis { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of digits to fetch. This parameter has a minimum value of 1.
        /// </summary>
        [JsonProperty("minimum_digits")]
        public int MinimumDigits { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of digits to fetch. This parameter has a maximum value of 128.
        /// </summary>
        [JsonProperty("maximum_digits")]
        public int MaximumDigits { get; set; }

        /// <summary>
        /// Gets or sets the digit used to terminate input if fewer than maximum_digits digits have been gathered.
        /// </summary>
        [JsonProperty("terminating_digit")]
        public string TerminatingDigit { get; set; }

        /// <summary>
        /// Gets or sets a list of all digits accepted as valid.
        /// </summary>
        [JsonProperty("valid_digits")]
        public string ValidDigits { get; set; }

        /// <summary>
        /// Gets or sets the number of milliseconds to wait for input between digits.
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901".</value>
        [JsonProperty("inter_digit_timeout_millis")]
        public int InterDigitTimeoutMillis { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901".</value>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same command_id.
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901".</value>
        [JsonProperty("command_id")]
        public Guid? CommandId { get; set; }
    }
}