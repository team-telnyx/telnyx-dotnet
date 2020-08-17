namespace Telnyx.net.Services.WebRTC.Credentials
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.WebRTC.Credentials;

    public class TelephonyCredentialService : Service<WebRtcCredential>,
        IListable<WebRtcCredential, ListOptions>
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
