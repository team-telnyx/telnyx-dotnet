using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.BulkCredential;

namespace Telnyx.net.Services.BulkCredentials
{
    public class BulkCredentialService : Service<BulkCredential>
    {
        public override string BasePath => "actions/bulk/telephony_credentials";
        public async Task<BulkCredential> CreateFQDNsAsync(UpsertBulkCredential options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public BulkCredential CreateFQDNs(UpsertBulkCredential options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

        public async Task<BulkCredential> DeleteAccessFQDNsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, parentToken: "data", ct);
        }
        public BulkCredential DeleteAccessFQDNs(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts, parentToken: "data");
        }

        public async Task<BulkCredential> UpdateFQDNsAsync(string id, UpsertBulkCredential options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, options, reqOpts, "data", ct);
        }

        public BulkCredential UpdateFQDNs(string id, UpsertBulkCredential options, RequestOptions reqOpts = null)
        {
            return this.UpdateEntity(id, options, reqOpts, "data");
        }

    }
}
