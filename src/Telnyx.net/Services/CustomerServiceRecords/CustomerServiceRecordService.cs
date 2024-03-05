using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.CustomerServiceRecords;

namespace Telnyx.net.Services.PhoneNumbers.CustomerServiceRecords
{
    public class CustomerServiceRecordService : Service<CustomerServiceRecord>
    {
        public override string BasePath => "/customer_service_records";

        public async Task<TelnyxList<CustomerServiceRecord>> ListCustomerServiceRecordAsync(CustomerServiceRecordOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<CustomerServiceRecord> ListCustomerServiceRecord(CustomerServiceRecordOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<CustomerServiceRecord> GetCustomerServiceRecordAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public CustomerServiceRecord GetCustomerServiceRecord(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public async Task<CustomerServiceRecord> CreateCustomerServiceRecordAsync(UpsertCustomerServiceRecord options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public CustomerServiceRecord CreateCustomerServiceRecord(UpsertCustomerServiceRecord options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
