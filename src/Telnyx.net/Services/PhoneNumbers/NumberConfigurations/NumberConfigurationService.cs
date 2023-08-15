namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;

    public class NumberConfigurationService : Service<NumberConfiguration>
    {
        public NumberConfigurationService()
            : base(null)
        {
        }

        public NumberConfigurationService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/phone_numbers";

        public async Task<TelnyxList<NumberConfiguration>> ListPhoneNumbersAsync(NumberConfigurationsListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, ct);
        }

        public TelnyxList<NumberConfiguration> ListPhoneNumbers(NumberConfigurationsListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<IEnumerable<NumberConfiguration>> ListPhoneNumbersPagedAsync(NumberConfigurationsListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAutoPagingAsync(options, reqOpts, string.Empty, ct);
        }

        public IEnumerable<NumberConfiguration> ListPhoneNumbersPaged(NumberConfigurationsListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.ListEntitiesAutoPaging(options, reqOpts);
        }

        public async Task<NumberConfiguration> DeletePhoneNumberAsync(string id, BaseOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, opts, reqOpts, parentToken: "data", ct);
        }

        public NumberConfiguration DeletePhoneNumber(string id, BaseOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.DeleteEntity(id, opts, reqOpts, parentToken: "data");
        }

        public async Task<NumberConfiguration> RetrievePhoneNumberAsync(string id, BaseOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, opts, reqOpts, parentToken: "data", ct);
        }

        public NumberConfiguration RetrievePhoneNumber(string id, BaseOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.GetEntity(id, opts, reqOpts, parentToken: "data");
        }

        public async Task<NumberConfiguration> UpdatePhoneNumberSettingsAsync(string id, NumberConfigurationOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, opts, reqOpts, parentToken: "data", ct);
        }

        public NumberConfiguration UpdatePhoneNumberSettings(string id, NumberConfigurationOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.UpdateEntity(id, opts, reqOpts, parentToken: "data");
        }
    }
}
