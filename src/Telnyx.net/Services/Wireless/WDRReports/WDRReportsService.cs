using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.WDRReports;

namespace Telnyx.net.Services.Wireless.WDRReports
{
    public class WDRReportsService : Service<WDRReportsRecord>,
        IListable<WDRReportsRecord, ListWDRReportsOptions>,
        ICreatable<WDRReportsRecord, CreateWDRReportsOptions>,
        IRetrievable<WDRReportsRecord>,
        IDeletable<WDRReportsRecord>
    {
        public override string BasePath => throw new NotImplementedException();

        public TelnyxList<WDRReportsRecord> List(ListWDRReportsOptions listOptions = null, RequestOptions requestOptions = null)
        {
            throw new NotImplementedException();
        }

        public Task<TelnyxList<WDRReportsRecord>> ListAsync(ListWDRReportsOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public WDRReportsRecord Create(CreateWDRReportsOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.Create(createOptions, requestOptions);
        }

        public async Task<WDRReportsRecord> CreateAsync(CreateWDRReportsOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateAsync(createOptions, requestOptions, cancellationToken);
        }

        public WDRReportsRecord Get(string id, RequestOptions requestOptions = null)
        {
            return this.Get(id, requestOptions);
        }

        public async Task<WDRReportsRecord> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetAsync(id, requestOptions);
        }

        public WDRReportsRecord Delete(string id, RequestOptions requestOptions = null)
        {
            return this.Delete(id, requestOptions);
        }

        public async Task<WDRReportsRecord> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteAsync(id, requestOptions);
        }
    }
}
