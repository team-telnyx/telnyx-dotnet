namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CreateConferenceService
    /// </summary>
    public class CreateConferenceService : Service<ConferenceResponse>,
        ICreatable<ConferenceResponse, CreateConferenceCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateConferenceService"/> class.
        /// </summary>
        public CreateConferenceService()
        : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateConferenceService"/> class.
        /// </summary>
        /// <param name="apiKey">api key</param>
        public CreateConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public virtual ConferenceResponse Create(CreateConferenceCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        /// <inheritdoc/>
        public Task<ConferenceResponse> CreateAsync(CreateConferenceCreateOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(createOptions, requestOptions, cancellationToken);
        }
    }
}