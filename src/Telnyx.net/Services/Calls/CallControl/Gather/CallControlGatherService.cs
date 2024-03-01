namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlGatherService.
    /// </summary>
    public class CallControlGatherService : Service<CallGatherResponse>,
        INestedCreatableWithIdInMid<CallGatherResponse, CallControlGatherOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlGatherService"/> class.
        /// </summary>
        public CallControlGatherService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlGatherService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public CallControlGatherService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallGatherResponse Create(string id, CallControlGatherOptions options, string postFix = "actions/gather", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallGatherResponse> CreateAsync(string parentId, CallControlGatherOptions createOptions, string postFix = "actions/gather", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}