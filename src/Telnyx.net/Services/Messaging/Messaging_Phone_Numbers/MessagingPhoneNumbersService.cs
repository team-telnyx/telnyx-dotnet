namespace Telnyx
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// MessagingPhoneNumbersService.
    /// </summary>
    public class MessagingPhoneNumbersService : Service<MessagingPhoneNumber>,
        IRetrievable<MessagingPhoneNumber>,
        IUpdatable<MessagingPhoneNumber, MessagingPhoneNumberUpdate>,
        IListable<MessagingPhoneNumber, MessagingPhoneNumerListOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingPhoneNumbersService"/> class.
        /// </summary>
        public MessagingPhoneNumbersService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingPhoneNumbersService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public MessagingPhoneNumbersService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/messaging_phone_numbers";

        /// <inheritdoc/>
        public MessagingPhoneNumber Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<MessagingPhoneNumber> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetEntityAsync(id, null, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public TelnyxList<MessagingPhoneNumber> List(MessagingPhoneNumerListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<MessagingPhoneNumber>> ListAsync(MessagingPhoneNumerListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public MessagingPhoneNumber Update(string id, MessagingPhoneNumberUpdate updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<MessagingPhoneNumber> UpdateAsync(string id, MessagingPhoneNumberUpdate updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, cancellationToken);
        }
    }
}
