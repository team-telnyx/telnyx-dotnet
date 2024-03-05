using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.SettingSIMCardPublicIPs;

namespace Telnyx.net.Services.Wireless.SettingSIMCardPublicIPs
{
    public class SettingSIMCardPublicIPService : ServiceNested<SettingSIMCardPublicIP>
    {
        public override string BasePath => "/sim_cards/:id/actions/set_public_ip";

        /// <inheritdoc/>
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
