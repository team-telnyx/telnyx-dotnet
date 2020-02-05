namespace Telnyx
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// MessagingSenderIdService
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
        /// <param name="apiKey">api key</param>
        public MessagingSenderIdService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/messages";

        /// <inheritdoc/>
        public MessagingSenderId Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions);
        }

        /// <inheritdoc/>
        public Task<MessagingSenderId> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteEntityAsync(id, null, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingSenderId Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions);
        }

        /// <inheritdoc/>
        public Task<MessagingSenderId> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(id, null, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public TelnyxList<MessagingSenderId> List(MessagingSenderIdListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public Task<TelnyxList<MessagingSenderId>> ListAsync(MessagingSenderIdListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingSenderId Update(string id, MessagingSenderIdUpdate updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions);
        }

        /// <inheritdoc/>
        public Task<MessagingSenderId> UpdateAsync(string id, MessagingSenderIdUpdate updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateEntityAsync(id, updateOptions, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingSenderId Create(NewMessagingSenderId createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions);
        }

        /// <inheritdoc/>
        public Task<MessagingSenderId> CreateAsync(NewMessagingSenderId createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(createOptions, requestOptions, cancellationToken);
        }
    }
}
