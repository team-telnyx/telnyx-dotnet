namespace Telnyx.net.Services.VerifyAPI
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.VerifyAPI;

    internal class VerificationCodeService : Service<VerifyCode>
    {
        internal VerificationCodeService()
       : base(null)
        {
        }

        internal VerificationCodeService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/verifications/by_phone_number";

        public override string PostPath => "actions/verify";

        public async Task<VerifyCode> PostAsync(string phone, VerifyCodeOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(phone, this.PostPath, options, requestOptions, string.Empty, ct);
        }

        public VerifyCode Post(string phone, VerifyCodeOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(phone, this.PostPath, options, requestOptions, string.Empty);
        }
    }
}
