using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.WebRTC.Credentials;

namespace Telnyx.net.Services.WebRTC.Credentials
{
    public class TelephonyCredentialTagsService : Service<TelephonyCredentialTag>
    {
        public override string BasePath => "/telephony_credentials/tags";

        public async Task<TelnyxList<TelephonyCredentialTag>> ListTelephonyCredentialAsync(TelephonyCredentialTagOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<TelephonyCredentialTag> ListTelephonyCredential(TelephonyCredentialTagOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
