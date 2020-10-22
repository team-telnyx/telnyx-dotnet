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
        public override string BasePath => "/2fa_verifications/by_tn";
        public override string PostPath => "/actions/verify";

        public async Task<TwoFACode> GetAsync(string phone, TwoFACodeOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(phone, options, requestOptions, ct, postPath: this.PostPath);
        }
        public TwoFACode Get(string phone, TwoFACodeOptions options, RequestOptions requestOptions = null)
        {
            return this.GetEntity(phone, options, requestOptions, postPath: this.PostPath);
        }
    }
}
