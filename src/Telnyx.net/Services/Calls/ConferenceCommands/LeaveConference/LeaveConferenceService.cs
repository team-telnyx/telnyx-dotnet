namespace Telnyx.net.Services.Calls.ConferenceCommands.LeaveConference
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    class LeaveConferenceService : Service<TelnyxApiResponse>
    {
        public LeaveConferenceService()
            : base(null)
        {
        }

        public LeaveConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/conferences";

        public override string PostPath => "/actions/leave";

        public TelnyxApiResponse Leave(string id, LeaveConferenceOptions leaveOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.PostPath, leaveOptions, requestOptions, "data");
        }

        public async Task<TelnyxApiResponse> LeaveAsync(string id, LeaveConferenceOptions leaveOptions, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.PostPath, leaveOptions, requestOptions, "data", ct);
        }
    }
}
