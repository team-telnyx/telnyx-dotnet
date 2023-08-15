namespace Telnyx.net.Services.WebRTC.Credentials
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.WebRTC.Credentials;

    public class TelephonyCredentialService : Service<WebRtcCredential>,
        IListable<WebRtcCredential, ListOptions>,
        ICreatable<WebRtcCredential, TelephonyCredentialCreateOptions>,
        IRetrievable<WebRtcCredential>,
        IUpdatable<WebRtcCredential, TelephonyCredentialUpdateOptions>,
        IDeletable<WebRtcCredential>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TelephonyCredentialService"/> class.
        /// </summary>
        public TelephonyCredentialService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephonyCredentialService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public TelephonyCredentialService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/telephony_credentials";

        public WebRtcCredential Create(TelephonyCredentialCreateOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions, parentToken: "data");
        }

        public async Task<WebRtcCredential> CreateAsync(TelephonyCredentialCreateOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }

        public WebRtcCredential Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions, parentToken: "data");
        }

        public async Task<WebRtcCredential> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, requestOptions, parentToken: "data", cancellationToken);
        }

        public TelnyxList<WebRtcCredential> List(ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public async Task<TelnyxList<WebRtcCredential>> ListAsync(ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, cancellationToken);
        }

        public WebRtcCredential Update(string id, TelephonyCredentialUpdateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions, parentToken: "data");
        }

        public async Task<WebRtcCredential> UpdateAsync(string id, TelephonyCredentialUpdateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, parentToken: "data", cancellationToken);
        }

        public WebRtcCredential Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions, parentToken: "data");
        }

        public async Task<WebRtcCredential> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, parentToken: "data", cancellationToken);
        }

        public string GetToken(string id, RequestOptions requestOptions = null, string postFix = "token")
        {
            return this.CreateEntity(id, postFix, null, requestOptions, false);
        }

        public async Task<string> GetTokenAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default, string postFix = "token")
        {
            return await this.CreateEntityAsync(id, postFix, null, requestOptions, false, string.Empty, cancellationToken);
        }
    }
}
