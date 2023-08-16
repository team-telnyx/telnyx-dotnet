namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlTransferService.
    /// </summary>
    public class CallControlTransferService : Service<CallTransferResponse>,
        INestedCreatableWithIdInMid<CallTransferResponse, CallControlTransferOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlTransferService"/> class.
        /// </summary>
        public CallControlTransferService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlTransferService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public CallControlTransferService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallTransferResponse Create(string id, CallControlTransferOptions options, string postFix = "actions/transfer", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallTransferResponse> CreateAsync(string parentId, CallControlTransferOptions createOptions, string postFix = "actions/transfer", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}