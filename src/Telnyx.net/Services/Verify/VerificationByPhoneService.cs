namespace Telnyx.net.Services.VerifyAPI
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.VerifyAPI;

    internal class VerificationByPhoneService : Service<Verify>
    {
        internal VerificationByPhoneService()
       : base(null)
        {
        }

        internal VerificationByPhoneService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/verifications/by_phone_number/";

        public async Task<TelnyxList<Verify>> GetAsync(string phone, ListOptions listOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(phone, listOptions, requestOptions, string.Empty, null, ct);
        }

        public TelnyxList<Verify> Get(string phone, ListOptions listOptions, RequestOptions requestOptions = null)
        {
            return this.ListEntities(phone, listOptions, requestOptions);
        }
    }
}
