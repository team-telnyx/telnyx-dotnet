using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Entities.Enum.Messaging;
using Telnyx.net.Entities.Enum.Webhooks;

namespace Telnyx.net.Entities.Messaging.Messaging
{
    public class MessageWebhook : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Gets or sets the direction of the message. Inbound messages are sent to you whereas outbound messages are sent from you.
        /// </summary>
        [JsonProperty("direction")]
        public DirectionEnum? Direction { get; set; }

        /// <summary>
        /// Gets or sets uniquely identifies the resource or object.
        /// </summary>
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the type of message. This value can be either &#x27;sms&#x27; or &#x27;mms&#x27;.
        /// </summary>
        [JsonProperty("type")]
        public TypeEnum? Type { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        [JsonProperty("cc")]
        public List<MessageCC> Cc { get; set; }

        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

        [JsonProperty("organization_id")]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets sending address (+E.164 formatted phone number, alphanumeric sender, or short code).
        /// </summary>
        [JsonProperty("from")]
        public MessageFrom From { get; set; }

        /// <summary>
        /// Gets or sets To.
        /// </summary>
        [JsonProperty("to")]
        public List<MessageTo> To { get; set; }

        /// <summary>
        /// Gets or sets message body (i.e., content) as a non-empty string.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets Media.
        /// </summary>
        [JsonProperty("media")]
        public List<MessageMedia> Media { get; set; }

        /// <summary>
        /// Gets or sets the URL where webhooks related to this message will be sent.
        /// </summary>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// Gets or sets the failover URL where webhooks related to this message will be sent if sending to the primary URL fails.
        /// </summary>
        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        /// <summary>
        /// Gets or sets if the profile this number is associated with has webhooks, use them for delivery notifications. If webhooks are also specified on the message itself, they will be attempted first, then those on the profile.
        /// </summary>
        [JsonProperty("use_profile_webhooks")]
        public bool? UseProfileWebhooks { get; set; }

        /// <summary>
        /// Gets or sets Cost.
        /// </summary>
        [JsonProperty("cost")]
        public MessageCost Cost { get; set; }

        /// <summary>
        /// Gets or sets number of parts into which the message&#x27;s body must be split.
        /// </summary>
        [JsonProperty("parts")]
        public int? Parts { get; set; }

        /// <summary>
        /// Gets or sets iSO 8601 formatted date indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets iSO 8601 formatted date indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets message must be out of the queue by this time or else it will be discarded and marked as &#x27;sending_failed&#x27;. Once the message moves out of the queue, this field will be nulled.
        /// </summary>
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
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        /// <summary>
        /// Gets or sets these errors may point at addressees when referring to unsuccessful/unconfirmed delivery statuses.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

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

        /// <summary>
        /// The delivery status of the message.
        /// </summary>
        [JsonProperty("status")]
        public DeliveryStatus? Status { get; set; }

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt { get; set; }
    }
}
