using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Verify;

namespace Telnyx.net.Services.Verify
{
    internal class VerificationAuthenticationPhoneService : Service<TwoFABase>
    {
        public override string BasePath => "/2fa_verifications/by_tn/";
        public override string PostPath => "/actions/verify";

        public async Task<TwoFA> GetAsync(string phone, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return (TwoFA)await this.GetEntityAsync(phone, requestOptions, ct);
        }
        public TwoFA Get(string phone, RequestOptions requestOptions = null)
        {
            return (TwoFA)this.GetEntity(phone, requestOptions);
        }
        public async Task<TwoFACode> GetCodeAsync(string phone, TwoFACodeOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return (TwoFACode)await this.GetEntityAsync(phone, options, requestOptions, ct, postPath: this.PostPath);
        }
        public TwoFACode GetCode(string phone, TwoFACodeOptions options, RequestOptions requestOptions = null)
        {
            return (TwoFACode)this.GetEntity(phone, options, requestOptions, postPath: this.PostPath);
        }
    }
}
