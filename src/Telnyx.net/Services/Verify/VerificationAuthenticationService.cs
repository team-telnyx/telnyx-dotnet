using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Verify;

namespace Telnyx.net.Services.Verify
{
    internal class VerificationAuthenticationService : Service<TwoFA>
    {
        public override string BasePath => "/2fa_verifications";

        public async Task<TwoFA> CreateAsync(TwoFAOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, requestOptions, ct);
        }
        public TwoFA Create(TwoFAOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }
        public async Task<TwoFA> GetAsync(string id, RequestOptions requestOptions, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, requestOptions, ct);
        }
        public TwoFA Get(string id, RequestOptions requestOptions)
        {
            return this.GetEntity(id, requestOptions);
        }
    }
}
