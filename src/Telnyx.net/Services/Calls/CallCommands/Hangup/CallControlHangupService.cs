namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlHangupService
    /// </summary>
    public class CallControlHangupService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlHangupCreateOptions>
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
        /// <param name="apiKey">api key</param>
        public CallControlHangupService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlHangupCreateOptions options, string postFix = "actions/hangup", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public Task<CallAnswerResponse> CreateAsync(string parentId, CallControlHangupCreateOptions createOptions, string postFix = "actions/hangup", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}