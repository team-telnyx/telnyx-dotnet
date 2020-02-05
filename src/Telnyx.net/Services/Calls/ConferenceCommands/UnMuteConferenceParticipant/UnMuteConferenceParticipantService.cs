namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// UnMuteConferenceParticipantService
    /// </summary>
    public class UnMuteConferenceParticipantService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, MuteConferenceCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnMuteConferenceParticipantService"/> class.
        /// </summary>
        public UnMuteConferenceParticipantService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnMuteConferenceParticipantService"/> class.
        /// </summary>
        /// <param name="apiKey">api key</param>
        public UnMuteConferenceParticipantService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, MuteConferenceCreateOptions options, string postFix = "actions/unmute", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public Task<CallAnswerResponse> CreateAsync(string parentId, MuteConferenceCreateOptions createOptions, string postFix = "actions/unmute", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}