namespace Telnyx.net.Entities.VerifyAPI
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class VerifyProfile : TelnyxEntity
    {
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// For every request that is initiated via this verify Profile, this sets the number of seconds before a verification request code expires. Once the verification request expires, the user cannot use the code to verify their identity.
        /// </summary>
        [JsonProperty("default_timeout_secs")]
        public long DefaultTimeoutSecs { get; set; }

        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Enables SMS text messaging for the verify profile.
        /// </summary>
        [JsonProperty("messaging_enabled")]
        public bool MessagingEnabled { get; set; }

        /// <summary>
        /// Optionally sets a messaging text template when sending the verification code. Uses `{code}` to template in the actual verification code.
        /// </summary>
        [JsonProperty("messaging_template")]
        public string MessagingTemplate { get; set; }

        /// <summary>
        /// The name of the verify profile.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// Enables RCS messaging for the verify profile.
        /// </summary>
        [JsonProperty("rcs_enabled")]
        public bool RcsEnabled { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
