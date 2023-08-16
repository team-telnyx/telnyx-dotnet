namespace Telnyx.net.Entities.PhoneNumbers.Campaigns
{
    using System;
    using Newtonsoft.Json;

    public class Records
    {
        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
