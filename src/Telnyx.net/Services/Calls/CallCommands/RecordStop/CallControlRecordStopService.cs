namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlRecordStopService
    /// </summary>
    public class CallControlRecordStopService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlRecordStopCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlRecordStopService"/> class.
        /// </summary>
        public CallControlRecordStopService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlRecordStopService"/> class.
        /// </summary>
        /// <param name="apiKey">api key</param>
        public CallControlRecordStopService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlRecordStopCreateOptions options, string postFix = "actions/record_stop", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public Task<CallAnswerResponse> CreateAsync(string parentId, CallControlRecordStopCreateOptions createOptions, string postFix = "actions/record_stop", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}