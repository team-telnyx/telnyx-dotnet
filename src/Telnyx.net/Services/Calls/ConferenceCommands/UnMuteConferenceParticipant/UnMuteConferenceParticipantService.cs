namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// UnMuteConferenceParticipantService.
    /// </summary>
    public class UnMuteConferenceParticipantService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, MuteConferenceOptions>
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
        /// <param name="apiKey">api key.</param>
        public UnMuteConferenceParticipantService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, MuteConferenceOptions options, string postFix = "actions/unmute", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, MuteConferenceOptions createOptions, string postFix = "actions/unmute", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}