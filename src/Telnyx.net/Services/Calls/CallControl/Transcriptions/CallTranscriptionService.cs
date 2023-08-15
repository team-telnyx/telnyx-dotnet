namespace Telnyx.net.Services.Calls.CallControl.Transcriptions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    internal class CallTranscriptionService : Service<TelnyxApiResponse>
    {
        public CallTranscriptionService()
            : base(null)
        {
        }

        public CallTranscriptionService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/calls";

        private string transcriptionStartPath => "actions/transcription_start";

        private string transcriptionStopPath => "actions/transcription_stop";

        public async Task<TelnyxApiResponse> StartAsync(string id, TranscriptionStartOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.transcriptionStartPath, options, requestOptions, string.Empty, ct);
        }

        public async Task<TelnyxApiResponse> StopAsync(string id, TranscriptionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.transcriptionStopPath, options, requestOptions, string.Empty, ct);
        }

        public TelnyxApiResponse Start(string id, TranscriptionStartOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.transcriptionStartPath, options, requestOptions, string.Empty);
        }

        public TelnyxApiResponse Stop(string id, TranscriptionOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.transcriptionStopPath, options, requestOptions, string.Empty);
        }
    }
}
