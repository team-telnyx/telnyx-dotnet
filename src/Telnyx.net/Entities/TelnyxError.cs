namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// Telnyx Error: For regular API errors
    /// </summary>
    public class TelnyxError : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets charge Id
        /// </summary>
        [JsonProperty("charge")]
        public string ChargeId { get; set; }

        /// <summary>
        /// Gets or sets code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets decline code
        /// </summary>
        [JsonProperty("decline_code")]
        public string DeclineCode { get; set; }

        /// <summary>
        /// Gets or sets message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets parameter
        /// </summary>
        [JsonProperty("param")]
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets error type
        /// </summary>
        [JsonProperty("type")]
        public string ErrorType { get; set; }

        /// <summary>
        /// Gets or sets OAuth Error
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets OAuth Error Description
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets or sets error title
        /// </summary>
        [JsonProperty("title")]
        public string ErrorTitle { get; set; }

        /// <summary>
        /// Gets or sets error detail
        /// </summary>
        [JsonProperty("detail")]
        public string ErrorDetail { get; set; }

        /// <summary>
        /// Gets or sets Request URI
        /// </summary>
        public string RequestUri { get; set; }
    }
}
