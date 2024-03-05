using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Telnyx.net.Entities.VirtualCrossConnects
{
    public class UpdateVirtualCrossConnect : BaseOptions
    {
        [JsonProperty("primary_enabled")]
        public bool PrimaryEnabled { get; set; }

        [JsonProperty("primary_routing_announcement")]
        public bool PrimaryRoutingAnnouncement { get; set; }

        [JsonProperty("primary_cloud_ip")]
        public string PrimaryCloudIp { get; set; }

        [JsonProperty("secondary_enabled")]
        public bool SecondaryEnabled { get; set; }

        [JsonProperty("secondary_routing_announcement")]
        public bool SecondaryRoutingAnnouncement { get; set; }

        [JsonProperty("secondary_cloud_ip")]
        public string SecondaryCloudIp { get; set; }
    }
}
