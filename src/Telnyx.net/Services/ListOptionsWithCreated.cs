namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// ListOptionsWithCreated
    /// </summary>
    public class ListOptionsWithCreated : ListOptions
    {
        /// <summary>
        /// Gets or sets created
        /// </summary>
        [JsonProperty("created")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets createdRange
        /// </summary>
        [JsonProperty("created")]
        public DateRangeOptions CreatedRange { get; set; }
    }
}
