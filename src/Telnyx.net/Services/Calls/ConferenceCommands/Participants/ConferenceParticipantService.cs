namespace Telnyx.net.Services.Calls.ConferenceCommands.Participants
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Participants;

    public class ConferenceParticipantService : Service<Participant>
    {
        public ConferenceParticipantService()
        : base(null)
        {
        }

        public ConferenceParticipantService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/conferences";

        public override string PostPath => "/participants";

        public TelnyxList<Participant> ListParticipants(string id, ParticipantListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(this.PostPath, listOptions, requestOptions, id);
        }

        public async Task<TelnyxList<Participant>> ListParticipantsAsync(string id, ParticipantListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(this.PostPath, listOptions, requestOptions, string.Empty, id, cancellationToken);
        }
    }
}
