
namespace Telnyx.net.Services.PhoneNumbers.InboundChannels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// 
    /// </summary>
    public class InboundChannelUpdateOptions : BaseOptions
    {
        [JsonProperty("channels")]
        public int Channels { get; set; }
    }
}
