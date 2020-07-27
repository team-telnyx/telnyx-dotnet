namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Wireless.SimCards;

    /// <summary>
    /// SimCardsEnableService
    /// </summary>
    public class SimCardEnableService : Service<SimCardRecord>,
        INestedCreatableWithIdInMid<SimCardRecord, SimCardEnableOptions>
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

        public SimCardRecord Create(string parentId, SimCardEnableOptions createOptions, string postFix = "actions/enable", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(parentId, postFix, createOptions, requestOptions);
        }

        public async Task<SimCardRecord> CreateAsync(string parentId, SimCardEnableOptions createOptions, string postFix = "actions/enable", RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}
