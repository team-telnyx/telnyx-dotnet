namespace Telnyx.net.Entities.AuthenticationProviders
{
    using System;
    using Newtonsoft.Json;

    public class AuthenticationProviders : TelnyxEntity
    {
        /// <summary>
        /// The active status of the authentication provider.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Full contact name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("organization_id")]
        public Guid OrganizationId { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// The settings associated with the authentication provider.
        /// </summary>
        [JsonProperty("settings")]
        public SettingsObject Settings { get; set; }

        /// <summary>
        /// The short name associated with the authentication provider. This must be unique and URL-friendly, as it's going to be part of the login URL.
        /// </summary>
        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
