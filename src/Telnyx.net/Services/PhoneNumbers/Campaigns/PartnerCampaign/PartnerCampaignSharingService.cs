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
        public override string BasePath => "/10dlc/campaign/{PARENT_ID}/sharing";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            if (string.IsNullOrEmpty(parentId) || parentId == "." || parentId == "..")
            {
                throw new ArgumentException("A non-empty campaign ID path segment is required.", nameof(parentId));
            }

            return base.ClassUrl(Uri.EscapeDataString(parentId), baseUrl);
        }

        /// <inheritdoc/>
        public PartnerCampaignSharing Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetRequest<PartnerCampaignSharing>(this.ClassUrl(id), null, requestOptions, false, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<PartnerCampaignSharing> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetRequestAsync<PartnerCampaignSharing>(this.ClassUrl(id), null, requestOptions, false, string.Empty, cancellationToken);
        }

    }
}
