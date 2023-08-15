namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services._interfaces;

    public class SimCardNetworkPreferenceService : Service<MobileOperatorNetworksPreferencesRecord>,
        IRetrievableWithIdInMid<MobileOperatorNetworksPreferencesRecord>,
        IUpdatable<MobileOperatorNetworksPreferencesRecord, BaseOptions>,
        IDeletable<MobileOperatorNetworksPreferencesRecord>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimCardNetworkPreferenceService"/> class.
        /// </summary>
        internal SimCardNetworkPreferenceService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimCardNetworkPreferenceService"/> class.
        /// </summary>
        /// <param name="apiKey">api key.</param>
        internal SimCardNetworkPreferenceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/sim_cards";

        public override string PostPath => "network_preferences";

        public MobileOperatorNetworksPreferencesRecord Get(string id, BaseOptions baseOptions, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, baseOptions, requestOptions, this.PostPath, parentToken: "data");
        }

        public async Task<MobileOperatorNetworksPreferencesRecord> GetAsync(string id, BaseOptions baseOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, baseOptions, requestOptions, this.PostPath, parentToken: "data", cancellationToken: cancellationToken);
        }

        public MobileOperatorNetworksPreferencesRecord Update(string id, BaseOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpgradeEntity(id, updateOptions, requestOptions, this.PostPath, parentToken: "data");
        }

        public async Task<MobileOperatorNetworksPreferencesRecord> UpdateAsync(string id, BaseOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpgradeEntityAsync(id, updateOptions, requestOptions, this.PostPath, parentToken: "data", cancellationToken);
        }

        public MobileOperatorNetworksPreferencesRecord Delete(string id, RequestOptions requestOptions)
        {
            return this.DeleteEntity(id, this.PostPath, null, requestOptions, parentToken: "data");
        }

        public async Task<MobileOperatorNetworksPreferencesRecord> DeleteAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return await this.DeleteEntityAsync(id, this.PostPath, null, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
