namespace Telnyx
{
    /// <summary>
    /// MessagingPhoneNumerListOptions
    /// </summary>
    public class MessagingPhoneNumerListOptions : ListOptions
    {
        /// <summary>
        /// Gets or sets pageNumber
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Gets or sets pageSize
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or sets pageToken
        /// </summary>
        public string PageToken { get; set; }

        /// <summary>
        /// Gets or sets filterMessagingProfileId
        /// </summary>
        public string FilterMessagingProfileId { get; set; }

        /// <summary>
        /// Gets or sets filterPhoneNumber
        /// </summary>
        public string FilterPhoneNumber { get; set; }
    }
}
