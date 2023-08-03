namespace Telnyx.net.Entities.DetailRecords
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.DetailRecords;

    public class DetailRecord : TelnyxEntity
    { /// <summary>
      /// Country-specific carrier used to send or receive the message.
      /// </summary>
        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        /// <summary>
        /// Fee charged by certain carriers in order to deliver certain message types.
        /// </summary>
        [JsonProperty("carrier_fee")]
        public string CarrierFee { get; set; }

        /// <summary>
        /// The recipient of the message (to parameter in the Messaging API).
        /// </summary>
        [JsonProperty("cld")]
        public string CLD { get; set; }

        /// <summary>
        /// The sender of the message (from parameter in the Messaging API).
        /// </summary>
        [JsonProperty("cli")]
        public string CLI { get; set; }

        /// <summary>
        /// Message completion time.
        /// </summary>
        [JsonProperty("completed_at")]
        public DateTimeOffset CompletedAt { get; set; }

        /// <summary>
        /// Amount, in the user currency, for the Telnyx billing cost.
        /// </summary>
        [JsonProperty("cost")]
        public string Cost { get; set; }

        /// <summary>
        /// Two-letter representation of the country of the cld property using the ISO 3166-1 alpha-2 format.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Message creation time.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Telnyx account currency used to describe monetary values, including billing cost.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Final webhook delivery status.
        /// </summary>
        [JsonProperty("delivery_status")]
        public string DeliveryStatus { get; set; }

        /// <summary>
        /// Failover customer-provided URL which Telnyx posts delivery status webhooks to.
        /// </summary>
        [JsonProperty("delivery_status_failover_url")]
        public string DeliveryStatusFailoverUrl { get; set; }

        /// <summary>
        /// Primary customer-provided URL which Telnyx posts delivery status webhooks to.
        /// </summary>
        [JsonProperty("delivery_status_webhook_url")]
        public string DeliveryStatusWebhookUrl { get; set; }

        /// <summary>
        /// Logical direction of the message from the Telnyx customer's perspective.
        /// </summary>
        [JsonProperty("direction")]
        public Direction Direction { get; set; }

        /// <summary>
        /// Telnyx API error codes returned by the Telnyx gateway.
        /// </summary>
        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        /// <summary>
        /// Indicates whether this is a Free-To-End-User (FTEU) short code message.
        /// </summary>
        [JsonProperty("fteu")]
        public bool Fteu { get; set; }

        /// <summary>
        /// Mobile country code. Only available for certain products.
        /// </summary>
        [JsonProperty("mcc")]
        public string MCC { get; set; }

        /// <summary>
        /// Describes the Messaging service used to send the message.
        /// </summary>
        [JsonProperty("message_type")]
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Mobile network code. Only available for certain products.
        /// </summary>
        [JsonProperty("mnc")]
        public string MNC { get; set; }

        /// <summary>
        /// Indicates whether both sender and recipient numbers are Telnyx-managed.
        /// </summary>
        [JsonProperty("on_net")]
        public bool OnNet { get; set; }

        /// <summary>
        /// Number of message parts.
        /// </summary>
        [JsonProperty("parts")]
        public int Parts { get; set; }

        /// <summary>
        /// Unique identifier of the Messaging Profile used to send or receive the message.
        /// </summary>
        [JsonProperty("profile_id")]
        public string ProfileId { get; set; }

        /// <summary>
        /// Name of the Messaging Profile used to send or receive the message.
        /// </summary>
        [JsonProperty("profile_name")]
        public string ProfileName { get; set; }

        /// <summary>
        /// Currency amount per billing unit used to calculate the Telnyx billing cost.
        /// </summary>
        [JsonProperty("rate")]
        public string Rate { get; set; }

        /// <summary>
        /// Identifies the record schema.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Time when the message was sent.
        /// </summary>
        [JsonProperty("sent_at")]
        public DateTimeOffset SentAt { get; set; }

        /// <summary>
        /// Two-letter representation of the country of the cli property using the ISO 3166-1 alpha-2 format.
        /// </summary>
        [JsonProperty("source_country_code")]
        public string SourceCountryCode { get; set; }

        /// <summary>
        /// Final status of the message after the delivery attempt.
        /// </summary>
        [JsonProperty("status")]
        public MessageStatus Status { get; set; }

        /// <summary>
        /// Comma-separated tags assigned to the Telnyx number associated with the message.
        /// </summary>
        [JsonProperty("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Message updated time.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Identifier of the Telnyx account who owns the message.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Unique identifier of the message.
        /// </summary>
        [JsonProperty("uuid")]
        public string UUID { get; set; }
    }
}
