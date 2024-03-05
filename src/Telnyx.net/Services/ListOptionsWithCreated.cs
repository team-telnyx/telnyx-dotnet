namespace Telnyx
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    /// <summary>
    /// ListOptionsWithCreated.
    /// </summary>
    [ExcludeFromCodeCoverage] // not referenced anywhere
    public class ListOptionsWithCreated : ListOptions
    {
        /// <summary>
        /// Gets or sets created.
        /// </summary>
        [JsonProperty("created")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets createdRange.
        /// </summary>
        [JsonProperty("created")]
        public DateRangeOptions CreatedRange { get; set; }
    }
}
