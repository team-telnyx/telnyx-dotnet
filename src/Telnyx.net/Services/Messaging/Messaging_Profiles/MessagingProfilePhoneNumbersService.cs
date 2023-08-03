namespace Telnyx
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// Messaging Profile Service.
    /// </summary>
    public class MessagingProfilePhoneNumbersService : ServiceNested<MessagingPhoneNumber>,
        IRetrievable<MessagingPhoneNumber>,
        INestedListable<MessagingPhoneNumber, ListOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingProfilePhoneNumbersService"/> class.
        /// </summary>
        public MessagingProfilePhoneNumbersService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingProfilePhoneNumbersService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public MessagingProfilePhoneNumbersService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/messaging_profiles/{PARENT_ID}/phone_numbers";

        /// <inheritdoc/>
        public MessagingPhoneNumber Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetNestedEntity(id, null, null, requestOptions, "data");
        }

        /// <inheritdoc/>
        public async Task<MessagingPhoneNumber> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetNestedEntityAsync(id, null, null, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public TelnyxList<MessagingPhoneNumber> List(string id, ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<MessagingPhoneNumber>> ListAsync(string id, ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListNestedEntitiesAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public IEnumerable<MessagingPhoneNumber> ListPaged(string id, ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MessagingPhoneNumber>> ListPagedAsync(string id, ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListNestedEntitiesAutoPagingAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }
    }
}
