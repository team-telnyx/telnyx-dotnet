namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// BrandFeedbackService.
    /// </summary>
    public class BrandFeedbackService : Service<BrandFeedbackOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandFeedbackService"/> class.
        /// </summary>
        public BrandFeedbackService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandFeedbackService"/> class.
        /// </summary>
        /// <param name="apiKey">API key.</param>
        public BrandFeedbackService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/10dlc/brand/feedback"; // Adjust the BasePath to the correct endpoint for brand feedback.

        /// <summary>
        /// Retrieves a BrandFeedback entity by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the BrandFeedbackService entity.</param>
        /// <param name="requestOptions">Additional options for the request, such as headers.</param>
        /// <returns>A BrandFeedbackService entity.</returns>
        public BrandFeedbackOptions Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, requestOptions);
        }

        /// <summary>
        /// Asynchronously retrieves a BrandFeedback entity by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the BrandFeedback entity.</param>
        /// <param name="requestOptions">Additional options for the request, such as headers.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns a BrandFeedback entity.</returns>
        public async Task<BrandFeedbackOptions> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetEntityAsync(id, requestOptions, string.Empty, cancellationToken);
        }
    }
}
