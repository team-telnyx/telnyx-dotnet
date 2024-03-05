namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// BulkSimCardSearchService.
    /// </summary>
    public class BulkSimCardService : Service<BulkSimCardSearch>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkSimCardService"/> class.
        /// </summary>
        public BulkSimCardService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BulkSimCardService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public BulkSimCardService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/bulk_sim_card_actions"; // Adjust the BasePath to the correct endpoint.

        /// <summary>
        /// List.
        /// </summary>
        /// <param name="options">options for searching sim cards.</param>
        /// <param name="requestOptions">additional request options.</param>
        /// <returns>TelnyxList of BulkSimCardSearch.</returns>
        public virtual TelnyxList<BulkSimCardSearch> List(BulkSimCardSearchOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// ListAsync.
        /// </summary>
        /// <param name="options">options for searching sim cards.</param>
        /// <param name="requestOptions">additional request options.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>Task of TelnyxList of BulkSimCardSearch.</returns>
        public virtual async Task<TelnyxList<BulkSimCardSearch>> ListAsync(BulkSimCardSearchOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(options, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public BulkSimCardSearch Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<BulkSimCardSearch> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }


    }
}
