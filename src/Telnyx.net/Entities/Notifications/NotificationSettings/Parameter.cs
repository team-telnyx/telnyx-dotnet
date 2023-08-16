namespace Telnyx.net.Entities.Notifications.NotificationSettings
{
    using Newtonsoft.Json;

    public class Parameter
    {
        /// <summary>
        /// The name of the parameter.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The value of the parameter.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
