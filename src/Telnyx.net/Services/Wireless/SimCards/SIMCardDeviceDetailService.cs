using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.SimCards;

namespace Telnyx.net.Services.Wireless.SimCards.SIMCardDeviceDetails
{
    public class SIMCardDeviceDetailService : ServiceNested<SIMCardDeviceDetail>
    {
        public override string BasePath => "/sim_cards/:sim_card_id/device_details";

        /// <inheritdoc/>
        public SIMCardDeviceDetail Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetNestedEntity(id, null, null, requestOptions, "data");
        }

        /// <inheritdoc/>
        public async Task<SIMCardDeviceDetail> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetNestedEntityAsync(id, null, null, requestOptions, string.Empty, cancellationToken);
        }
    }
}
