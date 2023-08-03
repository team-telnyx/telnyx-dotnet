namespace Telnyx.net.Services.AuthentictionProvider
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.AuthenticationProviders;

    public class AuthenticationProviderService : Service<AuthenticationProviders>
    {
        private string parentToken;

        public AuthenticationProviderService()
           : base(null)
        {
        }

        public AuthenticationProviderService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/authentication_providers";

        public TelnyxList<AuthenticationProviders> ListAuthenticationProviders(AuthenticationProviderListOption listOption, RequestOptions reqOpts = null)
        {
            return this.ListEntities(listOption, reqOpts);
        }

        public async Task<TelnyxList<AuthenticationProviders>> ListAuthenticationProvidersAsync(AuthenticationProviderListOption listOption, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOption, reqOpts, string.Empty, ct);
        }

        public AuthenticationProviders CreateAuthenticationProviders(AuthenticationProviderCreateOption createOptions, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(createOptions, reqOpts, null, "data");
        }

        public async Task<AuthenticationProviders> CreateAuthenticationProvidersAsync(AuthenticationProviderCreateOption createOptions, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(createOptions, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public AuthenticationProviders DeleteAuthenticationProviders(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions, "data");
        }

        public async Task<AuthenticationProviders> DeleteAuthenticationProvidersAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, "data", ct).ConfigureAwait(false);
        }

        public AuthenticationProviders UpdateAuthenticationProviders(string id, AuthenticationProviderCreateOption createOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, createOptions, requestOptions, "data");
        }

        public async Task<AuthenticationProviders> UpdateAuthenticationProvidersAsync(string id, AuthenticationProviderCreateOption createOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, createOptions, requestOptions, "data", ct).ConfigureAwait(false);
        }

        public async Task<AuthenticationProviders> RetrieveAuthenticationProvidersAsync(string id, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, reqOpts, "data", cancellationToken);
        }

        public AuthenticationProviders RetrieveAuthenticationProviders(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts, "data");
        }
    }
}
