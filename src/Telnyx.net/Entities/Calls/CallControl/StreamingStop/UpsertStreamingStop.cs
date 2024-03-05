using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Calls.CallControl.StreamingStop
{
    public class UpsertStreamingStop : BaseOptions
    {
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        [JsonProperty("command_id")]
        public string CommandId { get; set; }
    }
}
