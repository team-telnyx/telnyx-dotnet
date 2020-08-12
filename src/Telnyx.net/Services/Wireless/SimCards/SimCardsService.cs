namespace Telnyx.net.Services.Wireless.SimCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.SimCards;

    public class SimCardsService : Service<SimCardRecord>,
        IListable<SimCardRecord, ListOptions>,
        IDeletable<SimCardRecord>,
        IUpdatable<SimCardRecord, UpdateSimCardOptions>
    {

        private readonly SimCardEnableService simCardEnableService;

        private readonly SimCardDisableService simCardDisableService;

        private readonly SimCardRegisterService simCardRegisterService;

        private readonly SimCardBulkNetworkPreferenceService simCardBulkNetworkPreferenceService;

        private readonly SimCardNetworkPreferenceService simCardNetworkPreferenceService;

        public override string BasePath => "/sim_cards";

        public SimCardsService()
        {
            this.simCardEnableService = new SimCardEnableService();
            this.simCardDisableService = new SimCardDisableService();
            this.simCardRegisterService = new SimCardRegisterService();
            this.simCardBulkNetworkPreferenceService = new SimCardBulkNetworkPreferenceService();
            this.simCardNetworkPreferenceService = new SimCardNetworkPreferenceService();
        }

        public SimCardRecord Get(string id, BaseOptions baseOptions, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, baseOptions, requestOptions);
        }

        public async Task<SimCardRecord> GetAsync(string id, BaseOptions baseOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, baseOptions, requestOptions, cancellationToken);
        }

        public TelnyxList<SimCardRecord> List(ListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        public async Task<TelnyxList<SimCardRecord>> ListAsync(ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
        }

        public SimCardRecord Delete(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions);
        }

        public async Task<SimCardRecord> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, cancellationToken);
        }

        public SimCardRecord Update(string id, UpdateSimCardOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions);
        }

        public async Task<SimCardRecord> UpdateAsync(string id, UpdateSimCardOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, cancellationToken);
        }

        public SimCardRecord Enable(string parentId)
        {
            return this.simCardEnableService.Create(parentId, new BaseOptions());
        }

        public async Task<SimCardRecord> EnableAsync(string parentId)
        {
            return await this.simCardEnableService.CreateAsync(parentId, new BaseOptions());
        }

        public SimCardRecord Disable(string parentId)
        {
            return this.simCardDisableService.Create(parentId, new BaseOptions());
        }

        public async Task<SimCardRecord> DisableAsync(string parentId)
        {
            return await this.simCardDisableService.CreateAsync(parentId, new BaseOptions());
        }

        public TelnyxCollection<SimCardRecord> Register(SimCardRegisterOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.simCardRegisterService.Create(createOptions, requestOptions);
        }

        public async Task<TelnyxCollection<SimCardRecord>> RegisterAsync(SimCardRegisterOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.simCardRegisterService.CreateAsync(createOptions, requestOptions, cancellationToken);
        }

        public TelnyxCollection<MobileOperatorNetworksPreferencesRecord> BulkUpdateNetworkPreference(SimCardBulkNetworkPreferenceUpdateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.simCardBulkNetworkPreferenceService.Update(updateOptions, requestOptions);
        }

        public async Task<TelnyxCollection<MobileOperatorNetworksPreferencesRecord>> BulkUpdateNetworkPreferenceAsync(SimCardBulkNetworkPreferenceUpdateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.simCardBulkNetworkPreferenceService.UpdateAsync(updateOptions, requestOptions, cancellationToken);
        }

        
        public MobileOperatorNetworksPreferencesRecord GetNetworkPreference(string id, BaseOptions baseOptions, RequestOptions requestOptions = null, string postFix = "network_preferences")
        {
            return this.simCardNetworkPreferenceService.Get(id, baseOptions, requestOptions, postFix);
        }

        public async Task<MobileOperatorNetworksPreferencesRecord> GetNetworkPreferenceAsync(string id, BaseOptions baseOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default, string postFix = "network_preferences")
        {
            return await this.simCardNetworkPreferenceService.GetAsync(id, baseOptions, requestOptions, cancellationToken, postFix);
        }

        public MobileOperatorNetworksPreferencesRecord SetNetworkPreference(string id, BaseOptions baseOptions, RequestOptions requestOptions = null)
        {
            return this.simCardNetworkPreferenceService.Update(id, baseOptions, requestOptions);
        }

        public async Task<MobileOperatorNetworksPreferencesRecord> SetNetworkPreferenceAsync(string id, BaseOptions baseOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.simCardNetworkPreferenceService.UpdateAsync(id, baseOptions, requestOptions, cancellationToken);
        }

        public MobileOperatorNetworksPreferencesRecord DeleteNetworkPreference(string id, RequestOptions requestOptions = null)
        {
            return this.simCardNetworkPreferenceService.Delete(id, requestOptions);
        }

        public async Task<MobileOperatorNetworksPreferencesRecord> DeleteNetworkPreferenceAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.simCardNetworkPreferenceService.DeleteAsync(id, requestOptions, cancellationToken);
        }
    }
}
