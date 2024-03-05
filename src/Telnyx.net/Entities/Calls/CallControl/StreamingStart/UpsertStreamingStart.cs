using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Calls.CallControl.StreamingStart
{
    public class UpsertStreamingStart : BaseOptions
    {
        [JsonProperty("stream_url")]
        public string StreamUrl { get; set; }

        [JsonProperty("stream_track")]
        public string StreamTrack { get; set; } = "inbound_track";

        [JsonProperty("enable_dialogflow")]
        public bool EnableDialogflow { get; set; } = false;

        [JsonProperty("dialogflow_config")]
        public DialogflowConfig DialogflowConfig { get; set; }

        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        [JsonProperty("command_id")]
        public string CommandId { get; set; }
    }
    public class DialogflowConfig
    {
        [JsonProperty("analyze_sentiment")]
        public bool AnalyzeSentiment { get; set; } = false;

        [JsonProperty("partial_automated_agent_reply")]
        public bool PartialAutomatedAgentReply { get; set; } = false;
    }
}
