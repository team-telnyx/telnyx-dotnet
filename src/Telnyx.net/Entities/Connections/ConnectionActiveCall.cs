using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Connections
{
    public class ConnectionActiveCall : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("call_session_id")]
        public string CallSessionId { get; set; }

        [JsonProperty("call_leg_id")]
        public string CallLegId { get; set; }

        [JsonProperty("call_control_id")]
        public string CallControlId { get; set; }

        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        [JsonProperty("call_duration")]
        public int CallDuration { get; set; }
    }
}
