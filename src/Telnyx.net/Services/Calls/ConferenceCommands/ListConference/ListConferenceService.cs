﻿namespace Telnyx
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ListConferenceService.
    /// </summary>
    public class ListConferenceService : Service<CreateConferenceResponse>,
        IListable<CreateConferenceResponse, ListConferenceOptions>
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
        public TelnyxList<CreateConferenceResponse> List(ListConferenceOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<CreateConferenceResponse>> ListAsync(ListConferenceOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
        }
    }
}