namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// MuteConferenceService
    /// </summary>
    public class MuteConferenceService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, MuteConferenceCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MuteConferenceService"/> class.
        /// </summary>
        public MuteConferenceService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MuteConferenceService"/> class.
        /// </summary>
        /// <param name="apiKey">api key</param>
        public MuteConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, MuteConferenceCreateOptions options, string postFix = "actions/mute", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, MuteConferenceCreateOptions createOptions, string postFix = "actions/mute", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}