using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;

namespace Telnyx
{
    /// <summary>
    /// NumberBlockSearchService.
    /// </summary>
    public class NumberBlockSearchServices : Service<AvailablePhoneNumberBlock>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberBlockSearchServices"/> class.
        /// </summary>
        public NumberBlockSearchServices()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberBlockSearchServices"/> class.
        /// </summary>
        /// <param name="apiKey">API key.</param>
        public NumberBlockSearchServices(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/available_phone_number_blocks";

        /// <summary>
        /// List.
        /// </summary>
        /// <param name="options">Options for searching available phone number blocks.</param>
        /// <param name="requestOptions">Options for the request to the API.</param>
        /// <returns>TelnyxList of AvailablePhoneNumberBlock.</returns>
        public virtual TelnyxList<AvailablePhoneNumberBlock> List(NumberBlockSearchOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// ListAsync.
        /// </summary>
        /// <param name="options">Options for searching available phone number blocks.</param>
        /// <param name="requestOptions">Options for the request to the API.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task representing the asynchronous operation which, when completed, returns a TelnyxList of AvailablePhoneNumberBlock.</returns>
        public virtual async Task<TelnyxList<AvailablePhoneNumberBlock>> ListAsync(NumberBlockSearchOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, requestOptions, string.Empty, cancellationToken);
        }
    }
}
