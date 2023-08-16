namespace Telnyx.net.Services.HostedNumbers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.HostedNumbers;

    public class HostedNumberOrderService : Service<HostedNumberOrder>
    {
        public HostedNumberOrderService()
        {
        }

        public HostedNumberOrderService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/messaging_hosted_number_orders";

        public override string PostPath => "/actions/file_upload";

        /// <summary>
        /// List messaging hosted number orders async.
        /// </summary>
        /// <param name="listOptions">Defaults to page 1, 25 pagesize.</param>
        /// <param name="requestOptions">Additional options (optional).</param>
        /// <param name="ct">CancellationToken.</param>
        /// <returns>List of Hosted Number Orders.</returns>
        public async Task<TelnyxList<HostedNumberOrder>> ListHostedNumberOrdersAsync(ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            listOptions = listOptions == null ? new ListOptions(1, 25) : listOptions;
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// List messaging hosted number orders.
        /// </summary>
        /// <param name="listOptions">Defaults to page 1, 25 pagesize.</param>
        /// <param name="requestOptions">Additional options (optional).</param>
        /// <returns>List of Hosted Number Orders.</returns>
        public TelnyxList<HostedNumberOrder> ListHostedNumberOrders(ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            listOptions = listOptions == null ? new ListOptions(1, 25) : listOptions;
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <summary>
        /// Create a messaging hosted number order async.
        /// </summary>
        /// <param name="options">Options to create.</param>
        /// <param name="requestOptions">Additional request options (optional).</param>
        /// <param name="ct">CanellationToken.</param>
        /// <returns>Hosted Number Order.</returns>
        public async Task<HostedNumberOrder> CreateHostedNumberOrdersAsync(HostedNumberOrderOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, requestOptions, cancellationToken: ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a messaging hosted number order.
        /// </summary>
        /// <param name="options">Options to create.</param>
        /// <param name="requestOptions">Additional request options (optional).</param>
        /// <returns>Hosted Number Order.</returns>
        public HostedNumberOrder CreateHostedNumberOrders(HostedNumberOrderOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        /// <summary>
        /// Retrieve a messaging hosted number order.
        /// </summary>
        /// <param name="id">Hosted Number order Id.</param>
        /// <param name="requestOptions">Additional Request options (optional).</param>
        /// <param name="ct">Cancellation Token (optional).</param>
        /// <returns>Requested hosted number order.</returns>
        public async Task<HostedNumberOrder> RetrieveHostedNumberOrdersAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, requestOptions, string.Empty, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve a messaging hosted number order.
        /// </summary>
        /// <param name="id">Hosted Number Order Id.</param>
        /// <param name="requestOptions">Additional Request options (optional).</param>
        /// <returns>Requested hosted number order.</returns>
        public HostedNumberOrder RetrieveHostedNumberOrders(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }

        /// <summary>
        /// Upload file required for a messaging hosted number order.
        /// </summary>
        /// <param name="id">Identifies the type of resource.</param>
        /// <param name="options">File Upload Data.</param>
        /// <param name="requestOptions">Additional request options (optional).</param>
        /// <param name="ct">Cancellation Token (optional).</param>
        /// <returns>Successful response with details about a messaging hosted number order.</returns>
        public async Task<HostedNumberOrder> UploadFileAsync(string id, FileUploadOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(id, this.PostPath, options, requestOptions, string.Empty, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Upload file required for a messaging hosted number order.
        /// </summary>
        /// <param name="id">Identifies the type of resource.</param>
        /// <param name="options">File Upload Data.</param>
        /// <param name="requestOptions">Additional request options (optional).</param>
        /// <returns>Successful response with details about a messaging hosted number order.</returns>
        public HostedNumberOrder UploadFile(string id, FileUploadOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, this.PostPath, options, requestOptions, string.Empty);
        }
    }
}
