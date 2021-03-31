using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;

namespace Telnyx.net.Services.Calls.CallControl.RecordActions
{
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

        private string recordPausePath => "/actions/record_pause";

        private string recordResumePath => "/actions/record_resume";

        private string recordStartPath => "/actions/record_start";

        private string recordStopPath => "/actions/record_stop";

        public TelnyxApiResponse Pause(string id, RecordActionOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, recordPausePath, options, requestOptions);
        }

        public TelnyxApiResponse Resume(string id, RecordActionOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, recordResumePath, options, requestOptions);
        }

        public TelnyxApiResponse Start(string id, RecordStartOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, recordStartPath, options, requestOptions);
        }

        public TelnyxApiResponse Stop(string id, RecordActionOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, recordStopPath, options, requestOptions);
        }

        public async Task<TelnyxApiResponse> PauseAsync(string id, RecordActionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, recordPausePath, options, requestOptions, ct);
        }

        public async Task<TelnyxApiResponse> ResumeAsync(string id, RecordActionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, recordResumePath, options, requestOptions, ct);
        }

        public async Task<TelnyxApiResponse> StartAsync(string id, RecordStartOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, recordStartPath, options, requestOptions, ct);
        }

        public async Task<TelnyxApiResponse> StopAsync(string id, RecordActionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, recordStopPath, options, requestOptions, ct);
        }
    }
}
