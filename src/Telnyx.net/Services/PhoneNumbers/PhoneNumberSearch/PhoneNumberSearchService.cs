namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// AvailablePhoneNumberSearchService.
    /// </summary>
    public class PhoneNumberSearchService : Service<AvailablePhoneNumberSearch>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberSearchService"/> class.
        /// </summary>
        public PhoneNumberSearchService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberSearchService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public PhoneNumberSearchService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/phone_number_searches";

        /// <summary>
        /// List.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>TelnyxList of AvailablePhoneNumberSearch.</returns>
        public virtual TelnyxList<AvailablePhoneNumberSearch> List(PhoneNumberSearchOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// ListAsync.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Task of TelnyxList of AvailablePhoneNumberSearch.</returns>
        public virtual async Task<TelnyxList<AvailablePhoneNumberSearch>> ListAsync(PhoneNumberSearchOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(options, requestOptions, string.Empty, cancellationToken);
        }
    }
}

