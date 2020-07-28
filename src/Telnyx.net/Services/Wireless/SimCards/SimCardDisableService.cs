namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Wireless.SimCards;

    /// <summary>
    /// SimCardsDisableService
    /// </summary>
    public class SimCardDisableService : Service<SimCardRecord>,
        INestedCreatableWithIdInMid<SimCardRecord, BaseOptions>
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

        public SimCardRecord Create(string parentId, BaseOptions createOptions = null, string postFix = "actions/disable", RequestOptions requestOptions = null)
        {
            return this.CreateEntity(parentId, postFix, createOptions,  requestOptions);
        }

        public async Task<SimCardRecord> CreateAsync(string parentId, BaseOptions createOptions = null, string postFix = "actions/disable", RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateEntityAsync(parentId, postFix, createOptions, requestOptions, cancellationToken);
        }
    }
}
