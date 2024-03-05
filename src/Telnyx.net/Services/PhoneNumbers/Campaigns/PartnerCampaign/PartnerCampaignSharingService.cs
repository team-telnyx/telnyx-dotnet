using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.Campaigns.PartnerCampaign;

namespace Telnyx.net.Services.PhoneNumbers.Campaigns.PartnerCampaign
{
    public class PartnerCampaignSharingService : ServiceNested<PartnerCampaignSharing>
    {
        public override string BasePath => "/campaign/:campaignId/sharing";

        /// <inheritdoc/>
        public PartnerCampaignSharing Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetNestedEntity(id, null, null, requestOptions, "data");
        }

        /// <inheritdoc/>
        public async Task<PartnerCampaignSharing> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetNestedEntityAsync(id, null, null, requestOptions, string.Empty, cancellationToken);
        }

    }
}
