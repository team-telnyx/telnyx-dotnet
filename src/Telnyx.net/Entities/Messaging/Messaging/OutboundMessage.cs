namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Entities.Messaging.Messaging;

    /// <summary>
    /// Outbound message.
    /// </summary>
    public class OutboundMessage : TelnyxEntity, IHasId
    {

        /// <summary>
        /// The direction of the message. Inbound messages are sent to you whereas outbound messages are sent from you.
        /// </summary>
        /// <value>The direction of the message. Inbound messages are sent to you whereas outbound messages are sent from you.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum DirectionEnum
        {
            /// <summary>
            /// Enum OutboundEnum for outbound
            /// </summary>
            [EnumMember(Value = "outbound")]
            OutboundEnum = 0
        }

        /// <summary>
        /// The type of message. This value can be either 'sms' or 'mms'.
        /// </summary>
        /// <value>This value can be either 'sms' or 'mms'.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum SmsEnum for sms
            /// </summary>
            [EnumMember(Value = "sms")]
            SmsEnum = 0,

            /// <summary>
            /// Enum MmsEnum for mms
            /// </summary>
            [EnumMember(Value = "mms")]
            MmsEnum = 1
        }

        /// <summary>
        /// The line-type of the receiver.
        /// </summary>
        /// <value>The line-type of the receiver.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum LineTypeEnum
        {
            /// <summary>
            /// Enum WirelineEnum for Wireline
            /// </summary>
            [EnumMember(Value = "Wireline")]
            WirelineEnum = 0,

            /// <summary>
            /// Enum WirelessEnum for Wireless
            /// </summary>
            [EnumMember(Value = "Wireless")]
            WirelessEnum = 1,

            /// <summary>
            /// Enum VoWiFiEnum for VoWiFi
            /// </summary>
            [EnumMember(Value = "VoWiFi")]
            VoWiFiEnum = 2,

            /// <summary>
            /// Enum VoIPEnum for VoIP
            /// </summary>
            [EnumMember(Value = "VoIP")]
            VoIPEnum = 3,

            /// <summary>
            /// Enum PrePaidWirelessEnum for Pre-Paid Wireless
            /// </summary>
            [EnumMember(Value = "Pre-Paid Wireless")]
            PrePaidWirelessEnum = 4
        }

        /// <summary>
        /// Gets or sets identifies the type of the resource.
        /// </summary>
        /// <value>Identifies the type of the resource.</value>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Gets or sets the direction of the message. Inbound messages are sent to you whereas outbound messages are sent from you.
        /// </summary>
        /// <value>The direction of the message. Inbound messages are sent to you whereas outbound messages are sent from you.</value>
        [JsonProperty("direction")]
        public DirectionEnum? Direction { get; set; }

        /// <summary>
        /// Gets or sets uniquely identifies the resource or object.
        /// </summary>
        /// <value>Uniquely identifies the resource or object.</value>
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the type of message. This value can be either &#x27;sms&#x27; or &#x27;mms&#x27;.
        /// </summary>
        /// <value>The type of message. This value can be either &#x27;sms&#x27; or &#x27;mms&#x27;.</value>
        [JsonProperty("type")]
        public TypeEnum? Type { get; set; }

        /// <summary>
        /// Gets or sets sending address (+E.164 formatted phone number, alphanumeric sender, or short code).
        /// </summary>
        /// <value>Sending address (+E.164 formatted phone number, alphanumeric sender, or short code).</value>
        [JsonProperty("from")]
        public OutboundMessageFrom From { get; set; }

        /// <summary>
        /// Gets or sets To.
        /// </summary>
        [JsonProperty("to")]
        public List<OutboundMessageTo> To { get; set; }

        /// <summary>
        /// Gets or sets message body (i.e., content) as a non-empty string.
        /// </summary>
        /// <value>Message body (i.e., content) as a non-empty string.</value>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets Media.
        /// </summary>
        [JsonProperty("media")]
        public List<OutboundMessageMedia> Media { get; set; }

        /// <summary>
        /// Gets or sets the URL where webhooks related to this message will be sent.
        /// </summary>
        /// <value>The URL where webhooks related to this message will be sent.</value>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// Gets or sets the failover URL where webhooks related to this message will be sent if sending to the primary URL fails.
        /// </summary>
        /// <value>The failover URL where webhooks related to this message will be sent if sending to the primary URL fails.</value>
        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        /// <summary>
        /// Gets or sets if the profile this number is associated with has webhooks, use them for delivery notifications. If webhooks are also specified on the message itself, they will be attempted first, then those on the profile.
        /// </summary>
        /// <value>If the profile this number is associated with has webhooks, use them for delivery notifications. If webhooks are also specified on the message itself, they will be attempted first, then those on the profile.</value>
        [JsonProperty("use_profile_webhooks")]
        public bool? UseProfileWebhooks { get; set; }

        /// <summary>
        /// Gets or sets Cost.
        /// </summary>
        [JsonProperty("cost")]
        public OutboundMessageCost Cost { get; set; }

        /// <summary>
        /// Gets or sets number of parts into which the message&#x27;s body must be split.
        /// </summary>
        /// <value>Number of parts into which the message&#x27;s body must be split.</value>
        [JsonProperty("parts")]
        public int? Parts { get; set; }

        /// <summary>
        /// Gets or sets iSO 8601 formatted date indicating when the resource was created.
        /// </summary>
        /// <value>ISO 8601 formatted date indicating when the resource was created.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets iSO 8601 formatted date indicating when the resource was updated.
        /// </summary>
        /// <value>ISO 8601 formatted date indicating when the resource was updated.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets message must be out of the queue by this time or else it will be discarded and marked as &#x27;sending_failed&#x27;. Once the message moves out of the queue, this field will be nulled.
        /// </summary>
        /// <value>Message must be out of the queue by this time or else it will be discarded and marked as &#x27;sending_failed&#x27;. Once the message moves out of the queue, this field will be nulled.</value>
        [JsonProperty("valid_until")]
        public DateTime? ValidUntil { get; set; }

        /// <summary>
        /// Gets or sets InfoBlobFieldname.
        /// </summary>
        [JsonProperty("info_blob_fieldname")]
        public string InfoBlobFieldname { get; set; }

        /// <summary>
        /// Gets or sets these errors may point at addressees when referring to unsuccessful/unconfirmed delivery statuses.
        /// </summary>
        /// <value>These errors may point at addressees when referring to unsuccessful/unconfirmed delivery statuses.</value>
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        /// <summary>
        /// Gets or sets the carrier of the receiver.
        /// </summary>
        /// <value>The carrier of the receiver.</value>
        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or sets the line-type of the receiver.
        /// </summary>
        /// <value>The line-type of the receiver.</value>
        [JsonProperty("line_type")]
        public LineTypeEnum? LineType { get; set; }

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt { get; set; }

        [JsonProperty("organization_id")]
        public Guid? OrganizationId { get; set; }

        /// <inheritdoc/>
        string IHasId.Id
        {
            get => this.Id.ToString();
            set => Guid.Parse(value);
        }
    }
}
