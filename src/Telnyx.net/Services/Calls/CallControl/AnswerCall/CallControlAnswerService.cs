namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlAnswerService.
    /// </summary>
    public class CallControlAnswerService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlAnswerOptions>
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
        /// <param name="apiKey">apiKey.</param>
        public CallControlAnswerService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlAnswerOptions options, string postFix = "actions/answer", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, CallControlAnswerOptions createOptions, string postFix = "actions/answer", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}