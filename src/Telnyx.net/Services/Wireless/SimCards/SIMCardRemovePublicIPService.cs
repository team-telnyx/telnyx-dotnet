using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.SettingSIMCardPublicIPs;
using Telnyx.net.Entities.Wireless.SimCards;

namespace Telnyx.net.Services.Wireless.SimCards.SIMCardRemovePublicIPs
{
    public class SIMCardRemovePublicIPService : ServiceNested<SettingSIMCardPublicIP>
    {
        public override string BasePath => "/sim_cards/{PARENT_ID}/actions/remove_public_ip";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            // Ref: canonical action path parameter schema requires a UUID.
            if (!Guid.TryParse(parentId, out _))
            {
                throw new ArgumentException("The action parent ID must be a UUID.", nameof(parentId));
            }

            return base.ClassUrl(parentId, baseUrl);
        }

        public SettingSIMCardPublicIP Create(string parentId, BaseOptions options, RequestOptions requestOptions)
        {
            return BodylessActionRequest.Send<SettingSIMCardPublicIP>(this.ClassUrl(parentId), this.SetupRequestOptions(requestOptions));
        }

        public async Task<SettingSIMCardPublicIP> CreateAsync(string parentId, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await BodylessActionRequest.SendAsync<SettingSIMCardPublicIP>(this.ClassUrl(parentId), this.SetupRequestOptions(requestOptions), parentToken, cancellationToken);
        }
    }
}
