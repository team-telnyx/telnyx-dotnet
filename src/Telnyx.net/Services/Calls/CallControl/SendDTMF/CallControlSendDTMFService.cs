namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlSendDTMFService
    /// </summary>
    public class CallControlSendDTMFService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlSendDTMFCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlSendDTMFService"/> class.
        /// </summary>
        public CallControlSendDTMFService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlSendDTMFService"/> class.
        /// </summary>
        /// <param name="apiKey">api key</param>
        public CallControlSendDTMFService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlSendDTMFCreateOptions options, string postFix = "actions/send_dtmf", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, CallControlSendDTMFCreateOptions createOptions, string postFix = "actions/send_dtmf", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}