using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Calls.CallControl.GatherDTMFs
{
    public class UpsertGatherDTMF : BaseOptions
    {
        [JsonProperty("minimum_digits")]
        public int MinimumDigits { get; set; } = 1;

        [JsonProperty("maximum_digits")]
        public int MaximumDigits { get; set; } = 128;

        [JsonProperty("timeout_millis")]
        public int TimeoutMillis { get; set; } = 60000;

        [JsonProperty("inter_digit_timeout_millis")]
        public int InterDigitTimeoutMillis { get; set; } = 5000;

        [JsonProperty("initial_timeout_millis")]
        public int InitialTimeoutMillis { get; set; } = 5000;

        [JsonProperty("terminating_digit")]
        public string TerminatingDigit { get; set; } = "#";

        [JsonProperty("valid_digits")]
        public string ValidDigits { get; set; } = "0123456789#*";

        [JsonProperty("gather_id")]
        public string GatherId { get; set; } = null;

        [JsonProperty("client_state")]
        public string ClientState { get; set; } = null;

        [JsonProperty("command_id")]
        public string CommandId { get; set; } = null;
    }
}
