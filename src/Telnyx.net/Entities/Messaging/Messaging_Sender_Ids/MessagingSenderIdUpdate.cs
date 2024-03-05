namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Messaging Sender Id Update.
    /// </summary>
    public class MessagingSenderIdUpdate : BaseOptions
    {
        /// <summary>
        /// Gets or sets unique identifier for a messaging profile.
        /// </summary>
        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }
    }
}
