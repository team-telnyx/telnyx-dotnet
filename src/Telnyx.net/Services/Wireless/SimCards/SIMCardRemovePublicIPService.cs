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
        public override string BasePath => "/sim_cards/:id/actions/remove_public_ip";

        public SettingSIMCardPublicIP Create(string parentId, BaseOptions options, RequestOptions requestOptions)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public async Task<SettingSIMCardPublicIP> CreateAsync(string parentId, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, parentToken, cancellationToken);
        }
    }
}
