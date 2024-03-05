using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.ESim.GetActivationCodeESIMs;

namespace Telnyx.net.Services.Wireless.ESim
{
    public class GetActivationCodeESIMs : ServiceNested<GetActivationCodeESIM>
    {
        public override string BasePath => "/sim_cards/:sim_card_id/activation_code";

        /// <inheritdoc/>
        public GetActivationCodeESIM Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetNestedEntity(id, null, null, requestOptions, "data");
        }

        /// <inheritdoc/>
        public async Task<GetActivationCodeESIM> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetNestedEntityAsync(id, null, null, requestOptions, string.Empty, cancellationToken);
        }
    }
}
