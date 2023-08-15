namespace Telnyx
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    /// <summary>
    /// Messaging Sender Id.
    /// </summary>
    public class MessagingSenderId : TelnyxEntity, IHasId
    {

        /// <summary>
        /// Gets or sets identifies the type of the resource.
        /// </summary>
        /// <value>Identifies the type of the resource.</value>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Gets or sets uniquely identifies the resource or object.
        /// </summary>
        /// <value>Uniquely identifies the resource or object.</value>
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets sender identifier.
        /// </summary>
        /// <value>Sender identifier.</value>
        [JsonProperty("sender_id")]
        public string SenderId { get; set; }

        /// <summary>
        /// Gets or sets unique identifier for the organization that owns the resource.
        /// </summary>
        /// <value>Unique identifier for the organization that owns the resource.</value>
        [JsonProperty("organization_id")]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets unique identifier for a messaging profile.
        /// </summary>
        /// <value>Unique identifier for a messaging profile.</value>
        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

        /// <summary>
        /// Gets or sets denotes whether the sender ID has been approved by relevant carriers.
        /// </summary>
        /// <value>Denotes whether the sender ID has been approved by relevant carriers.</value>
        [JsonProperty("approved")]
        public bool? Approved { get; set; }

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
        /// Gets or sets Id.
        /// </summary>
        string IHasId.Id { get => this.Id.ToString(); set => Guid.Parse(value); }
    }
}
