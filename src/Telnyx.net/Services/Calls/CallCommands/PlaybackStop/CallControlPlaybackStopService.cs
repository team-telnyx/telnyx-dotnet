namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlPlaybackStopService
    /// </summary>
    public class CallControlPlaybackStopService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlPlaybackStopCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlPlaybackStopService"/> class.
        /// </summary>
        public CallControlPlaybackStopService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlPlaybackStopService"/> class.
        /// </summary>
        /// <param name="apiKey">api key</param>
        public CallControlPlaybackStopService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlPlaybackStopCreateOptions options, string postFix = "actions/playback_stop", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, CallControlPlaybackStopCreateOptions createOptions, string postFix = "actions/playback_stop", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}