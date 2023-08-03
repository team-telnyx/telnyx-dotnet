namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// JoinConferenceService.
    /// </summary>
    public class JoinConferenceService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, JoinConferenceOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JoinConferenceService"/> class.
        /// </summary>
        public JoinConferenceService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinConferenceService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public JoinConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, JoinConferenceOptions options, string postFix = "actions/join", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, JoinConferenceOptions createOptions, string postFix = "actions/join", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}