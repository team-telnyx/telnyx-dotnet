namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Wireless.SimCards;

    /// <summary>
    /// SimCardsEnableService.
    /// </summary>
    [ExcludeFromCodeCoverage] // API doesn't work, API Message: Couldn't parse query/body: unexpected end of JSON input.
    internal class SimCardEnableService : Service<SimCardRecord>,
        INestedCreatable<SimCardRecord, BaseOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimCardEnableService"/> class.
        /// </summary>
        public SimCardEnableService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimCardEnableService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public SimCardEnableService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/sim_cards";

        public override string PostPath => "actions/enable";

        public SimCardRecord Create(string parentId, BaseOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(parentId, this.PostPath, createOptions, requestOptions, parentToken: "data");
        }

        public async Task<SimCardRecord> CreateAsync(string parentId, BaseOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateEntityAsync(parentId, this.PostPath, createOptions, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
