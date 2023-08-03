namespace Telnyx.net.Entities.PhoneNumbers.NumberConfigurations
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public partial class PhoneNumberMessaging : TelnyxEntity
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("eligible_messaging_products")]
        public List<string> EligibleMessagingProducts { get; set; }

        [JsonProperty("features")]
        public Features Features { get; set; }

        [JsonProperty("health")]
        public Health Health { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; set; }

        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        [JsonProperty("traffic_type")]
        public string TrafficType { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public partial class Features
    {
        [JsonProperty("mms")]
        public MessagingService Mms { get; set; }

        [JsonProperty("sms")]
        public MessagingService Sms { get; set; }
    }

    public partial class MessagingService
    {
        [JsonProperty("domestic_two_way")]
        public bool DomesticTwoWay { get; set; }

        [JsonProperty("international_inbound")]
        public bool InternationalInbound { get; set; }

        [JsonProperty("international_outbound")]
        public bool InternationalOutbound { get; set; }
    }

    public partial class Health
    {
        [JsonProperty("inbound_outbound_ratio")]
        public double InboundOutboundRatio { get; set; }

        [JsonProperty("message_count")]
        public long MessageCount { get; set; }

        [JsonProperty("spam_ratio")]
        public double SpamRatio { get; set; }

        [JsonProperty("success_ratio")]
        public double SuccessRatio { get; set; }
    }
}
