using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.SettingSIMCardPublicIPs;
using Telnyx.net.Entities.Wireless.SimCards;

namespace Telnyx.net.Services.Wireless.SimCards.SIMCardNetworkPreference
{
    public class SIMCardDeleteNetworkPreferenceService : ServiceNested<SettingSIMCardPublicIP>
    {
        public override string BasePath => "/sim_cards/{PARENT_ID}/actions/delete_network_preferences";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            if (parentId == null || parentId.Length != 36 || !Guid.TryParseExact(parentId, "D", out _))
            {
                throw new ArgumentException("The SIM card ID must be a hyphenated UUID.", nameof(parentId));
            }

            return base.ClassUrl(parentId, baseUrl);
        }

        public SettingSIMCardPublicIP Create(string id, BaseOptions options, RequestOptions requestOptions)
        {
            // Ref: openapi@1d97a787, DeleteNetworkPreference has no requestBody.
            // Retain options for source compatibility.
            return BodylessActionRequest.Send<SettingSIMCardPublicIP>(this.ClassUrl(id), this.SetupRequestOptions(requestOptions));
        }

        public async Task<SettingSIMCardPublicIP> CreateAsync(string parentId, BaseOptions options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await BodylessActionRequest.SendAsync<SettingSIMCardPublicIP>(this.ClassUrl(parentId), this.SetupRequestOptions(requestOptions), parentToken, cancellationToken);
        }
    }
}
