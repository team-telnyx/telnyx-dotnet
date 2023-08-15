namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlForkStopService.
    /// </summary>
    public class CallControlForkStopService : Service<CallForkStopResponse>,
        INestedCreatableWithIdInMid<CallForkStopResponse, CallControlForkStopOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlForkStopService"/> class.
        /// </summary>
        public CallControlForkStopService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlForkStopService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public CallControlForkStopService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallForkStopResponse Create(string id, CallControlForkStopOptions options, string postFix = "actions/fork_stop", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallForkStopResponse> CreateAsync(string parentId, CallControlForkStopOptions createOptions, string postFix = "actions/fork_stop", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}