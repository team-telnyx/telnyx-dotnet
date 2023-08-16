namespace Telnyx.net.Services.Calls.CallControl.RecordActions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    internal class RecordActionService : Service<TelnyxApiResponse>
    {
        public RecordActionService()
            : base(null)
        {
        }

        public RecordActionService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/calls";

        private string RecordPausePath => "actions/record_pause";

        private string RecordResumePath => "actions/record_resume";

        private string RecordStartPath => "actions/record_start";

        private string RecordStopPath => "actions/record_stop";

        public TelnyxApiResponse Pause(string id, RecordActionOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.RecordPausePath, options, requestOptions, string.Empty);
        }

        public TelnyxApiResponse Resume(string id, RecordActionOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.RecordResumePath, options, requestOptions, string.Empty);
        }

        public TelnyxApiResponse Start(string id, RecordStartOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.RecordStartPath, options, requestOptions, string.Empty);
        }

        public TelnyxApiResponse Stop(string id, RecordActionOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.RecordStopPath, options, requestOptions, string.Empty);
        }

        public async Task<TelnyxApiResponse> PauseAsync(string id, RecordActionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.RecordPausePath, options, requestOptions, string.Empty, ct);
        }

        public async Task<TelnyxApiResponse> ResumeAsync(string id, RecordActionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.RecordResumePath, options, requestOptions, string.Empty, ct);
        }

        public async Task<TelnyxApiResponse> StartAsync(string id, RecordStartOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.RecordStartPath, options, requestOptions, string.Empty, ct);
        }

        public async Task<TelnyxApiResponse> StopAsync(string id, RecordActionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.RecordStopPath, options, requestOptions, string.Empty, ct);
        }
    }
}
