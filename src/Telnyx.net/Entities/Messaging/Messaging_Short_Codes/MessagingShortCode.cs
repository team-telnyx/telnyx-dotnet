namespace Telnyx
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    /// <summary>
    /// Messaging Short Code.
    /// </summary>
    public class MessagingShortCode : TelnyxEntity, IHasId
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
        /// Gets or sets short digit sequence used to address messages.
        /// </summary>
        /// <value>Short digit sequence used to address messages.</value>
        [JsonProperty("short_code")]
        public string ShortCode { get; set; }

        /// <summary>
        /// Gets or sets iSO3166-1 alpha-2 country code.
        /// </summary>
        /// <value>ISO3166-1 alpha-2 country code.</value>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

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
