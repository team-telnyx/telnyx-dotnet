using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.WDRReports;

namespace Telnyx.net.Services.Wireless.WDRReports
{
    public class WDRReportsService : Service<WDRReportsRecord>,
        IListable<WDRReportsRecord, ListOptions>,
        ICreatable<WDRReportsRecord, CreateWDRReportsOptions>,
        IRetrievable<WDRReportsRecord>,
        IDeletable<WDRReportsRecord>
    {
        public override string BasePath => "/wireless/detail_records_reports";

        public TelnyxList<WDRReportsRecord> List(ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public Task<TelnyxList<WDRReportsRecord>> ListAsync(ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
        }

        public WDRReportsRecord Create(CreateWDRReportsOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions);
        }

        public async Task<WDRReportsRecord> CreateAsync(CreateWDRReportsOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, cancellationToken);
        }

        public WDRReportsRecord Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }

        public async Task<WDRReportsRecord> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, CancellationToken.None);
        }

        public WDRReportsRecord Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions);
        }

        public async Task<WDRReportsRecord> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, cancellationToken);
        }
    }
}
