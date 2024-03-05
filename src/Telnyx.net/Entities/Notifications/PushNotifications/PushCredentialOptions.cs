namespace Telnyx.net.Entities.Notifications.PushNotifications
{
    using Newtonsoft.Json;
    public class PushNotificationCredentialOptions : ListOptions
    {
        /// <summary>
        /// Filter by the type.
        /// </summary>
        [JsonProperty("filter[type]")]
        public string Type { get; set; }

        /// <summary>
        /// Filter by the alias.
        /// </summary>
        [JsonProperty("filter[alias]")]
        public string Alias { get; set; }
    }
}
