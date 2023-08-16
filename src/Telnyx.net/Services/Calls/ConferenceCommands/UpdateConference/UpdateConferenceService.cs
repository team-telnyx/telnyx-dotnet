namespace Telnyx.net.Services.Calls.ConferenceCommands.UpdateConference
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    public class UpdateConferenceService : Service<TelnyxApiResponse>
    {
        public UpdateConferenceService()
            : base(null)
        {
        }

        public UpdateConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/conferences";

        public override string PostPath => "/actions/update";

        public TelnyxApiResponse Leave(string id, UpdateConferenceOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.PostPath, updateOptions, requestOptions, "data");
        }

        public async Task<TelnyxApiResponse> LeaveAsync(string id, UpdateConferenceOptions updateOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.PostPath, updateOptions, requestOptions, "data", ct);
        }
    }
}
