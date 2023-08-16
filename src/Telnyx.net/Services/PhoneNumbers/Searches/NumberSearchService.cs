namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// NumberSearchService.
    /// </summary>
    public class NumberSearchService : Service<AvailablePhoneNumber>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberSearchService"/> class.
        /// </summary>
        public NumberSearchService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberSearchService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public NumberSearchService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/available_phone_numbers";

        /// <summary>
        /// List.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>TelnyxList of AvailablePhoneNumber.</returns>
        public virtual TelnyxList<AvailablePhoneNumber> List(NumberSearchOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// ListAsync.
        /// </summary>
        /// <param name="options">options.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>TelnyxList of AvailablePhoneNumber.</returns>
        public virtual async Task<TelnyxList<AvailablePhoneNumber>> ListAsync(NumberSearchOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(options, requestOptions, string.Empty, cancellationToken);
        }
    }
}