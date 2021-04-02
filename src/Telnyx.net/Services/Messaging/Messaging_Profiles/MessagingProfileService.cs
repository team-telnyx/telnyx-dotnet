namespace Telnyx
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// MessagingProfileService.
    /// </summary>
    public class MessagingProfileService : Service<MessagingProfile>,
        IListable<MessagingProfile, ListOptions>,
        IRetrievable<MessagingProfile>,
        IDeletable<MessagingProfile>,
        ICreatable<MessagingProfile, NewMessagingProfile>,
        IUpdatable<MessagingProfile, MessagingProfileUpdate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingProfileService"/> class.
        /// </summary>
        public MessagingProfileService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingProfileService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public MessagingProfileService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/messaging_profiles";

        /// <inheritdoc/>
        public MessagingProfile Create(NewMessagingProfile createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions);
        }

        /// <inheritdoc/>
        public Task<MessagingProfile> CreateAsync(NewMessagingProfile createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(createOptions, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingProfile Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<MessagingProfile> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingProfile Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<MessagingProfile> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetEntityAsync(id, null, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public TelnyxList<MessagingProfile> List(ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<MessagingProfile>> ListAsync(ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public IEnumerable<MessagingProfile> ListPaged(ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MessagingProfile>> ListPagedAsync(ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAutoPagingAsync(listOptions, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingProfile Update(string id, MessagingProfileUpdate updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<MessagingProfile> UpdateAsync(string id, MessagingProfileUpdate updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, cancellationToken);
        }
    }
}
