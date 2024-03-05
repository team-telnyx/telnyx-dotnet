using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.NumberBlockOrders;

namespace Telnyx.net.Services.PhoneNumbers.NumberBlockOrders
{
    public class NumberBlockOrderService : Service<NumberBlockOrder>
    {
        public override string BasePath => "/number_block_orders";

        public async Task<TelnyxList<NumberBlockOrder>> ListNumberBlockOrdersAsync(NumberBlockOrderOptions options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<NumberBlockOrder> ListNumberBlockOrders(NumberBlockOrderOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<NumberBlockOrder> GetNumberBlockOrderAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public NumberBlockOrder GetNumberBlockOrder(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public async Task<NumberBlockOrder> CreateNumberBlockOrderAsync(UpsertNumberBlockOrder options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public NumberBlockOrder CreateNumberBlockOrder(UpsertNumberBlockOrder options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

    }
}
