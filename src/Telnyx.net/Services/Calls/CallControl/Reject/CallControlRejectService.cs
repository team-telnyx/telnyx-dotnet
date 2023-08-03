namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlRejectService.
    /// </summary>
    public class CallControlRejectService : Service<CallRejectResponse>,
        INestedCreatableWithIdInMid<CallRejectResponse, CallControlRejectOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlRejectService"/> class.
        /// </summary>
        public CallControlRejectService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlRejectService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public CallControlRejectService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallRejectResponse Create(string id, CallControlRejectOptions options, string postFix = "actions/reject", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallRejectResponse> CreateAsync(string parentId, CallControlRejectOptions createOptions, string postFix = "actions/reject", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}