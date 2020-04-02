namespace Telnyx
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    public class MessagingFrom
    {
        /// <summary>
        /// Gets or sets the message from carrier
        /// </summary>
        /// <value>Message from carrier</value>
        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or sets the message from line type
        /// </summary>
        /// <value>Message from line type</value>
        [JsonProperty("line_type")]
        public string LineType { get; set; }

        /// <summary>
        /// Gets or sets the message from phone number
        /// </summary>
        /// <value>Message from phone number</value>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the message from status
        /// </summary>
        /// <value>Message from status</value>
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class MessagingCost
    {
        /// <summary>
        /// Gets or sets the message cost
        /// </summary>
        /// <value>Message cost</value>
        [JsonProperty("cost")]
        public string Cost { get; set; }

        /// <summary>
        /// Gets or sets the message cost currency
        /// </summary>
        /// <value>Message cost currency</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    /// <summary>
    /// Messaging Sender Id
    /// </summary>
    public class MessagingSenderId : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        /// <value>Type of the resource.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum RecordTypeEnum
        {
            /// <summary>
            /// Enum IdEnum for message
            /// </summary>
            [EnumMember(Value = "message")]
            IdEnum = 0
        }

        /// <summary>
        /// Gets or sets identifies the type of the resource.
        /// </summary>
        /// <value>Identifies the type of the resource.</value>
        [JsonProperty("record_type")]
        public RecordTypeEnum? RecordType { get; set; }

        /// <summary>
        /// Gets or sets uniquely identifies the resource or object.
        /// </summary>
        /// <value>Uniquely identifies the resource or object.</value>
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets unique identifier for the organization that owns the resource.
        /// </summary>
        /// <value>Unique identifier for the organization that owns the resource.</value>
        [JsonProperty("organization_id")]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets the message text
        /// </summary>
        /// <value>Message body</value>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the direction
        /// </summary>
        /// <value>Message direction</value>
        [JsonProperty("direction")]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets the encoding
        /// </summary>
        /// <value>Message encoding</value>
        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        /// <summary>
        /// Gets or sets the message From
        /// </summary>
        /// <value>Message from</value>
        [JsonProperty("from")] public MessagingFrom From { get; set; }

        /// <summary>
        /// Gets or sets the message To
        /// </summary>
        /// <value>Message To</value>
        [JsonProperty("to")] public string To { get; set; }

        /// <summary>
        /// Gets or sets the message parts
        /// </summary>
        /// <value>Message parts</value>
        [JsonProperty("parts")] public int Parts { get; set; }

        /// <summary>
        /// Gets or sets the message received at time
        /// </summary>
        /// <value>Message received at</value>
        [JsonProperty("received_at")]
        public DateTime? ReceivedAt { get; set; }

        /// <summary>
        /// Gets or sets the message sent at time
        /// </summary>
        /// <value>Message set at time</value>
        [JsonProperty("sent_at")]
        public DateTime? SentAt { get; set; }

        /// <summary>
        /// Gets or sets the message webhook url
        /// </summary>
        /// <value>Message webhook url</value>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// Gets or sets the message webhook failover url
        /// </summary>
        /// <value>Message webhook failover url</value>
        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }
        
        /// <summary>
        /// Gets or sets the messaging costs
        /// </summary>
        /// <value>Message costs</value>
        [JsonProperty("cost")]
        public MessagingCost Cost { get; set; }
        
        /// <summary>
        /// Gets or sets unique identifier for a messaging profile.
        /// </summary>
        /// <value>Unique identifier for a messaging profile.</value>
        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

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
        /// Gets or sets Id
        /// </summary>
        string IHasId.Id { get => this.Id.ToString(); set => Guid.Parse(value); }
    }
}