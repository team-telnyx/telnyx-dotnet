namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// NumberOrderListOptions
    /// </summary>
    public class NumberOrderListOptions : ListOptions
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
        [JsonProperty("filter[phone_numbers.phone_number]")]
        public string PhoneNumbersPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets customerReference
        /// </summary>
        public string CustomerReference { get; set; }

        /// <summary>
        /// Gets or sets requirementsMet
        /// </summary>
        public bool? RequirementsMet { get; set; }
    }
}