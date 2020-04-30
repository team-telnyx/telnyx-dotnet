using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;

namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    public class NumberConfigurationService : Service<NumberConfiguration>
    {
        public NumberConfigurationService() : base(null)
        {
        }
        public NumberConfigurationService(string apiKey) : base(apiKey) { }

        public override string BasePath => "/phone_numbers";

        public async Task<TelnyxList<NumberConfiguration>> ListPhoneNumbersAsync(NumberConfigurationsListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }
        public TelnyxList<NumberConfiguration> ListPhoneNumbers(NumberConfigurationsListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.ListEntities(options, reqOpts);
        }
        public async Task<NumberConfiguration> DeletePhoneNumberAsync(string id, BaseOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, opts, reqOpts, ct);
        }
        public NumberConfiguration DeletePhoneNumber(string id, BaseOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.DeleteEntity(id, opts, reqOpts);
        }
        public async Task<NumberConfiguration> RetrievePhoneNumberAsync(string id, BaseOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, opts, reqOpts, ct);
        }
        public NumberConfiguration RetrievePhoneNumber(string id, BaseOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.GetEntity(id, opts, reqOpts);
        }
        public async Task<NumberConfiguration> UpdatePhoneNumberSettingsAsync(string id, NumberConfigurationOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.UpdateEntityAsync(id, opts, reqOpts, ct);
        }
        public NumberConfiguration UpdatePhoneNumberSettings(string id, NumberConfigurationOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.UpdateEntity(id, opts, reqOpts);
        }
    
    }
}
