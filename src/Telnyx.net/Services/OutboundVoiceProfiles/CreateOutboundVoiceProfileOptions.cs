namespace Telnyx.net.Services.OutboundVoiceProfiles
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.OutboundVoiceProfiles;

    public class CreateOutboundVoiceProfileOptions : BaseOptions
    {
        /// <summary>
        /// A user-supplied name to help with organization.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Specifies the type of traffic allowed in this profile.
        /// </summary>
        [JsonProperty("traffic_type")]
        public string TrafficType { get; set; }

        /// <summary>
        /// Gets or Sets ServicePlan.
        /// </summary>
        [JsonProperty("service_plan")]
        public string ServicePlan { get; set; }

        /// <summary>
        /// Must be no more than your global concurrent call limit. Null means no limit.
        /// </summary>
        [JsonProperty("concurrent_call_limit")]
        public int? ConcurrentCallLimit { get; set; }

        /// <summary>
        /// Specifies whether the outbound voice profile can be used. Disabled profiles will result in outbound calls being blocked for the associated Connections.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or Sets Tags.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or Sets UsagePaymentMethod.
        /// </summary>
        [JsonProperty("usage_payment_method")]
        public string UsagePaymentMethod { get; set; }

        /// <summary>
        /// The list of destinations you want to be able to call using this outbound voice profile formatted in alpha2.
        /// </summary>
        [JsonProperty("whitelisted_destinations")]
        public List<string> WhitelistedDestinations { get; set; }

        /// <summary>
        /// Maximum rate (price per minute) for a Destination to be allowed when making outbound calls.
        /// </summary>
        [JsonProperty("max_destination_rate")]
        public decimal? MaxDestinationRate { get; set; }

        /// <summary>
        /// The maximum amount of usage charges, in USD, you want Telnyx to allow on this outbound voice profile in a day before disallowing new calls.
        /// </summary>
        [JsonProperty("daily_spend_limit")]
        public string DailySpendLimit { get; set; }

        /// <summary>
        /// Specifies whether to enforce the daily_spend_limit on this outbound voice profile.
        /// </summary>
        [JsonProperty("daily_spend_limit_enabled")]
        public bool? DailySpendLimitEnabled { get; set; }

        /// <summary>
        /// Gets or Sets CallRecording.
        /// </summary>
        [JsonProperty("call_recording")]
        public OutboundVoiceProfileCallRecording CallRecording { get; set; }

        /// <summary>
        /// The ID of the billing group associated with the outbound proflile. Defaults to null (for no group assigned).
        /// </summary>
        [JsonProperty("billing_group_id")]
        public Guid? BillingGroupId { get; set; }
    }
}