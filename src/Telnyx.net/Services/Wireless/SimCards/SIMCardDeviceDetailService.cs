using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.SimCards;

namespace Telnyx.net.Services.Wireless.SimCards.SIMCardDeviceDetails
{
    public class SIMCardDeviceDetailService : ServiceNested<SIMCardDeviceDetail>
    {
        public override string BasePath => "/sim_cards/{PARENT_ID}/device_details";

        /// <inheritdoc/>
        public SIMCardDeviceDetail Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetRequest<SIMCardDeviceDetail>(this.ClassUrl(System.Uri.EscapeDataString(id)), null, requestOptions, false, "data");
        }

        /// <inheritdoc/>
        public async Task<SIMCardDeviceDetail> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetRequestAsync<SIMCardDeviceDetail>(this.ClassUrl(System.Uri.EscapeDataString(id)), null, requestOptions, false, "data", cancellationToken);
        }
    }
}
