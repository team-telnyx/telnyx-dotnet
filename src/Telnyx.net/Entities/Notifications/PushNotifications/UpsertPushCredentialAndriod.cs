namespace Telnyx.net.Entities.Notifications.PushNotifications
{
    using Newtonsoft.Json;

    public class UpsertPushNotificationCredentialsAndroid : BaseOptions
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "android";

        [JsonProperty("server_key")]
        public string ServerKey { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }
    }
}
