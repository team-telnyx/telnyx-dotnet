namespace Telnyx
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    /// <summary>
    /// DateRangeOptions.
    /// </summary>
    [ExcludeFromCodeCoverage] // only used in class TestOptions which is not referenced anywhere
    public class DateRangeOptions : INestedOptions
    {
        /// <summary>
        /// Gets or sets greaterThan.
        /// </summary>
        [JsonProperty("gt")]
        public DateTime? GreaterThan { get; set; }

        /// <summary>
        /// Gets or sets greaterThanOrEqual.
        /// </summary>
        [JsonProperty("gte")]
        public DateTime? GreaterThanOrEqual { get; set; }

        /// <summary>
        /// Gets or sets lessThan.
        /// </summary>
        [JsonProperty("lt")]
        public DateTime? LessThan { get; set; }

        /// <summary>
        /// Gets or sets lessThanOrEqual.
        /// </summary>
        [JsonProperty("lte")]
        public DateTime? LessThanOrEqual { get; set; }
    }
}
