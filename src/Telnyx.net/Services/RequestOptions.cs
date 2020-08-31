namespace Telnyx
{
    /// <summary>
    /// RequestOptions.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// Gets or sets apiKey.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets idempotencyKey.
        /// </summary>
        public string IdempotencyKey { get; set; }

        /// <summary>
        /// Gets or sets telnyxVersion
        /// This is used specifically for Ephemeral Keys as they have to be created
        /// with a specific API version. It should not be used for anything else which
        /// is why it is set as internal.
        /// </summary>
        internal string TelnyxVersion { get; set; }
    }
}
