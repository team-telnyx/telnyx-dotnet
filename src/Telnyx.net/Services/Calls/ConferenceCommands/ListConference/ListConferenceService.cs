namespace Telnyx
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// ListConferenceService
    /// </summary>
    public class ListConferenceService : Service<ConferenceResponse>,
        IListable<ConferenceResponse, ListConferenceCreateOptions>
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
        /// <param name="apiKey">api key</param>
        public ListConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public TelnyxList<ConferenceResponse> List(ListConferenceCreateOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<ConferenceResponse>> ListAsync(ListConferenceCreateOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
        }
    }
}