namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlGatherUsingSpeakCreateOptions
    /// </summary>
    public class CallControlGatherUsingSpeakOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets the text or SSML to be converted into speech. There is a 5,000 character limit.
        /// Example: "Say this on the call"
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the text or SSML to be converted into speech when digits don't match the valid_digits parameter or the number of digits is not between min and max. There is a 5,000 character limit
        /// </summary>
        [JsonProperty("invalid_payload")]
        public string InvalidPayload { get; set; }

        /// <summary>
        /// Gets or sets the type of the provided payload. The payload can either be plain text, or Speech Synthesis Markup Language (SSML).
        /// Default: "text"
        /// </summary>
        [JsonProperty("payload_type")]
        public string PayloadType { get; set; }

        /// <summary>
        /// Gets or sets this parameter impacts speech quality, language options and payload types. When using basic, only the en-US language and payload type text are allowed.
        /// Default: "premium"
        /// </summary>
        [JsonProperty("service_level")]
        public string ServiceLevel { get; set; }

        /// <summary>
        /// Gets or sets the gender of the voice used to speak back the text.
        /// Example: "female"
        /// </summary>
        [JsonProperty("voice")]
        public string Voice { get; set; }

        /// <summary>
        /// Gets or sets the language you want spoken.
        /// Example: "en-US"
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of digits to fetch. This parameter has a minimum value of 1.
        /// Default: 1
        /// </summary>
        [JsonProperty("minimum_digits")]
        public int MinimumDigits { get; set; } = 1;

        ///// <summary>
        ///// The call control id of the call you want to bridge with.
        ///// </summary>
        // [JsonProperty("custom_headers")]
        // public IEnumerable<> { get; private set; }

        /// <summary>
        /// Gets or sets the maximum number of digits to fetch. This parameter has a maximum value of 128.
        /// Default: 128
        /// </summary>
        [JsonProperty("maximum_digits")]
        public int MaximumDigits { get; set; } = 128;

        /// <summary>
        /// Gets or sets the maximum number of times that a file should be played back if there is no input from the user on the call.
        /// Default: 128
        /// </summary>
        [JsonProperty("maximum_tries")]
        public int MaximumTries { get; set; } = 128;

        /// <summary>
        /// Gets or sets the number of milliseconds to wait for a DTMF response after speak ends before a replaying the sound file.
        /// Default: 60000
        /// </summary>
        [JsonProperty("timeout_millis")]
        public int TimeoutMillis { get; set; } = 60000;

        /// <summary>
        /// Gets or sets the digit used to terminate input if fewer than maximum_digits digits have been gathered.
        /// Default: "#"
        /// </summary>
        [JsonProperty("terminating_digit")]
        public string TerminatingDigit { get; set; }

        /// <summary>
        /// Gets or sets a list of all digits accepted as valid.
        /// Default: "0123456789#*"
        /// </summary>
        [JsonProperty("valid_digits")]
        public string ValidDigits { get; set; }

        /// <summary>
        /// Gets or sets the number of milliseconds to wait for input between digits. 
        /// Default: 5000
        /// </summary>
        [JsonProperty("inter_digit_timeout_millis")]
        public int InterDigitTimeoutMillis { get; set; } = 5000;

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same
        /// </summary>
        [JsonProperty("command_id")]
        public Guid CommandId { get; set; }
    }
}
