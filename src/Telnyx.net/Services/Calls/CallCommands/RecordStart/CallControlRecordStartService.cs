namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlRecordStartService
    /// </summary>
    public class CallControlRecordStartService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlRecordStartCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlRecordStartService"/> class.
        /// </summary>
        public CallControlRecordStartService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlRecordStartService"/> class.
        /// </summary>
        /// <param name="apiKey">api key</param>
        public CallControlRecordStartService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlRecordStartCreateOptions options, string postFix = "actions/record_start", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public Task<CallAnswerResponse> CreateAsync(string parentId, CallControlRecordStartCreateOptions createOptions, string postFix = "actions/record_start", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}