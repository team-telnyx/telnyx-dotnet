namespace Telnyx.net.Entities.Connections.DialogFlowConnections
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public class DialogFlowConnectionCreateOptions : BaseOptions
    {
        /// <summary>
        /// The JSON map to connect your Dialogflow account.
        /// </summary>
        [JsonProperty("service_account")]
        public Dictionary<string, object> ServiceAccount { get; set; }

        /// <summary>
        /// Determines which Dialogflow API will be used. Possible values: [cx, es]
        /// </summary>
        [JsonProperty("dialogflow_api")]
        public string DialogflowApi { get; set; }

        /// <summary>
        /// The ID of a configured conversation profile on your Dialogflow account.
        /// This is required if you use Dialogflow CX.
        /// </summary>
        [JsonProperty("conversation_profile_id")]
        public string ConversationProfileId { get; set; }

        /// <summary>
        /// The region of your agent is. This is required if you use Dialogflow CX.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Specifies which Dialogflow environment will be used.
        /// </summary>
        [JsonProperty("environment")]
        public string Environment { get; set; }
    }
}
