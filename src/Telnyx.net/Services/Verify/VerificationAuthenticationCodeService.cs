using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Verify;

namespace Telnyx.net.Services.Verify
{
    internal class VerificationAuthenticationCodeService : Service<TwoFACode>
    {
        internal VerificationAuthenticationCodeService()
       : base(null)
        {
        }
        internal VerificationAuthenticationCodeService(string apiKey)
            : base(apiKey)
        {
        }
        public override string BasePath => "/2fa_verifications/by_tn";
        public override string PostPath => "/actions/verify";

        public async Task<TwoFACode> PostAsync(string phone, TwoFACodeOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(phone, this.PostPath, options, requestOptions, ct);
        }
        public TwoFACode Post(string phone, TwoFACodeOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(phone, this.PostPath, options, requestOptions);
        }
    }
}
