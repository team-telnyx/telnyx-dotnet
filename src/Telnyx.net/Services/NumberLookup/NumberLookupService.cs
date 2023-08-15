namespace Telnyx.net.Services
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.NumberLookup;

    public class NumberLookupService : Service<NumberLookupRecord>
    {
        public override string BasePath => "/number_lookup";

        public NumberLookupRecord Get(string number, NumberLookupRecordOptions options, RequestOptions requestOptions = null)
        {
            return this.GetEntity(number, options, requestOptions, parentToken: "data");
        }

        public async Task<NumberLookupRecord> GetAsync(string number, NumberLookupRecordOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(number, options, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
