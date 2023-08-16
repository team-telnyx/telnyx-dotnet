namespace Telnyx.net.Services.Calls.ConferenceCommands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Calls.ConferenceCommands;

    public class ConferenceService : Service<Conference>
    {
        public override string BasePath => "/conferences";

        public virtual Conference RetrieveConference(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }

        public async Task<Conference> RetrieveConferenceAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, requestOptions, string.Empty, ct);
        }
    }
}
