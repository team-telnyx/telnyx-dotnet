namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlPlaybackStartService.
    /// </summary>
    public class CallControlPlaybackStartService : Service<CallPlaybackStartResponse>,
        INestedCreatableWithIdInMid<CallPlaybackStartResponse, CallControlPlaybackStartOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlPlaybackStartService"/> class.
        /// </summary>
        public CallControlPlaybackStartService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlPlaybackStartService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public CallControlPlaybackStartService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallPlaybackStartResponse Create(string id, CallControlPlaybackStartOptions options, string postFix = "actions/playback_start", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<CallPlaybackStartResponse> CreateAsync(string parentId, CallControlPlaybackStartOptions createOptions, string postFix = "actions/playback_start", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}