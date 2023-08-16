namespace Telnyx.net.Services.VerifyAPI
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.VerifyAPI;

    internal class VerificationAuthenticationService : Service<Verify>
    {
        internal VerificationAuthenticationService()
       : base(null)
        {
        }

        internal VerificationAuthenticationService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/verifications";

        public async Task<Verify> CreateAsync(VerifyOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, requestOptions, cancellationToken: ct);
        }

        public Verify Create(VerifyOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public async Task<Verify> GetAsync(string id, RequestOptions requestOptions, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, requestOptions, string.Empty, ct);
        }

        public Verify Get(string id, RequestOptions requestOptions)
        {
            return this.GetEntity(id, requestOptions);
        }
    }
}
