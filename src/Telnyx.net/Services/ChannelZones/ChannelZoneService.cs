using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telnyx.net.Entities;
using Telnyx.net.Services;

namespace Telnyx
{
    /// <summary>
    /// Service class for managing channel zones.
    /// </summary>
    public class ChannelZoneService : Service<ChannelZones>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelZoneService"/> class.
        /// </summary>
        public ChannelZoneService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelZoneService"/> class with an API key.
        /// </summary>
        /// <param name="apiKey">API key.</param>
        public ChannelZoneService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/channel_zones";

        /// <summary>
        /// Lists channel zone entities.
        /// </summary>
        /// <param name="options">Options for filtering and pagination.</param>
        /// <param name="requestOptions">Additional request options.</param>
        /// <returns>A list of channel zone entities.</returns>
        public TelnyxList<ChannelZones> List(ChannelZoneOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// Asynchronously lists channel zone entities.
        /// </summary>
        /// <param name="options">Options for filtering and pagination.</param>
        /// <param name="requestOptions">Additional request options.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns a list of channel zone entities.</returns>
        public virtual async Task<TelnyxList<ChannelZones>> ListAsync(ChannelZoneOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, requestOptions, string.Empty, cancellationToken);
        }

        /// <summary>
        /// Legacy single-zone retrieval. No GET-by-ID operation is defined in the canonical API; this remains unsupported.
        /// </summary>
        /// <param name="id">The unique identifier of the channel zone entity.</param>
        /// <param name="requestOptions">Additional request options.</param>
        /// <returns>A channel zone entity.</returns>
        public virtual ChannelZones Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <summary>
        /// Legacy asynchronous single-zone retrieval. No GET-by-ID operation is defined in the canonical API; this remains unsupported.
        /// </summary>
        /// <param name="id">The unique identifier of the channel zone entity.</param>
        /// <param name="requestOptions">Additional request options.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns a channel zone entity.</returns>
        public virtual async Task<ChannelZones> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        /// <summary>
        /// Updates a channel zone entity by its ID with new channel quantity.
        /// </summary>
        /// <param name="id">The unique identifier of the channel zone entity to update.</param>
        /// <param name="updateOptions">The update options containing the new quantity of reserved channels.</param>
        /// <param name="requestOptions">Additional options for the request, such as headers.</param>
        /// <returns>The updated ChannelZone entity.</returns>
        public ChannelZones Update(string id, ChannelZoneUpdate updateOptions, RequestOptions requestOptions = null)
        {
            // PUT returns the channel zone directly, without a data envelope.
            return this.PutRequest<ChannelZones>(this.InstanceUrl(id), updateOptions, requestOptions, string.Empty);
        }

        /// <summary>
        /// Asynchronously updates a channel zone entity by its ID with new channel quantity.
        /// </summary>
        /// <param name="id">The unique identifier of the channel zone entity to update.</param>
        /// <param name="updateOptions">The update options containing the new quantity of reserved channels.</param>
        /// <param name="requestOptions">Additional options for the request, such as headers.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns the updated ChannelZone entity.</returns>
        public async Task<ChannelZones> UpdateAsync(string id, ChannelZoneUpdate updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // PUT returns the channel zone directly, without a data envelope.
            return await this.PutRequestAsync<ChannelZones>(this.InstanceUrl(id), updateOptions, requestOptions, string.Empty, cancellationToken);
        }

    }
}
