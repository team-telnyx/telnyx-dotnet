using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;

namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferencePlay
{
    public class ConferencePlayService : Service<TelnyxApiResponse>
    {
        public ConferencePlayService()
            : base(null)
        {
        }

        public ConferencePlayService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/conferences";

        public override string PostPath => "/actions/play";

        private string stopURI => "/actions/stop";

        public TelnyxApiResponse Play(string id, ConferencePlayOptions stopOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.PostPath, stopOptions, requestOptions);
        }

        public async Task<TelnyxApiResponse> PlayAsync(string id, ConferencePlayOptions stopOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.PostPath, stopOptions, requestOptions, ct);
        }

        public TelnyxApiResponse Stop(string id, StopAudioOptions stopOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, stopURI, stopOptions, requestOptions);
        }

        public async Task<TelnyxApiResponse> StopAsync(string id, StopAudioOptions stopOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, stopURI, stopOptions, requestOptions, ct);
        }

    }
}
