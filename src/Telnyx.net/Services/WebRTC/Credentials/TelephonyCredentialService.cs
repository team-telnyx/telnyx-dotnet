namespace Telnyx.net.Services.WebRTC.Credentials
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.WebRTC.Credentials;

    public class TelephonyCredentialService : Service<WebRtcCredential>,
        IListable<WebRtcCredential, ListOptions>,
        ICreatable<WebRtcCredential, TelephonyCredentialCreateOptions>,
        IRetrievable<WebRtcCredential>
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
            return this.CreateEntity(createOptions, requestOptions);
        }

        public async Task<WebRtcCredential> CreateAsync(TelephonyCredentialCreateOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, cancellationToken);
        }

        public WebRtcCredential Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }

        public async Task<WebRtcCredential> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, requestOptions, cancellationToken);
        }

        public TelnyxList<WebRtcCredential> List(ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public async Task<TelnyxList<WebRtcCredential>> ListAsync(ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
        }
    }
}
