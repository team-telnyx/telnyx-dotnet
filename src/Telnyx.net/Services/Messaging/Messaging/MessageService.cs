namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// MessageService.
    /// </summary>
    public class MessageService : Service<OutboundMessage>,
        ICreatable<OutboundMessage, NewMessage>,
        IRetrievable<OutboundMessage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageService"/> class.
        /// </summary>
        public MessageService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public MessageService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/messages";

        /// <inheritdoc/>
        public OutboundMessage Create(NewMessage createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<OutboundMessage> CreateAsync(NewMessage createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public OutboundMessage Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<OutboundMessage> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
