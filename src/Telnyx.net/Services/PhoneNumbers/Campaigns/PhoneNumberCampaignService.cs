namespace Telnyx.net.Services.PhoneNumbers.Campaigns
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.PhoneNumbers.Campaigns;

    public class PhoneNumberCampaignService : Service<PhoneNumberCampaign>
    {
        public PhoneNumberCampaignService()
            : base(null)
        {
        }

        public PhoneNumberCampaignService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/phoneNumberCampaign";

        public async Task<PhoneNumberCampaign> CreatePhoneNumberCampaignAsync(CreatePhoneNumberCampaignOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, requestOptions, cancellationToken: ct);
        }

        public PhoneNumberCampaign CreatePhoneNumberCampaign(CreatePhoneNumberCampaignOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }
    }
}
