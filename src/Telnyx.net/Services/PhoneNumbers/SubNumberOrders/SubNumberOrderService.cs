using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.SubNumberOrders;

namespace Telnyx.net.Services.PhoneNumbers.SubNumberOrders
{
    public class SubNumberOrderService : Service<SubNumberOrder>
    {
        public SubNumberOrderService()
            : base(null) { }

        public SubNumberOrderService(string apiKey)
            : base(apiKey) { }

        public override string BasePath => "/sub_number_orders";

        public async Task<TelnyxList<SubNumberOrder>> ListSubNumberOrdersAsync(SubNumberOrderListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }

        public TelnyxList<SubNumberOrder> ListSubNumberOrders(SubNumberOrderListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<SubNumberOrder> RetrieveSubNumberOrdersAsync(string id, RetrieveSubNumberOrderOption options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, ct);
        }
        public SubNumberOrder RetrieveSubNumberOrders(string id, RetrieveSubNumberOrderOption options, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts);
        }
        public async Task<SubNumberOrder> UpdateSubNumberOrderAsync(string id, UpdateSubNumberOrderOptions updateOptions, RequestOptions reqOps = null, CancellationToken ct = default)
        {
            return await this.UpgradeEntityAsync(id, updateOptions, reqOps, ct);
        }
        public SubNumberOrder UpdateSubNumberOrder(string id, UpdateSubNumberOrderOptions updateOptions, RequestOptions reqOps = null)
        {
            return this.UpgradeEntity(id, updateOptions, reqOps);
        }
    }
}