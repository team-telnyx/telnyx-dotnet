namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlAnswerService
    /// </summary>
    public class CallControlAnswerService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlAnswerCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlAnswerService"/> class.
        /// </summary>
        public CallControlAnswerService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlAnswerService"/> class.
        /// </summary>
        /// <param name="apiKey">apiKey</param>
        public CallControlAnswerService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlAnswerCreateOptions options, string postFix = "actions/answer", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, CallControlAnswerCreateOptions createOptions, string postFix = "actions/answer", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}