namespace Telnyx
{
    /// <summary>
    /// NumberReservationsListOptions
    /// </summary>
    public class NumberReservationsListOptions : ListOptions
    {
        /// <summary>
        /// Gets or sets status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets createdAtGt
        /// </summary>
        public string CreatedAtGt { get; set; }

        /// <summary>
        /// Gets or sets createdAtLt
        /// </summary>
        public string CreatedAtLt { get; set; }

        /// <summary>
        /// Gets or sets phoneNumbersPhoneNumber
        /// </summary>
        public string PhoneNumbersPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets customerReference
        /// </summary>
        public string CustomerReference { get; set; }
    }
}