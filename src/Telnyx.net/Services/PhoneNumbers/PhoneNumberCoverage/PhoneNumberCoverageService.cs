namespace Telnyx.net.Services.PhoneNumbers.Coverage
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.Coverage;

    /// <summary>
    /// This service handles operations related to phone number coverage.
    /// </summary>
    public class PhoneNumberCoverageService : Service<PhoneNumberCoverage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberCoverageService"/> class.
        /// </summary>
        public PhoneNumberCoverageService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberCoverageService"/> class.
        /// </summary>
        /// <param name="apiKey">Your Telnyx API Key.</param>
        public PhoneNumberCoverageService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/origination/porting/portability_checks";

        /// <summary>
        /// Lists phone number coverage details synchronously.
        /// </summary>
        /// <param name="options">Options for filtering and searching phone number coverage.</param>
        /// <param name="requestOptions">Options for the request to the API.</param>
        /// <returns>A TelnyxList of PhoneNumberCoverage.</returns>
        public TelnyxList<PhoneNumberCoverage> List(PhoneNumberCoverageOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// Lists phone number coverage details asynchronously.
        /// </summary>
        /// <param name="options">Options for filtering and searching phone number coverage.</param>
        /// <param name="requestOptions">Options for the request to the API.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task representing the asynchronous operation which, when completed, returns a TelnyxList of PhoneNumberCoverage.</returns>
        public async Task<TelnyxList<PhoneNumberCoverage>> ListAsync(PhoneNumberCoverageOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, requestOptions, string.Empty, cancellationToken);
        }
    }

}
