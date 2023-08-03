namespace Telnyx.net.Entities.AuthenticationProviders
{
    using Newtonsoft.Json;

    public class AuthenticationProviderCreateOption : BaseOptions
    {
        /// <summary>
        /// The active status of the authentication provider.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Full contact name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The settings associated with the authentication provider.
        /// </summary>
        [JsonProperty("settings")]
        public SettingsObject Settings { get; set; }

        /// <summary>
        /// The URL for the identity provider metadata file to populate the settings automatically. If the settings attribute is provided, that will be used instead.
        /// </summary>
        [JsonProperty("settings_url")]
        public string SettingsUrl { get; set; }

        /// <summary>
        /// The short name associated with the authentication provider. This must be unique and URL-friendly, as it's going to be part of the login URL.
        /// </summary>
        [JsonProperty("short_name")]
        public string ShortName { get; set; }
    }
}
