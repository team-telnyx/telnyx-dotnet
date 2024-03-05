using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.Campaigns.PartnerCampaign
{
   public class PartnerCampaignSharedByMe : TelnyxEntity
    {
        [JsonProperty("brandId")]
        public string BrandId { get; set; }

        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        [JsonProperty("createDate")]
        public long CreateDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("usecase")]
        public string Usecase { get; set; }

        [JsonProperty("totalRecords")]
        public int TotalRecords { get; set; }
    }
}
