namespace Telnyx.net.Entities.VerifyAPI
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class Verify : VerifyBase
    {
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// The possible statuses of the verify verification request.
        /// </summary>
        [JsonProperty("status")]
        public VerifyStatus Status { get; set; }

        /// <summary>
        /// This is the number of seconds before the code of the request is expired. Once this request has expired, the code will no longer verify the user. 
        /// <para>Note: this will override the `default_timeout_secs` on the verify profile.</para>
        /// </summary>
        [JsonProperty("timeout_secs")]
        public long TimeoutSecs { get; set; }

        /// <summary>
        /// The identifier of the associated verify profile.
        /// </summary>
        [JsonProperty("verify_profile_id")]
        public Guid VerifyProfileId { get; set; }

        /// <summary>
        /// The verification request type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
