using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferenceResume
{
    public class ConferenceResumeOption : BaseOptions
    {
        [JsonProperty("command_id")]
        public string CommandId { get; set; }

        [JsonProperty("recording_id")]
        public string RecordingId { get; set; }
    }
}
