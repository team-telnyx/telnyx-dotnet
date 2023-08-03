namespace Telnyx.net.Services.AccessIPRange
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.AccessIPRanges;

    public class AcessIPRangesService : Service<AccessIPRanges>
    {
        private string parentToken;

        public AcessIPRangesService()
           : base(null)
        {
        }

        public AcessIPRangesService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/access_ip_ranges";

        public TelnyxList<AccessIPRanges> ListAllAccessIPRanges(AccessIPRangesListOption listOptions, RequestOptions reqOpts = null)
        {
            return this.ListEntities(listOptions, reqOpts);
        }

        public async Task<TelnyxList<AccessIPRanges>> ListAllAccessIPRangesAsync(AccessIPRangesListOption listOptions, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOptions, reqOpts, string.Empty, ct);
        }

        public AccessIPRanges CreateAllAccessIPRanges(AccessIPRangesCreateOption createOptions, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(createOptions, reqOpts);
        }

        public async Task<AccessIPRanges> CreateAllAccessIPRangesAsync(AccessIPRangesCreateOption createOptions, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(createOptions, reqOpts, cancellationToken: ct);
        }

        public AccessIPRanges DeleteAllAccessIPRanges(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions);
        }

        public async Task<AccessIPRanges> DeleteAllAccessIPRangesAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, string.Empty, ct).ConfigureAwait(false);
        }
    }
}
