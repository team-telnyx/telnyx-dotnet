namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlBridgeService.
    /// </summary>
    public class CallControlBridgeService : Service<CallBridgeResponse>,
        INestedCreatableWithIdInMid<CallBridgeResponse, CallControlBridgeOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlBridgeService"/> class.
        /// </summary>
        public CallControlBridgeService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlBridgeService"/> class.
        /// </summary>
        /// <param name="apiKey">apiKey.</param>
        public CallControlBridgeService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallBridgeResponse Create(string id, CallControlBridgeOptions options, string postFix = "actions/bridge", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallBridgeResponse> CreateAsync(string parentId, CallControlBridgeOptions createOptions, string postFix = "actions/bridge", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}