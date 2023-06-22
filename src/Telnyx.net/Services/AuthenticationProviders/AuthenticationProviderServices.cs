using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Telnyx.net.Entities.AuthenticationProviders;
using Telnyx.net.Entities;
using Telnyx.net.Entities.AuthenticationProviders;
using Telnyx.net.Services;

namespace Telnyx.net.Services.AuthentictionProvider
{
    public class AuthenticationProviderService : Service<AuthenticationProviders>
    {
        private string parentToken;

        public AuthenticationProviderService()
           : base(null) { }

        public AuthenticationProviderService(string apiKey)
            : base(apiKey) { }

        public override string BasePath => "/authentication_providers";
        public TelnyxList<AuthenticationProviders> ListAuthenticationProviders(AuthenticationProviderListOption listOption, RequestOptions reqOpts = null)
        {
            return this.ListEntities(listOption, reqOpts);
        }

        public async Task<TelnyxList<AuthenticationProviders>> ListAuthenticationProvidersAsync(AuthenticationProviderListOption listOption, RequestOptions reqOpts = null)
        {
            return await this.ListEntitiesAsync(listOption, reqOpts, parentToken = "");
        }

        public AuthenticationProviders CreateAuthenticationProviders(AuthenticationProviderCreateOption createOptions, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(createOptions, reqOpts);
        }

        public async Task<AuthenticationProviders> CreateAuthenticationProvidersAsync(AuthenticationProviderCreateOption createOptions, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(createOptions, reqOpts, ct);
        }
        public AuthenticationProviders DeleteAuthenticationProviders(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions);
        }

        public async Task<AuthenticationProviders> DeleteAuthenticationProvidersAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, ct).ConfigureAwait(false);
        }
        public AuthenticationProviders UpdateAuthenticationProviders(string id, AuthenticationProviderCreateOption createOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, createOptions, requestOptions);
        }

        public async Task<AuthenticationProviders> UpdateAuthenticationProvidersAsync(string id, AuthenticationProviderCreateOption createOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, createOptions, requestOptions, ct).ConfigureAwait(false);
        }
        public async Task<AuthenticationProviders> RetrieveAuthenticationProvidersAsync(string id, RequestOptions reqOpts = null)
        {
            return await this.GetEntityAsync(id, reqOpts);
        }

        public AuthenticationProviders RetrieveAuthenticationProviders(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts);
        }
    }
}
