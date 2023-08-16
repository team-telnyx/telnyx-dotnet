namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// HoldConferenceService.
    /// </summary>
    public class HoldConferenceService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, HoldConferenceOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HoldConferenceService"/> class.
        /// </summary>
        public HoldConferenceService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HoldConferenceService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public HoldConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, HoldConferenceOptions options, string postFix = "actions/hold", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, HoldConferenceOptions createOptions, string postFix = "actions/hold", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}