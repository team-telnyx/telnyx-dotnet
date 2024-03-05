using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.SimCards
{
    public class SIMCardDeviceDetail : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("imei")]
        public long IMEI { get; set; }

        [JsonProperty("model_name")]
        public string ModelName { get; set; }

        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        [JsonProperty("device_type")]
        public string DeviceType { get; set; }

        [JsonProperty("operating_system")]
        public string OperatingSystem { get; set; }
    }
}
