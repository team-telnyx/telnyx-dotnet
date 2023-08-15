namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// ListConferenceService.
    /// </summary>
    public class ListConferenceService : Service<ListConferenceResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListConferenceService"/> class.
        /// </summary>
        public ListConferenceService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListConferenceService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public ListConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public TelnyxList<ListConferenceResponse> List(ListConferenceOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<ListConferenceResponse>> ListAsync(ListConferenceOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}