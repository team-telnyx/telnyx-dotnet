namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Call control dial service.
    /// </summary>
    public class CallControlDialService : Service<CallDialResponse>,
        ICreatable<CallDialResponse, CallControlDialOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlDialService"/> class.
        /// </summary>
        public CallControlDialService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallControlDialService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public CallControlDialService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/calls";

        /// <inheritdoc/>
        public virtual CallDialResponse Create(CallControlDialOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions, null, "data");
        }

        /// <inheritdoc/>
        public async Task<CallDialResponse> CreateAsync(CallControlDialOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, null, "data", cancellationToken);
        }

        public async Task<CallDialResponse> RetrieveAsync(string callControlId, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(callControlId, reqOpts, "data", cancellationToken);
        }

        public CallDialResponse Retrieve(string callControlId, RequestOptions reqOpts = null)
        {
            return this.GetEntity(callControlId, reqOpts, "data");
        }
    }
}