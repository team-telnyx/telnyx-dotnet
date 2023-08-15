namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlHangupService.
    /// </summary>
    public class CallControlHangupService : Service<CallHangUpResponse>,
        INestedCreatableWithIdInMid<CallHangUpResponse, CallControlHangupOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlHangupService"/> class.
        /// </summary>
        public CallControlHangupService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlHangupService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public CallControlHangupService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallHangUpResponse Create(string id, CallControlHangupOptions options, string postFix = "actions/hangup", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallHangUpResponse> CreateAsync(string parentId, CallControlHangupOptions createOptions, string postFix = "actions/hangup", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}