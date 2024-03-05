using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Telnyx.net.Entities.ManagedAccounts
{
    public class UpsertAllocatableGlobalOutboundChannel : BaseOptions
    {
        [JsonProperty("channel_limit")]
        public int ChannelLimit { get; set; }
    }
}
