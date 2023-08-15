namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlSendDTMFService.
    /// </summary>
    public class CallControlSendDTMFService : Service<CallSendDTMFResponse>,
        INestedCreatableWithIdInMid<CallSendDTMFResponse, CallControlSendDTMFOptions>
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
        /// <param name="apiKey">api key.</param>
        public CallControlSendDTMFService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallSendDTMFResponse Create(string id, CallControlSendDTMFOptions options, string postFix = "actions/send_dtmf", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallSendDTMFResponse> CreateAsync(string parentId, CallControlSendDTMFOptions createOptions, string postFix = "actions/send_dtmf", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}