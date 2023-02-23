namespace Telnyx.net.Services
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PortingOrders;

    public class PortingOrderService : Service<PortingOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortingOrderService"/> class.
        /// </summary>
        public PortingOrderService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortingOrderService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public PortingOrderService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "porting_orders";

        public async Task<TelnyxList<PortingOrder>> ListPortingOrdersAsync(PortingOrderOption options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(this.PostPath, options, requestOptions, ct);
        }
    }
}
