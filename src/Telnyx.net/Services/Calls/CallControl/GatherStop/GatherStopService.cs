namespace Telnyx.net.Services.Calls.CallControl.GatherStop
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    internal class GatherStopService : Service<TelnyxApiResponse>
    {
        public override string BasePath => "/calls";

        public override string PostPath => "actions/gather_stop";

        public GatherStopService()
            : base(null)
        {
        }

        public GatherStopService(string apiKey)
            : base(apiKey)
        {
        }

        public TelnyxApiResponse Stop(string id, GatherStopOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.PostPath, options, requestOptions, string.Empty);
        }

        public async Task<TelnyxApiResponse> StopAsync(string id, GatherStopOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.PostPath, options, requestOptions, string.Empty, ct);
        }
    }
}
