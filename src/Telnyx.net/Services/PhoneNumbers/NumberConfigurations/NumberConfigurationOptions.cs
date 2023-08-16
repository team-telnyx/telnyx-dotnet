namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class NumberConfigurationOptions : BaseOptions
    {
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
        /// If someone attempts to port your phone number away from Telnyx 
        /// and your phone number has an external PIN set, we will attempt to verify that you provided the correct external PIN 
        /// to the winning carrier. Note that not all carriers cooperate with this security mechanism.
        /// </summary>
        [JsonProperty("external_pin")]
        public string ExternalPin { get; set; }

        /// <summary>
        /// A list of user-assigned tags to help organize phone numbers.
        /// </summary>
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}
