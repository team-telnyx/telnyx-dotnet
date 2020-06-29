namespace Telnyx.net.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.NumberLookup;

    public class NumberLookupService : Service<NumberLookupRecord>,
        IListable<NumberLookupRecord, NumberLookupRecordListOptions>
    {
        public override string BasePath => "/number_lookup";

        public TelnyxList<NumberLookupRecord> List(NumberLookupRecordListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.List(listOptions, requestOptions);
        }

        public async Task<TelnyxList<NumberLookupRecord>> ListAsync(NumberLookupRecordListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListAsync(listOptions, requestOptions, cancellationToken);
        }
    }
}
