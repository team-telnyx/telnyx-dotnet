namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlGatherUsingSpeakService
    /// </summary>
    public class CallControlGatherUsingSpeakService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlGatherUsingSpeakCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlGatherUsingSpeakService"/> class.
        /// </summary>
        public CallControlGatherUsingSpeakService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlGatherUsingSpeakService"/> class.
        /// </summary>
        /// <param name="apiKey">api key</param>
        public CallControlGatherUsingSpeakService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlGatherUsingSpeakCreateOptions options, string postFix = "actions/gather_using_speak", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, CallControlGatherUsingSpeakCreateOptions createOptions, string postFix = "actions/gather_using_speak", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}