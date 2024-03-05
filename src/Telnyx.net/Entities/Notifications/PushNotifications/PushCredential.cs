
namespace Telnyx.net.Entities.Notifications.PushNotifications
{
    using System;
    using Newtonsoft.Json;

    public class PushNotificationCredentials : TelnyxEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("certificate")]
        public string Certificate { get; set; }

        [JsonProperty("private_key")]
        public string PrivateKey { get; set; }

        [JsonProperty("server_key")]
        public string ServerKey { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
