
namespace Telnyx.net.Entities.Notifications.PushNotifications
{
    using Newtonsoft.Json;

    public class UpsertPushNotificationCredentialsIOS : BaseOptions
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "ios";

        [JsonProperty("certificate")]
        public string Certificate { get; set; }

        [JsonProperty("private_key")]
        public string PrivateKey { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }
    }
}
