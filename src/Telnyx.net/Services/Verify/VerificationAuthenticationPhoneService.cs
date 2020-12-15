using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.VerifyAPI;

namespace Telnyx.net.Services.VerifyAPI
{
    internal class VerificationAuthenticationPhoneService : Service<Verify>
    {
        internal VerificationAuthenticationPhoneService()
       : base(null)
        {
        }
        internal VerificationAuthenticationPhoneService(string apiKey)
            : base(apiKey)
        {
        }
        public override string BasePath => "/verifications/by_phone_number/";

        public async Task<TelnyxList<Verify>> GetAsync(string phone, ListOptions listOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(phone, listOptions, requestOptions, ct);
        }
        public TelnyxList<Verify> Get(string phone, ListOptions listOptions, RequestOptions requestOptions = null)
        {
            return this.ListEntities(phone, listOptions, requestOptions);
        }
    }
}
