namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.SimCards;

    internal class SimCardBulkNetworkPreferenceService : Service<TelnyxCollection<MobileOperatorNetworksPreferencesRecord>>,
        IBulkUpdatable<TelnyxCollection<MobileOperatorNetworksPreferencesRecord>, SimCardBulkNetworkPreferenceUpdateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimCardBulkNetworkPreferenceService"/> class.
        /// </summary>
        internal SimCardBulkNetworkPreferenceService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimCardBulkNetworkPreferenceService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        internal SimCardBulkNetworkPreferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/actions/network_preferences/sim_cards";

        public TelnyxCollection<MobileOperatorNetworksPreferencesRecord> Update(SimCardBulkNetworkPreferenceUpdateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.BulkUpdateEntity(updateOptions, requestOptions, postPath: null, parentToken: "data");
        }

        public async Task<TelnyxCollection<MobileOperatorNetworksPreferencesRecord>> UpdateAsync(SimCardBulkNetworkPreferenceUpdateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.BulkUpdateEntityAsync(updateOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }
    }
}
