namespace Telnyx.net.Entities.Calls.CallControl.Refer.Webhook
{
    using System;
    using Newtonsoft.Json;

    public class Refer
    {
        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        [JsonProperty("call_leg_id")]
        public Guid? CallLegId { get; set; }

        [JsonProperty("call_session_id")]
        public Guid? CallSessionId { get; set; }

        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("sip_notify_response")]
        public long SipNotifyResponse { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }
}
