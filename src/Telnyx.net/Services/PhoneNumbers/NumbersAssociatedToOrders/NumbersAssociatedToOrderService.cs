namespace Telnyx.net.Services.PhoneNumbers.NumbersAssociatedToOrders
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.NumbersAssociatedToOrders;

    public class NumbersAssociatedToOrderService : Service<NumbersAssociatedToOrder>
    {
        public NumbersAssociatedToOrderService()
           : base(null)
        {
        }

        public NumbersAssociatedToOrderService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/number_order_phone_numbers";

        public async Task<TelnyxList<NumbersAssociatedToOrder>> ListNumbersAssociatedToOrdersAsync(RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(null, reqOpts, string.Empty, ct);
        }

        public TelnyxList<NumbersAssociatedToOrder> ListNumbersAssociatedToOrders(RequestOptions reqOpts = null)
        {
            return this.ListEntities(null, reqOpts);
        }

        public async Task<NumbersAssociatedToOrder> RetrieveNumbersAssociatedToOrdersAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, parentToken: "data", ct);
        }

        public NumbersAssociatedToOrder RetrieveNumbersAssociatedToOrders(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts, parentToken: "data");
        }

        public async Task<NumbersAssociatedToOrder> UpdateNumbersAssociatedToOrderAsync(string id, UpdateNumbersAssociatedToOrderOptions updateOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, reqOps, parentToken: "data", cancellationToken: ct);
        }

        public NumbersAssociatedToOrder UpdateNumbersAssociatedToOrder(string id, UpdateNumbersAssociatedToOrderOptions updateOptions, RequestOptions reqOps = null)
        {
            return this.UpdateEntity(id, updateOptions, reqOps, parentToken: "data");
        }
    }
}
