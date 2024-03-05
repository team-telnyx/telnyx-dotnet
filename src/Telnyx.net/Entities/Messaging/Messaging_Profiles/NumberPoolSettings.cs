namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// Number Pool allows you to send messages from a pool of numbers of different types, assigning weights to each type. The pool consists of all the Long Code and Toll Free numbers assigned to the Messaging profile.
    /// </summary>
    public class NumberPoolSettings
    {
        /// <summary>
        /// Gets or sets defines the probability weight for a Toll Free number to be selected when sending a message. The higher the weight the higher the probability. The sum of the weights for all number types does not necessarily need to add to 100. Weight must be a non-negative number, and when equal to zero it will remove the number type from the pool.
        /// </summary>
        /// <value>Defines the probability weight for a Toll Free number to be selected when sending a message. The higher the weight the higher the probability. The sum of the weights for all number types does not necessarily need to add to 100. Weight must be a non-negative number, and when equal to zero it will remove the number type from the pool. </value>
        [JsonProperty("toll_free_weight")]
        public decimal? TollFreeWeight { get; set; }

        /// <summary>
        /// Gets or sets defines the probability weight for a Long Code number to be selected when sending a message. The higher the weight the higher the probability. The sum of the weights for all number types does not necessarily need to add to 100.  Weight must be a non-negative number, and when equal to zero it will remove the number type from the pool.
        /// </summary>
        /// <value>Defines the probability weight for a Long Code number to be selected when sending a message. The higher the weight the higher the probability. The sum of the weights for all number types does not necessarily need to add to 100.  Weight must be a non-negative number, and when equal to zero it will remove the number type from the pool. </value>
        [JsonProperty("long_code_weight")]
        public decimal? LongCodeWeight { get; set; }

        /// <summary>
        /// Gets or sets if set to true all unhealthy numbers will be automatically removed from the pool. Health metrics  per number are calculated on a regular basis, taking into account the deliverability rate and the amount of messages marked as spam by upstream carriers. Numbers with a deliverability rate below 25% or spam ratio over 75% will be considered unhealthy.
        /// </summary>
        /// <value>If set to true all unhealthy numbers will be automatically removed from the pool. Health metrics  per number are calculated on a regular basis, taking into account the deliverability rate and the amount of messages marked as spam by upstream carriers. Numbers with a deliverability rate below 25% or spam ratio over 75% will be considered unhealthy. </value>
        [JsonProperty("skip_unhealthy")]
        public bool? SkipUnhealthy { get; set; }

        /// <summary>
        /// Gets or sets if set to true, Number Pool will try to choose the same sending number for all messages to a particular recipient. If the sending number becomes unhealthy and &#x60;skip_unhealthy&#x60; is set to &#x60;true&#x60;, a new number will be chosen.
        /// </summary>
        /// <value>If set to true, Number Pool will try to choose the same sending number for all messages to a particular recipient. If the sending number becomes unhealthy and &#x60;skip_unhealthy&#x60; is set to &#x60;true&#x60;, a new number will be chosen. </value>
        [JsonProperty("sticky_sender")]
        public bool? StickySender { get; set; }

        /// <summary>
        /// Gets or sets if set to true, Number Pool will try to choose a sending number with the same area code as the destination number. If there are no such numbers available, a nunber with a different area code will be chosen. Currently only NANP numbers are supported.
        /// </summary>
        /// <value>If set to true, Number Pool will try to choose a sending number with the same area code as the destination number. If there are no such numbers available, a nunber with a different area code will be chosen. Currently only NANP numbers are supported. </value>
        [JsonProperty("geomatch")]
        public bool? Geomatch { get; set; }
    }
}
