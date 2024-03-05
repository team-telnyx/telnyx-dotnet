namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// Error source.
    /// </summary>
    public class ErrorSource
    {
        /// <summary>
        /// Gets or sets jSON pointer (RFC6901) to the offending entity.
        /// </summary>
        [JsonProperty("pointer")]
        public string Pointer { get; set; }

        /// <summary>
        /// Gets or sets indicates which query parameter caused the error.
        /// </summary>
        [JsonProperty("parameter")]
        public string Parameter { get; set; }
    }
}
