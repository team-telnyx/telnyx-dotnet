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
    internal class VerificationAuthenticationPhoneService : Service<TwoFA>
    {
        internal VerificationAuthenticationPhoneService()
       : base(null)
        {
        }
        internal VerificationAuthenticationPhoneService(string apiKey)
            : base(apiKey)
        {
        }
        public override string BasePath => "/2fa_verifications/by_tn";

        public async Task<TelnyxList<TwoFA>> GetAsync(string phone, ListOptions listOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(phone, listOptions, requestOptions, ct);
        }
        public TelnyxList<TwoFA> Get(string phone, ListOptions listOptions, RequestOptions requestOptions = null)
        {
            return this.ListEntities(phone, listOptions, requestOptions);
        }
    }
}
