namespace Telnyx
{
    using System;

    /// <summary>
    /// ListMessagingProfilesPhoneNumbersOptions
    /// </summary>
    public class ListMessagingProfilesPhoneNumbersOptions : ListOptions
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        public Guid? Id { get; set; }

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
    }
}
