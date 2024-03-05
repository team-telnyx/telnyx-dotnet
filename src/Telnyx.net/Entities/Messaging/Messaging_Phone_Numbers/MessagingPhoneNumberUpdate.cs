namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Messaging Phone Number Update.
    /// </summary>
    public class MessagingPhoneNumberUpdate : BaseOptions
    {
        /// <summary>
        /// Gets or sets unique identifier for a messaging profile.
        /// </summary>
        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }
    }
}
