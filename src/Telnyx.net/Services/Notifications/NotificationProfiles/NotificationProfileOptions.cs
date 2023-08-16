namespace Telnyx.net.Services.Notifications.NotificationProfiles
{
    using Newtonsoft.Json;

    public class NotificationProfileOptions : BaseOptions
    {
        /// <summary>
        /// A human readable name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
