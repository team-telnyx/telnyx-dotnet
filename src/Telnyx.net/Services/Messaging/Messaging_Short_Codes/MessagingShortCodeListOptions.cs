namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// MessagingShortCodeListOptions.
    /// </summary>
    public class MessagingShortCodeListOptions : ListOptions
    {

        /// <summary>
        /// Gets or sets pageToken.
        /// </summary>
        [JsonProperty("page[token]")]
        public string PageToken { get; set; }

        /// <summary>
        /// Gets or sets filter by Messaging Profile ID. Use the string null for phone numbers without assigned profiles. A synonym for the /messaging_profiles/{id}/short_codes endpoint when querying about an extant profile.
        /// </summary>
        [JsonProperty("filter[messaging_profile_id]")]
        public string FilterMessagingProfileId { get; set; }
    }
}
