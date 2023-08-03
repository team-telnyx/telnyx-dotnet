namespace Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UpdateABatchOfNumbersOptions : BaseOptions
    {
        /// <summary>
        /// The array of phone numbers in e164 format.
        /// </summary>
        [JsonProperty("phone_numbers")]
        public List<string> PhoneNumber { get; set; }

        /// <summary>
        /// Identifies the billing group associated with the phone number.
        /// </summary>
        [JsonProperty("billing_group_id")]
        public string BillingGroupId { get; set; }

        /// <summary>
        /// Identifies the connection associated with the phone number.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// A customer reference string for customer look ups.
        /// </summary>
        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// If someone attempts to port your phone number away from Telnyx and your phone number has an external PIN set,
        /// we will attempt to verify that you provided the correct external PIN to the winning carrier.
        /// Note that not all carriers cooperate with this security mechanism.
        /// </summary>
        [JsonProperty("external_pin")]
        public string ExternalPin { get; set; }

        /// <summary>
        /// A list of user-assigned tags to help organize phone numbers.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
