namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CallControlGatherUsingAudioService
    /// </summary>
    public class CallControlGatherUsingAudioService : Service<CallAnswerResponse>,
        INestedCreatableWithIdInMid<CallAnswerResponse, CallControlGatherUsingAudioCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlGatherUsingAudioService"/> class.
        /// </summary>
        public CallControlGatherUsingAudioService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlGatherUsingAudioService"/> class.
        /// </summary>
        /// <param name="apiKey">api key</param>
        public CallControlGatherUsingAudioService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallAnswerResponse Create(string id, CallControlGatherUsingAudioCreateOptions options, string postFix = "actions/gather_using_audio", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, postFix, options, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<CallAnswerResponse> CreateAsync(string parentId, CallControlGatherUsingAudioCreateOptions createOptions, string postFix = "actions/gather_using_audio", RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}