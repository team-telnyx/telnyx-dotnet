namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlRejectService
    /// </summary>
    public class CallControlRejectService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlRejectCreateOptions>
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
        /// <param name="apiKey">api key</param>
        public CallControlRejectService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlRejectCreateOptions options, string postFix = "actions/reject", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, CallControlRejectCreateOptions createOptions, string postFix = "actions/reject", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}