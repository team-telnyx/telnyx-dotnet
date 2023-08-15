namespace Telnyx.net.Services.Calls.Models
{
    using Newtonsoft.Json;

    public class AnsweringMachineDetectionConfig
    {
        /// <summary>
        /// Silence duration threshold after a greeting message or voice for it be considered human.
        /// Default: 800
        /// Example: 1000.
        /// </summary>
        [JsonProperty("after_greeting_silence_millis")]
        public int AfterGreetingSilenceMiilis { get; set; } = 800;

        /// <summary>
        /// Maximum threshold for silence between words.
        /// Default: 50
        /// Example: 100
        /// ///. </summary>
        [JsonProperty("between_words_silence_millis")]
        public int BetweenWordsSilenceMiilis { get; set; } = 50;

        /// <summary>
        /// Maximum threshold of a human greeting. If greeting longer than this value, considered machine.
        /// Default: 3500.
        /// </summary>
        [JsonProperty("greeting_duration_millis")]
        public int GreetingDurationMiilis { get; set; } = 3500;

        /// <summary>
        /// If machine already detected, maximum threshold for silence between words.If exceeded, the greeting is considered ended.
        /// Default: 1500.
        /// </summary>
        [JsonProperty("greeting_silence_duration_millis")]
        public int GreetingSilenceMiilis { get; set; } = 1500;

        /// <summary>
        /// If machine already detected, maximum timeout threshold to determine the end of the machine greeting. Default: 5000.
        /// </summary>
        [JsonProperty("greeting_total_analysis_time_millis")]
        public int GreetingTotalAnalysisTimeMillis { get; set; } = 5000;

        /// <summary>
        /// If initial silence duration is greater than this value, consider it a machine.Default: 3500.
        /// </summary>
        [JsonProperty("initial_silence_millis")]
        public int InitialSilenceMiilis { get; set; } = 3500;

        /// <summary>
        /// If number of detected words is greater than this value, consder it a machine. Default: 5.
        /// </summary>
        [JsonProperty("maximum_number_of_words")]
        public int MaximumNumOfWords { get; set; } = 5;

        /// <summary>
        /// If a single word lasts longer than this threshold, consider it a machine. Default: 3500.
        /// </summary>
        [JsonProperty("maximum_word_length_millis")]
        public int MaximumWordLengthMillis { get; set; } = 3500;

        /// <summary>
        /// Minimum noise threshold for any analysis. Default: 256.
        /// </summary>
        [JsonProperty("silence_threshold")]
        public int SilenceThreshold { get; set; } = 256;

        /// <summary>
        /// Maximum timeout threshold for overall detection. Default: 3500.
        /// </summary>
        [JsonProperty("total_analysis_time_millis")]
        public int TotalAnalysisTimeMillis { get; set; } = 3500;
    }
}
