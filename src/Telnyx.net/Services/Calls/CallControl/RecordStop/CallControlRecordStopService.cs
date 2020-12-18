namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlRecordStopService.
    /// </summary>
    public class CallControlRecordStopService : Service<CallRecordStopResponse>,
        INestedCreatableWithIdInMid<CallRecordStopResponse, CallControlRecordStopOptions>
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
        /// <param name="apiKey">api key.</param>
        public CallControlRecordStopService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallRecordStopResponse Create(string id, CallControlRecordStopOptions options, string postFix = "actions/record_stop", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<CallRecordStopResponse> CreateAsync(string parentId, CallControlRecordStopOptions createOptions, string postFix = "actions/record_stop", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}