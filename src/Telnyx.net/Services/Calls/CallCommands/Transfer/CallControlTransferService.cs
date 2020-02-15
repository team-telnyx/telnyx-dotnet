namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlTransferService
    /// </summary>
    public class CallControlTransferService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlTransferCreateOptions>
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
        /// <param name="apiKey">api key</param>
        public CallControlTransferService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlTransferCreateOptions options, string postFix = "actions/transfer", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, CallControlTransferCreateOptions createOptions, string postFix = "actions/transfer", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}