namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlRecordStartService
    /// </summary>
    public class CallControlRecordStartService : Service<CallRecordStartResponse>,
        INestedCreatableWithIdInMid<CallRecordStartResponse, CallControlRecordStartOptions>
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
        public virtual CallRecordStartResponse Create(string id, CallControlRecordStartOptions options, string postFix = "actions/record_start", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<CallRecordStartResponse> CreateAsync(string parentId, CallControlRecordStartOptions createOptions, string postFix = "actions/record_start", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}