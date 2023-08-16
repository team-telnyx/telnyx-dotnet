namespace Telnyx.net.Services.Calls.ConferenceCommands.Participants
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    public class ConferenceDialParticipantService : Service<TelnyxApiResponse>
    {
        public ConferenceDialParticipantService()
        : base(null)
        {
        }

        public ConferenceDialParticipantService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/conferences";

        public override string PostPath => "/actions/dial_participant";

        public TelnyxApiResponse DialParticipants(string conferenceId, DialParticipantOptions options = null, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(conferenceId, this.PostPath, options, requestOptions, string.Empty);
        }

        public async Task<TelnyxApiResponse> DialParticipantsAsync(string conferenceId, DialParticipantOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(conferenceId, this.PostPath, options, requestOptions, string.Empty, cancellationToken);
        }
    }
}
