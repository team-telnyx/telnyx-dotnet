namespace Telnyx.net.Entities.PhoneNumbers.Campaigns
{
    using Newtonsoft.Json;

    public class CreatePhoneNumberCampaignOptions : BaseOptions
    {
        /// <summary>
        /// The ID of the campaign you want to link to the specified phone number.
        /// </summary>
        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        /// <summary>
        /// The phone number you want to link to a specified campaign.
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
