namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// UnHoldConferenceService.
    /// </summary>
    public class UnHoldConferenceService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, HoldConferenceOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnHoldConferenceService"/> class.
        /// </summary>
        public UnHoldConferenceService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnHoldConferenceService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public UnHoldConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, HoldConferenceOptions options, string postFix = "actions/unhold", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, HoldConferenceOptions createOptions, string postFix = "actions/unhold", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}