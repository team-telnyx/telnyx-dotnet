using Newtonsoft.Json;

namespace Telnyx.net.Entities.VirtualCrossConnectCloudRegions
{
    public class VirtualCrossConnectCloudRegionOption : ListOptions
    {
        [JsonProperty("region_code")]
        public string RegionCode { get; set; }

        [JsonProperty("cloud_provider")]
        public string CloudProvider { get; set; }
    }
}
