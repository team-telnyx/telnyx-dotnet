using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.Campaigns.PartnerCampaign;

namespace Telnyx.net.Services.PhoneNumbers.Campaigns.PartnerCampaign
{
   public class PartnerCampaignSharedByMeService : Service<PartnerCampaignSharedByMe>
    {
        public override string BasePath => "/partnerCampaign/sharedByMe";

        public async Task<TelnyxList<PartnerCampaignSharedByMe>> ListPartnerCampaignSharedByMeAsync(PartnerCampaignSharedByMeOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<PartnerCampaignSharedByMe> ListPartnerCampaignSharedByMe(PartnerCampaignSharedByMeOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
