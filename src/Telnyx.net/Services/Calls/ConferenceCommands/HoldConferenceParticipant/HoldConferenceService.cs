namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// HoldConferenceService
    /// </summary>
    public class HoldConferenceService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, HoldConferenceCreateOptions>
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
        /// <param name="apiKey">api key</param>
        public HoldConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, HoldConferenceCreateOptions options, string postFix = "actions/hold", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public Task<CallAnswerResponse> CreateAsync(string parentId, HoldConferenceCreateOptions createOptions, string postFix = "actions/hold", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}