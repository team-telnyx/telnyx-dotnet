namespace Telnyx
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// Number Order Service.
    /// </summary>
    public class NumberOrderService : Service<NumberOrder>,
        ICreatable<NumberOrder, NumberOrderCreateOptions>,
        IListable<NumberOrder, NumberOrderListOptions>,
        IRetrievable<NumberOrder>,
        IUpdatable<NumberOrder, NumberOrderUpdateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberOrderService"/> class.
        /// </summary>
        public NumberOrderService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberOrderService"/> class.
        /// </summary>
        /// <param name="apiKey">Api key.</param>
        public NumberOrderService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Gets the base path, /number_orders.
        /// </summary>
        public override string BasePath => "/number_orders";

        /// <summary>
        /// Create Number Order.
        /// </summary>
        /// <param name="options">Options.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>Number Order.</returns>
        public virtual NumberOrder Create(NumberOrderCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions, parentToken: "data");
        }

        /// <summary>
        /// Create Number Order.
        /// </summary>
        /// <param name="createOptions">Create Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>Task of Number Order.</returns>
        public async Task<NumberOrder> CreateAsync(NumberOrderCreateOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <returns>Number Order.</returns>
        public NumberOrder Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <summary>
        /// Get numbers.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>Task of OrderNumber.</returns>
        public async Task<NumberOrder> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="updateOptions">Update Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <returns>Number Order.</returns>
        public virtual NumberOrder Update(string id, NumberOrderUpdateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions, parentToken: "data");
        }

        /// <summary>
        /// Update Async.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="updateOptions">Update Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>Number Order.</returns>
        public async virtual Task<NumberOrder> UpdateAsync(string id, NumberOrderUpdateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, parentToken: "data", cancellationToken);
        }

        /// <summary>
        /// List Number oRDER.
        /// </summary>
        /// <param name="listOptions">Number Order List Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <returns>Telnyx List of Number Order.</returns>
        public virtual TelnyxList<NumberOrder> List(NumberOrderListOptions listOptions, RequestOptions requestOptions)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <summary>
        /// List Number Order Async.
        /// </summary>
        /// <param name="listOptions">Number Order List Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>Task of Telnyx List of Number Order.</returns>
        public async virtual Task<TelnyxList<NumberOrder>> ListAsync(NumberOrderListOptions listOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, cancellationToken);
        }

        /// <summary>
        /// List Auto Paging.
        /// </summary>
        /// <param name="listOptions">Number Order List Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <returns>List of Number Order.</returns>
        public IEnumerable<NumberOrder> ListAutoPaging(NumberOrderListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListAutoPaging(listOptions, requestOptions);
        }
    }
}