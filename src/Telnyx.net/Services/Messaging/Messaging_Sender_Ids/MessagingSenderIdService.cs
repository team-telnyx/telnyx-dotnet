namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// MessagingSenderIdService.
    /// </summary>
    public class MessagingSenderIdService : Service<MessagingSenderId>,
        IListable<MessagingSenderId, MessagingSenderIdListOptions>,
        IRetrievable<MessagingSenderId>,
        IDeletable<MessagingSenderId>,
        IUpdatable<MessagingSenderId, MessagingSenderIdUpdate>,
        ICreatable<MessagingSenderId, NewMessagingSenderId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingSenderIdService"/> class.
        /// </summary>
        public MessagingSenderIdService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingSenderIdService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public MessagingSenderIdService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/messages";

        // API not available in telnyx doc

        /// <inheritdoc/>
        public MessagingSenderId Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<MessagingSenderId> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingSenderId Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<MessagingSenderId> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        // API not available in telnyx doc

        /// <inheritdoc/>
        public TelnyxList<MessagingSenderId> List(MessagingSenderIdListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<MessagingSenderId>> ListAsync(MessagingSenderIdListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingSenderId Update(string id, MessagingSenderIdUpdate updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<MessagingSenderId> UpdateAsync(string id, MessagingSenderIdUpdate updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, parentToken: "data", cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingSenderId Create(NewMessagingSenderId createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<MessagingSenderId> CreateAsync(NewMessagingSenderId createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }
    }
}
