namespace Telnyx.net.Services.VerifyAPI
{
    using Newtonsoft.Json;

    public class VerifyProfileOptions : BaseOptions
    {
        /// <summary>
        /// Enables RCS messaging for the verify profile.
        /// Default: false.
        /// </summary>
        [JsonProperty("rcs_enabled")]
        public bool RcsEnabled { get; set; }

        /// <summary>
        /// Enables SMS text messaging for the Verify profile.
        /// Default: false.
        /// </summary>
        [JsonProperty("messaging_enabled")]
        public bool MessagingEnabled { get; set; }

        /// <summary>
        /// Optionally sets a messaging text template when sending the verification code. Uses `{code}` to template in the actual verification code.
        /// Example: Hello, this is the Acme Inc verification code you requested: {code}.".
        /// </summary>
        [JsonProperty("messaging_template")]
        public string MessagingTemplate { get; set; }

        /// <summary>
        /// For every request that is initiated via this verify Profile, this sets the number of seconds before a verification request code expires. Once the verification request expires, the user cannot use the code to verify their identity.
        /// Example: 300.
        /// </summary>
        [JsonProperty("default_timeout_secs")]
        public long? DefaultTimeoutSecs { get; set; }

        /// <summary>
        /// The human readable label for the verify profile.
        /// Example: "Test Profile".
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
