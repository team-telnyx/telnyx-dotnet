using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PhoneNumbers.PhoneNumberBlocksJobs;

namespace Telnyx.net.Services.PhoneNumbers.PhoneNumberBlockJobs
{
    public class PhoneNumberBlockJobService : Service<PhoneNumberblockJob>
    {
        public override string BasePath => "/phone_number_blocks/jobs";

        public async Task<TelnyxList<PhoneNumberblockJob>> ListPhoneNumberblockJobAsync(PhoneNumberBlocksJobOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<PhoneNumberblockJob> ListPhoneNumberblockJob(PhoneNumberBlocksJobOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<PhoneNumberblockJob> GetPhoneNumberblockJobAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public PhoneNumberblockJob GetPhoneNumberblockJob(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public async Task<PhoneNumberblockJob> CreatePhoneNumberblockJobAsync(UpsertPhoneNumberBlocksJob options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public PhoneNumberblockJob CreatePhoneNumberblockJob(UpsertPhoneNumberBlocksJob options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
