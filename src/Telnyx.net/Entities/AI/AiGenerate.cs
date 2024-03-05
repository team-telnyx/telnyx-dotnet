using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.AI.AiGenerates
{
    public class AiGenerate : TelnyxEntity
    {
        [JsonProperty("answer")]
        public string[] Answer { get; set; }
    }
}
