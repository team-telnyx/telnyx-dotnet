namespace Telnyx.net.Entities.Calls.CallControl.Transcriptions.Webhooks
{
    using Newtonsoft.Json;

    public class Transcription
    {
        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        [JsonProperty("call_leg_id")]
        public string CallLegId { get; set; }

        [JsonProperty("call_session_id")]
        public string CallSessionId { get; set; }

        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("transcription_data")]
        public TranscriptionData TranscriptionData { get; set; }
    }

    public class TranscriptionData
    {
        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("transcript")]
        public string Transcript { get; set; }
    }
}
