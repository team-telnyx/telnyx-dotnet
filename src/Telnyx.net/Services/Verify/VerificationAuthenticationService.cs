using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.VerifyAPI;

namespace Telnyx.net.Services.VerifyAPI
{
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
            return await this.CreateEntityAsync(options, requestOptions, ct);
        }
        public Verify Create(VerifyOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }
        public async Task<Verify> GetAsync(string id, RequestOptions requestOptions, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, requestOptions, ct);
        }
        public Verify Get(string id, RequestOptions requestOptions)
        {
            return this.GetEntity(id, requestOptions);
        }
    }
}
