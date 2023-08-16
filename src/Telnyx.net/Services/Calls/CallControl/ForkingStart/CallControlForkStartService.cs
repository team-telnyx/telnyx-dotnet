namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlForkStartService.
    /// </summary>
    public class CallControlForkStartService : Service<CallForkStartResponse>,
        INestedCreatableWithIdInMid<CallForkStartResponse, CallControlForkStartOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlForkStartService"/> class.
        /// </summary>
        public CallControlForkStartService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlForkStartService"/> class.
        /// /.</summary>
        /// <param name="apiKey">api key.</param>
        public CallControlForkStartService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallForkStartResponse Create(string id, CallControlForkStartOptions options, string postFix = "actions/fork_start", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallForkStartResponse> CreateAsync(string parentId, CallControlForkStartOptions createOptions, string postFix = "actions/fork_start", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}