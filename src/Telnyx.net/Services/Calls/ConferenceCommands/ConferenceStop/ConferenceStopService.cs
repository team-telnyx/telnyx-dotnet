namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferenceStop
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    class ConferenceStopService : Service<TelnyxApiResponse>
    {
        public ConferenceStopService()
            : base(null)
        {
        }

        public ConferenceStopService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/conferences";

        public override string PostPath => "/actions/stop";

        public TelnyxApiResponse Stop(string id, StopAudioOptions stopOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.PostPath, stopOptions, requestOptions, "data");
        }

        public async Task<TelnyxApiResponse> StopAsync(string id, StopAudioOptions stopOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.PostPath, stopOptions, requestOptions, "data", ct);
        }
    }
}
