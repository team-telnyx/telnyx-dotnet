namespace Telnyx.net.Services.Calls.CallControl.Refer
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    internal class CallControlReferService : Service<TelnyxApiResponse>
    {
        public CallControlReferService()
           : base(null)
        {
        }

        public CallControlReferService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/calls";

        public override string PostPath => "actions/refer";

        public TelnyxApiResponse Refer(string id, ReferOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.PostPath, options, requestOptions, string.Empty);
        }

        public async Task<TelnyxApiResponse> ReferAsync(string id, ReferOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.PostPath, options, requestOptions, string.Empty, ct);
        }
    }
}
