namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Wireless.SimCards;

    /// <summary>
    /// SimCardsDisableService.
    /// </summary>
    [ExcludeFromCodeCoverage] // API doesn't work, API Message: Couldn't parse query/body: unexpected end of JSON input.
    internal class SimCardDisableService : Service<SimCardRecord>,
        INestedCreatable<SimCardRecord, BaseOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimCardDisableService"/> class.
        /// </summary>
        public SimCardDisableService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimCardDisableService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        public SimCardDisableService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/sim_cards";

        public override string PostPath => "actions/disable";

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
