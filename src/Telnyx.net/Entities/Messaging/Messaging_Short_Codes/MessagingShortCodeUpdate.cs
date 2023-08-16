namespace Telnyx
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Messaging Short Code Update.
    /// </summary>
    public class MessagingShortCodeUpdate : BaseOptions
    {
        /// <summary>
        /// Gets or sets unique identifier for a messaging profile.
        /// </summary>
        /// <value>Unique identifier for a messaging profile.</value>
        [DataMember(Name = "messaging_profile_id")]
        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }
    }
}
