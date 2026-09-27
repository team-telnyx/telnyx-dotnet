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
        public override string BasePath => "/sim_cards/{PARENT_ID}/actions/set_public_ip";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            // Ref: canonical action path parameter schema requires a UUID.
            if (!Guid.TryParse(parentId, out _))
            {
                throw new ArgumentException("The action parent ID must be a UUID.", nameof(parentId));
            }

            return base.ClassUrl(parentId, baseUrl);
        }

        /// <inheritdoc/>
        public SettingSIMCardPublicIP Create(string parentId, BaseOptions options, RequestOptions requestOptions)
        {
            return BodylessActionRequest.Send<SettingSIMCardPublicIP>(this.ActionUrl(parentId, options), this.SetupRequestOptions(requestOptions));
        }

        public async Task<SettingSIMCardPublicIP> CreateAsync(string parentId, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await BodylessActionRequest.SendAsync<SettingSIMCardPublicIP>(this.ActionUrl(parentId, options), this.SetupRequestOptions(requestOptions), parentToken, cancellationToken);
        }

        private string ActionUrl(string parentId, BaseOptions options)
        {
            var url = this.ClassUrl(parentId);
            // The action has no request body; region_code is an optional query parameter.
            if (options?.ExtraParams != null && options.ExtraParams.TryGetValue("region_code", out var regionCode))
            {
                url = Telnyx.Infrastructure.ParameterBuilder.ApplyParameterToUrl(url, "region_code", regionCode);
            }

            return url;
        }
    }
}
