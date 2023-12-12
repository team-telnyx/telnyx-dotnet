namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlGatherUsingSpeakCreateOptions.
    /// </summary>
    public class CallControlGatherOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets the minimum number of digits to fetch. This parameter has a minimum value of 1.
        /// Default: 1.
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
        /// Default: 128.
        /// </summary>
        [JsonProperty("maximum_digits")]
        public int MaximumDigits { get; set; } = 128;

        /// <summary>
        /// Gets or sets the number of milliseconds to wait to complete the request.
        /// Default: 60000.
        /// </summary>
        [JsonProperty("timeout_millis")]
        public int TimeoutMillis { get; set; } = 60000;

        /// <summary>
        /// Gets or sets the digit used to terminate input if fewer than maximum_digits digits have been gathered.
        /// Default: "#".
        /// </summary>
        [JsonProperty("terminating_digit")]
        public string TerminatingDigit { get; set; }

        /// <summary>
        /// Gets or sets a list of all digits accepted as valid.
        /// Default: "0123456789#*".
        /// </summary>
        [JsonProperty("valid_digits")]
        public string ValidDigits { get; set; }

        /// <summary>
        /// Gets or sets the number of milliseconds to wait for input between digits.
        /// Default: 5000.
        /// </summary>
        [JsonProperty("inter_digit_timeout_millis")]
        public int InterDigitTimeoutMillis { get; set; } = 5000;

        /// <summary>
        /// Gets or sets the number of milliseconds to wait for the first DTMF.
        /// Default: 5000.
        /// </summary>
        public int InitialTimeoutMillis { get; set; } = 5000;

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same.
        /// </summary>
        [JsonProperty("command_id")]
        public Guid? CommandId { get; set; }
    }
}
