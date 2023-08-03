namespace Telnyx.net.Services.ManagedAccounts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.ManagedAccounts;

    public class ManagedAccountService : Service<ManagedAccount>
    {
        public ManagedAccountService()
           : base(null)
        {
        }

        public ManagedAccountService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/managed_accounts";

        public async Task<TelnyxList<ManagedAccount>> ListManagedAccountsAsync(ManagedAccountListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<ManagedAccount> ListManagedAccounts(ManagedAccountListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<ManagedAccount> RetrieveManagedAccountAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, string.Empty, ct);
        }

        public ManagedAccount RetrieveManagedAccount(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, string.Empty);
        }

        public ManagedAccount CreateManagedAccount(CreateManagedAccountOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions, parentToken: "data");
        }

        public Task<ManagedAccount> CreateManagedAccountAsync(CreateManagedAccountOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }

        public async Task<ManagedAccount> DeleteCredentialConnectionAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, reqOpts, string.Empty, ct);
        }

        public ManagedAccount DeleteCredentialConnection(string id, RequestOptions reqOpts = null)
        {
            return this.DeleteEntity(id, reqOpts);
        }
    }
}
