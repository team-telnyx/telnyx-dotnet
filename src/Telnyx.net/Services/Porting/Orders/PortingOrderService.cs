using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Porting.Orders;

namespace Telnyx.net.Services.Porting.Orders
{
    public class PortingOrderService : Service<PortOrder>
    {
        public PortingOrderService()
            : base(null)
        {
        }

        public PortingOrderService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/porting_orders";

        public async Task<TelnyxList<PortOrder>> ListAsync(PortingOrderListOptions listOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, ct);
        }

        public TelnyxList<PortOrder> List(PortingOrderListOptions listOptions, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public async Task<TelnyxList<PortOrder>> CreateAsync(PortingOrderCreateOptions createOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsListAsync(createOptions, requestOptions, ct);
        }

        public TelnyxList<PortOrder> Create(PortingOrderCreateOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntityAsList(createOptions, requestOptions);
        }

        public async Task<PortOrder> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, ct);
        }

        public PortOrder Delete(string id, RequestOptions requestOptions)
        {
            return this.DeleteEntity(id, requestOptions);
        }

        public async Task<PortOrder> RetrieveAsync(string id, bool includePhoneNumbers = true, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            var baseOptions = new BaseOptions();
            baseOptions.AddExtraParam("include_phone_numbers", includePhoneNumbers.ToString());
            return await this.GetEntityAsync(id, baseOptions, requestOptions, ct);
        }

        public PortOrder Retrieve(string id, bool includePhoneNumbers = true, RequestOptions requestOptions = null)
        {
            var baseOptions = new BaseOptions();
            baseOptions.AddExtraParam("include_phone_numbers", includePhoneNumbers.ToString());
            return this.GetEntity(id, baseOptions, requestOptions);
        }

        //TODO: Revisit logic for explicit null values when editing a porting order
        public async Task<PortOrder> EditAsync(string id, EditPortingOrderOptions orderToEdit, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, orderToEdit, requestOptions, ct);
        }

        public PortOrder Edit(string id, EditPortingOrderOptions orderToEdit, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, orderToEdit, requestOptions);
        }



    }
}
