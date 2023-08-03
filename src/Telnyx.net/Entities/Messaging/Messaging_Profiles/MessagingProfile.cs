namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Entities.Messaging.Messaging_Profiles;

    /// <summary>
    /// Messaging Profile.
    /// </summary>
    public class MessagingProfile : TelnyxEntity, IHasId
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
        /// Gets or sets unique identifier for the organization that owns the resource.
        /// </summary>
        /// <value>Unique identifier for the organization that owns the resource.</value>
        [JsonProperty("organization_id")]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets a user friendly name for the messaging profile.
        /// </summary>
        /// <value>A user friendly name for the messaging profile.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL where webhooks related to this messaging profile will be sent.
        /// </summary>
        /// <value>The URL where webhooks related to this messaging profile will be sent.</value>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// Gets or sets the failover URL where webhooks related to this messaging profile will be sent if sending to the primary URL fails.
        /// </summary>
        /// <value>The failover URL where webhooks related to this messaging profile will be sent if sending to the primary URL fails.</value>
        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        /// <summary>
        /// Gets or sets specifies whether the messaging profile is enabled or not.
        /// </summary>
        /// <value>Specifies whether the messaging profile is enabled or not.</value>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets specifies whether to apply character simplification to text.
        /// </summary>
        /// <value>Specifies whether to apply character simplification to text.</value>
        [JsonProperty("simplify_characters")]
        public bool? SimplifyCharacters { get; set; }

        /// <summary>
        /// Gets or sets destinations to which the messaging profile is allowed to send.
        /// </summary>
        /// <value>Destinations to which the messaging profile is allowed to send.</value>
        [JsonProperty("whitelisted_destinations")]
        public List<string> WhitelistedDestinations { get; set; }

        /// <summary>
        /// Gets or sets determines which webhook format will be used, API V1 or API V2.
        /// </summary>
        /// <value>Determines which webhook format will be used, API V1 or API V2.</value>
        [JsonProperty("webhook_api_version")]
        public WebhookAPIVersion? WebhookApiVersion { get; set; }

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
        /// Gets or sets NumberPoolSettings.
        /// </summary>
        [JsonProperty("number_pool_settings")]
        public NumberPoolSettings NumberPoolSettings { get; set; }

        /// <summary>
        /// Gets or sets UrlShortnerSettings.
        /// </summary>
        [JsonProperty("url_shortener_settings")]
        public UrlShortenerSettings UrlShortenerSetting { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        string IHasId.Id { get => this.Id.ToString(); set => Guid.Parse(value); }
    }
}
