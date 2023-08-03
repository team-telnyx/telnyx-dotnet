namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CreateConferenceService.
    /// </summary>
    public class CreateConferenceService : Service<CreateConferenceResponse>,
        ICreatable<CreateConferenceResponse, CreateConferenceOptions>
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
        /// <param name="apiKey">api key.</param>
        public CreateConferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/conferences";

        /// <inheritdoc/>
        public virtual CreateConferenceResponse Create(CreateConferenceOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions, parentToken: "data");
        }

        /// <inheritdoc/>
        public async Task<CreateConferenceResponse> CreateAsync(CreateConferenceOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }
    }
}