namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlGatherUsingSpeakService.
    /// </summary>
    public class CallControlGatherUsingSpeakService : Service<CallGatherUsingSpeakResponse>,
        INestedCreatableWithIdInMid<CallGatherUsingSpeakResponse, CallControlGatherUsingSpeakOptions>
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
        /// <param name="apiKey">api key.</param>
        public CallControlGatherUsingSpeakService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallGatherUsingSpeakResponse Create(string id, CallControlGatherUsingSpeakOptions options, string postFix = "actions/gather_using_speak", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallGatherUsingSpeakResponse> CreateAsync(string parentId, CallControlGatherUsingSpeakOptions createOptions, string postFix = "actions/gather_using_speak", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}