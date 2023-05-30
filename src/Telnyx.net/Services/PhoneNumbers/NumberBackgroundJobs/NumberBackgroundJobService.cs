using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.NumberBackgroundJobs;

namespace Telnyx.net.Services.PhoneNumbers.NumberBackgroundJobs
{
    public class NumberBackgroundJobService : Service<NumberBackgroundJob>
    {
        public NumberBackgroundJobService()
            : base(null) { }

        public NumberBackgroundJobService(string apiKey)
            : base(apiKey) { }

        public override string BasePath => "/phone_numbers/jobs";

        public async Task<TelnyxList<NumberBackgroundJob>> ListNumberBackgroundJobsAsync(NumberBackgroundJobListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, ct);
        }

        public TelnyxList<NumberBackgroundJob> ListNumberBackgroundJobs(NumberBackgroundJobListOptions options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<NumberBackgroundJob> DeleteABatchOfNumbersAsync(DeleteABatchOfNumbersOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, ct, "/delete_phone_numbers");
        }

        public NumberBackgroundJob DeleteABatchOfNumbers(DeleteABatchOfNumbersOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, "/delete_phone_numbers");
        }

        public async Task<NumberBackgroundJob> UpdateTheEmergencySettingsFromABatchOfNumbersAsync(UpdateTheEmergencySettingsFromABatchOfNumbersOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, ct, "/update_emergency_settings");
        }

        public NumberBackgroundJob UpdateTheEmergencySettingsFromABatchOfNumbers(UpdateTheEmergencySettingsFromABatchOfNumbersOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, "/update_emergency_settings");
        }

        public async Task<NumberBackgroundJob> UpdateABatchOfNumbersAsync(UpdateABatchOfNumbersOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, ct, "/update_emergency_settings");
        }

        public NumberBackgroundJob UpdateABatchOfNumbers(UpdateABatchOfNumbersOptions options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, "/update_phone_numbers");
        }

        public async Task<NumberBackgroundJob> RetrieveNumberBackgroundJobAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, ct);
        }

        public NumberBackgroundJob RetrieveNumberBackgroundJob(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts);
        }
    }
}
