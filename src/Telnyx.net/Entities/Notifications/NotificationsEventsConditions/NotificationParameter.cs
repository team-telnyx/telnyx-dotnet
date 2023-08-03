namespace Telnyx.net.Entities.Notifications.NotificationsEventsConditions
{
    using Newtonsoft.Json;

    public class NotificationParameter
    {
        /// <summary>
        /// The data type of the parameter.
        /// </summary>
        [JsonProperty("data_type")]
        public string DataType { get; set; }

        /// <summary>
        /// The name of the parameter.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Indicates if the parameter is optional.
        /// </summary>
        [JsonProperty("optional")]
        public bool Optional { get; set; }
    }
}
