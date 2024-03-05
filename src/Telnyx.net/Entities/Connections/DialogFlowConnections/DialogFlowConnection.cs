namespace Telnyx.net.Entities.Connections.DialogFlowConnections
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the response for a DialogFlow Connection.
    /// </summary>
    public class DialogFlowConnection : TelnyxEntity
    {
        /// <summary>
        /// Uniquely identifies a Telnyx application (Call Control).
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// The ID of a configured conversation profile on your Dialogflow account.
        /// </summary>
        [JsonProperty("conversation_profile_id")]
        public string ConversationProfileId { get; set; }

        /// <summary>
        /// Specifies which Dialogflow environment will be used.
        /// </summary>
        [JsonProperty("environment")]
        public string Environment { get; set; }

        /// <summary>
        /// The JSON map to connect your Dialogflow account.
        /// </summary>
        [JsonProperty("service_account")]
        public string ServiceAccount { get; set; }

        /// <summary>
        /// Specifies the record type, typically related to the type of entity.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
}
