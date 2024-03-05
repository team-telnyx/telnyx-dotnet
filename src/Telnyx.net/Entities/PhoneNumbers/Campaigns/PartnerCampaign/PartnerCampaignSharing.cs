using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.Campaigns.PartnerCampaign
{
    public class PartnerCampaignSharing : TelnyxEntity
    {
        [JsonProperty("sharedByMe")]
        public SharedObject SharedByMe { get; set; }

        [JsonProperty("sharedWithMe")]
        public SharedObject SharedWithMe { get; set; }
    }
    public class SharedObject
    {
        [JsonProperty("downstreamCnpId")]
        public string DownstreamCnpId { get; set; }

        [JsonProperty("sharedDate")]
        public string SharedDate { get; set; }

        [JsonProperty("sharingStatus")]
        public string SharingStatus { get; set; }

        [JsonProperty("statusDate")]
        public string StatusDate { get; set; }

        [JsonProperty("upstreamCnpId")]
        public string UpstreamCnpId { get; set; }
    }
}
