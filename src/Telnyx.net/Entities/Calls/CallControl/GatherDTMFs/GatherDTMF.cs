using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Calls.CallControl.GatherDTMFs
{
    public class GatherDTMF : TelnyxEntity
    {
        [JsonProperty("result")]
        public string Result { get; set; }

    }
}
