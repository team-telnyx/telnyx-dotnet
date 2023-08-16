namespace Telnyx.net.Services.Calls.ConferenceCommands.ConferencePlay
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

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

        public TelnyxApiResponse Play(string id, ConferencePlayOptions stopOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.PostPath, stopOptions, requestOptions, string.Empty);
        }

        public async Task<TelnyxApiResponse> PlayAsync(string id, ConferencePlayOptions stopOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.PostPath, stopOptions, requestOptions, string.Empty, ct);
        }
    }
}
