namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Messaging Profile Service.
    /// </summary>
    public class MessagingProfilePhoneNumbersService : ServiceNested<MessagingPhoneNumber>,
        IRetrievable<MessagingPhoneNumber>,
        INestedListable<MessagingPhoneNumber, ListMessagingProfilesPhoneNumbersOptions>
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
            return this.GetNestedEntity(id, null, null, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<MessagingPhoneNumber> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetNestedEntityAsync(id, null, null, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public TelnyxList<MessagingPhoneNumber> List(string id, ListMessagingProfilesPhoneNumbersOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(id, listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<MessagingPhoneNumber>> ListAsync(string id, ListMessagingProfilesPhoneNumbersOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListNestedEntitiesAsync(id, listOptions, requestOptions, cancellationToken);
        }

    }
}
